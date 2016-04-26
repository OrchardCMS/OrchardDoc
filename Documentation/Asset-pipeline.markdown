Orchard includes an asset pipeline which builds the scripts and styles for each module. You can opt-in to it by using a manifest file called `assets.json` which lives in the root folder of each module. This manifest file lists groups of assets such as `.css`, `.js`, `.less`, `.ts` etc. Each group within the manifest file will output a single compiled and minified file.

## Overview

The pipeline is powered by [Gulp](http://gulpjs.com/), a popular open source build system. Each module within Orchard supports an asset manifest file. This is a JSON format filew which lists the resources that should be compiled.
 
When the pipeline is run, Gulp reads a solution-wide JavaScript file which then parses all of the asset manifests and compiles the resources listed within them.

All of the modules distributed with Orchard already have their compiled and minified assets included. This means you don't need to run the asset pipeline to compile Orchard unless you make changes to these files. To save build time this is disabled by default. 

## Pre-processing your assets with Gulp

In the Visual Studio Solution Explorer you will find a folder called Solution Items. Inside there is a folder with two files, `Gulpfile.js` and `Package.json`:

![](../Attachments/asset-pipeline/solution-items.png)

The `Gulpfile.js` is the JavaScript code that is executed during the build. It will scan all the modules folders for `assets.json` manifests and process them. The assets manifest is a simple JSON format file which groups together files by inputs and outputs. This is what the Orchard.DynamicForms asset.json looks like:

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
The asset pipeling is not enabled by default when you build Orchard. This is to save time as often you won't need to recompile all the assets for each build. Broadly speaking, the installation process requires the following steps:

 1. Install Node.js
 2. Run NPM to install gulp and its related packages
 3. Hook the pipeline script into the build with Task Runner Explorer

These steps are described in detail in the next section.

## Setting up the solution

The first step is to install [Node.js](https://nodejs.org) first. This will install a package manager called NPM which is like NuGet for the JavaScript world. 
 
 1. Visit the [Node.js](https://nodejs.org) homepage
 2. Download your preferred version, either the latest stable edition or the LTS (long term support) version
 3. Install the file the you have downloaded

After that NPM needs running which will read the package.json and install gulp and its associated packages. To do this:

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
  
The next time you build Orchard (for example, by pressing `F5`) the asset pipeline will be executed at the start of the build process.

## Assets.json file format
 - Format
 - Globbing

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

## Custom theme and module folders are currently not automatically included

If your project is using the custom modules and theme folders feature introduced in v1.10 the `gulpfile.js` will not automatically pick up your custom folder locations.

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
   
The Orchard Team are currently looking in to ways to automate this process.