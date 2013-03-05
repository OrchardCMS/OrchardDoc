This section enumerates the dependencies used in the Orchard project, with a brief description of what Orchard makes use of. A copy of a dependencies is located in the "lib" directory of the source repository, along with their respective licenses.  You can also view the attributions for our library dependencies in the CREDITS.txt file at the root of the Orchard source tree.


## Akismet
This is the default spam protection service in Orchard.

## ANTLR v3
This is a language recognition tool, which provides a framework for constructing recognizers, interpreters, compilers, and translators from grammatical descriptions containing actions in a variety of target languages.

## ASP.NET MVC 4
ASP.NET MVC is used as the web programming model.

## Autofac 2 & Autofac contrib
Dependency Injection is used heavily internally, mainly for publishing and consuming services between the Ochard.Web host and the Orchard packages. 

## Castle Windsor 2.0
Orchard uses Castle Winder 2.0 for type proxy generation and logging support.

## Clay
The Clay library offers a flexible implementation of dynamic objects that is used in UI composition.

## CodeMirror
Client-side code colorization.

## DLR
The DLR can be optionally used to script certain aspects of Orchard (currently, widget layer rules).

## Eric Meyer's Reset CSS
This is used to even the CSS rendering playing field across browsers.

## Fam Fam Fam Silk Icons
The Orchard user interface uses Silk Icons, which is an icon set containing over 700 16-by-16 pixel icons in PNG format. 

## Fluent NHibernate
Orchard uses Fluent NHibernate, which lets you write object-relational mappings in strongly typed C# code.

## FluentPath
This library is a fluent wrapper around System.IO that we use in some tests.

## Html Agility Pack
Flexible HTML parsing and querying.

## Html5shim
Provides Html 5 helpers.

## jQuery & jQueryUI, jQuery ui.timepickr, jQuery utils, jQuery ScrollTo
We use jQuery to progressively improve the user experience in Orchard.

## Log4Net
Log4Net is a tool used in Orchard to help write log statements to a variety of output targets.

## Lucene.Net
Full-text search and indexation engine.

## Microsoft SQL Server Compact 4.0, SQL Server, SQL Server Express
Orchard uses SQL Compact by default for database access but can also use SQL Server and SQL Server Express.

## Moq
The moq library is used when object moqs are needed for writing unit tests.

## NHibernate & dependencies, FluentNHibernate, NHLambdaExtensions, LinqNHibernate
Orchard uses NHibernate, Fluent NHibernate and Linq To NHibernate for data access.

## NuGet
NuGet is used as the package manager (modules and themes come in the form of NuGet packages).

## NUnit
NUnit is used for writing unit tests.

## SharpZipLib
SharpZipLib is used for zipping/unzipping files. For example, the Orchard media manager module uses this library to unzip uploaded media files.

## SpecFlow
This BDD-style library is used in Orchard for integration tests.

## TESI Collections
Orchard uses the Tesi.collections library, which supports a SET collection that contains no duplicates.

## TinyMCE
TinyMCE is currently used for editing CMS pages content.

## WCat
WCat is a lightweight HTTP load generating tool used for performance testing.

## YUI
We use parts of YUI for easier CSS.
