> Draft topic This document is providing the steps in order to deploy to an Azure __Web Site__ such that we can add custom themes, add custom modules, use an Azure SQL Database, and keep both the DB and the code in source control.

Requirements
=====

- Visual Studio (Express or better)
- SQL Server (Express or better)
- Windows Azure account

Let's do this...
=======

Clean Source Code Drop
-----

- Do a squeaky clean source-code-drop from Orchard's Mercurial repository (https://hg01.codeplex.com/orchard)
- Ensure we're on the default branch. 

Run in Visual Studio
-----

- Orchard.Web.csproj > Right click > Open With > Visual Studio 2013 Preview
- Run without debugging (Ctrl + Shift + F5)
- At this point, we are at the Orchard Get Started page.
- Orchard has created the App_Data folder.

Configure the Get Started
-----

- Point at an empty local development DB. 
- Run the Default recipe. 
- We do initial set-up to a local DB, because we want to be able to install modules and themes locally.

Install and Enable a Theme
-----

- Login and go to the Dashboard.
- Go to Themes > Gallery > Search > Bootstrap > Install > Wait > Themes > Bootstrap > Set Current. 
- Navigate to the homepage to test that Bootstrap theme is enabled. 
- Close the browser, and close Visual Studio, and stop debugging if cued.

Create a Package using build Precompiled
-----

- Open a Developer Command Prompt
- Run build Precompiled
- The creates a /build/Precompiled directory that we will publish to a Windows Azure Web Site.

Backup the Local DB
-----

- Open SSMS. 
- Connect to your local DB server.
- Find the local DB.
- Right Click > Tasks > Export Data-Tier Application

Publish the database to Windows Azure
-----

- Open SSMS. 
- Connect to your local DB server. 
- Find the local DB.
- Right Click > Tasks > Deploy database to SQL Azure 

Deploy locally to IIS (ie Test)
-----

- Open IIS > Sites > Add Website
- Site Name: [somename]
- Application Pool: [somename]
- Physical Path: inetpub/[somename]
- Copy the contents of build/precomplied to this dir.
- Give IIS APPPOOL/[SOMENAME] permissions x3 (App_Data dir, Media dir, target db)
- Browse to the website.
- Download and install the desired themes and modules (or use a recipe).

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






