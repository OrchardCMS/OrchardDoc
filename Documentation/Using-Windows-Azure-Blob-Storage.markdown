Orchard ships with providers for Windows Azure Blob Storage, allowing Orchard to use Windows Azure Blob Storage as the underlying file system implementation for shell settings (`Settings.txt`) and/or media storage. This topic describes how to configure and enable this functionality.

# Using shell settings storage

Storing shell settings in Windows Azure Blob Storage is useful when running Orchard in server farm where there is no shared file system storage. Windows Azure Cloud Services is an example of this. For this reason, when deploying Orchard to a Windows Azure Cloud Service using the `Orchard.Azure.sln` solution, the resulting package is already preconfigured to store shell settings in Windows Azure Blob Storage.

The only thing you need to change before deploying is the connection string of the storage account you want to use:

![](../Attachments/Using-Windows-Azure-Blob-Storage/settings-storage-account.png)

1. Open `Orchard.Azure.sln`.
2. Navigate to `Orchard.Azure.CloudService`, double click the role `Orchard.Azure.Web` to bring up its property page, and navigate to the *Settings* tab.
3. Set the `Orchard.Azure.Settings.StorageConnectionString` setting to be the connection string of the storage account you want to use.
4. Deploy the cloud service.

> NOTE: It is **not** necessary to use this feature when running Orchard in a Windows Azure Web Site, because in this environment the file system is shared among instances.

It is also possible to use this feature is any other hosting environment where you have a server farm with multiple nodes but no shared file system. To do this you need to do the following:

* Add the `Orchard.Azure.Settings.StorageConnectionString` setting in the `<appSettings>` element of your `Web.config` file and set it to the connection string of the storage account you want to use.
* Configure Autofac to load the `AzureBlobShellSettingsManager` implementation in your `Config\Host.config` file.

Here's an example `Config\Host.config` configuration:

	<autofac defaultAssembly="Orchard.Framework">
		<components>
			<!-- Configure Orchard to store shell settings in Windows Azure Blob Storage. -->
			<component instance-scope="single-instance" type="Orchard.FileSystems.Media.ConfigurationMimeTypeProvider, Orchard.Framework" service="Orchard.FileSystems.Media.IMimeTypeProvider"></component>
			<component instance-scope="single-instance" type="Orchard.Azure.Services.Environment.Configuration.AzureBlobShellSettingsManager, Orchard.Azure" service="Orchard.Environment.Configuration.IShellSettingsManager"></component>
		</components>
	</autofac>

# Using Windows Azure Media Storage

The *Windows Azure Media Storage* feature in the `Orchard.Azure` module configures Orchard to use Windows Azure Blob Storage is the underlying file system implementation for storing media:

	Orchard.Azure:
		Name: Windows Azure Media Storage
		Description: Activates an Orchard media storage provider that targets Windows Azure Blob Storage.
		Category: Hosting

There are two main reasons to use this feature:

* Running Orchard in a server farm configuration. Without using some form of shared storage, media content will become out of sync between the nodes in your farm as users add or remove media files.
* Offloading media requests from the Orchard web server. When *Windows Azure Media Storage* is enabled all end user requests for media content are made directly to the public blob storage endpoint.

### Enabling for Windows Azure Cloud Services

Before the feature can be enabled you must configure the connection string to the storage account you want to use. When running Orchard in a Windows Azure Cloud Service this can be done either before deploying (in the cloud service project) or after deploying (in the Windows Azure management portal).

To configure the connection string *before* deploying:

1. Open `Orchard.Azure.sln`.
2. Navigate to `Orchard.Azure.CloudService`, double click the role `Orchard.Azure.Web` to bring up its property page, and navigate to the *Settings* tab.
3. Set the `Orchard.Azure.Media.StorageConnectionString` setting to be the connection string of the storage account in which you want to store media content.
4. Deploy the cloud service.

Example syntax for `[storageConnectionString]`: `DefaultEndpointsProtocol=http;AccountName=[blobAccount];AccountKey=[access key for Azure storage]`

To configure the connection string *after* deploying:

1. Deploy the cloud service.
2. In the management portal, navigate to your cloud service and select the *Configure* tab.
2. Under `Orchard.Azure.Web` locate the setting `Orchard.Azure.Media.StorageConnectionString`.
3. Set it to be the connection string of the storage account in which you want to store media content.
4. Click *Save*.

> NOTE: For Azure storage accounts using a custom domain, add `BlobEndpoint=http://mycustomdomain.foo.com;` to the start of the connection string.

You can now enable the feature *Windows Azure Media Storage* in the admin dashboard.

> NOTE: For multi-tenancy scenarios the `Orchard.Azure.Media.StorageConnectionString` setting can optionally be prefixed with a tenant name. For example, `<add key="Default:Orchard.Azure.Media.StorageConnectionString" value=".."/>` and `<add key="Tenant1:Orchard.Azure.Media.StorageConnectionString" value=".."/>`.

### Enabling for Windows Azure Web Sites

Before the feature can be enabled you must configure the connection string to the storage account you want to use. When running Orchard in a Windows Azure Web Site this can be done either before deploying (in Web.config) or after deploying (in the Windows Azure management portal).

To configure the connection string *before* deploying:

1. Open `Orchard.sln`.
2. Navigate to `Orchard.Web` and open the `Web.config` file.
3. In the `<appSettings>` element add a setting named `Orchard.Azure.Media.StorageConnectionString` and set its value to be the connection string of the storage account in which you want to store media content (see example below).
4. Deploy the web site.

Here's an example configuration:

	<appSettings>
		...
		<add key="Orchard.Azure.Media.StorageConnectionString" value="[storageConnectionString]"/>
	</appSettings>

Example syntax for `[storageConnectionString]`: `DefaultEndpointsProtocol=http;AccountName=[blobAccount];AccountKey=[access key for Azure storage]`

To configure the connection string *after* deploying:

1. Deploy the web site.
2. In the management portal, navigate to your web site and select the *Configure* tab.
2. Under *App settings* add a setting named `Orchard.Azure.Media.StorageConnectionString` and set its value to be the connection string of the storage account in which you want to store media content.
4. Click *Save*.

> NOTE: For Azure storage accounts using a custom domain, add `BlobEndpoint=http://mycustomdomain.foo.com;` to the start of the connection string.

You can now enable the feature *Windows Azure Media Storage* in the admin dashboard.

> NOTE: For multi-tenancy scenarios the `Orchard.Azure.Media.StorageConnectionString` setting can optionally be prefixed with a tenant name. For example, `<add key="Default:Orchard.Azure.Media.StorageConnectionString" value=".."/>` and `<add key="Tenant1:Orchard.Azure.Media.StorageConnectionString" value=".."/>`.

### Enabling for any other hosting

To enable the feature when running Orchard in any other hosting environment, use the `Web.config` method described above. Once the connection string has been added to the `<appSettings>` element, can enable the feature *Windows Azure Media Storage* in the admin dashboard.
