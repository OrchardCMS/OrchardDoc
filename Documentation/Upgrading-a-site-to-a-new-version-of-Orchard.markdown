A new version of a CMS is an important event in the life of a site, and transitioning to it should ideally be simple. Unfortunately, Orchard does not currently have an automated upgrade mechanism. This topic will show how to upgrade to a new version as painlessly as possible today while focusing on making your data safe.


# A Word of Warning

No matter which method you choose to use to upgrade your site, you are going to have to overwrite a lot of files in the process. This should emphasize the requirement to backup first, but it should also call your attention to any modifications you made to common files. For example, if you made any modifications to core modules and/or the framework (something you shouldn't do: custom modules and themes should be used instead), you will loose them, or you will need to re-apply your changes after the upgrade. Any modification you made to web.config or other common files will also need to be re-applied after the process.

If you made modifications to permissions on the files and folders inside your site, they may also get reset in the upgrade and need to be re-applied.

# Upgrading a Running Instance of Orchard to a New Version

The instructions in this section only apply for a standalone Orchard web site. If you are working with the full source code of Orchard, please refer to [#enlistment](Upgrading-a-site-to-a-new-version-of-Orchard#IfYouHaveaSourceCodeEnlistment).

It is highly recommended that you work on a local copy of your site throughout the update process.

* Make a backup of everything in your site, including the database. This is extremely important so that you can roll back to a running site no matter what happens during migration.
* Visit the **Settings** pages on your current Orchard instance and make a note of the current settings. This information might not be needed during the migration process, but if it is, it will otherwise be difficult to get the information.
* Visit the **Modules/Features** and the **Themes** pages on your current Orchard instance and make a note of all the modules and themes you have installed.
* Download a copy of the site from the server to your local computer. If you are routinely working with a staging environment from which you publish to production, you already have that local copy, but the data and media might be out of date. Make sure you download the _App_Data_ and _Media_ folders from the server.
* If you're using a SQL Server Compact database, you've copied the site data by downloading the _App_Data_ folder. If your site is using SQL Server, you can copy that data to a local server in order to work with up-to-date data. However, this isn't required for migration. If you want to work with a local database, you'll also need to edit the _settings.txt_ file for each of the tenants. The _settings.txt_ files can be found under _App_Data\Sites\Default_ or _App_Data\Sites\\[NameOfTheTenant\]_.
* In a new, empty directory, install a fresh copy of the latest version of Orchard, but don't go through setup. 
* Copy your existing site's _Media_ folder into the new directory.
* Copy the remaining module and themes directories that you have on your existing site and that are not already in the new one into the new directory's _Modules_ and _Themes_ directories.
* Copy the _App_Data_ folder from the existing site into the new directory.
* Point a local web server to the new directory. You can use IIS; in that case, use IIS Manager to create a new web site that points at the directory and then navigate to it. Alternatively, you can use WebMatrix and IIS Express; to do that, right-click the directory in Windows Explorer and choose **Open as a Web Site with Microsoft WebMatrix** and then run the site. Finally, you can open the site in Visual Studio as a web site and run it. The new site will have all the data from the old site and have all the new features of Orchard 1.1.
* Go into the dashboard. You're prompted to upgrade features. Click **Modules** and upgrade each of the modules one by one until they are all up to date.
* If you are upgrading from 1.0, the Recipes feature is disabled at this point, and unfortunately it can't be enabled from the admin UI. Open an [Orchard command-line](Using-the-command-line-interface) and execute the following command:
    
    feature enable Orchard.Recipes

Alternatively, if you can't run the command-line, you can use the web command-line from the [Experimental module](http://orchardproject.net/gallery/List/Modules/Orchard.Module.Orchard.Experimental). Once the Web Command Line feature has been enabled, the web command-line can be navigated to by going to /Experimental/Commands.
A third alternative is to unzip the following archive under a new Upgrade.From.1.0 folder under Modules: [Upgrade.From.1.0.zip](../Attachments/Upgrading-a-site-to-a-new-version-of-Orchard/Upgrade.From.1.0.zip). Enabling the Upgrade From 1.0 feature will enable the Recipes module. Once this is done and you've verified that Recipes are enabled, you can safely delete the upgrade.from.1.0 folder from Modules.
* Go to the Orchard Gallery and get the latest version of all the modules you have on your site.

## Publishing the Upgraded Site

You can deploy the locally upgraded site to your production server using your preferred deployment solution. That might be Visual Studio Web deployment, WebMatrix, or even FTP. You again have a choice of wiping out the target directory before you deploy. Make your choice depending on your deployment method, how clean you want the resulting directory to be, and on how long it's acceptable to keep the site down.

As you deploy, make sure that the target _settings.txt_ files aren't overwritten, so that the production site continues to point to the production database.

While you deploy, you might want to shut the site down by dropping an _app_offline.htm_ file into the root. Remove that file once you're done.

# Upgrading An Orchard Site In-Place

It is possible to upgrade a site in-place, if you can't or don't want to work with a local copy and then publish it. The procedure is less clean but it works.

* Backup everything (site and database).
* Download the new version to your local machine.
* Add App_offline.htm to the root of the site during the upgrade. This effectively tells the web server to return this page for all requests. You should put a message such as "The site is currently being updated. Thank you for your patience. Please try again later." in the file.
* Delete what's in bin. This ensures that old versions of binaries that won't get replaced will not continue to be picked up by the application.
* Delete the App_Data\Dependencies folder. Orchard will rebuild this folder on startup. This ensures that old versions of module assemblies will not be picked up by the application.
* Extract the new version's zip file and copy what's in its Orchard folder over the server's Orchard web directory (answer yes to all prompts to overwrite).
* Remove the app_offline file.
* The site should be running now. Log-in and go into admin.
* Modules need to be updated. Do each of them.
* If you are upgrading from 1.0, the Recipes feature is disabled at this point, and unfortunately it can't be enabled from the admin UI. Open an [Orchard command-line](Using-the-command-line-interface) and execute the following command:
    
    feature enable Orchard.Recipes

Alternatively, if you can't run the command-line, you can use the web command-line from the [Experimental module](http://orchardproject.net/gallery/List/Modules/Orchard.Module.Orchard.Experimental). Once the Web Command Line feature has been enabled, the web command-line can be navigated to by going to /Experimental/Commands.
A third alternative is to unzip the following archive under a new Upgrade.From.1.0 folder under Modules: [Upgrade.From.1.0.zip](../Attachments/Upgrading-a-site-to-a-new-version-of-Orchard/Upgrade.From.1.0.zip). Enabling the Upgrade From 1.0 feature will enable the Recipes module. Once this is done and you've verified that Recipes are enabled, you can safely delete the upgrade.from.1.0 folder from Modules.

You are done.

# Upgrading an Azure Instance of Orchard

* You should already have the full source code, with your modifications if you had any (additional modules or themes). Upgrade that by copying the source of the new version over it (overwrite whenever asked), or by doing a Mercurial update to the desired version. If you do not already have the full source code, then that means you don't have any changes to the default distribution. In that case just get the source code for the new version. In any case, at this point you should have a local directory on your development machine that has the code for the new version, plus any themes and modules you may have added, and no data (be it media or database, as on Azure you are using blob storage for the former, and Sql Azure for the latter). All that remains to be done is to build the new package and deploy it.
* Run clickToBuildAzurePackage.cmd. This file should be at the root of your source code folder. If it's not there (it was missing from older release files), get it and other root files from the relevant version in http://orchard.codeplex.com/SourceControl/list/changesets
* Unzip artifacts/Azure/AzurePackage.zip
* Open ServiceConfiguration.cscfg and replace the value of the DataConnectionString with your DefaultEndpointsProtocol=https;AccountName=your-account-name;AccountKey=your-account-key
* Open the Azure Management Portal, go to Hosted Services, Storage Accounts & CDN and choose your deployment target. Click Upgrade. ![](../Attachments/Upgrading-a-site-to-a-new-version-of-Orchard/AzureDeployNewPackage.PNG)
* Browse to the package and config file, click OK. ![](../Attachments/Upgrading-a-site-to-a-new-version-of-Orchard/AzureDeployNewPackageDialog.PNG)
* Log-in and go to admin.
* Upgrade features.
* If you are upgrading from 1.0, you need to enable the Recipes module. Enable the Web Command Line feature. Go to /experimental/commands and type "feature enable Orchard.Recipes". Hit return. You may disable the web command line feature.

You're done.


# If You Have a Source Code Enlistment

If you are working with a source code enlistment, the update process is going to be extremely simple because you are already going through it every time you sync your source code directory with the repository. When the time comes to upgrade, just get the latest changes and sync to the latest in the default branch.

# Import/Export

The [Import/Export](http://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.ImportExport) module 
can be used to do clean data migrations from one version to another.

# Applying a framework patch

Occasionally, we may release small updates in the form of a patch to one or several dlls.
These patch files are regular zip files that contain updated dll files.

To install such a patch, first extract the zip, then make a copy of the version of those files that are already
in the bin folder of your site. Then, replace the existing copy with the one from the patch file.
