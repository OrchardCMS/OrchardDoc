# Introduction

In this document, you can read about the various ways Orchard and its individual extensions can be compiled and the different methods used to recognize and load extensions is documented in [Extension Loaders](Extension-Loaders).

The details below apply to every extension in Orchard 1.10.3 and above, as well as the ones created using Code Generation. At the time of the release of Orchard 1.10.3, the recommended IDE for Orchard development is Visual Studio 2017.


## 1. Visual Studio IntelliSense

### 1.1. C\#

The language features supported by IntelliSense is determined by the VS version you're using, which, of course also determines what language features VS is able to compile. Checkout the [Roslyn GitHub Wiki](https://github.com/dotnet/roslyn/wiki/NuGet-packages#versioning) to see which C# language version is supported by each VS version.

The default configuration restricts language features to the highest major version (e.g. C# 7.0 for VS 2017), but this restriction can be lifted by adding `<LangVersion>latest</LangVersion>` to a project's build configurations in its csproj file. Orchard is configured to do so.

### 1.2. Razor

While VS of course has IntelliSense support for Razor code too out of the box, it doesn't offer the same language version support as in the case of C# by default. To improve that, extensions' web.configs are also modified to add support for the latest C# language features, but in a quite different way as this configuration change will be used for other purposes too - see below how.


## 2. Dynamic Compilation

This is a great feature for Orchard developers as changing just a single line of code doesn't require rebuilding the affected project (or the whole solution) manually: Instead, the next time you try to load a page, Orchard will take care of detecting what changed (i.e. which extensions need to be re-compiled - including those that depend on them) and recompile them seamlessly (although reloading after dynamic compilation will be a bit slower, since compilation takes some time and then those extensions need to be reloaded).

### 2.1. C\#

In previous versions, Orchard was configured to use the compiler service built into the .NET Framework for Dynamic Compilation, but that only supports C# language features up until version 5. To be able to use more recent language features, we've added Roslyn as a compiler service and configured the following way:

The `Microsoft.CodeDom.Providers.DotNetCompilerPlatform` NuGet package (and a DLL reference to this assembly) was added to Orchard.Web, as well as the following section in its Web.config (to register Roslyn as an available compiler):
```
<system.codedom>
    <compilers>
        <compiler language="c#;cs;csharp" extension=".cs" type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=2.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" warningLevel="4" compilerOptions="/langversion:latest /nowarn:1699;1701" />
    </compilers>
</system.codedom>
```

**Orchard 1.10.3 uses DotNetCompilerPlatform 2.0.1, which includes Microsoft.Net.Compilers 2.9.0 (the equivalent Roslyn version of VS 2017 version 15.8). This means that Dynamic Compilation (and Static Razor Compilation) supports language features up to C# 7.3.**
Microsoft.Net.Compilers can be used separately too.

Finally, for Roslyn to be available in a central location even when the application is deployed, the Roslyn tools folder from DotNetCompilerPlatform is copied to Orchard.Web's bin folder:
```
<Target Name="CopyRoslynFilesToOutputFolder" AfterTargets="AfterBuild">
    <!-- Copying Roslyn tools and their dependencies to the "bin" folder for Dynamic Compilation. -->
    <PropertyGroup>
        <RoslynFilesDestination>$(ProjectDir)bin\roslyn\</RoslynFilesDestination>
    </PropertyGroup>
    <ItemGroup>
        <RoslynFiles Include="..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.2.0.1\tools\RoslynLatest\*" />
    </ItemGroup>
    <Copy SourceFiles="@(RoslynFiles)" DestinationFolder="$(RoslynFilesDestination)" Condition="!Exists('$(RoslynFilesDestination)csc.exe')" />
</Target>
```

### 2.2. Razor

This requires the same configuration as Static Razor compilation, see below.


## 3. Static Code Compilation

### 3.1. C\#

The same details apply here as with IntelliSense.

### 3.2. Razor

#### Background

While it is perfectly normal for C# code to be statically compiled (completely independent from running it), Razor files are dynamically compiled into memory the first time they are needed. How can I run static code analysis on Razor files to find errors, you ask? Well, IntelliSense of course will still tell you about syntactic errors, but changes from other files only propagate to Razor files if they are open, so it's really easy to make a breaking change, which will result in an YSOD the next time you'll try to run it. But there's a better way!

Disclaimer: This is not the same as precompiling Razor templates into a DLL (e.g. what Orchard Core does), this is just for static code analysis.

#### Configuration

To make sure that both Razor IntelliSense and Static Razor compilation is available in each project (where needed) using the same C# language version as the C# (since the ASP.NET Compiler does not use Roslyn by default), extension project needs to be modified similarly to Orchard.Web: Add the DotNetCompilerPlatform package and a reference to it, then register Roslyn as an available compiler by modifying the Web.config.

By default, when a project initiates Roslyn compilation, it DotNetCompilerPlatform will look for the Roslyn tools in the project's bin folder - copying the Roslyn tools there is done automatically when you add this NuGet package to your project with the NuGet Package Manager. This works great with a solution that has only one project which uses Roslyn, but would be a huge drag for an Orchard application: Since the majority of Orchard extensions need Roslyn, copying all those files to each extension involved would multiple the size of the output folder (e.g. for a deployment package).

Since DotNetCompilerPlatform 1.0.6, a project-specific AppSetting (in the Web.config) allows us to override the location of the Roslyn tools. We already have those tools copied to the bin folder of Orchard.Web, because we need them for Dynamic Compilation anyway, so let's use it for each project where we need them (i.e. the ones that have Razor templates):
```
<appSettings>
    <add key="aspnet:RoslynCompilerLocation" value="..\..\bin\roslyn" />
</appSettings>
```
This also means that each of those projects have an implicit dependency on Orchard.Web, but Orchard.Web is the de facto starting point of an Orchard application - you can use a customized Web project too, of course, but that can be set up to benefit from all this by making same changes its csproj and Web.config as detailed above.

#### Usage

And finally, reaping the benefits of the work done above, let's see how to actually invoke static Razor compilation:
- When calling `msbuild` on a solution or project directly, just pass the `/p:MvcBuildViews=true` parameter.
- When calling `msbuild` on Orchard.proj:
  - Pass the same parameter to the `Compile` build target as above.
  - Call the `BuildViews` target.
- When using `ClickToBuild.cmd`, the `BuildViews` target can also be used as the first parameter.


## Downgrading

If using the latest C# version causes technical difficulties (e.g. lack of support in CI; team members use different VS versions), you can restrict the accepted C# language version to a specific one: The csproj and Web.config of Orchard.Web and each extension project that has Razor templates need to be modified in the following way (for this example, let's restrict everything to C# 6). This can be achieved with a simple search and replace operation.

### csproj

Replace every occurrence of
```
<LangVersion>latest</LangVersion>
```
with
```
<LangVersion>6</LangVersion>
```

### Web.config
Replace every occurrence of
```
/langversion:latest
```
with
```
/langversion:6
```
but make sure that it only changed at the end of the compiler registration (see section 2.1.), although it probably won't occur anywhere else.