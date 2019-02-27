# Introduction

As a composable CMS, Orchard has the ability to load an arbitrary set of modules (also known as "extensions") at run-time. One of the goals of the 0.5 release was to make the process of installing and updating modules as easy as possible. The goal of this document is to describe at a technical level how Orchard loads modules since version 0.5.

Orchard, like any ASP.NET MVC application, supports loading modules compiled as assemblies using Visual Studio. Orchard also offers a customized module loading strategy which, for example, allows loading assemblies for modules without having to deploy them in the `~/bin` folder.

In addition to that, Orchard supports the ability to dynamically compile modules deployed as source code only. This is also a very handy developer feature that you can read about in [Compilation Configuration and Language Support](Compilation-Configuration-and-Language-Support) and how dynamically compiled extensions are loaded is detailed below in the "Dynamic Module Loader" section.

# High Level Overview

When an Orchard application starts, the Orchard Framework (the `ExtensionLoaderCoordinator` class to be precise) needs to figure out what are the modules installed in the Web Site and activate them (typically by loading their assembly).

At a high level, this process can be divided in 3 distinct phases:

* _Discovery_: Figure out what extensions are present withing the application.
* _Activation_: Figure out what strategy to use to "activate" (or load) each extension.
* _References Resolution_: Figure out what are the assembly references needed to be activated for each extension. This phase is technically part of the "Activation" phase, but it is easier to think about the problem of reference resolution as a separate concern.

Once each extension is properly activated, they are further examined to detect and enable individual _features_, but this is a topic for another section.

# Discovery 

The list of available extensions in an Orchard installation is built by searching various folders of the file system for `Module.txt` and `Theme.txt` files. The folders looked at by default are listed in the following sections.

##  `~/Core` Folder 

The `~/Core` folder contains, by convention, modules defined in the `Orchard.Core` assembly. These modules are part of the "Core" Orchard system and are not intended to be modified as freely as modules in the `~/Modules` folder.

##  `~/Modules` Folder 

The `~/Modules` folder is intended to contain the vast majority of Orchard modules. The convention is that each module is stored in a sub-folder named `<ModuleName>` containing a single `Module.txt` file.  Packaging, distribution and sharing of modules is only supported for modules in the `~/Modules` folder.

##  `~/Themes` Folder 

The `~/Themes` folder is intended to contain Orchard Themes. With respect to dynamic compilation, Themes are treated almost exactly the same as Modules, except that Themes don't have to have code (assembly in `bin` or `.csproj` file). For the rest of this page, when we refer to "Module", it should be understand that the concept applies to "Theme" the same way.

## Custom Folders

Orchard 1.10 introduced a new feature that allows the loading of extensions from custom-defined folders outside of the ones listed above by adding the `ExtensionLocations` service that is utilised by each extension loader (see the `Loaders` in the `Activation` section below).

Additional extension folders can be configured by defining an `AppSetting` (e.g. by adding it to the root `web.config` file, which contains appropriate examples) with the key `Modules` and/or `Themes` with their respective `value` being e.g. `~/Modules.Custom` and/or `~/Themes.Custom`.

##  Example 

Here is an example of an Orchard installation which contains the following extensions: `Common` and `Localization` (`Core` modules), `Orchard.Azure` and `Orchard.Caching` (built-in modules), `SafeMode` and `TheAdmin` (built-in themes), `MyModule1` and `MyModule2` (custom modules), `MyBaseTheme` and `MyTheme` (custom themes).

    
    Root (Orchard.Web)
      Core
        Common
          Module.txt  <= "Common" module from "Core"
        Localization
          Module.txt  <= "Localization" module from "Core"
      Modules
        Orchard.Azure
          Module.txt  <= "Orchard.Azure" module
        Orchard.Caching
          Module.txt  <= "Orchard.Caching" module
      Modules.Custom
        MyModule1
          Module.txt  <= "MyModule1" module
        MyModule2
          Module.txt  <= "MyModule2" module
      Themes
        SafeMode
          Theme.txt  <= "SafeMode" theme
        TheAdmin
          Theme.txt  <= "TheAdmin" theme
      Themes.Custom
        MyBaseTheme
          Theme.txt  <= "MyBaseTheme" theme
        MyTheme
          Theme.txt  <= "MyTheme" theme


# Activation 

Once Orchard has collected all the `Module.txt` files from the discovery phase, Orchard uses distinct strategies (or "Module Loaders") to load these modules in memory. Internally, the act of "loading a module" is an activity that takes a `Module.txt` file as input and returns a list of `System.Type` as output. Note that this is slightly more generic than simply returning a `System.Assembly`, as it allows Orchard to support multiple modules per assembly. For example, the `Orchard.Core.dll` assembly currently contains about 10 modules.

The Orchard framework currently implements the following loaders:

##  "Referenced Module" Loader 

This loader looks in `~/bin` directory for a assembly name corresponding to the module name specified in `Module.txt`. If the assembly exists, it is loaded and all its types are returned. This loader is useful when someone wants to deploy an Orchard web site where all modules are pre-compiled and stored in `~/bin`, in a typical "ASP.NET web application" way.

##  "Core Module" Loader 

