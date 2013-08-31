> Draft topic Orchard supports several methods of deploying to the Windows Azure environment. Here are some of these methods:

* Deploy the Orchard binary to an Azure Website using the Azure Website Gallery.
* Deploy the Orchard binary to an Azure Website using FTP.
* Build and deploy the Orchard source code to an Azure Website.
* Build and deploy the Orchard source code to an Azure Cloud Service.

# Deploy the Orchard binary to an Azure Website using the Azure Website Gallery.

Coming soon.

# Deploy the Orchard binary to an Azure Website using FTP.

Coming soon.

# Build and deploy the Orchard source code to an Azure Website.

Coming soon.

# Build and deploy the Orchard source code to an Azure Cloud Service.

[Orchard Source Code Repo]: https://orchard.codeplex.com/SourceControl/list/changesets
[Web Platform Installer]: http://www.microsoft.com/web/downloads/platform.aspx



[StorageAccountKeys]: ../Attachments/Deploying-Orchard-to-Windows-Azure/StorageAccountKeys.PNG
[NewCloudServiceDeployment]: ../Attachments/Deploying-Orchard-to-Windows-Azure/NewCloudServiceDeployment.PNG
[UploadAPackage]: ../Attachments/Deploying-Orchard-to-Windows-Azure/UploadAPackage.PNG
[AzureSDKVersions]: ../Attachments/Deploying-Orchard-to-Windows-Azure/AzureSDKVersions.PNG



> Last tested on 30 August 2013 from Windows 8 with Visual Studio 2012 and Azure SDK 2.0

What follows is one method of deploying a source code drop of Orchard 1.7 to a new Azure Cloud Service.

## Overview

* Download the Orchard source
* Install the appropriate Windows Azure SDK version
* Update the csproj references to the correct SDK version
* Build an Azure cloud service package (.cspkg)
* Create an Azure Storage account
* Update the cloud service configuration file (.cscfg)
* Create an Azure cloud service
* Deploy to the Azure cloud service

## Prerequisites

* Microsoft SQL Azure account
* Visual Studio

## See Also

