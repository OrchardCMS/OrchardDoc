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
1. Once deployment is complete, browse to orchardrocks.cloudapp.net