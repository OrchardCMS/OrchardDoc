> This topic is being updated for the Orchard 1.1 release.

Orchard provides a packaging feature that lets you share themes you have created. The feature creates a package (_.zip_ file, in [.nupkg](http://nuget.org) format) that contains your theme. It also lets you upload your new theme to the Orchard Gallery.

This article shows you how to package a theme and upload it the Orchard Gallery, and how users can download and install your theme.

# Viewing the Packaging Modules
To view the packaging modules, open the Orchard dashboard and click **Modules**. Scroll to **Packaging**. 

![](../Upload/screenshots_675/packaging_modules_675.png)

The **Packaging** modules are enabled by default. If any of the modules have been disabled, you must enable them in order to package and upload your theme.

# Packaging Your Theme
To package your theme, open the Orchard command line and type the following command, replacing _MyFirstTheme_ with the name of your theme, and _C:\Temp_ with the output path for the generated package file. 

    
    package create MyFirstTheme C:\Temp


The package feature creates a _.nupkg_ file. (For more information, see [NuGet.org](http://nuget.org).) The name of the _.nupkg_ file is the name of your theme plus its version number, as in the following example:

    
    Orchard.Theme.<nameOfYourTheme>.<version>.nupkg


# Uploading Your Theme to Gallery
After creating your package, you can share your theme by giving someone the package file. You can also contribute your theme to the Orchard Gallery. For information about how to contribute your theme, see [Contributing a Module or Theme to the Gallery](Contributing-a-module-or-theme-to-the-gallery).

# Installing a Packaged Theme
To install a packaged theme in Orchard, open the Orchard dashboard. Click **Themes**, and then click **Install a theme from my compter**.

![](../Upload/screenshots_675/themes_installNew_675.png)

Click **Choose File**. Browse to, and select, the theme package (_.nupkg_) file, and then click **Open**. Then click **Install**. If Orchard is running on a remote server, you will be browsing your local computer; you do not need to put the _.nupkg_ file onto the server before installing.

![](../Upload/screenshots/themes_chooseFile.png)

Your new theme appears under **Available**.

![](../Upload/screenshots_675/themes_newThemeImage_675.png)
