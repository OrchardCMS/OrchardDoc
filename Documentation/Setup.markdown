

# Requirements and declaration of intents

## Goals

* Simple
* Localizable
* Web-based: unzip in a web app directory and browse
* Small number of decisions, none of which require knowledge that is out of reach of the typical user. It should be made clear why we're asking a question to make it easier to make a decision.
* Good defaults that are easily overridable by advanced users
* Adaptable to different usage profiles: hosters, site administrators, developers, theme builders, etc.
* Enables specialized "distributions" of the application (blog, commerce, etc.)
* Gracefully handling failure is an important scenario
* Works with WebPI or standalone
* Modules can take part in the install process
* Sample data can optionally be installed along with the application
* Scriptable
* Must work as a real wizard and enable the user to go back and change his mind
* Progress should be visible
* Distinguishes between initial setup and configuration

## Non-goals

* Update / upgrade of the application, themes and modules is not handled by this specification. It will be the object of a separate spec.

# Scenarios

## Hosted site with support for Orchard

A user goes to his hoster's control panel and chooses Orchard. With just one click, he was able to deploy the application. He can then navigate to it and provide an administrator password (the database setup step can be skipped as that choice is made once and for all by the hoster). The site is then ready to use.

> To enable this scenario, the setup model of the application must be scriptable so that hosters can provide one-click installs from common control panel applications.

## Hosted site without support for Orchard

A user downloads a zip file from the Orchard web site. He unpacks the archive and uploads the resulting directory to his web site using ftp. He navigates to the application and follows the setup wizard.

## Local install for core development purposes

A developer wants to create an extension for Orchard. He points TortoiseSVN to the CodePlex repository and gets enlisted. He starts the project in Visual Studio and works on the application. He then uploads a patch to CodePlex.

## Local install for module development

A developer downloads the latest version of the application (same as end users) and opens the project file that can be found at the root of the application in Visual Studio. He is able to use Visual Studio tooling to create a new area/module. Once his module is built and working, he can run a command-line tool to package his module into a zip file that he uploads to the Orchard module gallery.

## Local install for theme developement

A user wants to create his own theme for Orchard. He downloads the application (same as end users), installs it. Then, he creates a subdirectory under the themes folder, and with the help of existing themes and a few tools that are integrated into Orchard, he builds his own theme. He then zips it up and uploads it to the online gallery.

## Deployment from a local install to a hosted site

A user downloads and installs Orchard locally in order to evaluate it. Once he's found that he likes it and would like to use it on his public site, he just uploads it to his hosted account using ftp. The web site just works there as it was working locally.

## Dedicated server

A user runs WebPI on his dedicated web server. WebPI installs everything necessary (including IIS and ASP.NET) as well as the application. He can then go through the setup wizard to finish installation.

## Serial installs on dedicated server

A site administrator or integrator who routinely creates new Orchard sites installs the necessary pieces using WebPI. Once this is done, he can run a command-line version of setup to easily create new instances of Orchard on his server.

## Extension developer creates a specialized distribution

A developer creates a new e-commerce module for Orchard. He packages it and creates a special distribution of Orchard. He is able to add a few additional setup steps (visual or not) to gather some e-commerce specific settings and add sample data. Users can then download that special version and get an e-commerce application installed with minimal efforts. That special version can still be extended exactly like the base Orchard distribution. In particular, users can add other modules and build their own composite application from it.

## Handling failure

Install failures will necessarily happen, for a variety of reasons, some that we can anticipate, some that we can't. In those scenarios, it is very likely that the user would just give up or become frustrated at the difficulty of making it work.

We should do everything possible to:

* Anticipate possible failures and do capability checks **before** the failures happen. For example, check for writing rights on directories and provide clear instructions when such rights aren't properly configured.
* In case of unforeseen catastrophic failure, provide links to forums and support e-mails. Also try to restore the state of the application to a state where it can be salvaged. In other words, work with transactions, always have back buttons.

### Capability check and known error cases

Here's a tentative list of possible error cases:

