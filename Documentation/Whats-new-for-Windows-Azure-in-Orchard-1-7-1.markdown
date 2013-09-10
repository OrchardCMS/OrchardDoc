The Windows Azure integration and deployment in Orchard have undergone a complete overhaul for version 1.7.1. This topic describes what's changed and the benefits of some of the new capabilities.

## Visual Studio tooling

Prior to version 1.7.1, packaging and deploying to Windows Azure had to be done from the command line, outside of Visual Studio. The external custom MSBuild file `AzurePackage.proj` that was used to do this is no longer needed (but retained for people whose established build processes depend on it). The cloud service deployment configuration has been redesigned to work fully and seamlessly within **Visual Studio Tools for Windows Azure**. This has a number of benefits:

* We now have **one-click publishing** to Windows Azure from directly within Visual Studio, like the Azure gods intended.
* Newer releases of the Visual Studio Tools for Windows Azure **automate things** like creating and connecting to a Windows Azure subscription, creating and provisioning the necessary certificates, and downloading subscription IDs and access keys. This functionality can now be utilized seamlessly. With the old deployment solution this had to be done manually.
* Newer **SDK features** such as [role content folders](http://blogs.msdn.com/b/philliphoff/archive/2012/06/08/add-files-to-your-windows-azure-package-using-role-content-folders.aspx) can now be utilized.
* **Adding more roles to your deployment** besides Orchard.Azure.Web is now as easy as right-clicking and selecting "Add New Role" in Solution Explorer. Before, they also had to be carefully worked into the `AzurePackage.proj` file which was far from trivial.
* Publish can now be done for either **Debug or Release build configurations**. Previous hard coded assumptions no longer apply. This can be very useful for things like collecting IntelliTrace logs from your cloud service deployment, or to simply get line numbers in exception stack traces.
* **Continuous deployment** from TFS to Windows Azure should now "just work" although this has not yet been tested.

Additionally, when building and publishing using `Release` build configuration, **configuration file transformations are now used** instead of custom MSBuild logic. Configuration transform files are visible and editable directly in Solution Explorer (visualized as child items of the `Web.config`, `Host.config` and `Log4net.config` files) and therefore much more discoverable and maintainable.

See the topic [Deploying Orchard to Windows Azure](Deploying-Orchard-to-Windows-Azure) topic for more information.

### Windows Azure SDK 2.1

All Azure-specific solution and project files have been migrated to Windows Azure SDK 2.1. You will need to install **Windows Azure SDK for .NET (VS 2012) - 2.1** using Web Platform Installer to open the `Orchard.Azure.sln` solution and to package and publish Orchard to Windows Azure.

All code that reads settings from Azure role configuration has been updated to use the new platform-agnostic [CloudConfigurationManager](http://msdn.microsoft.com/en-us/library/microsoft.windowsazure.cloudconfigurationmanager.aspx) class, so settings are now read from either Windows Azure Cloud Service role configuration, Windows Azure Web Site configuration settings, or the Web.config `<appSettings>` element.

All code that uses Windows Azure Blob Storage has been migrated to use version 2.0 of the Windows Azure Storage Client.

The Azure-specific solution `Orchard.Azure.sln` has been brought up to date with main solution `Orchard.sln` in terms of project structure etc.

All referenced assemblies from Windows Azure SDK has been placed in the `lib` folder, and are now referenced from there. This avoids having to install Windows Azure SDK just to compile and run Orchard from the main solution `Orchard.sln`.

### New module Orchard.Azure

A new module **Orchard.Azure** has been added. All Azure-specific functionality has been consolidated into this module. Some functionality is enabled automatically by configuration when publishing to a Windows Azure Cloud Service, while other functionality is packaged as features which can be enabled regardless of hosting. The module contains the following features:

* **Windows Azure Media Storage**: Provides an Orchard media storage provider that targets Windows Azure Blob Storage.
* **Windows Azure Output Cache**: Provides an Orchard output cache provider that targets Windows Azure Cache.
* **Windows Azure Database Cache**: Provides an NHibernate second-level cache provider that targets Windows Azure Cache.

These features are completely portable and can be used from any hosting environment, i.e. Windows Azure Cloud Services, Windows Azure Web Sites or some other hosting option.

As you might guess from above, as part of this work two new **native providers for Windows Azure Cache** have been written and are shipped built-in with Orchard. No more need to add the *memcached shim* to your deployment, and no more need to install custom modules with third-party *memcached* providers in order to use Windows Azure Cache (which also means better performance as the *memcached* compatibility layer is not used). The new native providers have been designed and tested to work with both Windows Azure Role-based Cache and the newly released Windows Azure Cache Service.

See the following topics for more information:

* [Using Windows Azure Blob Storage](Using-Windows-Azure-Blob-Storage)
* [Using Windows Azure Cache](Using-Windows-Azure-Cache)

### Cloud services and web sites

As far as possible we now have **feature parity between Windows Azure Cloud Services and Windows Azure Web Sites**. Things like media storage and output caching have been reimplemented and packaged as features in the `Orchard.Azure` module that can be enabled from either environment. Also, automated publishing from within Visual Studio has been overhauled and is supported for both target environments.

### Fully loaded by default

Orchard is now **pre-configured for Windows Azure Cache** when deploying to a Windows Azure Cloud Service. If you scale out your deployment to more than one role instance, you can take advantage of this to keep your instances in sync.

By default the cloud service project is configured for co-located role-based caching with 30% of the role instance memory allowed for cache usage. Three named caches `OutputCache`, `DatabaseCache` and `SessionStateCache` are configured by default. Windows Azure Output Cache and Windows Azure Database Cache have to be enabled as features in the dashboard post-deployment, while the ASP.NET Session State Provider for Windows Azure Cache is configured and enabled by default in Web.config.

**Windows Azure Diagnostics** is now fully configured by default when deploying Orchard to a Windows Azure Cloud Service. The Windows Azure Diagnostics appender is configured by default in the cloud service web role. You can use Server Explorer to download and examine diagnostics data from within your deployment. Additionally, the Windows Azure Diagnostics appender has been improved and now logs messages with their correct severity level (prior to 1.7.1 all Log4net entries were logged to Windows Azure Diagnostics as verbose messages).

As before, when deploying to a Windows Azure Cloud Service, Orchard is pre-configured to use Windows Azure Blob Storage as the underlying file system implementation for shell settings (the `Settings.txt` file). Unlike before, using Windows Azure Blob Storage for media storage is **not** preconfigured, but easily activated by enabling the new *Windows Azure Media Storage* feature. Storage account credentials for these providers need to be specified in the cloud service project before deployment (Visual Studio will display warning messages if you don't). As before, containers are created automatically in the storage service if they don't already exist.
