> Draft topic This document is providing the steps in order to deploy and update a custom Orchard build to an Azure __Web Site__ and Azure __SQL Database__.

Overview
=====

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

Requirements for this Walkthrough
=====

- Visual Studio
- Web Matrix 
- Internet Information Server
- SQL Server with Management Studio
- Your Own Windows Azure Account
- Git

Let's do this...
=======

Do a Clean Source Code Drop
-----

- Create a directory for your Orchard CMS. (We'll call the directory __tsokh__.)
- Initialize a source control repository (e.g. git init) inside __tsokh__ and make your first commit.

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture.PNG)

- Then, do a source code drop from Orchard's Mercurial repository into __tsokh__.
- https://hg01.codeplex.com/orchard

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture1.PNG)

- Ensure we're on the default Mercurial Orchard branch.
- Make your second commit to your source control repo.

Create a Local Database
-----

- Open SQL Server Management Studio.
- Create a new database on your local server.
- (We'll call the new database __tsokh_db__.)

Run Orchard in Visual Studio
-----

- Go to orchard > src > Orchard.Web.csproj > Right click > Open With > Visual Studio
- Run without debugging (Ctrl + Shift + F5.)
- At this point, we are at the Orchard Get Started page, and Orchard has created the App_Data folder, which you can see from the status of your source control.


Configure the Get Started
-----

- Now complete the Get Started process.
- Point at the empty tsokh_db that we created. E.g:
- data source=FONTY;initial catalog=tsokh_db;integrated security=True;MultipleActiveResultSets=True;
- Run the Default recipe. 
- After it completes you will see the default Orchard homepage.
- Note: We do the initial set-up to a local DB instance, because we want to be able to install modules and themes locally, which Azure Web Sites makes non-trivial.

Backup the Database
-----

- Open SSMS and export the database as a data-tier application.
- tsokh_db > Right Click > Tasks > Export Data-Tier Applcation > ...
- Save the bacpac file in your tsokh version control directory.
- Commit and push.
- This step isn't strictly necessary, because we do not have any custom data in the db yet, and because the db schema is stored inside Orchard code-first.

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture2.PNG)

Checkpoint
----

At this point we have done the following:

- Create a clean, local Orchard CMS website.
- Point it at a clean local Orchard CMS database. 
- Export the database as a bacpac into the databackups directory of our local repo.
- Commit and push all changes. 

This is good because we can now recreate our current code and DB configuration whenever we want.

Install Helpful Developer Modules
-----

- Run Orchard and go to Dashboard > Modules > Gallery > Search.
- Search for Designer Tools and install. 
- Enable all three features (Shape Tracing, Url Alternates, Widget Alternates.)
- Test to ensure that Shape Tracer is working (it doesn't work for me right now, bummer, so I disabled it.)

---
- If you receive a message that ClaySharp is missing after intalling Designer Tools, install into the Orchard.DesignerTools project through through NuGet.
- Visual Studio > Tools > Library Package Manager > Manage NuGet Packages for Solution... > Online > Search > ClaySharp > ...
- After installing ClaySharp, rebuild the Orchard.DesignerTools project and refresh Orchard. The warning should be gone.

---

Install and Enable a Theme
-----

- Go to the Dashboard.
- Go to Themes > Gallery > Search > Bootstrap > Install > Wait > Themes > Bootstrap > Set Current. 
- Navigate to the homepage to test that Bootstrap theme is enabled. 
- Close the browser, and close Visual Studio, and stop debugging if cued.

Checkpoint
-----

Here is what we have accomplished since the last checkpoint:

- Install Designer Tools. 
- Install the Bootstrap theme.
- Put the database and source code into version control.
- Now lets publish to Azure.

Create a Package using build Precompiled
-----

- Open a Developer Command Prompt. 
- Change the directory to the Orchard root folder. E.g. 
- cd "C:\Users\Shaun\Documents\GitHub\tsokh\orchard"
- Run build Precompiled
- This will take about two minutes.
- The result is a tsokh/orchard/build/Precompiled directory that we will publish to a Windows Azure Web Site.

Deploy the Database to Windows Azure SQL Database
-----

- Backup the database again, just as we did above.
- Once that's done, open SSMS if you haven't already.
- Connect to your local DB server. 
- Right click on the tsokh_db database.
- Choose Tasks > Deploy database to SQL Azure.
- Connect to your Windows Azure SQL Database Server. E.g. 
- my6wvevkhg.database.windows.net
- Follow the prompts to deploy the database to Azure.
- The import might take two minutes, after which you'll see your database in the Azure management portal.

![](../Attachments/Deploying-Orchard-to-Windows-Azure-Web-Site-and-SQL-Database/Capture3.PNG)

Deploy the Orchard CMS Code to Your Local IIS (this is to test)
-----

- Open IIS > Sites > Add Website
- Site Name: tsokh
- Application Pool: tsokh
- Physical Path: inetpub/tsokh
- Copy the contents of build/precomplied to this dir.
- Give IIS APPPOOL/tsokh permissions x3 (App_Data dir, Media dir, target db).
- Copy the contents of the Orchard.Web App_Data folder to the App_Data folder.
- Browse to the website.

Prepare for Launch
-----

- Create backups of what we will publish BEFORE we publish it.
- for the database, delete current users first, then use tasks > export data-tier application
- for the website, copy and paste the entire contents of the local dev IIS root directory

Test Locally One Last Time
-----

- change the connection string of the local IIS website settings.txt to point to the Azure DB.
- browse to the IIS website locally > does it work as expected?

Launch
-----

- use ftp to publish the contents of the most recent version of the publishing-website subdirectory
- if necessary, use SSMS to deploy the most recent version of the db

Celebrate!
-----