* The setup information will have to persist its database setup information, and it obviously can't use the database for it. The first check setup should do is verify that app_data is writable: this will be necessary for many database configurations and in particular the default one, and it is a good place to store the setup completion file. If that directory is not writable, we should give an error message ("The app_data directory in the application is not writable. That will restrict your choice of database and may deteriorate the setup experience. If you have access to Windows file permissions on this server, please grant the NETWORK SERVICE account Write and Modify permissions on app_data. If you don't know what that means or are hosting the site externally, please contact your hoster or server administrator and ask him to do this for you. If this is still not possible, you can upload the following file into the app_data folder using ftp: \[link to database config file\]."). The link to the file should open a download dialog in the browser and should contain the chosen database configuration in YAML format (database provider name, and if relevant database login info).
* When using a database provider that stores data locally in app_data, we also need to check write access to app_data. If it fails when validating the database configuration, we should display the following error message: "The database provider that you chose requires the application to be able to write into the app_data directory of the application. If you have access to Windows file permissions on this server, please grant the NETWORK SERVICE account Write and Modify permissions on app_data. If you don't know what that means or are hosting the site externally, please contact your hoster or server administrator and ask him to do this for you. If this is still not possible, please choose another database provider such as SQL Server. This may require a different hosting plan."
* When providing database connection information, for some providers it will be necessary to provide credentials. Thos cerdentials will need to be checked right away. If authentication failed, we should surface the error message from the database.
* When checking database access, database access may fail because the database provider is not available. We should then recommend the user pick a different provider.
* Checking database access may fail in some configurations because the database server address was wrong or because the server timed out or responded in error. In those cases, display: "The database failed to respond in time. Please check that its address is correct and that the server is up and running."
* The credentials provided may not give rights to create tables in the database. We should test that we can create tables and display the following error message if that fails: "The database credentials you provided don't seem to allow the application to create the table structures that it will need. Please check with your hoster or database administrator that the credentials have table creation rights."
* Same thing for creating the database if not pointing to an existing database.

When one of these error cases happen, the setup wizard should stay on the same setup screen. This will enable the user to attempt to fix the problem and click next again.

### Logging

Setup should produce a log of the install operations, detailing the success or failure of each operation. When a failure occurs, the error message should include a link to the log file so that it can be downloaded and posted to support forums.

# Installation steps

Although the following steps could be arranged so that each one is on a separate screen, there are so few here that we will consolidate them into a single setup page with sections. Eventually, modules may be able to chime in and provide their own setup steps but the core ones will be on a single screen.

In the future case where more than one step is available, there will be buttons to go to the next step and go back to previous ones and the list of steps should be visible at all times, with a clear indication in the UI of what's already been done and what remains to be done.

> **Note:** eventually, we will have an admin screen to enable or disable modules. We will then have to decide on the set of modules that we ship with the core distribution, and among those, which ones we activate by default. We will also need to be able to run the setup for each module if it exists at the time it gets activated.

## Language

> **Note:** This step will not be developed until we add localization ability to the rest of the application.

The first installation step should be to ask the user for the language he wants to use during install. This step should only be shown if more than one language is available. The choices should be radio-buttons so that it is immediately obvious visually that you might find text in your own language and not just English.

"o Check this if you'd like us to use English throughout the rest of the installation process." The message should be localized in each of the available languages.

## Database engine

The choice of a database engine must be done early in the setup process for technical reasons but it is a choice that is only relevant to advanced users. For that reason, the default of using SQLite should require no further configuration from the user, and using an alternative to that choice must require additional manipulations.

We could display a text such as "Database configuration: Orchard uses a database to store the contents it manages. The default database engine that we chose for you should work just fine and if you don't have a specific reason to change it we recommend you proceed with that choice. This should be the last time you'll hear about such trivial technical details. Just skip this section and be on your merry way. If you do have a reason to use another database engine, please select it in the following list..."

There should be no other setting for SQLite, but other choices may require the user to enter an administrator login and password, and a user login and password (with password confirm) to create that the application will use to access data. It should be clear that the admin login/password will only be used to create the database and user, and that after that it's thrown away and never again used.

A checkbox enables the user to set-up with sample data: "Check this if you want us to install sample data. This is useful if you're installing the application to develop modules or themes and you want to work against existing data without having to create it yourself. It is also useful if you're installing the application for evaluation purposes. If you do not check this, we'll give you an empty site that you can populate yourself."

The choice of database can't obviously be stored in the database. It should be stored in a YAML file in the app_data folder instead.

## Administrator login

In most applications, the first person to run the application owns it and gets to set-up the administrator password. This works reasonably well although technically there is a risk that somebody might hijack the application, it is quite unlikely and even in that case, there is no data to be stolen yet. Nuking the site and starting over is a simple workaround. Some applications secure this further by giving a key file during setup that must be copied into the application's root directory, but that clearly gets in the way of simplicity to get rid of a very small risk.

This step will pre-fill the administrator's login with "admin" (which is shorter than "Administrator") and will ask for a preferably strong password. We should have a live strong password check here that indicates password strength as you type and we should provide an explanation:

"We are now going to ask you to provide a password for the administrator of the site. We recommend that you choose a password (or passphrase) that meets a number of complexity requirements that we'll check for you. Otherwise, it would be easy for an attacker to take control of your site and deface it. We're sorry to have to put you through this."

## Site name

