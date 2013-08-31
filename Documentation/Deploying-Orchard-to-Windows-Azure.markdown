> Draft topic Orchard supports several methods of deploying to the Windows Azure environment.

__Methods of deployment to Azure that this document outlines__

* Deploy the Orchard binary to an Azure Website using the Azure Website Gallery (coming soon)
* Deploy the Orchard binary to an Azure Website using FTP (draft)
* Build and deploy the Orchard source code to an Azure Website (coming soon)
* Build and deploy the Orchard source code to an Azure Cloud Service (done)

# Deploy the Orchard binary to an Azure Website using the Azure Website Gallery

> Coming soon.

# Deploy the Orchard binary to an Azure Website using FTP

> Draft. Not tested yet.

__Overview__

1. Do a clean source drop of the Orchard code for development.
2. Create a local SQL Server database for development.
3. Connect the database to the codebase.
4. Keep both the database and the codebase in Git version control throughout.
5. Install, enable, and build the Bootstrap Theme.
6. Install, enable (debug, and test) the DesignerTools module. 
7. Deploy our development database to a production Windows Azure SQL Database. 
8. Deploy our development code to a product Windows Azure Web Site. 
9. Set ourselves up to update the production database and codebase from development.
0. Solve and document bugs as they arise.

__Ideas for Workflow / Documentation Improvement__

- Publish from Web Matrix not FTP.
- Publish with Git Continuous Deployment not FTP (current problem is inability to update locked assemblies.)
- Add the usuage of SQL Sync to update the Azure SQL Database.

__Requirements for this Walkthrough__

- Visual Studio
- Web Matrix 
- Internet Information Server
- SQL Server with Management Studio
- Your Own Windows Azure Account
- Mercurial
- Git

__Do a clean source drop of the Orchard code for development.__

- Create a directory for your Orchard CMS. (We'll call the directory __tsokh__.)
- Initialize a Git repository inside __tsokh__ and make your first commit.

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture.PNG)

- Then, do a source code drop from Orchard's Mercurial repository into __tsokh__.
- https://hg01.codeplex.com/orchard

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture1.PNG)

- Ensure we're on the default Mercurial Orchard branch.
- Make your second commit to Git with a useful message, eg 
- "Do a clean Orchard source code drop of hash 585c378b737737bdb37721b2a8059b866c3e03d8."

__Create a local SQL Server database for development.__

- Open SQL Server Management Studio.
- Create a new database on your local server.
- (We'll call the new database __tsokh_db__.)

__Connect the database to the codebase.__

*Open and run Orchard.Web in Visual Studio*

- Go to orchard > src > Orchard.Web > Orchard.Web.csproj > Right click > Open With > Visual Studio
- Run without debugging (Ctrl + Shift + F5.)
- At this point, we are at the Orchard Get Started page, and Orchard has created the App_Data folder, which you can see from the status of your source control.

*Configure the Get Started*

- Name your site, provide a username and password.
- Store your data in an existing SQL Server...
- data source=[SQLServerName];initial catalog=tsokh_db;integrated security=True;MultipleActiveResultSets=True;
- Run the Default recipe. 
- After it completes you will see the default Orchard homepage.
- Note: We do the initial set-up to a local DB instance, because we want to be able to install modules and themes locally, which Azure Web Sites makes non-trivial.

__Keep both the database and the codebase in Git version control throughout.__

- The codebase is already in Git. Now is a good time to add the database to Git also.
- Open SSMS,  export the database as a data-tier application, and save it in your tsokh Git repo.
- tsokh_db > Right Click > Tasks > Export Data-Tier Applcation > Next > Save to local disk > browse > ...\tsokh\databackups\tsokh_db.bacpac
- Commit and push after the export completes.

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture2.PNG)

__Checkpoint__

At this point we have done the following:

- Create and name a clean, local Orchard CMS website.
- Connect it to a clean local Orchard CMS database. 
- Export the database as a bacpac into the databackups directory of our local repo.
- Commit and push all changes. 
- This is good because we can now recreate our current code and DB configuration from Git whenever we want. It's worth adding and pushing a git tag to your current commit.

__Install, enable, and build the Bootstrap Theme.__

*Install and Enable the Bootstrap Theme*

- Go to the Orchard Dashboard.
- Go to Themes > Gallery > Search > "Bootstrap" > Install
- Wait
- Go to Themes > Installed > Bootstrap > Set Current
- Navigate to the Orchard homepage to test that the Bootstrap theme is enabled. 

*Build the Bootstrap theme*

- Return to Visual Studio and stop the running site. 
- Right click on the Themes solution folder (not the Themes project).
- Choose Add > Existing Project
- Browse to the Bootstrap.csproj and add it.
- Right click the newly added Bootstrap project in Visual Studio and build. It should work. Hooray!

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture4.PNG)

__Install, enable (debug, and test) the DesignerTools module. __

*Install and enable*

- Run Orchard.Web, login, and go to Dashboard > Modules > Gallery > Search.
- Search for Designer Tools and install. 
- Enable all three features (Shape Tracing, Url Alternates, Widget Alternates.)

*Debug*

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture5.PNG)

- If you receive a message that ClaySharp is missing, do not install ClaySharp.
- Instead, remove the reference.

*Test*

- Go to your Orchard homepage.
- There will be a little maximize icon at the bottom right. 
- Click it to view the Shape Tracer. 
- Unfortunately, it isn't working right now. We have filed a bug.

