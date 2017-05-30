
In the Orchard CMS, modules and themes are important tools for extending and customizing an application. Every module and theme is required to have a manifest, which is a text file named `Module.txt` or `Theme.txt` that resides in the root folder of the associated module or theme. A manifest stores metadata that Orchard uses to describe modules and themes to the system, such as name, version, description, author, and tags.

This topic is a reference for manifest files. If you create a custom module or theme, or if you write code that accesses modules or themes, you must understand the metadata fields in a manifest. The data in a manifest is structured into name-value pairs in the form `Field Name: Value`. 

The following sections describe the available fields in a manifest for themes and for modules. Because a theme is a type of module, many of the same metadata fields occur in both theme manifests and module manifests.

## Module manifest fields

The manifest for a module should be called `Module.txt` and should be located in the root of the project. 

A module's manifest is made up of an overall description of the package itself and then an optional repeating section describing each of the individual features. 

The module can be comprised of a default single feature or a group of individually defined features. This allows module developers to specify separate areas of the module and allow users to enable them on a per-feature basis.

### Main `Module.txt` fields

Some of the fields may be overridden if a module defines multiple features. These are detailed in the [`Features:` sub-section fields](manifest-files#ModuletxtFeaturessubsectionfields) table below.

Field Name         | Description
------------------ | ---------------------------------------------------
**Name**           | <p>*Optional*</p><p>Provides a human-readable name for a module.</p><p>If a name is provided, it will be used as the module's display name in the [Orchard Gallery](http://gallery.orchardproject.net/) and in the Orchard UI.</p><p>If a name is not provided in the manifest, the ID is used instead.</p><p>Note: The ID of a module is generated internally from the name of the module's folder and is used for programmatic references to the module. For example, if the module is located in `/Modules/Bing.Maps/` its ID would be `Bing.Maps`. To make things more friendly to the end user module developers should provide a name in the manifest such as `Bing Mapping Component` or even `Bing Maps` (notice that the "." is removed).</p>
**Path**           | <p>*Optional*</p><p>Provides a name that is used to build more readable URLs for routing purposes compared to URLs that are based on module names or ID values.</p><p>If a path is not provided, Orchard builds URLs based on the module's name (if one is provided) or on the ID. However, module names often have spaces, and ID values often have "." characters, neither of which result in very readable URLs.</p><p>For example, for the `Orchard.ArchiveLater` module, its name is `Archive Later`, and its ID is `Archive.Later`. In the manifest, a path is provided with the value of `ArchiveLater`, which enables Orchard to build a more readable URL than the module name or the ID would.</p><p>Note: If specified, the Path must be a valid URL segment. If you're unsure what this means the best bet is to stick with letters and numbers with no spaces.</p>
**AntiForgery**    | <p>*Required*</p><p>Possible values are `enabled` or `disabled`.</p><p>A value that indicates whether request validation is enabled for a module.</p>
**Author**         | <p>*Optional*</p><p>The developer of the module.</p><p>This can be an organization, individual, or a list of individuals.</p>
**Website**        | <p>*Optional*</p><p>The URL for the website of the module developer.</p>
**Version**        | <p>*Required*</p><p>The version number of the module in [SemVer](http://semver.org/) format.</p><p>The version information is displayed in the [Orchard Gallery](http://gallery.orchardproject.net/) and in the Orchard UI.</p><p>It is also used to determine whether an update is available.</p>
**OrchardVersion** | <p>*Required*</p><p>The minimum version of Orchard CMS that the module has been tested against.</p>
**Description**    | <p>*Optional*</p><p>A brief summary of what the module does.</p><p>The description is used in the [Orchard Gallery](http://gallery.orchardproject.net/) and in the Orchard UI.</p><p>Will be overridden by the `FeatureDescription` field when present.</p>
**Dependencies**   | <p>*Required if the feature has dependencies. If all features are defined in the `Features:` subsection this field is not required.*</p><p>A comma-separated list of the application `Id` values of all features that the specified feature depends on.</p><p>Note: dependencies are **case sensitive**.</p>
**Category**       | <p>*Optional*</p><p>Defaults to **uncategorized**.</p><p>This field groups the module together in the Modules page of the Orchard admin dashboard. Related modules which have the same category are displayed together. The category field can be assigned one category. To aid in discoverability, module developers should review the Modules page of the Orchard admin dashboard and choose a related category from existing categories. If a relevant category doesn't exist modules can freely define a new category within this field.</p>
**Tags**           | <p>*Optional*</p><p>A comma-separated lists of tags for the module.</p><p>The tags field allow users to find related modules in the [Orchard Gallery](http://gallery.orchardproject.net/).</p>
**FeatureDescription** | <p>*Optional*</p><p>A description of the default feature in a module.</p><p>If the module has only a single feature, use either the `FeatureDescription` or `Description` field to describe it. The `FeatureDescription` will override the `Description` field.</p><p>If the module has multiple features and one of the features is the default, use the `FeatureDescription` field to describe the default feature. The `FeatureDescription` will override the `Description` field.</p><p>If the module has multiple features and doesn't define a default feature then leave this field out and follow the instructions in its description down in the `Features:` table below.</p>
**Features**       | <p>*Optional*</p><p>A special repeating section of the manifest which allows a module to define multiple features within a module.</p><p>Supports several sub-fields as described by the table in the next section.</p><p>The features section should be placed at the end of the manifest.</p>

### Module.txt **Features:** sub-section fields

If a module provides multiple individual features within a single module then the repeating `Features:` sub-section should be used. It allows module developers to specify separate manifest fields for each individual feature. These individual features can then be enabled and disabled separately by end users.

The `Features:` field doesn't have any assigned value. It is a placemarker field that indicates the beginning of a repeating list of features.

Examples of the formatting to be used for this part of the manifest can be found in the next section.

Field Name             | Description
---------------------- | ---------------------------------------------------
**FeatureId**         | <p>*Required*</p><p>Because the feature is already contained within the module ID module developers need to supply a unique ID for Orchard to use internally as a reference.</p><p>The `FeatureId` should take the form of the name of the feature with no punctuation and full stops where spaces would be.</p><p>This is a special field. The line must begin with either a `single tab character` **or** `four spaces`. Immediately following this the `Featured Id` itself (the **value** not the field name) must be entered, followed by a colon `:`. This serve as an indented header for the specification of the feature.</p><p>**Important:** All fields below must begin with either `two tab characters` **or** `eight spaces`. This indentation process resets back to the left margin and the process repeats with the next feature. Examples of this are shown in the next section.</p>
**Name**               | <p>*Optional*</p><p>Provides a human-readable name for the feature.</p><p>If a name is provided, it will be used as the features display name in the Modules section of the Orchard admin dashboard.</p><p>If a name is not provided in the manifest, the `FeatureId` is used instead.</p>
**Description**        | <p>*Optional*</p><p>A description of the feature. If this is the default feature of the module use the `FeatureDescription` instead.</p>
**FeatureDescription** | <p>*Optional*</p><p>Either the main manifest section should define this field or a single feature in the features sub-section should assign this field.</p><p>It should contain a description of the individual feature.</p>
**Category**           | <p>*Optional*</p><p>Defaults to **uncategorized**.</p><p>This field groups the feature together in the Modules page of the Orchard admin dashboard. Related features which have the same category are displayed together.</p><p>Each individual feature can be assigned one category, however the different features included in the module may have each have their own category to move that feature into the most relevant area of the admin dashboard.</p><p>To aid in discoverability, module developers should prefer to review the Modules page of the Orchard admin dashboard and choose a related category from existing categories. If a relevant category doesn't exist modules can freely define a new category within this field of the manifest.</p>
**Dependencies**       | <p>*Required if the feature has dependencies*</p><p>A comma-separated list of the application `Id` values of all features that the specified feature depends on.</p><p>Each individual feature should only define its own dependencies. If all features are defined in the `Features:` subsection this main `Dependencies` field is not required.</p><p>Note: dependencies are **case sensitive**.</p>
**Priority**           | <p>*Optional*</p><p>The default is `0` and higher priorities will take precedence.</p><p>Used by Orchard to determine how to resolve dependencies implementing a specific interface.</p>

### Module manifest examples

Listed below are the three different ways you can use the module manifest.

#### Single feature module

    Name: Modules
    AntiForgery: enabled
    Author: The Orchard Team
    Website: http://orchardproject.net
    Version: 1.9.1
    OrchardVersion: 1.9
    Description: The Modules module enables the administrator of the site to manage the installed modules as well as activate and de-activate features.
    FeatureDescription: Standard module and feature management.
    Dependencies: Orchard.ExampleModule, Orchard.AnotherModule
    Category: Core

#### Multiple features with a default module in the main manifest

The Orchard.Alias module itself (defined as `Name: Alias`) is its own default feature. There are two extra optional features defined in the `Features` which can be separately enabled. In this case they both have dependencies on their parent feature `Orchard.Alias` but module developers can define independent features as well.

    Name: Alias
    AntiForgery: enabled
    Author: The Orchard Team
    Website: http://orchardproject.net
    Version: 1.9.1
    OrchardVersion: 1.9
    Description: Maps friendly urls to specific module actions.
    FeatureDescription: Maps friendly urls to specific module actions.
    Category: Content
    Features:
        Orchard.Alias.UI:
            Name: Alias UI
            Description: Admin user interface for Orchard.Alias.
            Dependencies: Orchard.Alias, Orchard.ExampleModule
            Category: Content
        Orchard.Alias.Updater:
            Name: Alias Updater
            Description: Synchronizes aliases when created from different servers.
            Dependencies: Orchard.Alias
            Category: Content

#### Multiple features all defined in the features sub-section of the manifest

    Name: AntiSpam
    AntiForgery: enabled
    Author: The Orchard Team
    Website: http://orchardproject.net
    Version: 1.9.1
    OrchardVersion: 1.9
    Description: Provides anti-spam services to protect your content from malicious submissions.
    Features:
        Orchard.AntiSpam:
            Name: Anti-Spam
            Description: Provides anti-spam services to protect your content from malicious submissions.
            Category: Security
            Dependencies: Orchard.Tokens, Orchard.jQuery
        Akismet.Filter:
            Name: Akismet Anti-Spam Filter
            Description: Provides an anti-spam filter based on Akismet.
            Category: Security
            Dependencies: Orchard.AntiSpam
        TypePad.Filter: 
            Name: TypePad Anti-Spam Filter
            Description: Provides an anti-spam filter based on TypePad.
            Category: Security
            Dependencies: Orchard.AntiSpam

Notice the structure that is used for each feature described in the `Features` field. The `FeatureId` of the feature is listed followed by a colon `:`. Then on a new line for each field, you can specify the other relevant fields including `Name`, `Description`, `Category` and `Dependencies`. 

For more information about how to create a module, including how to generate a manifest file and how to modify the manifest, see these guides:

  * [Getting Started with Modules course](Getting-Started-with-Modules)
  * [Writing a Content Part](Writing-a-content-part)
  * [Writing a Content Field](Creating-a-custom-field-type)
  * [Building a Hello World Module](Building-a-hello-world-module).

## Theme manifest fields

A theme manifest can have the following fields:

Field Name  | Description
----------- | ----------------------------------------------------
Name        | Provides a human-readable name for a theme that is an alternative to using the theme's ID. The ID of a theme is the name of the theme's folder in the virtual base path (the default virtual base path is _~/Themes_), and is used for programmatic references. For example, for a theme whose ID is `Orchard.Theme.Contoso`, you might provide a name in the manifest such as `Contoso Theme`. If you do not provide a name in the manifest, the ID is used instead. If you do provide a name, it will be used as the theme's display name in the [Orchard Gallery](http://gallery.orchardproject.net/) and in the Orchard UI.
Description | A brief summary of a theme's appearance and layout details. The description is used in the [Orchard Gallery](http://gallery.orchardproject.net/) and in the Orchard UI.
Version     | The version number of a theme. The version information is displayed in the [Orchard Gallery](http://gallery.orchardproject.net/) and the Orchard UI, and is also used to determine whether an update is needed.
Author      | The developer of a theme. This can be an organization, individual, or a list of individuals.
Website     | The URL for the website of the theme developer.
Tags        | A comma-separated lists of tags for the theme. The tags can be used to filter or group themes in a list. For example, a custom online gallery of themes can provide the ability to filter and display themes by tag.
Zones       | A comma-separated list of the Orchard zones that are used by a theme. These zones are displayed in the Orchard dashboard and can be used to customize the layout of a site by adding, removing, or arranging widgets.
BaseTheme   | The ID of another theme that this theme inherits from. This is an optional field. It is useful in cases where you want to customize an existing theme by copying it and then making some changes in style and appearance. When you use this approach, add the `BaseTheme` field to the manifest for the customized theme, and specify the `Id` of the base theme. For example, if you customized the Contoso theme, you could add the line `BaseTheme: Orchard.Theme.Contoso` to the manifest of your theme.

The following example shows the manifest for **The Theme Machine** theme, which is the default Orchard theme.  

    Name: The Theme Machine
    Author: jowall, mibach, loudej, heskew
    Description: Orchard Theme Machine is a flexible multi-zone theme that provides a solid foundation to build your site. It features 20 collapsible widget zones and is flexible enough to cover a wide range of layouts.
    Version: 1.9.1
    Tags: Awesome
    Website: http://orchardproject.net
    Zones: Header, Navigation, Featured, BeforeMain, AsideFirst, Messages, BeforeContent, Content, AfterContent, AsideSecond, AfterMain, TripelFirst, TripelSecond, TripelThird, FooterQuadFirst, FooterQuadSecond, FooterQuadThird, FooterQuadFourth, Footer

For more information about how to write a theme, including how to generate and modify a manifest, see [Writing a New Theme](Writing-a-new-theme). For information about how to customize an existing theme and then generate a manifest for it, see [Customizing Themes](Customizing-the-default-theme).