* [Setting up a source enlistment](http://docs.orchardproject.net/Documentation/Setting-up-a-source-enlistment)
* [How to Create and Deploy a Cloud Service](http://www.windowsazure.com/en-us/manage/services/cloud-services/how-to-create-and-deploy-a-cloud-service/): a general version of the same steps we outline.
* [Windows Azure Service Configuration Schema (.cscfg File)](http://msdn.microsoft.com/en-us/library/windowsazure/ee758710.aspx)
* [AsmSpy: A little tool to help fix assembly version conflicts](http://mikehadlow.blogspot.ca/2011/02/asmspy-little-tool-to-help-fix-assembly.html)

## Download the Orchard source

* Go to the [Orchard Source Code Repo][]
* Choose the master branch
* Click on the latest change set
* Click download
* Save the file to your hard drive
* Unzip it into __C:/OrchardRocks__ (or wherever)

## Install the appropriate Windows Azure SDK version

* Start > Control Panel > Programs and Features > Search > Azure

![][AzureSDKVersions]

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

__Aside: Why is this necessary?__

The Orchard.Azure.CloudService.ccproj has a CloudExtensionsDir element that targets Windows Azure Tools 2.0. 
As a result, the build process will fail unless we have the right version of the SDK installed.

---

    <CloudExtensionsDir Condition=" '$(CloudExtensionsDir)' == '' ">
	     $(MSBuildExtensionsPath)\Microsoft\VisualStudio\v$(VisualStudioVersion)\Windows Azure Tools\2.0\	
	</CloudExtensionsDir>

## BugFix: Update the csproj references to the correct SDK version

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

## Build an Azure cloud service package (.cspkg)

* Open C:/OrchardRocks and double click on ClickToBuildAzurePackage.cmd
* Wait approx one minute; the build will run; several command windows will open during testing.
* Sometimes the build stalls after tests. Continue by hitting any key.
* If the build succeededs, C:/OrchardRocks will have two new subfolders: artifacts and buildazure.
> TODO What is the difference between artifacts and buildazure?

## Create an Azure Storage account

* Login to the Windows Azure management portal. 
* Click New > Data Services > Storage > Quick Create
* Name your service orchardrocks (or whatever) and Create Storage Account
* Once Azure has created the account, open it in the Azure management portal. 
* Choose Manage Access Keys (in the footer)
* Copy your __Storage Account Name__ and __Primary Access Key__

![][StorageAccountKeys]

> TODO Determine whether we really need to open an Azure Storage account or not. What does it do? Is it optional?

## Update the cloud service configuration file (.cscfg),

* Use a text editor to open C:\OrchardRocks\buildazure\Stage\ServiceConfiguration.cscfg 
* Update the DataConnectionString with the following <Setting /> element.
* Be sure to use your own Storage Account Name and Primary Access Key
* Leave the Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString for now.

---

    <Setting 
	    name="DataConnectionString" 
	    value="DefaultEndpointsProtocol=https;AccountName=storage-account-name;AccountKey=primary-access-key" />

## Optional: Create a new SQL Azure database for Orchard

* This isn't strictly necessary. 
* For the sake of simplicity in this tutorial, use the built-in SQL Server CE for now.

## Create a Azure Cloud Service

* Login to the Windows Azure management portal. 
* Click New > Computer > Cloud Service > Quick Create
* Name your service orchardrocks (or whatever) and then click Create Cloud Service

## Deploy to the Azure cloud service

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

## Some Warnings and Errors that Might Occur

__ClickToBuildAzurePackage: ...cannot be imported again__

Why: Unknown.
Fix: Unknown.

> Build succeeded.

> C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v11.0\Windows Azure Tools\2.0\Microsoft.Win
> dowsAzure.targets(119,3): warning MSB4011: "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Microsoft
> .Common.targets" cannot be imported again. It was already imported at "C:\Program Files (x86)\MSBui
> ld\Microsoft\VisualStudio\v10.0\Windows Azure Tools\2.0\Microsoft.WindowsAzure.targets (117,3)". Th
> is is most likely a build authoring error. This subsequent import will be ignored. 
> [C:\OrchardRocks\AzurePackage.proj]

__ClickToBuildAzurePackage: Found conflicts between different versions of the same dependent assembly.__

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

__ClickToBuildAzurePackage: ...was not found__

Why: We have an earlier or later version of the Windows Azure SDK installed.
Fix: Ensure that Windows Azure SDK 2.0 is the only version of the SDK installed.

> C:\OrchardRocks\src\Orchard.Azure\Orchard.Azure.CloudService\Orchard.Azure.Cl
> oudService.ccproj(59,3): error MSB4019: The imported project "C:\Program Files (x86)\MSBuild\Micros
> oft\VisualStudio\v11.0\Windows Azure Tools\2.0\Microsoft.WindowsAzure.targets" was not found. Confi
> rm that the path in the <Import> declaration is correct, and that the file exists on disk.
	
__After Deployment: Could not load file or assembly...__

Why: Our Microsoft.WindowsAzure.* references are an earlier version, which is resolving to 2.1.0.0
Fix: Update the references to version 2.0

> Could not load file or assembly 'Microsoft.WindowsAzure.ServiceRuntime, Version=2.1.0.0, 
> Culture=neutral, PublicKeyToken=31bf3856ad364e35' or one of its dependencies. 
> The system cannot find the file specified.

__After Deployment: Could not load file or assembly...__

Why: We deleted the assembly accidentally.
Fix: Add the missing assembly to the Orchard.Azure.Web project. 

> Could not load file or assembly 'Microsoft.Web.Infrastructure, Version=1.0.0.0, Culture=neutral, 
> PublicKeyToken=31bf3856ad364e35' or one of its dependencies. The system cannot find the file specified.