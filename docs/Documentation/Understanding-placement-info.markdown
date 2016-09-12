In a CMS such as Orchard, content is built as a composition of arbitrary parts. For example, a blog post is an assemblage of a route (`Autoroute` Part), title (`Title` part), contents (`Body` part), tags (`Tags` part), comments (`Comment` part), and a few additional technical parts (`Common` and `PublishLater`). 

To get a template to render an object like this, you could access each of these parts explicitly and render them; that's a scenario that would work in Orchard. But that would not handle well the unpredictable changes in the definition of the content types that are the essence of a CMS. For example, what if the administrator of the site downloaded a star rating module and added the rating part to posts? If the layout for the whole item were explicitly defined, you would have to explicitly modify the template. 

In Orchard, this isn't necessary, and adding a new part and displaying it can be done without touching the templates. This is possible because Orchard separates layout into two stages:

  - Rendering (performed by generating HTML from templates or shape methods) and
  - Placement (done through the `placement.info` file).

This way, parts can not only specify their default rendering, which can be overridden by themes, they can also specify where they prefer to be rendered relative to other parts (which can also be overridden by themes).

> **Best Practice:** Avoid creating templates for high level Content Types.
> 
> Instead, create templates for Content Parts and Content Fields then change their order with placement.

Specifying placement using the `placement.info` file is the subject of this article.

## Summary

- Placement works only on parts (and some fields) of content items. 
- Place element attributes are shape names (not alternate names).
- Find shape names via shape tracing or in driver code.
- Match element attributes include `ContentType`, `DisplayType`, and `Path`.
- Path can include a `*` to represent all child paths.
- Override module placements in the theme

## Syntax Overview

	<placement>
		[ <match scope> ]
			<place Shape_Name="order[;alternate][;wrapper][;shape]" />
		[ </match> ]
	</placement>

<table>
<tr><th>Scope<td colspan="2">ContentType="value" | ContentPart="value" | DisplayType="value" | Path="value"
<tr><th rowspan="3">Order<td colspan="2">position | suppress
<tr><th>Position<td>zone_name[ : { int | after | before } ][ .int ][ ...n ]
<tr><th>Suppress<td> - 
<tr><th>Alternate<td colspan="2">;Alternate=alternate_name
<tr><th>Wrapper<td colspan="2">;Wrapper=wrapper_name
<tr><th>Shape<td colspan="2">;Shape=new_shape_name
</table>

## The placement.info File

If you look at the files in your Orchard website, you'll see that most modules and themes have a `placement.info` file at their root. This is an XML file that specifies the placement of each part of a content item.