"You can choose the name of the site that will appear in the title bar of the browser and in the header of all your pages in the following field."

## After setup is done

Once these steps are completed, the user is directed to the home page of the site. He is logged as the administrator without having to log in.

# Handling back

> This does not need to be implemented yet, and we'll recommend any additional setup steps are independent of one another.

Handling a back button in a setup process is not trivial, especially if there are irreversible or interdependent steps. For example, if the user goes back to the choice of database and changes it, it affects the steps after it. A simple solution to this problem is that some setup settings are marked so that any change of these settings resets all subsequent steps. Reset does not necessarily mean that we forget the values the users entered, but rather that it is "uncommitted". Another approach is to recommend that steps are independent of one another.

# Progress indication

> This does not need to be implemented until we have multiple installation steps.

Global progress in the setup process is made visible to the user by showing a list of setup steps and giving a visual indication of what has already been executed and where the user currently is.

Local progress of a long-running setup step is not made visible, but an indication that something is running should be given.

# Welcome screen

Even if the user declined the offer to create sample data, we will pre-populate the CMS home page with the following text (the home page is a page named "Home" that has the slug "/"):

"Welcome to Orchard!

Congratulations, you've successfully set-up your Orchard site.

This is the home page of your new site. We've taken the liberty to write here about a few things you could look at next in order to get familiar with the application. Once you feel confident you don't need this anymore, just click \[Edit\] to go into edit mode and replace this with whatever you want on your home page to make it your own.

One thing you could do (but you don't have to) is go into \[Manage Settings\] (follow the \[Admin\] link and then look for it under "Settings" in the menu on the left)  and check that everything is configured the way you want.

You probably want to make the site your own. One of the ways you can do that is by clicking \[Manage Themes\] in the admin menu. A theme is a packaged look and feel that affects the whole site. We have installed a few themes already, but you'll also be able to browse through an online gallery of themes created by other users of Orchard.

Next, you can start playing with the content types that we installed. For example, go ahead and click \[Add New Page\] in the admin menu and create an "about" page\. Then, add it to the navigation menu by going to \[Manage Navigation\]\. You can also click \[Add New Blog\] and start posting by clicking \[Add New Post\].

Finally, Orchard has been designed to be extended. It comes with a few built-in modules such as pages and blogs but you can install new ones by going to \[Manage Themes\] and clicking \[Install a new Theme\]\. Like for themes, modules are created by other users of Orchard just like you so if you feel up to it, please \[consider participating\]\."

# WebPI steps

WebPI's main value is to make sure the application's most basic requirements are satisfied before it can take over and start its own consistent setup experience. There is little value in having WebPI replicate what the application's setup process already implements. Not doing so reduces duplication and avoids synchronization issues between the WebPI-provided setup data and the web-setup-provided data.

The database engines will be declared as optional dependencies of Orchard. USers will have to take care of installing the database engine that they want to use.

The WebPI install should include making sure the write permissions that are necessary for optimal use of Orchard are in place.

# Release process and format

The setup package should be the zipped contents of the web project, so that unzipping it into an IIS web application directory puts the application in a running state.

The build process for this package should be automated and should run on the continuous integration server. It soutput should be the zip file and the WebPI manifest.

Versioning should be integrated into the generated file names: Orchard\.\[major\]\.\[minor\]\.\[build\]\.zip. The major and minor versions are manually incremented, whereas the build number comes from the changeset number.

# When does setup run?

If no database has been set-up yet, navigating to any page of the application redirects to the first step of setup.

Until the final step of setup has been reached and executed, navigating to any page of the application redirects to the latest step of setup that has not been completed before.

If the browser is closed for whatever reason, navigating back to the application redirects to the latest step of setup that wasn't completed before.

Once the setup process has been completed, the setup controller should give 404 errors on all operations.

# Sample data

Sample data should be provided by each module. This means that each module will be able to chime into the setup process and create and populate data tables. Among the modules that will provide sample data out of the box, we will have blog, pages and some associated comments (validated, spam and unvalidated) as well as some images in the media folder.

The page sample data will consist of the home page (even if an empty site was chosen) and an about page. The about page will have the following text:
"About the Orchard Project

Orchard is a free, open source, community-focused project aimed at delivering applications and reusable components on the ASP.NET platform.

More information about Orchard can be found here: http://orchardproject.net/"

The blog sample data will consist in tutorial posts that we will build. There should be one post about customizing settings, one about writing pages, one about writing and managing blog posts, one about moderating comments, one about building a theme.

Sample comments can be short and simple "Amazing" kinds of comments.

# Initial features set

Initially, we'll focus on implementing the features necessary for the following scenarios:

* hosted site without support from the hoster
* local install for development or theme building purposes
* deploy from local install to host
* dedicated server
