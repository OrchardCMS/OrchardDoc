> Draft topic Orchard supports several methods of deploying to the Windows Azure environment.

__Methods of deployment to Azure that this document outlines__

* Deploy the Orchard binary to an Azure Website using the Azure Website Gallery (coming soon)
* Deploy the Orchard binary to an Azure Website using FTP (draft)
* Build and deploy the Orchard source code to an Azure Website (coming soon)
* Build and deploy the Orchard source code to an Azure Cloud Service (done)

# Deploy the Orchard binary to an Azure Website using the Azure Website Gallery

> Coming soon.

# Deploy the Orchard binary to an Azure Website using FTP

> Coming soon.

# Build and deploy the Orchard source code to an Azure Website using FTP

[Orchard Source Code Repo]: http://orchard.codeplex.com/sourcecontrol/list/changesets

> Last tested on 31 August 2013 from Windows 8 with Visual Studio 2012 and Orchard 1.7

__Overview__

1. Download the Orchard source to your local machine
2. Create an SQL Server database on your local machine
3. Get Started locally
4. Create an SQL Server instance in Windows Azure
5. Deploy the local database to the Windows Azure SQL Server
6. Create a Website in Windows Azure
7. Compile and deploy your local code to the Windows Azure Website
8. Configure the database connection string

__Requirements__

- Visual Studio
- SQL Server
- SQL Server Management Studio
- Windows Azure account
- FTP Client (e.g. FileZilla)

__Download the Orchard source to your local machine__

- Go to the [Orchard Source Code Repo][]
- Choose the master branch
- Click on the latest change set
- Click download
- Save the file to your hard drive
- Unzip it into C:/OrchardRocks (or wherever)

__Create an SQL Server database on your local machine__

- Open SQL Server Management Studio
- Connect to your local SQL Server engine
- Create a new database called orchardrocks_db (or whatever)

__Get Started locally__

- Open "C:\OrchardRocks\src\Orchard.sln" with Visual Studio
- View the solution explorer (Ctrl + Alt + L)
- Set Orchard.Web as the startup project (Right click > Set as startup project)
- Run without debugging (Ctrl + F5)
- Orchard's Get Started page will show
- Name your site
- Choose a username
- Create a strong password
- Use an existing SQL Server, SQL Express database
- Add the orchardrocks_db connection string

> data source=FONTY;initial catalog=orchardrocks\_db;integrated security=True;MultipleActiveResultSets=True;

- Choose the Default recipe
- Click Finish Setup
- After it completes you will see the default Orchard homepage

__Create an SQL Server instance in Windows Azure__

- Login to the Windows Azure Management portal. 
- Go to SQL DATABASES
- Choose SERVERS
- Click ADD
- Choose a LOGIN NAME, LOGIN PASSWORD, and REGION. 
- Do allow Windows Azure Services to Access the Server.
- Open the server in the management portal once Azure finishes creating it
- Choose CONFIGURE
- Under allowed ip addresses, choose to add the CURRENT CLIENT IP ADDRESS TO THE ALLOWED IP ADDRESSES.
- SAVE

__Deploy the local database to the Windows Azure SQL Server__

- Open SQL Server Management Studio
- Connect to your local SQL Server engine
- Right click orchardrocks_db 
- Choose Deploy database to SQL Azure
- Connect to your Windows Azure SQL Database Server
- Accept the default settings. 
- Click Next
- Click Finish
- The deployment might take two minutes
- When the operation is complete, you can check for the database in the Azure Management portal 

__Create a Website in Windows Azure__

- Login to the Windows Azure Management portal
- Choose New > Compute > Website > Quick Create
- Add a URL and select a region
- Click the giant green tickmark to create the site
- After Azure creates it, open the website in the management portal
- Go to DASHBOARD, and note its FTP host name, FTP USER, and FTP password
- Do not use the FTPS host name unless you want to setup a certificate
> TODO Explain how to setup and to find the Website's FTP password

__Compile and deploy your local code to the Windows Azure Website__

- Open a Visual Studio Developer Command Prompt
- Change the directory to the Orchard root folder with cd "C:\OrchardRocks"
- Run build Precompiled
- Compilation will take about two minutes.
- The result is a C:\OrchardRocks\build\Precompiled directory
- Open FileZilla or another FTP client
- Connect to the Azure Website using the its FTP host name, FTP USER, and FTP password
- Upload the contents of C:\OrchardRocks\build\Precompiled\ to /site/wwwroot
- The upload will contain about 1650 files and 45 MB

