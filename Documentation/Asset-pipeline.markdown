Orchard includes an asset pipeline which builds the scripts and styles for each module. You can opt-in to it by using a manifest file called `Assets.json` which lives in the root folder of each module. This manifest file lists groups of assets such as `.css`, `.js`, `.less` and `.ts`. Each asset group within the manifest file will output a single compiled file.

## Overview

The pipeline is powered by [Gulp](http://gulpjs.com/), a popular open source build system. Each module within Orchard supports an asset manifest file. This is a JSON format filew which lists the resources that should be compiled.
 
When the pipeline is run, Gulp reads a solution-wide JavaScript file which then parses all of the asset manifests and compiles the resources listed within them.

All of the modules distributed with Orchard already have their compiled and minified assets included. This means you don't need to run the asset pipeline to compile Orchard unless you make changes to these files. To save build time this is disabled by default. 

## Pre-processing your assets with Gulp

In the Visual Studio Solution Explorer you will find a folder called Solution Items. Inside there is a folder with two files, `Gulpfile.js` and `Package.json`:

![](../Attachments/asset-pipeline/solution-items.png)

The `Gulpfile.js` is the JavaScript code that is executed during the build. It will scan all the modules folders for `Assets.json` manifests and process them. The assets manifest is a simple JSON format file which groups together files by inputs and outputs. This is what the Orchard.DynamicForms asset.json looks like:

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

The file format is described in detail in the Assets.json section below.

The package.json is manifest that is used by NPM (Node Package Manager). It will pull down the various packages that gulp needs in order to compile the modules assets. 

## Installation overview
The asset pipeline is not enabled by default when you build Orchard. This is to save time as often you won't need to recompile all the assets for each build. Broadly speaking, the installation process requires the following steps:

 1. Install Node.js
 2. Run NPM to install gulp and its related packages
 3. Hook the pipeline script into the build with Task Runner Explorer

These steps are described in detail in the next section.

## Setting up the solution

The first step is to install [Node.js](https://nodejs.org). This will install a package manager called NPM which is like NuGet for the JavaScript world. 
 
 1. Visit the [Node.js](https://nodejs.org) homepage
 2. Download your preferred version, either the latest stable edition or the LTS (long term support) version
 3. Install the file the you have downloaded

After that NPM needs to be run which will read the package.json, install gulp and its associated packages. To do this:

 1. Open a command prompt in the root of your solution.
    - In `Solution Explorer` window, right click on `Solution 'Orchard'` and choose `Open Folder in File Explorer`
    - Click the up icon to travel one level further up the tree
    - Press `Shift` and `Right click` on the `src` folder
    - Click `Open command window here`
 2. Type the following command:
        npm install
        
It will take a minute or two while it pulls down the packages needed by Gulp. 

When it is complete the final step is to assign the gulpfile to the Before Build step in Task Runner Explorer:

  1. Go back to Visual Studio
  2. In `Solution Explorer` navigate to the `Solution Items` folder, then `Gulp` and right click on `Gulpfile.js`
  3. Select `Task Runner Explorer`

This will open up the Task Runner Explorer window. You might see an error message here:

![](../Attachments/asset-pipeline/gulpfile-failed-to-load.png)

If you do then just click the `Refresh` button and wait for it to reload:

![](../Attachments/asset-pipeline/task-runner-explorer-refresh.png)

When Visual Studio has correctly parsed the Gulpfile you will see a list of the Tasks which are contained inside it: 

![](../Attachments/asset-pipeline/gulpfile-loaded.png)

The tasks and bindings are explained in more detail in the `Task Runner Explorer` section below. A quickstart solution is:

  1. Right click on the `build` task
  2. Select `Bindings`
  3. Select `Before Build`
  
Then each time you build Orchard (for example, by pressing `F5`) the asset pipeline will be executed at the start of the build process.

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
  * But you can't mix and match - if you try, the build will throw an error
  
All file paths are relative to the module/theme root folder.

It is convention to use `Assets` as a folder for the input assets and keep those separate from the output assets, but this is not required.

Once generated by the asset pipeline, you can then include the assets into your module / theme just as you would do with any normal JavaScript / CSS file. They can either be included as files, or they can be declared in a resource manifest and required by yours or other modules.

Using the asset pipeline is optional. If you don't put an `Asset.json` manifest file in the root of your module/theme, the Gulp framework will seamlessly ignore your module.

### Format

<table>
<tr>
   <th>Element</th>
   <th>Type</th>
   <th>Usage</th>
</tr>
<tr>
   <td>`inputs`</td>
   <td>Array</td>
   <td>A list of files to include in this group. Supports glob format paths. If you just have one path you still need to wrap it in an array.</td>
</tr>
<tr>
   <td>`output`</td>
   <td>String</td>
   <td>An output file that you want to generate. Supports a glob form path. You can use `@` to generate one file for each input eg `@.css`.</td>
</tr>
<tr>
   <td>`generateSourceMaps`</td>
   <td>Boolean</td>
   <td>*optional* defaults to false. Use this if you want an configuration group to opt-out of generating the source maps.
   </td>
</tr>
</table>

### Globbing

The asset pipeline uses the npm package [glob](https://www.npmjs.com/package/glob) to provide glob pattern matching.

Glob format is a bit different if you have previously only been familiar with DOS style wildcards and the like. You have probably used them before but perhaps without realising such as when you put `build/*` into a `.gitignore` file.

The glob NPM package has great introduction to the glob specification [on its download page](https://www.npmjs.com/package/glob#glob-primer).

### Supported input formats and tasks

As of 1.10 the asset pipeline will process input assets using the following steps:

  * **LESS (*.less)**
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

For each of these four pipelines, the framework would provide three tasks:

  * **Build** to be performed on solution build
  * **Watch** to trigger pipeline execution whenever one of the input files changes
  * **Clean** to be performed on solution clean

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
            "output": "Styles/Styles.css"
        },
        {
            "inputs": [
                "Assets/Styles.less"
            ],
            "output": "Styles/Bootstrap.css"
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

You can combine a glob input pattern match with the `@` output notation to generate a separate asset file for each matched input. This example shows how you could compile a folder full of translation files into their own separate `.js` files without having to manually maintain a list of each language in your `Assets.json`:

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


## Task Runner Explorer
 - Brief overview
 - Separate package in older Visual Studio
 - How to open the pane
 - Explain the tasks
 - Explain the bindings

## Evolution of the asset pipeline
 - started per module, 
 - node folder path length issues
 - web deploy problems
 - same steps everywhere

## Customising the asset pipeline
 - Duplicate the file so it doesnt get overwritten during upgrade
 - Unbind existing if set up

## Module / theme developers
 
 As a module/theme developer you need to include the compiled output files in your project and add them to the package that you share.
 
 This is so that end users of your module can do so without having to install node/npm and then run the asset pipeline just to load your module/theme.

## Custom theme and module folders are not automatically included

If your project is using the custom modules and theme folders feature introduced in v1.10 the `gulpfile.js` will not automatically pick up these custom folder locations.

By default it only checks for `Assets.json` files in folders under these locations:

    ~/Orchard.Web/Core/
    ~/Orchard.Web/Modules/
    ~/Orchard.Web/Themes/

To add your this just follow the customising the asset pipeline tutorial above to create a clone of the `gulpfile.js` and then follow these steps:

  1. In `Solution Explorer`, expand the `Solution Items` folder, then `Gulp`  and open whatever you called your new copy of `Gulpfile.js`
   
  2. Find the `getAssetGroups()` function (it should be around line 73)
  
  3. The first line declares an `assetManifestPaths` array. You need to add your own `glob.sync` in and then merge the resulting arrays. For example:
  
         var assetManifestPaths = glob.sync("Orchard.Web/{Core,Modules,Themes}/*/Assets.json");
         var customThemePaths = glob.sync("Orchard.Web/MyCompanyThemes/*/Assets.json");
         assetManifestPaths = assetManifestPaths.concat(customThemePaths);
      
  4. Save and close the file.
  
The example above focuses on themes but your custom module folders can use the same technique.
   
The Orchard Team are currently looking into a way to automate this process.