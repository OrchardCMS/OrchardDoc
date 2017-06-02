# Orchard conventions

## Definitions
* [Camel case](http://en.wikipedia.org/wiki/CamelCase) is a casing convention where the first letter is lower-case, words are not separated by any character but have their first letter capitalized. Example: `thisIsCamelCased`.
* [Pascal case](http://c2.com/cgi/wiki?PascalCase) is a casing convention where the first letter of each word is capitalized, and no separating character is included between words. Example: `ThisIsPascalCased`.

## Solution conventions

* For the extensions to be able to properly load when running the application by hitting `Ctrl+F5` in Visual Studio (without building the full solution), each extension's project needs to be a project dependency of `Orchard.Web` (right-click on `Orchard.Web` -> **Build Dependencies** -> **Project Dependencies**); otherwise NuGet packages for the extension's project won't be restored.
Please note that this is not the same as a project reference (but adding a project reference adds a project dependency too) and this information is stored in the solution file, not the project file.

## C# Coding Conventions

We are using the C# coding conventions described in this document: [C# Coding Guidelines](http://blogs.msdn.com/brada/articles/361363.aspx) with the following exceptions:

* Orchard supports C# 5, so you cannot use C# 6 (or above) language features (even if you can build it in Visual Studio), since Dynamic Compilation currently uses the pre-Roslyn compiler.
* Opening braces are on the same line as the statement that begins the block, with a space before the brace (this is consistent with what we do in JavaScript), a.k.a. K&R convention.
  If you have the [Rebracer Visual Studio extension](https://visualstudiogallery.msdn.microsoft.com/410e9b9f-65f3-4495-b68e-15567e543c58) installed it will automatically configure the editor to use the conventional brace styling.
* Private fields are prefixed with an underscore and camel-cased.
* Using directives appear before the namespace, not inside it.

## JavaScript Coding Conventions

* Namespaces are Pascal-cased.
* Class names are Pascal-cased.
* Plugin names are Camel-cased.
* Properties, fields, local variables are Camel-cased.
* Parameters are Camel-cased.
* Function names are Camel-cased unless they really are class constructors or namespaces (in other words, global/local functions and methods are Camel-cased).
* Private/internal/protected members are underscore-prefixed and Camel-cased.
* Constants are just static fields (apply same rules as for fields).
* JavaScript coding conventions follow C# conventions except for Pascal vs. Camel.
* `"` and `'` are interchangeable (strictly equivalent).
  XHTML attributes should be in double quotes and if code needs to be in there, it has to use single quotes:
  e.g.: `<input type="button" onclick="alert('Foo');"/>` (note: this kind of DOM-0 event creating is itself discouraged and is only shown here as an example).
  In pure JS code, use double quotes for string delimiters.
  When the string is one character and the intent is a character, use single quote for consistency with managed code.
* There is no need for `String.Empty`, just use `""`.
* Localizable strings need to be isolated into resource dictionaries until we figure out our client localization story, e.g. `alert(Foo.badArgument); ... Foo = {badArgument: "The argument was bad."};`
* Don't worry about string concatenation unless you have specific evidence that regular concatenation is significantly harming performance in your specific scenario.
* Use the [K&R](http://en.wikipedia.org/wiki/Indent_style) style for opening braces (put the opening brace on the opening line).
  This is because in JavaScript, the semicolon is optional, which can cause difficult to spot bugs (see [http://msmvps.com/blogs/luisabreu/archive/2009/08/26/the-semicolon-bug.aspx](http://msmvps.com/blogs/luisabreu/archive/2009/08/26/the-semicolon-bug.aspx) for an example).
