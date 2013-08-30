Orchard supports several methods of deploying to the Windows Azure environment. Here are some of these methods:

1. Deploy the Orchard binary to an Azure Website using the Azure Website Gallery.
2. Deploy the Orchard binary to an Azure Website using FTP.
3. Build and deploy the Orchard source code to an Azure Website.
4. Build and deploy the Orchard source code to an Azure Cloud Service.

# Deploy the Orchard binary to an Azure Website using the Azure Website Gallery.

# Deploy the Orchard binary to an Azure Website using FTP.

# Build and deploy the Orchard source code to an Azure Website.

# Build and deploy the Orchard source code to an Azure Cloud Service.

## Steps

1. download the Orchard source, 
1. install the appropriate Windows Azure SDK,
1. build it into an Azure cloud service package (.cspkg),
1. create a cloud service configuration file (.cscfg),
1. deploy it to an Azure cloud service.

## Prerequisites

1. Microsoft SQL Azure account
2. Visual Studio software

## Remarks

If you don't want or need to build the package yourself from the source code, 
go to the [CodePlex site](http://orchard.codeplex.com/releases/view/97035), 
and download the Orchard.Azure.1.7.zip binary deployment package. 
This allows you to jump directory to step 5. 

## See Also

1. [Setting up a source enlistment](http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment)
1. [How to Create and Deploy a Cloud Service](http://www.windowsazure.com/en-us/manage/services/cloud-services/how-to-create-and-deploy-a-cloud-service/): a general version of the same steps we outline.
1. [Windows Azure Service Configuration Schema (.cscfg File)](http://msdn.microsoft.com/en-us/library/windowsazure/ee758710.aspx)
1. [Role Schema](http://msdn.microsoft.com/en-us/library/windowsazure/jj156212.aspx)

## 1. Download the Orchard source.
1. Go to https://orchard.codeplex.com/SourceControl/list/changesets
1. Choose the master branch
1. Click on the latest change set. 
1. Click download.
1. Unzip that file into a directory on your local hard drive.
1. We will call that directory __OrchardRocksDir__

## 2. Install the appropriate Windows Azure SDK.

1. Use a text editor to open ..\OrchardRocks\src\Orchard.Azure\Orchard.Azure.CloudService\Orchard.Azure.CloudService.ccproj
1. Find the CloudExtensionsDir element. 
1. Take note of the version of Windows Azure Tools that it specifies. 
1. As of Orchard 1.7 it is Windows Azure Tools 2.0
1. Either download the 2.0 Tools here: http://www.microsoft.com/en-us/download/details.aspx?id=38797 (easiest), 
1. or download the 2.1 Tools here: http://www.windowsazure.com/en-us/downloads/?fb=en-us 
and change the Orchard configuration (harder).

### CloudExtensionsDir using Windows Azure Tools 2.0

    <CloudExtensionsDir Condition=" '$(CloudExtensionsDir)' == '' ">
	     $(MSBuildExtensionsPath)\Microsoft\VisualStudio\v$(VisualStudioVersion)\Windows Azure Tools\2.0\	
	</CloudExtensionsDir>

## 3. Build the Azure cloud service package.

1. SHIFT + Right Click on the OrchardRocksDir. 
1. Choose Copy as path. 
1. Open an elevated Visual Studio Developer Command Prompt.
1. Change directory to OrhcardRocksDir e.g. >cd "C:\Users\Shaun\Desktop\OrchardRocks"
1. Run >ClickToBuildAzurePackage
1. When it gets to the "tests" stage of the build, hit any key to continue, otherwise it will just wait forever.
1. If the build succeededs, OrchardRocksDir will have two new subfolders: artifacts and buildazure

### Success with warnings ~ ignore? Hmm.

	Build succeeded.

	  C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v11.0\Windows Azure Tools\2.0\Microsoft.Win
	dowsAzure.targets(119,3): warning MSB4011: "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Microsoft
	.Common.targets" cannot be imported again. It was already imported at "C:\Program Files (x86)\MSBui
	ld\Microsoft\VisualStudio\v10.0\Windows Azure Tools\2.0\Microsoft.WindowsAzure.targets (117,3)". Th
	is is most likely a build authoring error. This subsequent import will be ignored. [C:\Users\Shaun\
	Desktop\OrchardRocks\AzurePackage.proj]

### Error due to inappropriate Windows Azure SDK version

	C:\Users\Shaun\Desktop\OrchardRocks\src\Orchard.Azure\Orchard.Azure.CloudService\Orchard.Azure.Cl
	oudService.ccproj(59,3): error MSB4019: The imported project "C:\Program Files (x86)\MSBuild\Micros
	oft\VisualStudio\v11.0\Windows Azure Tools\2.0\Microsoft.WindowsAzure.targets" was not found. Confi
	rm that the path in the <Import> declaration is correct, and that the file exists on disk.

### Configure the Azure Cloud Service

TODO Explain the differene between the artifacts and the buildAzure directories.
TODO Determine whether we need to open an Azure Storage account or not. Why do we need it, really? What does it do? 

1. Create a Windows Azure Storage Account. 
1. Open the storage account in the Azure management portal. 
1. Choose Manage Access Keys (in the footer)
1. Copy your Storage Account Name and Primary Access Key.
1. Use a text editor to open ..\OrchardRocks\buildazure\Stage\ServiceConfiguration.cscfg 
1. Edit the value attribute for DataConnectionString as follows: 

    <Setting 
	    name="DataConnectionString" 
	    value="DefaultEndpointsProtocol=https;AccountName=storage-account-name;AccountKey=primary-access-key" />

### Create a new SQL Azure database for Orchard

1. We called ours orchardRocks.

### Deploy to Azure!

1. Open your cloud service in the Windows Azure Management Portal. 
1. In the quickstart area, choose "New production deployment."
1. Name the deployement OrchardRocks_v1
1. Browse for the Package: "..\OrchardRocks\buildazure\Stage\Orchard.Azure.Web.cspkg"
1. Browse for the Configuration: "..\OrchardRocks\buildazure\Stage\ServiceConfiguration.cscfg"
1. Deploy! 
---


1. Install the [Windows Azure SDK](http://www.windowsazure.com/en-us/downloads/). We installed the VS 2012 version, last updated July 2013.

2. Create a cloud service using Quick Create.

3. Deploy the cloud service.

---




2. This includes the Windows Azure SDK. 
2. Download and install VSCloudService.exe which contains both the SDK and the Cloud Services. 
3. If you do not already have a local instance of Microsoft SQL Server, install [Microsoft SQL Server 2008 R2 RTM - Express with Management Tools](http://www.microsoft.com/downloads/en/details.aspx?familyId=967225EB-207B-4950-91DF-EEB5F35A80EE&amp;hash=CDEb%2fJRDkSXIcb5rEbkx2M7RlSbrPNqmx7hbB%2bWHG5DbEBxcq9rXHwK4JS2uDdtvAYo2C8xBh%2fnA7yzNC8xD8w%3d%3d). 
4. A local SQL Server instance is required in order to work with the Azure Storage Emulator. 
5. Management tools are recommended for administering your SQL Azure instance later.

You can build a deployable package for Azure from [the Visual Studio 2010 command line](http://msdn.microsoft.com/en-us/library/ms229859.aspx). 
You will need a [source tree enlistment](Setting-up-a-source-enlistment) of Orchard to do this. 
Run `ClickToBuildAzurePackage.cmd` from the command line in order to build the package. 
(Depending on your environment, you might need to run the script as an administrator.) 
ClickToBuildAzurePackage is not in the current 1.2 Azure package but can be obtained from [the Source Code tab on CodePlex](http://orchard.codeplex.com/SourceControl/list/changesets).

![](../Upload/screenshots_675/click_to_build_azure_package.png)

When the command completes successfully, you will have an Azure package under the _artifacts_ folder (_artifacts\Azure\AzurePackage.zip_).

![](../Upload/screenshots_675/click_to_build_azure_package_success.png)

Unzip the _AzurePackage.zip_ file and edit the _ServiceConfiguration.cscfg_ file. This file contains a sample configuration. 

![](../Upload/screenshots_675/azure_package.png)

The following example shows the sample configuration.

    <?xml version="1.0"?>
    <ServiceConfiguration serviceName="OrchardCloudService" osVersion="*"  xmlns="http://schemas.microsoft.com/ServiceHosting/2008/10/ServiceConfiguration">
      <Role name="Orchard.Azure.Web">
        <Instances count="1" />
        <ConfigurationSettings>
          <Setting name="DataConnectionString" value="UseDevelopmentStorage=true" />
        </ConfigurationSettings>
        <Certificates />
      </Role>
    </ServiceConfiguration>


To update the configuration with your account details, edit the `value` attribute for DataConnectionString. 

    <Setting name="DataConnectionString" value="DefaultEndpointsProtocol=https;AccountName=your-account-name;AccountKey=your-account-key" />


Log in to the [Windows Azure Developer Portal](http://msdn.microsoft.com/en-us/windowsazure/default.aspx).

![](../Upload/screenshots_675/developer_portal_login.png)

On the home page, view your projects and services.

![](../Attachments/Deploying-Orchard-to-Windows-Azure/developer_portal_home.png)

To find your primary and secondary access keys, view the **Storage Accounts** details by selecting a **Storage Account** in the main screen and then clicking **View** under **Properties** on the right. (This is the account key that you copied to the `DataConnectionString` attributes in the _ServiceConfiguration.cscfg_ file.)

![](../Attachments/Deploying-Orchard-to-Windows-Azure/developer_portal_storage.png)

View the details for your SQL Azure service. 

![](../Attachments/Deploying-Orchard-to-Windows-Azure/developer_portal_sqlazure.png)

Create a new SQL Azure database for Orchard. The example below assumes that you're using the name "orcharddb", but you can name it whatever you like.

![](../Attachments/Deploying-Orchard-to-Windows-Azure/sqlazure_create_db.png)

View the details for your Windows Azure Hosted Service. From here you will deploy your package. Click **New Staging/Production Deployment** for either the **Staging** or **Production** node.

![](../Attachments/Deploying-Orchard-to-Windows-Azure/developer_portal_deploy.png)

Browse to the package and configuration files that you built from the Orchard command line. Name the deployment and then click **OK**.

![](../Attachments/Deploying-Orchard-to-Windows-Azure/developer_portal_deploy2.png)

The Azure Developer Portal uploads the files.

When the upload is complete, the deployment is in a "Initializing" state. When the state changes to "Ready", you can start using your website. If the process loops between "Initializing", "Busy", and "Stopping", you might have made a mistake in your configuration file and should check it. 

![](../Attachments/Deploying-Orchard-to-Windows-Azure/developer_portal_deploy3.png)

If all went well, you will see the Orchard setup screen. In order to use Orchard in Azure, you need to configure it against the SQL Azure database in order to ensure that application state is retained while Azure recycles instances of your site during load balancing.

![](../Attachments/Deploying-Orchard-to-Windows-Azure/azure_setup.png)

After completing the setup step, you arrive at the familiar Orchard home page and can being configuring your site.

> **Note** The **Recipe** feature is not available on Azure at this time. To learn more about Orchard recipes, see [Making a Website Recipe](Making-a-Web-Site-Recipe).

# Changing the Machine Key
When you deploy to Azure, it is recommended that you define the machine key from the _web.config_ file in the **Orchard.Azure.Web** project before packaging and deploying.


# Deploying Orchard to Azure with Optional Modules
The package that you deploy to Azure does not have to be limited to the default modules that are distributed with Orchard. You can include third-party modules or your own modules and then deploy them to Orchard.

The only constraint is that the modules cannot be installed dynamically from the gallery as you would do with a regular deployment of Orchard, because of the distributed nature of Azure. The local file system is not automatically replicated across instances; instances might get out of sync if this were allowed. 

In order to work around this constraint and to allow you to deploy your own selection of modules to Azure, you can build your own package that includes the modules that you need.


## Adding a Module to the Distribution
To add a module to the distribution, edit the Azure solution located in _src/Orchard.Azure/Orchard.Azure.sln_. The following steps use `Contrib.Taxonomies` as an example.

Copy the module's files to _src/Orchard.Web/Modules/_. 

![](../Attachments/Deploying-Orchard-to-Windows-Azure/azure_module_source.png)

Open the Azure solution in Visual Studio 2010 and add the project for this module in the _Modules_ folder.

![](../Attachments/Deploying-Orchard-to-Windows-Azure/azure_module_solution.png)

In the project named `Orchard.Azure.Web`, add a reference to the newly included project. 

![](../Attachments/Deploying-Orchard-to-Windows-Azure/azure_module_project.png)

When this is done, launch the build script as described earlier. The resulting package will contain your additional modules. After you've deployed the new package to Azure, you can go to the features screen and enable the features.


## Adding a Theme to the Distribution
To add a theme to the distribution, edit the Azure solution located in _src/Orchard.Azure/Orchard.Azure.sln_. The following steps use `Classic` as an example.

Copy the theme's files to _src/Orchard.Web/Themes_. 

![](../Attachments/Deploying-Orchard-to-Windows-Azure/azure_theme_source.png)

Open the Azure solution in Visual Studio 2010 and add the files for this theme in the `Themes` project.

![](../Attachments/Deploying-Orchard-to-Windows-Azure/azure_theme_solution.png)

When this is done, launch the build script as described earlier. The resulting package will contain your additional themes. 

After you've deployed the new package to Azure, you can go to the themes screen and enable the themes in order to start using them. 

## See Also

[Step-by-step deploying Orchard to Windows Azure](http://ooiks.com/blog/how-to-2/step-by-step-deploying-orchard-to-windows-azure)