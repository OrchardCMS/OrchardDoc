> Draft topic Orchard supports several methods of deploying to the Windows Azure environment. Here are some of these methods:

1. Deploy the Orchard binary to an Azure Website using the Azure Website Gallery.
2. Deploy the Orchard binary to an Azure Website using FTP.
3. Build and deploy the Orchard source code to an Azure Website.
4. Build and deploy the Orchard source code to an Azure Cloud Service.

# Deploy the Orchard binary to an Azure Website using the Azure Website Gallery.

Coming soon.

# Deploy the Orchard binary to an Azure Website using FTP.

Coming soon.

# Build and deploy the Orchard source code to an Azure Website.

Coming soon.

# Build and deploy the Orchard source code to an Azure Cloud Service.

## Overview

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

## Download the Orchard source.
1. Go to https://orchard.codeplex.com/SourceControl/list/changesets
1. Choose the master branch
1. Click on the latest change set. 
1. Click download.
1. Unzip that file into a directory on your local hard drive.
1. We will call that directory __OrchardRocksDir__

## Install the appropriate Windows Azure SDK 2.0

1. Control Panel > Programs and Features > Search > Azure
1. If there are no listings in the search results, then you're good to go. 
1. If there are listings in the search results, uninstall them all to start with a clean slate.
1. Now, install the Windows Azure SDK for .NET (VS version#) - 2.0. 
1. Open the [Web Platform Installer](http://www.microsoft.com/web/downloads/platform.aspx)
1. Search for Azure SDK.
1. Choose Add, click Install, and Accept the terms.
1. You should now have only the Azure SDK version 2.0 installed.

__Aside: Why is this necessary?__

Either Orchard or Azure will complain if there is more than one SDK version installed or if the incorrect SDK is installed. 
Follow the steps just above to find out what version(s) you have installed.
Follow the steps just below to find out what is the appropriate SDK version.

1. Use a text editor to open C:\OrchardRocks\src\Orchard.Azure\Orchard.Azure.CloudService\Orchard.Azure.CloudService.ccproj
1. Find the CloudExtensionsDir element. 
1. Take note of the version of Windows Azure Tools that it specifies. 
1. As of Orchard 1.7 it is Windows Azure Tools 2.0 (see config sample).  

__Orchard.Azure.CloudService.ccproj Config Sample__

    <CloudExtensionsDir Condition=" '$(CloudExtensionsDir)' == '' ">
	     $(MSBuildExtensionsPath)\Microsoft\VisualStudio\v$(VisualStudioVersion)\Windows Azure Tools\2.0\	
	</CloudExtensionsDir>

## Build the Azure cloud service package.

1. SHIFT + Right Click on the OrchardRocksDir. 
1. Choose Copy as path. 
1. Open an elevated Visual Studio Developer Command Prompt.
1. Change directory to the OrhcardRocksDir e.g. >cd "C:\OrchardRocks"
1. Run >ClickToBuildAzurePackage
1. Wait approx 30 seconds, during which several command windows will open during the testing phase.
1. If the build stalls during the "tests" stage of the build, hit any key to continue, otherwise it will just wait forever.
1. If the build succeededs, OrchardRocksDir will have two new subfolders: artifacts and buildazure.
1. You might receive a "Build succeed" message with warnings. It's your call whether heed these warnings or not.

## Configure the Azure Cloud Service

TODO Explain the differene between the artifacts and the buildAzure directories.  
TODO Determine whether we need to open an Azure Storage account or not. What does it do? 

1. Create a Windows Azure Storage Account. 
1. Open the storage account in the Azure management portal. 
1. Choose Manage Access Keys (in the footer)
1. Copy your Storage Account Name and Primary Access Key.
1. Use a text editor to open C:\OrchardRocks\buildazure\Stage\ServiceConfiguration.cscfg 
1. Edit and then save the value attribute for DataConnectionString as follows: 

__DataConnectionString__

    <Setting 
	    name="DataConnectionString" 
	    value="DefaultEndpointsProtocol=https;AccountName=storage-account-name;AccountKey=primary-access-key" />

## Create a new SQL Azure database for Orchard

1. We called ours orchardRocks.

## Deploy to Azure

1. Open your cloud service in the Windows Azure Management Portal. 
1. In the quickstart area, choose "New production deployment."
1. Name the deployement anything (e.g. OrchardRocks_v1)
1. Browse for the Package: "C:\OrchardRocks\buildazure\Stage\Orchard.Azure.Web.cspkg"
1. Browse for the Configuration: "C:\OrchardRocks\buildazure\Stage\ServiceConfiguration.cscfg"
1. Deploy!
1. Once deployment is complete, browse to orchardrocks.cloudapp.net

## Some Warnings and Errors that Might Occur

__ClickToBuildAzurePackage: Success but with warnings__

> Build succeeded.

> C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v11.0\Windows Azure Tools\2.0\Microsoft.Win
> dowsAzure.targets(119,3): warning MSB4011: "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Microsoft
> .Common.targets" cannot be imported again. It was already imported at "C:\Program Files (x86)\MSBui
> ld\Microsoft\VisualStudio\v10.0\Windows Azure Tools\2.0\Microsoft.WindowsAzure.targets (117,3)". Th
> is is most likely a build authoring error. This subsequent import will be ignored. 
> [C:\OrchardRocks\AzurePackage.proj]

__ClickToBuildAzurePackage: Success but with warnings #2__

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

__ClickToBuildAzurePackage: Error due to inappropriate Windows Azure SDK version__

1. This happens when the wrong version of the SDK is installed. So:
1. Install the appropriate Windows Azure SDK.
1. In this particular case, Orchard wants version 2.0

> C:\OrchardRocks\src\Orchard.Azure\Orchard.Azure.CloudService\Orchard.Azure.Cl
> oudService.ccproj(59,3): error MSB4019: The imported project "C:\Program Files (x86)\MSBuild\Micros
> oft\VisualStudio\v11.0\Windows Azure Tools\2.0\Microsoft.WindowsAzure.targets" was not found. Confi
> rm that the path in the <Import> declaration is correct, and that the file exists on disk.
	
__After Deployment: Error due to inconsistent installation of Windows Azure SDK version

1. This happens when there are two versions of the Windows Azure SDK installed side by side. So, 
2. Uninstall the version of the SDK that you do not want. 
3. Intall the version of the SDK that you do want. 
4. In this particular case, we ran ClickToBuildAzurePackage targetting 2.0 but also referenced 2.1 somewhere.

> Could not load file or assembly 'Microsoft.WindowsAzure.ServiceRuntime, Version=2.1.0.0, 
> Culture=neutral, PublicKeyToken=31bf3856ad364e35' or one of its dependencies. 
> The system cannot find the file specified.

__Possible Fixes__

1. Open Orchard.Azure.sln in Visual Studio.
1. Unload the Orchard.Azure.Web.csproj
1. Edit the Orchard.Azure.Web.csproj
1. Delete any references that resemble the following assemblies.
1. Reload the Orchard.Azure.Web.csproj
1. Replace the references that you just deleted. 
1. References > Right Click > Add Reference
1. Seach Assemblies for "Azure"
1. Load the version 2.0 of the references that you just deleted (it will be 1.7 for Microsoft.WindowsAzure.StorageClient).
1. Repeat the process for Orchard.Azure.csproj.

__References to Delete__

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
    <Reference Include="Microsoft.WindowsAzure.Configuration, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>C:\Program Files\Microsoft SDKs\Windows Azure\.NET SDK\2012-10\ref\Microsoft.WindowsAzure.Configuration.dll</HintPath>
    </Reference>