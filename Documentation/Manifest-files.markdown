
In the Orchard CMS, modules and themes are important tools for extending and customizing an application. Every module and theme is required to have a manifest, which is a text file named _module.txt_ or _theme.txt_ that resides in the root folder of the associated module or theme. A manifest stores metadata that Orchard uses to describe modules and themes to the system, such as name, version, description, author, and tags.

This topic is a reference for manifest files. If you create a custom module or theme, or if you write code that accesses modules or themes, you must understand the metadata fields in a manifest. The data in a manifest is structured into name-value pairs in the form _Field Name_:_Value_. 

The following sections describe the available fields in a manifest for themes and for modules. Because a theme is a type of module, many of the same metadata fields occur in both theme manifests and module manifests.


## Module Manifest Fields

The manifest for a module can feature the following fields:

Field Name         | Description
------------------ | ---------------------------------------------------
Name               | Provides a human-readable name for a module that is an alternative to using the module's ID. The ID of a module is the name of the module's folder in the virtual base path (the default virtual base path is _~/Modules_), and is used for programmatic references to the module. For example, for a module whose ID is `Bing.Maps`, you might provide a name in the manifest such as `Bing Mapping Component` or even `Bing Maps` (notice that the "." is removed). If you do not provide a name in the manifest, the ID is used instead. If you do provide a name, it will be used as the module's display name in the gallery and in the Orchard UI.
Path               | Provides a name that is used to build more readable URLs for routing purposes compared to URLs that are based on module names or ID values. This is an optional field. If you do not provide a path, Orchard builds URLs based on the module's name (if one is provided) or on the ID. However, module names often have spaces, and ID values often have "." characters, neither of which result in very readable URLs. For example, for the Orchard **ArchiveLater** module, its name is `Archive Later`, and its ID is `Archive.Later`. In the manifest, a path is provided and the value is `ArchiveLater`, which enables Orchard to build a more readable URL than the module name or the ID would.
Description        | A brief summary of what a module does. The description is used in the gallery and in the Orchard UI.
Version            | The version number of a module. The version information is displayed in the gallery and in the Orchard UI. It is also used to determine whether an update is needed.
OrchardVersion     | The Orchard version number for the current module version.
AntiForgery        | A value that indicates whether request validation is enabled for a module. Possible values are `enabled` or `disabled`.
Author             | The developer of a module. This can be an organization, individual, or a list of individuals.
Website            | The URL for the website of the module developer.
Tags               | A comma-separated lists of tags for the module. The tags can be used to filter or group modules in a list. For example, a custom online gallery of modules can provide the ability to filter and display modules by tag.
FeatureDescription | A description of the default feature in a module. If a module has only a single feature, use the `FeatureDescription` field to describe it. If a module has multiple features and one of the features is the default, use the `FeatureDescription` field to describe the default feature, and describe the remaining features using the `Features` field. When you add this field to a manifest, you should also add a `Category` field to indicate the display category for the feature. If the feature is dependent on other features, also add a `Dependencies` field and provide a comma-separated list of the `Id` values of the other features that the feature depends on.
Category           | The display heading for a feature in the Orchard UI. For each individual feature that you describe in a manifest, you should also enter a category for the feature (if you don't, the feature will be displayed in an "uncategorized" section on the **Features** screen in the dashboard). The value appears as a section heading in the **Features** screen of the Orchard dashboard. If multiple features have the same category, they are displayed under a single shared heading in the **Features** screen. For examples of how to provide a category for a default single feature or for multiple features listed under the `Features` field, see the manifest files that follow.
Dependencies       | A comma-separated list of the application `Id` values of all features that the specified feature depends on.
Features           | A description of the features provided by a module. If a module has only one feature, use the `FeatureDescription` field instead. If a module has two or more features, use the `FeatureDescription` field to describe the default feature, and use the `Features` field to describe details of each additional feature. To complete the `Features` field, supply the following details for each feature: `Feature Id`, `Name`, `Description`, `Category`, and `Dependencies` (if any). You may also optionally specify a `Priority` for a feature that can be used by Orchard to determine how to resolve dependencies implementing a specific interface. The default is 0 and higher priorities will take precedence.

The following example shows an example of a manifest for the **Email Messaging** module. This module has a single feature, so it uses the `FeatureDescription` field. It also includes `Category` and `Dependencies` fields for the feature.

    Name: Email Messaging
    AntiForgery: enabled
    Author: The Orchard Team
    Website: http://orchardproject.net
    Version: 1.0.20
    OrchardVersion: 1.0.20
    Description: The Email Messaging module adds Email sending functionalities.
    FeatureDescription: Email Messaging services.
    Category: Messaging
    Dependencies: Orchard.Messaging


The following example shows a manifest for the **Blogs** module. This module has a default feature, which is described in the `FeatureDescription` field, and it specifies a category and dependencies for the default feature.  The module has an additional feature that is described in the `Features` field. 

    Name: Blogs
    AntiForgery: enabled
    Author: The Orchard Team
    Website: http://orchardproject.net
    Version: 1.0.20
    OrchardVersion: 1.0.20
    Description: The Orchard Blogs module is implementing basic blogging features. 
    FeatureDescription: A simple web log.
    Dependencies: Shapes, Common, Routable, Feeds, Navigation, Orchard.Widgets, Orchard.jQuery, Orchard.PublishLater
    Category: Content
    Features:
        Orchard.Blogs.RemotePublishing:
            Name: Remote Blog Publishing
            Description: Blog easier using a dedicated MetaWeblogAPI-compatible publishing tool.
            Dependencies: XmlRpc, Orchard.Blogs
            Category: Content Publishing


Notice the structure that is used for each feature described in the `Features` field. The ID of the feature is listed followed by ":". Then on a new line for each field, you can specify the name, description, category, and dependencies (if any). 

For more information about how to create a module, including how to generate a manifest file and how to modify the manifest, see [Building a Hello World Module](Building-a-hello-world-module).

## Theme Manifest Fields

A theme manifest can have the following fields:

Field Name  | Description
----------- | ----------------------------------------------------
Name        | Provides a human-readable name for a theme that is an alternative to using the theme's ID. The ID of a theme is the name of the theme's folder in the virtual base path (the default virtual base path is _~/Themes_), and is used for programmatic references. For example, for a theme whose ID is `Orchard.Theme.Contoso`, you might provide a name in the manifest such as `Contoso Theme`. If you do not provide a name in the manifest, the ID is used instead. If you do provide a name, it will be used as the theme's display name in the gallery and in the Orchard UI.
Description | A brief summary of a theme's appearance and layout details. The description is used in the gallery and in the Orchard UI.
Version     | The version number of a theme. The version information is displayed in the gallery and the Orchard UI, and is also used to determine whether an update is needed.
Author      | The developer of a theme. This can be an organization, individual, or a list of individuals.
Website     | The URL for the website of the theme developer.
Tags        | A comma-separated lists of tags for the theme. The tags can be used to filter or group themes in a list. For example, a custom online gallery of themes can provide the ability to filter and display themes by tag.
Zones       | A comma-separated list of the Orchard zones that are used by a theme. These zones are displayed in the Orchard dashboard and can be used to customize the layout of a site by adding, removing, or arranging widgets.
BaseTheme   | The ID of another theme that this theme inherits from. This is an optional field. It is useful in cases where you want to customize an existing theme by copying it and then making some changes in style and appearance. When you use this approach, add the `BaseTheme` field to the manifest for the customized theme, and specify the `Id` of the base theme. For example, if you customized the Contoso theme, you could add the line `BaseTheme: Orchard.Theme.Contoso` to the manifest of your theme.

The following example shows the manifest for **The Theme Machine** theme, which is the default Orchard theme.  

    Name: The Theme Machine
    Author: jowall, mibach, loudej, heskew
    Description: Orchard Theme Machine is a flexible multi-zone theme that provides a solid foundation to build your site. It features 20 collapsible widget zones and is flexible enough to cover a wide range of layouts.
    Version: 1.0.20
    Tags: Customize, Default
    Website: http://orchardproject.net
    Zones: Header, Navigation, Featured, BeforeMain, AsideFirst, Messages, BeforeContent, Content, AfterContent, AsideSecond, AfterMain, TripelFirst, TripelSecond, TripelThird, FooterQuadFirst, FooterQuadSecond, FooterQuadThird, FooterQuadFourth, Footer


For more information about how to write a theme, including how to generate and modify a manifest, see [Writing a New Theme](Writing-a-new-theme). For information about how to customize an existing theme and then generate a manifest for it, see [Customizing Themes](Customizing-the-default-theme).