If `Module.txt` indicates a module from the `~/Core` folder, the CoreExtensionLoader returns the types from the `Orchard.Core.<ModuleName>` namespace of the `Orchard.Core` assembly. `Orchard.Core` is a special assembly containing modules that are "core" to the system, i.e. offering basic functionality on top of the Orchard Framework.

##  "Precompiled Module" Loader 

If `Module.txt` indicates a module from the `~/Modules` folder, the `PrecompiledExtensionLoader` looks for an assembly named `<ModuleName>` in the `~/Modules/<ModuleName>/bin` folder. If the file exists, its is copied to the `~/App_Data/Dependencies` folder, which is a special folder used by ASP.NET to look for additional assemblies outside of the traditional `~/bin` folder.

##  "Dynamic Module" Loader

If `Module.txt` indicates a module from the `~/Modules` folder, the "Dynamic Module" loader looks for a file named `<ModuleName>.csproj` in the `~/Modules/<ModuleName>` folder. If the file exists, the loader will use the Orchard build manager for `.csproj` files to compile the file into an assembly and return all the types from that assembly.

Note: This loader is the only one in the system performing what is often referred to as `dynamic compilation`, and is indeed optional if modules have been pre-compiled.

##  Loader Disambiguation 

Since there is potentially more than one loader able to load a given module, Orchard has to have a way to resolve the ambiguity, i.e. pick the "right" loader.  Each loader has the ability to return a "date of last modification" for each module they can load.  For a given module, if there are multiple candidate loaders, Orchard will pick the loader which returns the most "recent" date of last modification.

For example, a given module can be distributed with both full source code (including `.csproj` file) **and** compiled into an assembly in its `bin` directory.  The first time the module is loaded, Orchard will pick the loader for the assembly in `bin` since it's very likely the assembly was compiled after the last source code change was made.  However, if any change was made to the source code afterward, the "Dynamic Module" loader will return the date of the most recently modified file (either the source file or `.csproj`), and Orchard will pick that loader for the given module.  

Note that the "Core Module" loader is never ambiguous, because there is only one way to load these modules. The ambiguity can only arise for modules in the `~/Modules` directory.

##  Example 

    
    RootFolder
      Bin
        Orchard.Web.dll
        Orchard.Core.dll
        Foo.dll
      Core           
        Common        <= "Core Module" loader
          Module.txt
        Localization  <= "Core Module" loader
          Module.txt
      Modules
        Foo           <= "Reference Module" loader (because a "~/bin/Foo.dll" file exists)
          Module.txt
        Bar           <= "Precompiled Module" loader (because a "~/Modules/Bar/bin/Bar.dll" file exists)
          bin
            Bar.dll
          Module.txt
        Baz           <= "Dynamic Module" loader (because a "~/Modules/Baz/Baz.csproj" file exists)
          Controller
             BazControler.cs
          Baz.csproj
          Module.txt

## Disabling the "Dynamic Module" loader

The dynamic module loader should be useless when deploying a website in production, as a production enviroment it
should not be able to install and load module dynamically. But another important reason why it should be disabled
is that it creates a lot of `FileSystemWatcher` instances to detect changes on the modules.

To disable the module, rename the file `\Config\Sample.HostComponents.config` to `\Config\HostComponents.config`, 
then check the content is:


    <?xml version="1.0" encoding="utf-8" ?>
    <HostComponents>
      <Components>
        <Component Type="Orchard.Environment.Extensions.ExtensionMonitoringCoordinator">
          <Properties>
            <Property Name="Disabled" Value="true"/>
          </Properties>
        </Component>
      </Components>
    </HostComponents>


Deploy this file and restart the App Pool.

NB: You will have to ensure that the binaries for every modules are available in the `/bin` folder of each module, 
such that the Precompiled Module loader can use them directly. When using Visual Studio this should be the case. 
Otherwise use the command line tool to build the website, which will have the same effect.

#  References Resolution 

(TODO: Explain how Orchard figures out references by looking at the "References" section of the csproj file as well as looking at additional assembly binaries dropped in each module `bin` directory)

#  Change of Configuration Detection 

As explained above, modules are loaded at application startup. However, once the application is started up, changes can happen: a new module might be installed, the source code of a module might be manually updated, a module might be removed from the site, etc.  To detect these changes, Orchard asks each module loader in the system to "monitor" potential changes, and notify when a change happens.

When a change is detected, the current module configuration is discarded and modules are re-examined, loaded and activated as if the application was starting up again.  In some cases, these changes require an ASP.NET AppDomain restart (e.g. a new version of a module assembly needs to be loaded). Orchard detects these situations and forces an ASP.NET AppDomain restart.


#  Rendering Web Forms Views 

(TODO: Explain that Orchard uses a custom virtual path provider to insert custom `Assembly Src=xx` and `Assembly Name=xxx` directive when reading `.ascx` and `.aspx` files)

#  Rendering Razor Views 

(TODO: Explain that Orchard uses a Razor custom API to add Module dependencies to Views)


#  The `~/App_Data/Dependencies/Dependencies.xml` file 

This file contains the list of modules, their loader and their resolved references of the "last known good" configuration of module, i.e. the last time Orchard successfully loaded all modules of the application.  Examining the content of this file can be useful for debugging purposes, e.g. if the latest version of a module doesn't seem to be loaded.