__Checkpoint__

Here is what we have accomplished since the last checkpoint:

- Install the Bootstrap theme.
- Install Designer Tools.
- Now lets deploy what we've done.

__Deploy our development database to a production Windows Azure SQL Database.__

- We've new data in the db, so backup the database again, just as we did above.
- Once that's done, right click the tsokh_db > Tasks > __Deploy database to SQL Azure__.
- (Note: this assumes setup of an SQL Database Server in Azure.)
- Connect to your Windows Azure SQL Database Server. E.g. my6wvevkhg.database.windows.net
- Use Next > Next > Next to deploy.
- The deployment might take two minutes, after which you'll see your database in the Azure management portal.

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture3.PNG)

__Deploy our development code to a product Windows Azure Web Site.__

*build Precompiled*

- Open a Developer Command Prompt as in step 3 [here](http://docs.orchardproject.net/Documentation/Building-and-deploying-Orchard-from-a-source-code-drop)
- Change the directory to the Orchard root folder. E.g. 
- cd "C:\Users\Shaun\Documents\GitHub\tsokh\orchard"
- Run build Precompiled
- This will take about two minutes.
- The result is a tsokh/orchard/build/Precompiled directory that we will publish.

*Debug the build, if necessary*

- When we ran build Precompiled the following warning occurred.

..

    "C:\Users\Shaun\Documents\GitHub\jungle\orchard\Orchard.proj" (Precompiled target) (1) ->
    "C:\Users\Shaun\Documents\GitHub\jungle\orchard\src\Orchard.sln" (Build target) (2:2) ->
    "C:\Users\Shaun\Documents\GitHub\jungle\orchard\src\Orchard.Web\Modules\SysCache\SysCache.csproj" (default target) (23:2) ->
 	(ResolveAssemblyReferences target) -> C:\Program Files (x86)\MSBuild\12.0\bin\Microsoft.Common.CurrentVersion.targets(1613,5): 
	warning MSB3247: Found conflicts between different versions of the same dependent assembly. 
	Please add the following binding redirects to the "runtime" node in your application configuration file: 
	
	<assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
	    <dependentAssembly>
			<assemblyIdentity name="NHibernate" culture="neutral" publicKeyToken="aa95f207798dfdb4" />
			<bindingRedirect oldVersion="0.0.0.0-3.3.1.4000" newVersion="3.3.1.4000" />
		</dependentAssembly>
	</assemblyBinding> 
	
	[C:\Users\Shaun\Documents\GitHub\jungle\orchard\src\Orchard.Web\Modules\SysCache\SysCache.csproj]

..

- So, do what it says: 
- Open Orchard in Visual Studio.
- Go to Modules\SysCache\SysCache.csproj
- Edit the web.config
- Add the following block as a child of the <configuration> element.
- Then save the SysCache project and run build Precompiled again. No more warnings!

..

	<runtime>
		<assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
			<dependentAssembly>
				<assemblyIdentity name="NHibernate" culture="neutral" publicKeyToken="aa95f207798dfdb4" />
				<bindingRedirect oldVersion="0.0.0.0-3.3.1.4000" newVersion="3.3.1.4000" />
			</dependentAssembly>
		</assemblyBinding> 
	</runtime>

..

- We now have a tickety-boo precompiled Orchard package to our specifications.

*Run the precompiled package in IIS (or WebMatrix) to test*

- Open IIS > Sites > Add Website
- Site Name: tsokh
- Application Pool: tsokh
- Physical Path: inetpub/tsokh
- Copy the contents of build/precomplied to this tsokh directory.
- Give IIS APPPOOL\tsokh write (or modify?) permissions x3 (Root, App_Data dir, Media dir, tsokh_db).
- (Note: If you were to browse to the website now, you would see the Get Started screen.)
- Copy the contents of the Orchard.Web/App_Data folder to the App_Data folder.
- Browse to the website from IIS.
- You should see the homepage of your Orchard website.

*Actually launch the codebase to Windows Azure Web Site*

- create a directory called _publishpacks at the same level as _databackups
- copy the testing IIS root directory into _publishpacks
- use ftp to publish the contents of _publishpacks/tsokh to a new Windows Azure Web Site.

__Set ourselves up to update the production database and codebase from development.__

- This will involve using SQL Sync from Windows Azure.
- This will also involve maybe using GitHub Continunous Deployment with Windows Azure.

# Build and deploy the Orchard source code to an Azure Website

> Coming soon.

# Build and deploy the Orchard source code to an Azure Cloud Service

[Orchard Source Code Repo]: https://orchard.codeplex.com/SourceControl/list/changesets
[Web Platform Installer]: http://www.microsoft.com/web/downloads/platform.aspx

[StorageAccountKeys]: ../Attachments/Deploying-Orchard-to-Windows-Azure/StorageAccountKeys.PNG
[NewCloudServiceDeployment]: ../Attachments/Deploying-Orchard-to-Windows-Azure/NewCloudServiceDeployment.PNG
[UploadAPackage]: ../Attachments/Deploying-Orchard-to-Windows-Azure/UploadAPackage.PNG
[ProgramsAndFeatures]: ../Attachments/Deploying-Orchard-to-Windows-Azure/ProgramsAndFeatures.PNG



> Last tested on 30 August 2013 from Windows 8 with Visual Studio 2012 and Azure SDK 2.0

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

__Prerequisites__

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