In Orchard, you can use rules to determine the visibility of both layers (see [Managing widgets](Managing-widgets) and elements within a Layout.

This article describes the rules that are available in a standard Orchard installation and how you can use them.

# Rules
Rules are implemented by the Orchard.Conditions core module, which provides a couple of standard rules that you can use:

- "authenticated" - Whether the current user is authenticated, or not
- "url" - To allow you to check whether the current request matches a certain URL, or not

These allow you to compose expressions that determine whether a given layer or element is visible, for example:

    (not authenticated and url("~/about")) or authenticated

If this expression was applied to a certain layer, the contents of the layer would be visible if:

- the user is not logged in *AND* the page is the "about" page, **or**
- the user is logged in

There are also other rules, implemented by other Orchard modules, that are described in detail below.

## Available Rules
There are several rules provided by the core Orchard modules, over and above the `authenticated` and `url` ones provided by the Orchard.Conditions module itself. In order to use a rule, the module it's provided by must be both installed and enabled, otherwise you may receive the below error message when attempting to use the rule:

> The rule is not valid: Expression is not a boolean value
The rules provided are:

Rule Syntax                            | Module               | Description
---------------------------------------| ---------------------|-----------------------
authenticated                          | Orchard.Conditions   | True if the user is logged in.
ContentType("&lt;Type&gt;")            | Orchard.Widgets      | True if the content type being view matches the content type specified e.g. `ContentType("Page")`
culturecode("&lt;Culture-Code&gt;"[])  | Orchard.Localization | Check to see if the culture of the content being rendered matches, for example `culturecode("en-gb")` will match the 'English - United Kingdom' locale
culturelcid(&lt;LocaleId&gt;[])        | Orchard.Localization | Check to see if the Locale ID of the content being rendered matches, for example `culturelcid(1033)` will match the 'English - United States' locale
cultureisrtl(true\|false)              | Orchard.Localization | Check to see if content is being rendered Right To Left, or not, for example `cultureisrtl(true)` will return false for non-RTL content
culturelang("&lt;Language&gt;"[])      | Orchard.Localization | Check the language that content is being rendered for, for example `culturelang('en')` will return true for English content
url("&lt;url&nbsp;path&gt;")           | Orchard.Conditions   | True if the current URL matches the specified path. If you add an asterisk (*) to the end of the path, all pages found in subfolders under that path will evaluate to true (for example, `url("~/home*")`).
role("&lt;role&gt;"[])                 | Orchard.Roles        | Allows you to test the current user to see if they're a member of a specific role, for example, `role("Moderator")` (Note: These are case-sensitive, 'Moderator' will be matched, 'moderator' won't)
not                                    | n/a                  | Logical NOT.
and                                    | n/a                  | Logical AND.
or                                     | n/a                  | Logical OR.

The presence of `[]` in the rule syntax denotes the fact tha this rule accepts multiple parameters. Examples of using these rules with multiple parameters are given below.

You can find modules that implement additional rules by [searching the gallery for the term 'rules'](http://gallery.orchardproject.net/Packages/Modules?q=rules).

### Rules that take multiple parameters

Several of the rules provided within core Orchard modules allow you to specify more than one parameter, both examples for each of the following rules are equally valid:

A rule to display content for either the en-gb or en-us culture code:

    culturecode("en-gb") or culturecode("en-us")
    culturecode("en-gb", "en-us")

A rule to display content for either the English, or French language:
    
    culturelang("en") or culturelang("fr")
    culturelang("en", "fr")
    
    culturelcid(1033) or culturelcid(2057)
    culturelcid(1033, 2057)

    roles("Moderator") or roles("Administrator")
    roles("Moderator", "Administrator")

## Places you can use rules
You can use rules to determine the visibility of things in at least these places:
- Layers - to determine when a layer is visible
- Layouts - to determine when individual elements within the layout are visible
- Pages - to determine when individual elements within the page are visible (this is effectively the same as for a Layout as from Orchard v.1.9 onwards, by default the Page content type has a LayoutPart instead of the BodyPart)

