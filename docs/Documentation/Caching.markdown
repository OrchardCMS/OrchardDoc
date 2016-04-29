Here are the different levels of caching that Orchard can provide:

## Application Settings Cache Using ICacheManager

This is used to store application settings and can be invalidated based on an extensible set of parameters.
By default you find expiration tokens based on time, file system and signals.
This is a very powerful caching API but has one drawback: it is not meant to provide farm invalidation,
because it has not been designed for this purpose and should not be used for data which is volatile.
Using for settings is totally fine, like for Content Types, module settings, etc. because those values
must not change on a production farm.
You never create a content type on production on a farm, or you have to restart all nodes one after the other.

Another reason to use this module (and why it has been done) is that it is not dependent on memory pressure,
so entries won't be removed if your system memory consumption grows, as opposed to the ASP.NET cache.
All the other cache providers are and must use memory pressure limits.

## 2nd Level NHibernate Caching

This is used to prevent recurring sql queries to the database.

Because the accessors are simple and well defined (checking a string in the dictionary),
it's safe to use it on a farm as long as the data is store in a central repository, like using Memcached.

A simple Memcached provider for it is tricky as you need to configure the provider (location, port),
and usually the settings are best placed in the database, but it's the chicken and egg issue and
you can't bootstrap it from a module. The only solution is then to have the configuration for it inside
the web.config, or maybe the settings.txt when it will be extensible.

## Output Caching Using Contrib.Cache

The goal of this module is to provide output caching like ASP.NET does, and to provide cache headers
management (max-age, Cache-Control, ETag). It was recently extended to be able to define the storage mechanism
dynamically for the cache data as distributed setups where more widely used.
This is why there are two distributed storage provider, one based on the Database and the other one based on Memcached. 

Here is the set of related modules:

* <http://orchardcache.codeplex.com/>
* <https://bitbucket.org/sebastienros/contrib.cache.database>
* <https://bitbucket.org/sebastienros/contrib.cache.memcached>

Not a single Orchard website should go into production without this module.
Not only does it improve responsiveness but also throughput, and finally it frees your CPU from unneeded cycles.
Using the Max Age setting you also enable IIS Kernel caching plus public proxy cache which makes your application
even faster. You can get thousands of requests per seconds with a very small server.

## Business Data Caching Using Orchard.Caching

Because of the limitations of the ICacheManager in terms of distributed caching, another set of modules was
necessary to cache business data which has to be shared across servers.
This module can set and get entries by a key only, and invalidate by name or time.
This is the only requirement for storage providers in this module, which allows its usage on farms. 

This is implemented in:

* <https://bitbucket.org/sebastienros/orchard.caching>
* <https://bitbucket.org/sebastienros/orchard.caching.memcached>

## Why Memcached ? 
Implementing Memcached providers by default is done for a specific reason, which is that Azure Caching Services
are binary compatible with it. So this implementation works by default on both custom Memcached servers
and also Azure services. 
