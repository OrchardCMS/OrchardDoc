This document is providing the steps in order to do so.

If you just need to compile locally, and you want to use IIS on your dev machine instead of
the built-in development web server, all you need to do is to go into the properties of
the Orchard.Web project in Visual Studio, go to the Web tab and check "use local IIS Web Server"
instead of the default development server.

If instead what you need is a clean version of the application ready to run, follow the following steps:

1. Make sure that you have either the .NET SDK or Visual Studio installed
(in the latter case, make sure you are using a Visual Studio command prompt).
2. [Enlist in the source](http://orchardproject.net/docs/Setting-up-a-source-enlistment.ashx)
3. Open a Visual Studio command prompt or a .NET SDK command prompt at the location of your enlistment
and run **build "compile;package"**. This will build the application into a "build" subdirectory.
4. Deploy the contents of the \build\Stage directory into a clean IIS web site's root directory.
5. If you are running on a 64 bit system, go into the advanced setting of the application pool
for the application and make sure 32 bit applications are enabled (create a new app pool if you have to).
6. Create an App\_Data folder under the IIS application's root and make sure the user that
IIS is running under has write access to that directory. If you're not sure what that user is,
go to IIS Authentication for the application. If anonymous access is enabled, the user is the local IIS\_USRS.
Make sure the directory is empty.
7. Create a Media folder under the IIS application's root and give write access.
8. Browse to the application. You should see the setup screen at this point.

Note: if you are using IIS6, you need to configure the star mapping: <http://haacked.com/archive/2008/11/26/asp.net-mvc-on-iis-6-walkthrough.aspx>.
