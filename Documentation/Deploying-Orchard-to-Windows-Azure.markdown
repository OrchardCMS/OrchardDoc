Orchard supports building and deploying to the Windows Azure environment. If you don't want or need to build the package by yourself, a binary version of the Windows Azure package is available on the [CodePlex site](http://orchard.codeplex.com/releases/view/50197). This topic describes the steps that you can take to build and packages of Orchard and deploy them to Azure. 

Before you begin this tutorial, you need a [Microsoft SQL Azure](http://www.microsoft.com/en-us/sqlazure/default.aspx?WT.srch=1&WT.srch=1)  account as well as the [Windows Azure Storage](http://www.microsoft.com/windowsazure/storage/default.aspx) service. Windows Azure Storage provides a BLOB (Binary Large Object) service, which is how binary content (such as files) are stored on Azure to be acccessed across multiple servers.



# Building and Deploying to Azure
To begin, install [Windows Azure SDK and Tools for Microsoft Visual Studio 1.5 (September 2011)](http://www.microsoft.com/download/en/details.aspx?id=27577), 
which includes the Windows Azure SDK. Download and install VSCloudService.exe which contains both the SDK 
and the Cloud Services. If you do not already have a local instance of Microsoft SQL Server, install
[Microsoft SQL Server 2008 R2 RTM - Express with Management Tools](http://www.microsoft.com/downloads/en/details.aspx?familyId=967225EB-207B-4950-91DF-EEB5F35A80EE&amp;hash=CDEb%2fJRDkSXIcb5rEbkx2M7RlSbrPNqmx7hbB%2bWHG5DbEBxcq9rXHwK4JS2uDdtvAYo2C8xBh%2fnA7yzNC8xD8w%3d%3d). 
A local SQL Server instance is required in order to work with the Azure Storage Emulator. Management tools are 
recommended for administering your SQL Azure instance later.

You can build a deployable package for Azure from [the Visual Studio 2010 command line](http://msdn.microsoft.com/en-us/library/ms229859.aspx). You will need a [source tree enlistment](Setting-up-a-source-enlistment) of Orchard to do this. Run `ClickToBuildAzurePackage.cmd` from the command line in order to build the package. (Depending on your environment, you might need to run the script as an administrator.) ClickToBuildAzurePackage is not in the current 1.2 Azure package but can be obtained from [the Source Code tab on CodePlex](http://orchard.codeplex.com/SourceControl/list/changesets).

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