The following example shows an example of a placement file. (It's based on the `placement.info` file that comes with `Orchard.Tags`.)

    <Placement>
        <Place Parts_Tags_Edit="Content:7"/>
        <Match DisplayType="Detail">
            <Place Parts_Tags_ShowTags="Header:after.7"/>
        </Match>
        <Match DisplayType="Summary">
            <Place Parts_Tags_ShowTags="Header:after.7"/>
        </Match>
        <Match DisplayType="SummaryAdmin">
            <Place Parts_Tags_ShowTags="-"/>
        </Match>        
    </Placement>


## Placement Scope

A placement file acts at the Content Item level. This means that you can use it to reorder the display of the parts of anything that is a content item (blog posts, pages, comments, custom items, widgets, elements, etc.), but not necessarily arbitrary shapes. If a shape that is not representing a content part needs placement, it is up to you to provide a placement mechanism for that shape.

## Comments
Comments can be included in the `placement.info` using normal `<!-- comment -->` syntax.

## The "Placement" Element

The `Placement` element must be present at the root of the `placement.info` document. It is a simple container.

## "Place" Element

The `Place` element is the main entity in a `placement.info` file. It can have any number of attributes, although it's recommended for readability to have only one shape place defined per `Place` element. For additional shapes, you can add more `Place` tags, one per line.

Single shape per line example:

    <Place Parts_TagCloud="Content:5"/>
    <Place Parts_TagCloud_Edit="Content:7"/>

Multiple shapes per line example:

    <Place Parts_TagCloud="Content:5" Parts_TagCloud_Edit="Content:7"/>

### Shape Name Attribute
Each attribute of a `Place` element is the name of a shape (such as `Parts_Tags_ShowTags`), as defined from the relevant part driver, and has the placement as the value. To determine the shapes that are part of the display of a given content item, you can read the code for the part drivers. Or a simpler method might be to enable the Shape Tracing module and use the shape debugging tools to examine the model.

The name of the attribute can be any shape name (but not an alternate name; use Match to specialize placement instead). 

There are also special extensions for certain fields so that placement can be targeted at specific field instances. 

For example, the following placement will display text fields named "Occupation" at the start of the **local** content zone:
    
    <Place Fields_Common_Text-Occupation="Content:before"/>

> **Note for field developers:** you may give your own fields this capability by using a special override of ContentShape in your driver that provides the differentiator (the part after the dash in the attribute name). See the Text Field driver for example, or read [Creating a Custom Field Type](Creating-a-custom-field-type).

You can learn more about shapes and alternates in these topics: [Accessing and Rendering Shapes](Accessing-and-rendering-shapes) and [Alternates](Alternates).

The value itself is split into a zone name, a colon, and then a position. 

### Local Zone Placement
By default the zone name will specify a **local** zone. 

If you look inside that shape template you will see that there are several locally defined zones. Razor templates would use `@Display(Model.Content)` to display the content zone for example.  

Usually you will find a zones like `Header`, `Meta`, `Content`, or `Footer` available for placement.

Example local zone placement:

    <Place Parts_TagCloud="Content:5"/>

### Top-Level Zone Placement
The zone name can also specify a top-level zone. Top level zones are defined in the *Layout.cshtml* view. 

In the case of a top-level zone, the zone name must begin with a slash, e.g. `/AsideFirst`

Example top-level zone placement:

    <Place Parts_TagCloud="/AsideFirst:5"/>

### Placement Order
The position is defined using a dotted notation. It can be a single number (1, 5, 10, 42) or it can be a succession of numbers separated by a dot (1.2, 1.52.3, etc.). The order will be determined starting from the first number, and if multiple positions have the same first number, using the subsequent numbers. This way, 1 comes before 2.4.5, and 2.4.5 comes before 2.10.

You can also use `before` and `after` qualifiers to position shapes before or after a certain position. For example, `Header:after` positions the shape at the next available position following everything that's defined using numeric positions.

Placement order examples:

    <!-- A weight of 5 in local content zone -->
    <Place Parts_TagCloud="Content:5"/>
    
    <!-- Before the top-level header zone -->
    <Place Parts_TagCloud="/Header:Before"/>
    
    <!-- After the top-level asidefirst zone with a weight of .5 -->
    <Place Parts_TagCloud="/AsideFirst:After.5"/>

### Suppression
There is a special value, "-", that suppresses the shape rendering instead of sending it to a zone.

Suppression examples:

    <!-- Suppress Parts_TagCloud everywhere -->
    <Place Parts_TagCloud="-"/>
    
    <!-- Suppress Parts_TagCloud in views using SummaryAdmin -->
    <Match DisplayType="SummaryAdmin">
      <Place Parts_TagCloud="-"/>
    </Match>

### Alternate
_Added in v1.1_

Use `alternate` to specify shape alternates from `Place` elements.

For example, if you want to enable a theme author to specify a different template for rendering the tags for blog posts, you can do the following:
    
    <Match ContentType="BlogPost">
      <Place
        Parts_Tags_ShowTags="Header:1;Alternate=Parts_Tags_ShowTags_BlogPost"/>
    </Match>

A theme author can then provide a _Parts/Tags.ShowTags.BlogPost.cshtml_ file that customizes the display of tags for blog posts.

### Wrapper
_Added in v1.1_

Use 'wrapper' from `Place` elements to wrap an extra shape around the original shape.

Similarly, you can provide a wrapper as part of the placement (`Header:after;Wrapper=Wrapper_GreenDiv`).

Using a wrapper enables wrapping content with a cshtml markup. Here is a 3 step example showing how to add a div around the Html Widget to enable css styling of the widget.

In placement.info : 

    <Match ContentType="Widget">
        <Place Parts_Common_Body="Content:5;Wrapper=Wrapper_HtmlContent" />
    </Match>

If you just put the wrapper without specifying 'Content:5' the body part will not show up. By adding `Content:5` it specifies which zone to render the part in.

After modifying your placement.info the Shape Tracing module Shape tab will show your wrapper location at the bottom. It will be: `~/Themes/{yourTheme}/Views/Wrapper.HtmlContent.cshtml`. 

Create this file and put the following text in it:

    <div class="htmlWrapperContent">
        @Model.Html
    </div>

This will enable you to target the wrapper from `site.css` like this:

    .htmlWrapperContent {
        background-color: #94CCE7;
    }

### Shape
_Added in v1.1_

Use 'shape' from `Place` elements to rename the shape.

For example:

    <Place Parts_Common_Body="Content:5;Header:after;
    Shape=IPreferToCallThoseStickersForSomeReason" />

## "Match" Element

`Match` elements let you scope a particular set of `Place` tags. `Match` elements can have the following scope attributes:

  * `DisplayType`
  * `ContentType`
  * `ContentPart`
  * `Path`

`Match` elements can be nested.

### DisplayType
Scopes the contained `Place` tags to a specific display type. 

You can define your own custom display types when developing content parts or fields, but Orchard uses standard ones:

  * Detail - Used when rendering a single item, e.g. a blog post
  * Summary - Used when rendering a list of items
  * SummaryAdmin - Used when rending a list of items in the admin panel
  
Some modules have registered their own such as:

  * Layout - _Added in v1.9_ - Used by the Orchard.Layouts module when an element is rendering a shape like a ContentField or ContentItem
  * Design - _Added in v1.9_ - Used by the Orchard.Layouts module when showing an element in the admin panel

### ContentType
Scopes the contained `Place` tags to a specific content type or stereotype.

  * Content Type - Such as `BlogPost` or `Page`
  * Stereotype - _Added in v1.1_ - Such as `Widget`

### ContentPart
_The `ContentPart` attribute was added in v1.7.2_

Scopes the contained `Place` tags to a specific content part such as `BodyPart` or `LayoutPart`. An example use of this scoping is to hide the title part in a content item with a `LayoutPart`.

In placement.info :

    <Match ContentPart="LayoutPart">
        <Place Parts_Title="-" />
    </Match>
    <Match DisplayType="Layout">
        <Place Parts_Title="Header:0" />
    </Match>
    
The first `Match` hides the `TitlePart` for content items that contain a `LayoutPart`. The second `Match` then displays the `TitlePart` when `DisplayType` is `Layout`. The title will only be displayed if the `TitlePart` element has been placed on the canvas.

### Path
_The `Path` attribute was added in v1.1_.

Scopes the contained `Place` tags to a specific path or to a path and its children. 

  * Specific Path - For example, `Path="/About"` enables changes that only affect the About page (assuming you have one)
  * Path and it's Children - For example, `Path="/MyBlog/*"` affects everything that is under the path _MyBlog_, such as _Myblog_ or _MyBlog/FirstPost_. 

## Overriding Placement

A module should define default placements for the parts and fields it provides by having a `placement.info` file at the root of the module's directory.

Without a placement your parts and fields will not appear on the page. By supplying a default you take the burden away from theme developers to configure your module and you make it easy for them to copy sections over to customise them. Consider the various DisplayTypes your parts and fields may be viewed and provide sensible defaults.  

That default placement can be overridden by any theme by placing a `placement.info` file in the root of the theme directory.

The current theme's placement will win over that of any module.