> Tip: If you are receiving a bunch of failed FTP transfers, make sure that you are using FTP not FTPS

- Once the upload is complete, __DO NOT NAVIGATE TO THE WEBSITE YET__, instead...
- Copy the contents of C:\OrchardRocks\src\Orchard.Web\App_Data\ to /site/wwwroot/AppData
- This upload will contain about 20 files and 5 MB

> Tip: If you navigate to the website now, you will see "The resource cannot be found." error, 
> because Orchard is trying to connect to your local database. You will need to configure the database
> connection string AND restart the website (e.g. by doing a trivial modification to the root web.config file).

__Configure the database connection string__

- With your FTP client still open, open the /site/wwwroot/App_Data/Sites/Default/Settings.txt file
- Change the DataConnectionString from the local database to the remote one, e.g.

> Server=tcp:w6jnz09d9i.database.windows.net,1433;Database=orchardrocks\_db;User ID=bigfont@w6jnz09d9i;Password=abc123!@#;Trusted\_Connection=False;Encrypt=True;Connection Timeout=30;

- Now you can navigate to the website at orchardrocks.azurewebsites.net (or whatever you named it)
- If all went as planned, you should see the Orchard homepage *not* the Orchard start page

# Build and deploy the Orchard source code to an Azure Cloud Service

[Orchard Source Code Repo]: https://orchard.codeplex.com/SourceControl/list/changesets
[Web Platform Installer]: http://www.microsoft.com/web/downloads/platform.aspx

[StorageAccountKeys]: ../Attachments/Deploying-Orchard-to-Windows-Azure/StorageAccountKeys.PNG
[NewCloudServiceDeployment]: ../Attachments/Deploying-Orchard-to-Windows-Azure/NewCloudServiceDeployment.PNG
[UploadAPackage]: ../Attachments/Deploying-Orchard-to-Windows-Azure/UploadAPackage.PNG
[ProgramsAndFeatures]: ../Attachments/Deploying-Orchard-to-Windows-Azure/ProgramsAndFeatures.PNG

> Last tested on 30 August 2013 from Windows 8 with Visual Studio 2012, Azure SDK 2.0 and Orchard 1.7

What follows is one method of deploying a source code drop of Orchard 1.7 to a new Azure Cloud Service.

__Overview__

* Download the Orchard source
* Install the appropriate Windows Azure SDK version
* Update the csproj references to the correct SDK version
* Build an Azure cloud service package (.cspkg)
* Create an Azure Storage account
* Update the cloud service configuration file (.cscfg)
* Create an Azure cloud service
* Deploy to the Azure cloud service

__Requirements__

* Microsoft SQL Azure account
* Visual Studio

__See Also__

