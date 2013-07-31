> Draft topic This document is providing the steps in order to deploy and update a custom Orchard build to an Azure __Web Site__ and Azure __SQL Database__.

# Overview

This workflow is a work in progress. If you see anything that doesn't look quite right, please let us know.

In this walkthough we are going to deploy Orchard to Azure as follows:

1. Do a clean source drop of the Orchard code for development.
2. Create a local SQL Server database for development.
3. Connect the database to the codebase.
4. Keep both the database and the codebase in Git version control throughout.
5. Install and enable the Bootstrap theme.
6. Install and enable the DesignerTools module. 
7. Deploy our development database to a production Windows Azure SQL Database. 
8. Deploy our development code to a product Windows Azure Web Site. 
9. Set ourselves up to update the production database and codebase from development.
0. Solve and document bugs as they arise.

# Requirements for this Walkthrough


- Visual Studio
- Web Matrix 
- Internet Information Server
- SQL Server with Management Studio
- Your Own Windows Azure Account
- Mercurial
- Git

# Let's do this...


## Do a clean source drop of the Orchard code for development.

- Create a directory for your Orchard CMS. (We'll call the directory __tsokh__.)
- Initialize a Git repository inside __tsokh__ and make your first commit.

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture.PNG)

- Then, do a source code drop from Orchard's Mercurial repository into __tsokh__.
- https://hg01.codeplex.com/orchard

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture1.PNG)

- Ensure we're on the default Mercurial Orchard branch.
- Make your second commit to Git with a useful message, eg 
- "Do a clean Orchard source code drop of hash 585c378b737737bdb37721b2a8059b866c3e03d8."

## Create a local SQL Server database for development.

- Open SQL Server Management Studio.
- Create a new database on your local server.
- (We'll call the new database __tsokh_db__.)

## Connect the database to the codebase

#### Open and run Orchard.Web in Visual Studio

- Go to orchard > src > Orchard.Web > Orchard.Web.csproj > Right click > Open With > Visual Studio
- Run without debugging (Ctrl + Shift + F5.)
- At this point, we are at the Orchard Get Started page, and Orchard has created the App_Data folder, which you can see from the status of your source control.

#### Configure the Get Started

- Name your site, provide a username and password.
- Store your data in an existing SQL Server...
- data source=[SQLServerName];initial catalog=tsokh_db;integrated security=True;MultipleActiveResultSets=True;
- Run the Default recipe. 
- After it completes you will see the default Orchard homepage.
- Note: We do the initial set-up to a local DB instance, because we want to be able to install modules and themes locally, which Azure Web Sites makes non-trivial.

## Keep both the database and the codebase in Git version control throughout.

- The codebase is already in Git. Now is a good time to add the database to Git also.
- Open SSMS,  export the database as a data-tier application, and save it in your tsokh Git repo.
- tsokh_db > Right Click > Tasks > Export Data-Tier Applcation > Next > Save to local disk > browse > ...\tsokh\databackups\tsokh_db.bacpac
- Commit and push after the export completes.

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture2.PNG)

## Checkpoint

At this point we have done the following:

- Create and name a clean, local Orchard CMS website.
- Connect it to a clean local Orchard CMS database. 
- Export the database as a bacpac into the databackups directory of our local repo.
- Commit and push all changes. 
- This is good because we can now recreate our current code and DB configuration from Git whenever we want. It's worth adding and pushing a git tag to your current commit.

## Install, Enable, and build the Bootstrap Theme

##### Install and Enable the Bootstrap Theme

- Go to the Orchard Dashboard.
- Go to Themes > Gallery > Search > "Bootstrap" > Install
- Wait
- Go to Themes > Installed > Bootstrap > Set Current
- Navigate to the Orchard homepage to test that the Bootstrap theme is enabled. 

##### Build the Bootstrap theme

- Return to Visual Studio and stop the running site. 
- Right click on the Themes solution folder (not the Themes project).
- Choose Add > Existing Project
- Browse to the Bootstrap.csproj and add it.
- Right click the newly added Bootstrap project in Visual Studio and build. It should work. Hooray!

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture4.PNG)

## Install, enable (debug, and test) the DesignerTools module. 

##### Install and enable

- Run Orchard.Web, login, and go to Dashboard > Modules > Gallery > Search.
- Search for Designer Tools and install. 
- Enable all three features (Shape Tracing, Url Alternates, Widget Alternates.)

##### Debug

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture5.PNG)

- If you receive a message that ClaySharp is missing, 
use [NuGet](https://docs.nuget.org/docs/start-here/Using-the-Package-Manager-Console) to install it into the Orchard.DesignerTools project.
- Visual Studio > Tools > Package Manager Console
- Run Install-Package ClaySharp -ProjectName Orchard.DesignerTools
- Build Orchard.DesignerTools.
- Refresh Orchard in the browser. 
- The scary pink message should be gone. Hooray!

##### Test

- Go to your Orchard homepage.
- There will be a little maximize icon at the bottom right. 
- Click it to view the Shape Tracer. 
- Unfortunately, it isn't working right now. We have filed a bug.

## Checkpoint

Here is what we have accomplished since the last checkpoint:

- Install the Bootstrap theme.
- Install Designer Tools.
- Now lets deploy what we've done.

## Deploy our development database to a production Windows Azure SQL Database. 

- We've new data in the db, so backup the database again, just as we did above.
- Once that's done, right click the tsokh_db > Tasks > __Deploy database to SQL Azure__.
- (Note: this assumes setup of an SQL Database Server in Azure.)
- Connect to your Windows Azure SQL Database Server. E.g. my6wvevkhg.database.windows.net
- Use Next > Next > Next to deploy.
- The deployment might take two minutes, after which you'll see your database in the Azure management portal.

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture3.PNG)

## Deploy our development code to a product Windows Azure Web Site. 

##### build Precompiled

- Open a Developer Command Prompt as in step 3 [here](http://docs.orchardproject.net/Documentation/Building-and-deploying-Orchard-from-a-source-code-drop)
- Change the directory to the Orchard root folder. E.g. 
- cd "C:\Users\Shaun\Documents\GitHub\tsokh\orchard"
- Run build Precompiled
- This will take about two minutes.
- The result is a tsokh/orchard/build/Precompiled directory that we will publish.

##### Debug if necessary

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

##### Run in IIS (or WebMatrix) to test.

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

##### Actually launch the codebase to Windows Azure.

- create a directory called _publishpacks at the same level as _databackups
- copy the testing IIS root directory into _publishpacks
- use ftp to publish the contents of _publishpacks/tsokh to a new Windows Azure Web Site.

Celebrate!
-----






