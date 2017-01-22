Orchard includes a processing pipeline for client-side assets (typically scripts and stylesheets) used to perform tasks such as transpilation, minification and bundling of client-side assets in both built-in and third-party extensions modules and themes). As an extension developer, can enable this pipeline by placing an *asset manifest file* named `Assets.json` in the root of your extension. This asset manifest file declares one or more *asset groups* to be processed by the pipeline. Each asset group specifies a set of input files in your extension (such as `.less`, `.scss`, `.css`, `.ts` or `.js` files) along with an output path and (optionally) one or more options to influence the processing.

## Overview

The client-side asset pipeline is powered by [Gulp](http://gulpjs.com), a popular open-source task runner based on [Node.js](https://nodejs.org) that can be used to automate a wide variety of tasks in a development workflow. The pipeline defines a set of *tasks* that can be executed by Gulp using either the command line or using the **Task Runner Explorer** in Visual Studio 2015 or later.

Physically, the client-side asset pipeline consists of two files in the Orchard solution folder:

- `src/Package.json` contains information about the Node packages required by the pipeline. This file tell the Node package manager (NPM) which packages it needs to download and install for the pipeline to function.
- `src/Gulpfile.js` contains the JavaScript code that defines a set of Gulp tasks and their implementation logic.

In Visual Studio you will find these files in **Solution Explorer** in a solution folder named `Solution Items/Gulp`:

![](../Attachments/assets-pipeline/solution-items.png)

The client-side asset pipeline is not configured by default to be invoked automatically when opening or building Orchard. To minimize build time and make it as easy as possible to get started with Orchard, all built-in modules and themes in Orchard are kept in version control with their processed output files included. This means you don't have to activate and run the client-side asset pipeline to build or run Orchard. You only need to run the client-side asset pipeline if you make changes to these assets or wish to process assets in your own extensions.

## Getting started

### Installing prerequisites

The client-side asset pipeline requires Node.js to be installed. If you are using Visual Studio 2015 or later, Node.js is typically already installed as part of Visual Studio. If you are not using Visual Studio or chose to exclude Node.js when installing Visual Studio, you will need to install Node.js manually from https://nodejs.org.

Next you will need to use NPM to install all the packages the client-side asset pipeline needs, including Gulp itself. Using the command line, navigate to the Orchard solution folder and execute the command `npm install`, which will install all dependencies referenced in the `Package.json`file. In Visual Studio 2015 or later, you can instead simply open the `Package.json` file and save it without making any changes - this will trigger an automatic `npm install` behind the scenes.

### Executing tasks (command line)

### Executing tasks (Visual Studio)

### Binding tasks to Visual Studio events

## Using the pipeline for your own module or theme

Adding an asset manifest.

### Basic example (single input file)

### Multiple input files

### Globs (wildcards)

### Separate output files for each input file

### Multiple asset groups

### Supported tasks and file formats

### Supported options

## Advanced scenarios

### Excluding output files from source control

### Including custom extension folders









## Pre-processing your assets with Gulp



The `Gulpfile.js` is the JavaScript code that is executed during the build. It will scan all the modules folders for `Assets.json` manifests and process them. The assets manifest is a simple JSON format file which groups together files by inputs and outputs. This is what the Orchard.DynamicForms Asset.json looks like:

```json
[
    {
        "inputs": [
            "Assets/JavaScript/Lib/jquery.validate.js",
            "Assets/JavaScript/Lib/jquery.validate.unobtrusive.js",
            "Assets/JavaScript/Lib/jquery.validate.unobtrusive.additional.js"
        ],
        "output": "Scripts/Lib.js"
    },
    {
        "inputs": [ "Assets/JavaScript/LayoutEditor/**/*.js" ],
        "output": "Scripts/LayoutEditor.js"
    },
    {
        "inputs": [ "Assets/CSS/*.css" ],
        "output": "Styles/@.css"
    }
]
```

The file format is described in detail in the Assets.json section below.

The Package.json is a manifest that is used by npm (Node Package Manager). It will pull down the various packages that gulp needs in order to compile the modules assets. 

## Installation overview
The assets pipeline is not enabled by default when you build Orchard. This is to save time as often you won't need to recompile all the assets for each build. Broadly speaking, the installation process requires the following steps:

 1. Install Node.js
 2. Run npm to install gulp and its related packages
 3. Hook the pipeline script into the build with Task Runner Explorer

These steps are described in detail in the next section.

## Setting up the solution

The first step is to install [Node.js](https://nodejs.org). This will install a package manager called npm which is like NuGet for the JavaScript world. 
 
 1. Visit the [Node.js](https://nodejs.org) homepage
 2. Download your preferred version, either the latest stable edition or the LTS (long term support) version
 3. Install the file you have downloaded

After that npm needs to be run which will read the Package.json, install gulp and its associated packages. To do this:

 1. Open a command prompt in the root of your solution.
    - In `Solution Explorer` window, right click on `Solution 'Orchard'` and choose `Open Folder in File Explorer`
    - Click the up icon to travel one level further up the tree
    - Press `Shift` and `Right click` on the `src` folder
    - Click `Open command window here`
 2. Type the following command: `npm install`
        
> TIP: There is actually a hidden feature in Visual Studio to run `npm install`. If you open `Package.json` and just hit `Save` it triggers an `npm install`.
        
It will take a minute or two while it pulls down the packages needed by gulp. 

When it is complete the final step is to assign the Gulpfile to the Before Build step in Task Runner Explorer:

  1. Go back to Visual Studio
  2. In `Solution Explorer` navigate to the `Solution Items` folder, then `Gulp` and right click on `Gulpfile.js`
  3. Select `Task Runner Explorer`

This will open up the Task Runner Explorer window. You might see an error message here:

![](../Attachments/assets-pipeline/gulpfile-failed-to-load.png)

If you do then just click the `Refresh` button and wait for it to reload:

![](../Attachments/assets-pipeline/task-runner-explorer-refresh.png)

When Visual Studio has correctly parsed the Gulpfile you will see a list of the Tasks which are contained inside it: 

![](../Attachments/assets-pipeline/gulpfile-loaded.png)

The tasks and bindings are explained in more detail in the `Task Runner Explorer` section below. A quick-start solution is:

  1. Right click on the `build` task
  2. Select `Bindings`
  3. Select `Before Build`
  
Then each time you build Orchard (for example, by pressing `F5`) the assets pipeline will be executed at the start of the build process. Any input files that have changed since the last build will be rebuilt.

## Assets.json file format

The `Assets.json` file is simple json manifest file which lists the input assets, what single file they should be combined into for output and other configuration options.

Each output file is grouped into its own configuration section.

Glob format pattern matching is supported for the paths.

The basic format is as follows:

    [
        {
            "inputs": [
                // array of paths
            ],
            "output": // output path
            // configuration items
        },
        {
            // repeat as needed
        }
    ]

A group can contain mixed types of input assets, as long as those can be processed into the same output file.

  * For example you can specify both LESS and CSS assets in a group targeted for a `.css` output
  * And you can specify both TypeScript and JavaScript assets in a group targeted for a `.js` output
  * But you can't mix and match - if you try to combine styles and scripts the build will throw an error
  
All file paths are relative to the module/theme root folder.

It is convention to use `Assets` as a folder for the input assets and keep those separate from the output assets, but this is not required.

Once generated by the assets pipeline, you can then include the assets into your module / theme just as you would do with any normal JavaScript / CSS file. They can either be included as files, or they can be declared in a resource manifest and required by yours or other modules.

Using the assets pipeline is optional. If you don't put an `Asset.json` manifest file in the root of your module/theme, the gulp framework will seamlessly ignore your module.

### Format

<table>
<thead>
<tr>
   <th>Element</th>
   <th>Type</th>
   <th>Usage</th>
</tr>
</thead>
<tbody>
<tr>
   <td>`inputs`</td>
   <td>Array</td>
   <td>A list of files to include in this group. Supports glob format paths. If you just have one path you still need to wrap it in an array.</td>
</tr>
<tr>
   <td>`output`</td>
   <td>String</td>
   <td>An output file that you want to generate. Supports a glob form path. You can use `@` to generate one output file for each input eg `@.css`.</td>
</tr>
<tr>
   <td>`generateSourceMaps`</td>
   <td>Boolean</td>
   <td>*optional* defaults to false. Use this if you want a configuration group to opt-out of generating the source maps.
   </td>
</tr>
</tbody>
</table>

### Globbing

The assets pipeline uses the npm package [glob](https://www.npmjs.com/package/glob) to provide glob pattern matching.

Glob format is a bit different if you have previously only been familiar with DOS style wildcards and the like. You have probably used them before but perhaps without realising such as when you put `build/*` into a `.gitignore` file.

The glob npm package has great introduction to the glob specification [on its download page](https://www.npmjs.com/package/glob#glob-primer).

### Supported input formats and tasks

As of 1.10 the assets pipeline will process input assets using the following steps:

  * **Less (*.less)**
    1. Compile down to CSS
    1. Hand off as input to the CSS pipeline
  * **CSS (*.css)**
    1. Bundle (concatenate)
    1. Autoprefix (add browser vendor prefixes)
      * At this point output to target `.css` file
      * Add sourcemap to bottom of file
    1. Minify
      * At this point output to target `.min.css` file
  * **TypeScript (*.ts)**
    1. Compile down to JavaScript
    1. Hand off as input to the JavaScript pipeline
  * **JavaScript (*.js)**
    1. Bundle (concatenate)
      * At this point output to target `.js` file
      * Add sourcemap to bottom of file
    1. Uglify (minify)
      * At this point output to target `.min.js` file

The Orchard 1.10.x branch (in development) adds Sass support.

### Examples

Here are some techniques that you can use to build your own `Assets.json` files. Don't forget, these tips can be combined within a single asset group to create a powerful asset processing pipeline.

#### Single input file

Note that you still need to provide the input as an array:

    [
        {
            "inputs": [
                "Assets/Styles.less"
            ],
            "output": "Styles/Styles.css"
        }
    ]

#### Simple input file array

When you have multiple files you can list them out individually:

    [
        {
            "inputs": [
                "Assets/Bootstrap/Bootstrap.less",
                "Assets/Bootstrap/Theme.less",
                "Assets/Styles.less",
            ],
            "output": "Styles/Styles.css"
        }
    ]

#### Glob format input array

The glob format supports the use of patterns to automatically include all matching assets. This example looks in the lib folder, for all subfolders (`/**/`), and collects all JavaScript files within them (`*.js`).

It then combines them into a single `Lib.js` output:
 
    [
        {
            "inputs": [
               "Assets/JavaScript/Lib/**/*.js"
            ],
            "output": "Scripts/Lib.js"
        }
    ]
    
#### Multiple asset groups
 
You can define multiple asset groups for each output you want. This example shows two separate CSS asset groups and a JavaScript group:

    [
        {
            "inputs": [
                "Assets/Bootstrap/Bootstrap.less",
                "Assets/Bootstrap/Theme.less"
            ],
            "output": "Styles/Bootstrap.css"
        },
        {
            "inputs": [
                "Assets/Styles.less"
            ],
            "output": "Styles/Styles.css"
        },
        {
            "inputs": [
               "Assets/JavaScript/Lib/**/*.js",
               "Assets/JavaScript/Admin/Admin.js"
            ],
            "output": "Scripts/Lib.js"
        }
    ]

#### Generate separate files for each input

You can combine a glob input pattern with the `@` output notation to generate a separate asset file for each matched input. This example shows how you could compile a folder full of translation files into their own separate `.js` files without having to manually maintain a list of each language in your `Assets.json`:

    [
        {
            "inputs": [
               "Assets/JavaScript/Translations/*.ts"
            ],
            "output": "Scripts/Translations/@.js"
        }
    ]

So if the `Assets/JavaScript/Translation/` folder had files such as `en-GB.ts`, `fr-FR.ts`, etc then you would end up with a `Scripts/Translations/` folder with  `en-GB.js`, `fr-FR.js`, etc after the pipeline had run.

#### Disable sourcemaps for a group

Sourcemaps are automatically generated by the pipeline and are inserted inline into the unminified versions of the generated assets. To opt-out of this process for any individual asset group you can use this property:

    [
        {
            "inputs": [
                "Assets/Styles.less"
            ],
            "output": "Styles/Styles.css",
            "generateSourceMaps": false
        }
    ]

#### Structuring a complex Less setup

Beyond the basic examples of watching a single `.less` file you would normally have a central `.less` file which includes a range of other partials. You should note that when using this configuration that simply adding the central `.less` file isn't enough.

Include all of the related assets with a glob, even if that glob will match an index `.less` and the partials that the index itself includes. The pipeline will filter out any redundant includes. If you don't explicitly include them all in the input group then changes to the partials won't trigger an update with the `build` or `watch` tasks.

If for example you have a central `Styles.less` which includes a list of other `.less` partials you might be tempted to just add the `Styles.less` to the asset group like this: 

    [
        {
            "inputs": [
                "Assets/Styles.less"
            ],
            "output": "Styles/Styles.css"
        }
    ]
    
Don't do this. If you do this then your partials will only be rebuilt when the `Styles.less` file is altered. Instead, write a glob format which monitors all of the less files. The pipeline will understand so you won't get your files included twice. For example:

    [
        {
            "inputs": [
                "Assets/**/*.less"
            ],
            "output": "Styles/Styles.css"
        }
    ]

### How to open the pane

You can access it by going to:

  1. Click the `View` menu
  1. Then `Other Windows`
  1. Select `Task Runner Explorer`
  
You can also use the keyboard shortcut:

  * `Ctrl+Alt+Bckspce`

### The available tasks

The assets pipeline provides three tasks:

  * **Build** performs an incremental build of the assets (only newer input files are rebuilt)
  * **Rebuild** performs a full rebuild of all assets in the pipeline
  * **Watch** begins an ongoing watch task which forms an incremental build whenever a watched input file is changed

### Task bindings
There are four standard bindings available to assign your tasks to be executed at key stages of the development process:

  * Before Build
  * After Build
  * Clean
  * Project Open

#### Binding tasks  
To bind any task to one of these stages you simply:

  1. In the Task Runner Explorer, expand the `Gulpfile.js` and `Tasks` leafs if they are not already expanded.
  2. Right click on any of the listed tasks.
  3. Select `Bindings`.
  4. Select your chosen binding.

By default the tasks are not bound to anything initially. This is because each module should already come with the precompiled assets so it would add redundant overhead to the development process. The expected use of these binding are to bind the tasks temporarily while you are working on a particular feature and then unbind them again afterwards.

#### Using the watch task independently
If you want to use the watch task then you shouldn't bind it to, for example, `Before build`. This is because the watch task doesn't end so when you attempt to build it will get stuck at this stage while it enters into a continuous loop watching for asset modifications.

Instead you can run the tasks independently of their bindings:

  1. Right click any task.
  2. Select `Run`.
  
     ![](../Attachments/assets-pipeline/task-runner-run.png)

This will open a new tab within the Task Runner Explorer which will allow the watch task to continuously run while you make changes to your assets.

## Module / theme developers
 
 As a module/theme developer you need to build the compiled output files in your project and add them to the package that you share.
 
 This is so that end users of your module can use your release without having to install node/npm and then run the assets pipeline just to load your module/theme.
 
 So what this means is before you share your module or theme you should run the `rebuild` task one final time to ensure that both your source files and your compiled assets are up to date and included in the project.

## Custom theme and module folders are not automatically included

If your project is using the custom modules and theme folders feature introduced in v1.10 the `Gulpfile.js` will not automatically pick up these custom folder locations.

By default it only checks for `Assets.json` files in folders under these locations:

    ~/Orchard.Web/Core/
    ~/Orchard.Web/Modules/
    ~/Orchard.Web/Themes/

To add your custom locations just follow these steps:

  1. In `Solution Explorer`, expand the `Solution Items` folder, then `Gulp` and open whatever you called your new copy of `Gulpfile.js`
   
  2. Find the `getAssetGroups()` function (it should be around line 73)
  
  3. The first line declares an `assetManifestPaths` array. You need to add your own `glob.sync` in and then merge the resulting arrays. For example:
  
         var assetManifestPaths = glob.sync("Orchard.Web/{Core,Modules,Themes}/*/Assets.json");
         var customThemePaths = glob.sync("AnotherLocation/MyCompanyThemes/*/Assets.json");
         assetManifestPaths = assetManifestPaths.concat(customThemePaths);
     
     You may need to customize the glob pattern to match your particular setup.
      
  4. Save and close the file.
  
The example above focuses on themes but your custom module folders can use the same technique.
   
The Orchard Team are currently looking into a way to automate this process.

## Evolution of the assets pipeline

For those interested in the history behind the assets pipeline, the initial discussion, reasons for its development and proposed solutions were discussed in [issue #5450](https://github.com/OrchardCMS/Orchard/issues/5450).
