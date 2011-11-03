
This topic discusses various techniques for tuning a server environment to run Orchard efficiently. The optimal configuration depends on the type of site you're running and on usage patterns, so site administrators should pick from this list what applies best to their particular scenario. As always, improving performance should involve measuring and analyzing performance data so that changes you propose are demonstrably beneficial.


# Trust Level

Orchard is configured out of the box to run in Medium trust. This was accomplished using techniques that sometimes affect performance. In particular, there are cases that result in exceptions being thrown under normal application operation.

For those reasons, if you can run Orchard under Full trust, you are almost certain to get a performance boost out of it. You can switch to full trust by editing the _Orchard.Web/web.config_ file and making the following change:

    
    <trust level="Full" originUrl="" />


# Debug/Release

On your production server, there is no reason to run in debug mode. Make sure that the application you deployed was compiled in release mode and that the _web.config_ file in _Orchard.Web_ specifies release mode:

    
    <compilation debug="false" targetFramework="4.0"
      batch="true" numRecompilesBeforeAppRestart="250">


# Shared Versus Dedicated Versus Cloud Hosting

## Shared Hosting

Shared hosting environments usually consist of web farms with load-balancing. The way this is implemented varies greatly between hosting companies and it is usually difficult for customers to get information on the specific configuration being used. How well these configurations perform depends on the load on hosted applications and on the architecture of the application itself.

Shared hosting is a nice solution for Orchard users on a budget, but there can be tradeoffs. There is a natural contention between the customer who wants his or her site to be immediately available and to run as fast as possible, and the hosting company that wants to support as many sites as possible on a single computer. In order improve site density, hosting companies can be very aggressive about app domain recycling, causing sites to shut down often if they are not accessed frequently or if they consume too much memory.

There are mitigations for these situations, such as using a pinging service or a module that accesses the site on a fixed interval to prevent the app domain from shutting down due to a timeout. A mitigation like this might seem like a good idea, but ultimately it ruins the site density objective and penalizes everyone.

Another mitigation is to improve the perceived startup time of the application so that a shutdown ceases to be a significant problem. The `Orchard.Warmup` module (new in Orchard 1.1) is a good way to make the most commonly accessed pages of your site immediately accessible even while the app domain is restarting.

Hosting companies can optimize for Orchard by setting up machine affinity so that a given instance always runs on the same server. This can in turn enable the local file system to be used rather than a network appliance. This can make a real difference, because Orchard can make a heavy use of the file system, such as when performing dynamic compilation or when using SQL Server Compact databases.

## Dedicated Hosting

A dedicated hosting environment is typically more expensive than a shared hosting account, but it might be worth the investment if your business depends on your application responding immediately to any request. A dedicated computer or a dedicated virtual machine offers the advantage of being configurable in exactly the way you want. You get guaranteed processing and bandwidth instead of sharing it with a varying load on other applications running on the same computer, and you get the opportunity to fine-tune all the parameters for the application.

## Cloud Hosting

Cloud hosting such as Microsoft Azure offers most of the advantages of dedicated hosting plus the ability to scale to increased loads with the flip of a switch. If you are building a business that is expected to grow considerably, this might be the most secure way of ensuring the scalability that you need.

# SQL Server Compact Versus SQL Server

An Orchard instance can either run on SQL Server Compact or on full versions of SQL Server or SQL Server Express. SQL Server Compact is an embedded version of SQL Server that has the advantage of being deployable by simply copying its DLLs and database files.

While SQL Server Compact is extremely lightweight and easy to use and deploy, full versions of SQL Server offer the guaranteed performance that you might need on your site. It might therefore be worth the cost of investing in a hosting solution that gives you access to a full edition of SQL Server.

# File System

The file system itself can be a drag on application performance. Possible bottlenecks can include a fragmented file system or a congested network connection to a NAS. Checking the speed of the file system and then optimizing it can be a way to get better performance.

# Memory

The more memory is available on a server, the better it will perform. If you can afford it, increasing memory might be among the most efficient ways of improving performance (assuming it's properly configured). Increasing processing power is more expensive and often has a lower return on investment.

# App Pool Recycling

If you have access to IIS settings and if your site has few hits over extended periods of time, consider increasing the default value for app pool recycling. This can be done by going into IIS Manager, going to **Application Pools**, selecting the app pool for your application, and clicking **Recycling**:

![](../Attachments/Optimizing-Performance-of-Orchard-with-Shared-Hosting/AppPoolRecycle.PNG)

Removing the timeout is generally a good idea if it is replaced by a limit on memory usage; recycling at an arbitrary interval has little benefit, whereas recycling if the application uses all available memory is a good practice.

# Multi-Tenancy

Orchard has an optional module called **Multi Tenancy** that enables more than one site to exist on the same Orchard instance. The data for the sites is separated, and for all practical purposes they are distinct sites. There are a few limitations on what each tenant can do, such as installing new modules and themes.

The advantage of a multi-tenant installation over multiple instances of Orchard is that there is only one app domain, which hosting companies favor because it improves site density considerably. It also has advantages for each of the multi-tenant sites, because a hit on any of the tenants keeps the app domain alive. Therefore, even sites that receive very few hits will remain responsive if they share the app domain with enough other sites.

This results in the seemingly paradoxical notion that more sites on a single app domain might perform better in some cases than a single site per app domain. In shared hosting scenarios in particular, this configuration is optimal if it is an option.

# Installed Modules

For both security and performance reasons, it's a good idea to keep the number of modules installed on your production server as low as compatible with your application. There's a cost to anything you add to the system, in particular in terms of dynamic compilation and loading additional assemblies.

If you are not using a module, it should be removed. Some modules, such as the gallery, will be useful on your development server but probably not on your production server and should be removed.

Going even further, some modules are a convenience that you might want to do without. For example, many modules do nothing more than render a pre-formatted bit of HTML to include some external script or embedded object. If so, it's a good to determine whether you couldn't achieve the same thing with an HTML widget or the body of content items by going into the HTML source and directly injecting HTML there.

# Depth of the Views Folders

The contents of _Views_ folders are dynamically compiled and there is some overhead associated with each subfolder. This, combined with the multiplication of modules in a typical Orchard instance, means that it can have an impact on startup performance to flatten _Views_ directories. Orchard gives a choice to module and theme authors to use subfolders or equivalent dotted names for templates (see [Accessing and Rendering Shapes](Accessing-and-rendering-shapes)). It is generally preferable to use the dotted notation.

# IPv6, Development Servers, and Modern Browsers

If you are in an IPv6 environment and using a local development server such as the Visual Studio Development Server or IIS Express in WebMatrix, some browsers may have trouble handling more than one request at once. This results in slower performance because resources are fetched one after the other. If you are testing locally and see images appearing one by one, you are probably hitting this bug.

An easy workaround is to use `127.0.0.1` instead of `localhost` as the domain for the development server. Another is to disable IPv6 in the browser, although this change can have side effects. A third workaround is to make sure there's an explicit entry for `localhost` in your HOSTS file.

# Future Perspectives

The Orchard team is planning more work for performance in the future. This might include versions of the core assemblies and main dependencies that can be put into the GAC as well as NGen optimizations.