* [Setting up a source enlistment](http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment)
* [How to Create and Deploy a Cloud Service](http://www.windowsazure.com/en-us/manage/services/cloud-services/how-to-create-and-deploy-a-cloud-service/): a general version of the same steps we outline.
* [Windows Azure Service Configuration Schema (.cscfg File)](http://msdn.microsoft.com/en-us/library/windowsazure/ee758710.aspx)
* [AsmSpy: A little tool to help fix assembly version conflicts](http://mikehadlow.blogspot.ca/2011/02/asmspy-little-tool-to-help-fix-assembly.html)

__Download the Orchard source__

* Go to the [Orchard Source Code Repo][]
* Choose the master branch
* Click on the latest change set
* Click download
* Save the file to your hard drive
* Unzip it into __C:/OrchardRocks__ (or wherever)

__Install the appropriate Windows Azure SDK version__

* Start > Control Panel > Programs and Features > Search > Azure

![][ProgramsAndFeatures]

* We need the search results to look just like that image.
* If they do not, then here is one procedure you can follow. 
* Uninstall all the programs that are listed in those search results.
* Then, close the control panel
* Open the [Web Platform Installer][]
* Search for "Azure SDK"
* Select "Windows Azure SDK for .NET (VS 20XX) - 2.0"
* Choose Add, click Install, and Accept the terms.
* Reboot your computer just to be thorough.
* Now you have _only_ the Azure SDK 2.0 installed.

*Aside: Why is this necessary?*

The Orchard.Azure.CloudService.ccproj has a CloudExtensionsDir element that targets Windows Azure Tools 2.0. 
As a result, the build process will fail unless we have the right version of the SDK installed.

---

    <CloudExtensionsDir Condition=" '$(CloudExtensionsDir)' == '' ">
	     $(MSBuildExtensionsPath)\Microsoft\VisualStudio\v$(VisualStudioVersion)\Windows Azure Tools\2.0\	
	</CloudExtensionsDir>

__BugFix: Update the csproj references to the correct SDK version__

* Open "C:\OrchardRocks\src\Orchard.Azure\Orchard.Azure.sln" in Visual Studio
* Unload the Orchard.Azure project (Right Click > Unload Project)
* Edit the Orchard.Azure project (Right Click > Edit...)
* Delete the following references:

---

    <Reference Include="Microsoft.WindowsAzure.Diagnostics, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>C:\Program Files\Microsoft SDKs\Windows Azure\.NET SDK\2012-10\ref\Microsoft.WindowsAzure.Diagnostics.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.WindowsAzure.ServiceRuntime, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <Private>True</Private>
    </Reference>
    <Reference Include="Microsoft.WindowsAzure.StorageClient, Version=1.7.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
    </Reference>

* Save. 
* Reload the Orchard.Azure project (Right Click > Reload Project > Yes)
* Expand Orchard.Azure. 
* Right Click on References > Add Reference > Assemblies > Search > "Azure"
* Select the assemblied that you just removed but choose version 2.0 where possible.
* Repeat with the Orchard.Azure.Web project but remove the following references:

---

    <Reference Include="Microsoft.WindowsAzure.Configuration, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>C:\Program Files\Microsoft SDKs\Windows Azure\.NET SDK\2012-10\ref\Microsoft.WindowsAzure.Configuration.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.WindowsAzure.Diagnostics, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <HintPath>C:\Program Files\Microsoft SDKs\Windows Azure\.NET SDK\2012-10\ref\Microsoft.WindowsAzure.Diagnostics.dll</HintPath>
      <SpecificVersion>False</SpecificVersion>
      <Private>True</Private>
    </Reference>
    <Reference Include="Microsoft.WindowsAzure.ServiceRuntime, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <Private>False</Private>
    </Reference>
    <Reference Include="Microsoft.WindowsAzure.StorageClient, Version=1.7.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
    </Reference


* When done, those references should be Version=2.0.0.0 where possible.
* Close Visual Studio and save the solution and projects.

__Build an Azure cloud service package (.cspkg)__

* Open C:/OrchardRocks and double click on ClickToBuildAzurePackage.cmd
* Wait approx one minute; the build will run; several command windows will open during testing.
* Sometimes the build stalls after tests. Continue by hitting any key.
* If the build succeededs, C:/OrchardRocks will have two new subfolders: artifacts and buildazure.
> TODO What is the difference between artifacts and buildazure?

__Create an Azure Storage account__

* Login to the Windows Azure management portal. 
* Click New > Data Services > Storage > Quick Create
* Name your service orchardrocks (or whatever) and Create Storage Account
* Once Azure has created the account, open it in the Azure management portal. 
* Choose Manage Access Keys (in the footer)
* Copy your __Storage Account Name__ and __Primary Access Key__

![][StorageAccountKeys]

> TODO Determine whether we really need to open an Azure Storage account or not. What does it do? Is it optional?

__Update the cloud service configuration file (.cscfg)__

* Use a text editor to open C:\OrchardRocks\buildazure\Stage\ServiceConfiguration.cscfg 
* Update the DataConnectionString with the following <Setting /> element.
* Be sure to use your own Storage Account Name and Primary Access Key
* Leave the Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString for now.

---

    <Setting 
	    name="DataConnectionString" 
	    value="DefaultEndpointsProtocol=https;AccountName=storage-account-name;AccountKey=primary-access-key" />

__Optional: Create a new SQL Azure database for Orchard__

* This isn't strictly necessary. 
* For the sake of simplicity in this tutorial, use the built-in SQL Server CE for now.

__Create a Azure Cloud Service__

* Login to the Windows Azure management portal. 
* Click New > Computer > Cloud Service > Quick Create
* Name your service orchardrocks (or whatever) and then click Create Cloud Service

__Deploy to the Azure cloud service__

* Login to the Windows Azure management portal
* Open your cloud service
* In the quickstart area, choose "New production deployment."

![][NewCloudServiceDeployment]

* Name the deployement anything (e.g. OrchardRocks_v1)
* Browse for the Package: "C:\OrchardRocks\buildazure\Stage\Orchard.Azure.Web.cspkg"
* Browse for the Configuration: "C:\OrchardRocks\buildazure\Stage\ServiceConfiguration.cscfg"
* Choose "Deploy even if one or more roles contain a single instance."
* Choose "Start deployment."
* Deploy!

![][UploadAPackage]

* Deployment should take about 10 to 15 minutes. Have some water :-)
* Go the the cloud service's Dashbaord to view the deployment progress. 
* Once complete, browse to orchardrocks.cloudapp.net (or whereever)

__Some Warnings and Errors that Might Occur__

*ClickToBuildAzurePackage: ...cannot be imported again*

Why: Unknown.
Fix: Unknown.

> Build succeeded.

> C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v11.0\Windows Azure Tools\2.0\Microsoft.Win
> dowsAzure.targets(119,3): warning MSB4011: "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Microsoft
> .Common.targets" cannot be imported again. It was already imported at "C:\Program Files (x86)\MSBui
> ld\Microsoft\VisualStudio\v10.0\Windows Azure Tools\2.0\Microsoft.WindowsAzure.targets (117,3)". Th
> is is most likely a build authoring error. This subsequent import will be ignored. 
> [C:\OrchardRocks\AzurePackage.proj]

*ClickToBuildAzurePackage: Found conflicts between different versions of the same dependent assembly.*

Why: Our project is targetting different versions of the same assemblies.
Fix: Run AsmSpy.exe, then update conflicting dependency references to consistent versions.

> Build succeeded.

> "C:\OrchardRocks\AzurePackage.proj" (Build target) (1) ->
> "C:\OrchardRocks\src\Orchard.Azure\Orchard.Azure.sln" (Build target) (2:2) ->
> "C:\OrchardRocks\src\Orchard.Azure\Orchard.Azure.CloudService\Orchard.Azure.CloudService.ccproj" (default target) (65:2) ->
> "C:\OrchardRocks\src\Orchard.Azure\Orchard.Azure.Web\Orchard.Azure.Web.csproj" (default target) (64:3) ->
> (ResolveAssemblyReferences target) ->
> C:\Windows\Microsoft.NET\Framework\v4.0.30319\Microsoft.Common.targets(1605,5): warning MSB3247:
> Found conflicts between different versions of the same dependent assembly. 
> [C:\OrchardRocks\src\Orchard.Azure\Orchard.Azure.Web\Orchard.Azure.Web.csproj]

> "C:\OrchardRocks\AzurePackage.proj" (Build target) (1) ->
> "C:\OrchardRocks\src\Orchard.Azure.Tests\Orchard.Azure.Tests.sln" (Build target) (67) ->
> "C:\OrchardRocks\src\Orchard.Azure.Tests\Orchard.Azure.Tests.csproj" (default target) (68) ->
>  C:\Windows\Microsoft.NET\Framework\v4.0.30319\Microsoft.Common.targets(1605,5): warning MSB3247:
> Found conflicts between different versions of the same dependent assembly. 
> [C:\OrchardRocks\src\Orchard.Azure.Tests\Orchard.Azure.Tests.csproj]

*ClickToBuildAzurePackage: ...was not found*

Why: We have an earlier or later version of the Windows Azure SDK installed.
Fix: Ensure that Windows Azure SDK 2.0 is the only version of the SDK installed.

> C:\OrchardRocks\src\Orchard.Azure\Orchard.Azure.CloudService\Orchard.Azure.Cl
> oudService.ccproj(59,3): error MSB4019: The imported project "C:\Program Files (x86)\MSBuild\Micros
> oft\VisualStudio\v11.0\Windows Azure Tools\2.0\Microsoft.WindowsAzure.targets" was not found. Confi
> rm that the path in the <Import> declaration is correct, and that the file exists on disk.
	
*After Deployment: Could not load file or assembly...*

Why: Our Microsoft.WindowsAzure.* references are an earlier version, which is resolving to 2.1.0.0
Fix: Update the references to version 2.0

> Could not load file or assembly 'Microsoft.WindowsAzure.ServiceRuntime, Version=2.1.0.0, 
> Culture=neutral, PublicKeyToken=31bf3856ad364e35' or one of its dependencies. 
> The system cannot find the file specified.

*After Deployment: Could not load file or assembly...*

Why: We deleted the assembly accidentally.
Fix: Add the missing assembly to the Orchard.Azure.Web project. 

> Could not load file or assembly 'Microsoft.Web.Infrastructure, Version=1.0.0.0, Culture=neutral, 
> PublicKeyToken=31bf3856ad364e35' or one of its dependencies. The system cannot find the file specified.