In a CMS such as Orchard, content is built as a composition of arbitrary parts. For example, a blog post is an assemblage of a route and title (`Routable` part), a body (`Body` part), tags (`Tags` part), comments (`Comment` part), and a few additional technical parts (`Common` and `PublishLater`). To get a template to render an object like this, you could access each of these parts explicitly and render them; that's a scenario that would work in Orchard. But that would not handle well the unpredictable changes in the definition of the content types that are the essence of a CMS. For example, what if the administrator of the site downloaded a star rating module and added the rating part to posts? If the layout for the whole item were explicitly defined, you would have to explicitly modify the template. 

In Orchard, this isn't necessary, and adding a new part and displaying it can be done without touching the templates. This is possible because the Orchard design separates layout into rendering (performed by templates or shape methods) and placement (done through the _placement.info_ file). This way, parts can not only specify their default rendering, which can be overridden by themes, they can also specify where they prefer to be rendered relative to other parts (which can also be overridden by themes).

Specifying placement using the _placement.info_ file is the subject of this article.


# The placement.info File

If you look at the files in your Orchard website, you'll see that most modules and themes have a _placement.info_ file at their root. This is an XML file that specifies the placement of each part of a content item.

The following example shows an example of a placement file. (Specifically, it's the _placement.info_ file that comes with `Orchard.Tags`.)

    
    <Placement>
        <Place Parts_Tags_Edit="Content:7"/>
        <Match DisplayType="Detail">
            <Place Parts_Tags_ShowTags="Header:after.7"/>
        </Match>
        <Match DisplayType="Summary">
            <Place Parts_Tags_ShowTags="Header:after.7"/>
        </Match>
    </Placement>


## Scope

A placement file acts at the content-item level. This means that you can use it to reorder the display of the parts of anything that is a content item (blog posts, pages, comments, custom items, widgets, etc.), but not necessarily arbitrary shapes. If a shape that is not representing a content part needs to handle placement, it is up to you to provide a placement mechanism for that shape.

## The "Placement" Element

The `Placement` element must be present at the root of the _placement.info_ document. It is a simple container.

## "Place" Element

The `Place` element is the main entity in a _placement.info_ file. It can have any number of attributes, although it's recommended for readability to have only one shape place defined per `Place` element. For additional shapes, you can add more `Place` tags, one per line.

Each attribute of a `Place` element is the name of a shape (such as `Parts_Tags_ShowTags`), as defined from the relevant part driver, and has the placement as the value. To determine the shapes that are part of the display of a given content item, you can read the code for the part drivers. Or a simpler method might be to enable the **Designer Tools** module and use the shape debugging tools to examine the model.

The name of the attribute can be any shape name (but not an alternate name; use Match to specialize placement instead). There are also special extensions for certain fields so that placement can be targeted at specific field instances. For example, the following placement will suppress the display of text fields named "Occupation":

    
    <Place Fields_Common_Text-Occupation="-"/>


> **Note for field developers:** you may give your own fields this capability by using a special override of ContentShape in your driver that provides the differentiator (the part after the dash in the attribute name). See the Text Field driver for example, or read [Creating a Custom Field Type](Creating-a-custom-field-type).

You can learn more about shapes and alternates in these topics: [Accessing and Rendering Shapes](Accessing-and-rendering-shapes) and [Alternates](Alternates).

The value itself is split into a zone name (this is a local zone, usually `Header`, `Meta`, `Content`. or `Footer`), a colon, and then a position. The position is defined using a dotted notation. It can be a single number (1, 5, 10, 42) or it can be a succession of numbers separated by a dot (1.2, 1.52.3, etc.). The order will be determined starting from the first number, and if multiple positions have the same first number, using the subsequent numbers. This way, 1 comes before 2.4.5, and 2.4.5 comes before 2.10.

There is a special value, "-", that suppresses the shape rendering instead of sending it to a local zone.

You can also use `before` and `after` qualifiers to position shapes before or after a certain position. For example, `Header:after` positions the shape at the next available position following everything that's defined using numeric positions.

A new feature in Orchard 1.1 is the ability to specify shape alternates and wrappers from `Place` elements and to rename the shape. For example, if you want to enable a theme author to specify a different template for rendering the tags for blog posts, you can do the following:

    
    <Match ContentType="BlogPost">
      <Place
        Parts_Tags_ShowTags="Header:after;Alternate=Parts_Tags_ShowTags_BlogPost"/>
    </Match>


A theme author can then provide a _Parts/Tags.ShowTags.BlogPost.cshtml_ file that customizes the display of tags for blog posts.

Similarly, you can provide a wrapper as part of the placement (`Header:after;Wrapper=Wrapper_GreenDiv`) or rename the shape (`Header:after;Shape=IPreferToCallThoseStickersForSomeReason`).

Using a wrapper enables wrapping content with a cshtml markup. Here is a 3 step example showing how to add a div around the Html Widget to enable css styling of the widget.

In placement.info : 

    <Match ContentType="Widget">
        <Place Parts_Common_Body="Content:5;Wrapper=Wrapper_HtmlContent" />
    </Match>

If you just put the wrapper without specifying 'Content:5' the body part will not show up. Content:5 specifies which zone to render the part in.

After modifying your placement.info the Shape Tracing module Shape tab will show your wrapper location at the bottom. It will be: ~/Themes/{yourTheme}/Views/Wrapper.HtmlContent.cshtml. Create this file and put the following text in it:

    <div class="htmlWrapperContent">
        @Model.Html
    </div>

This will enable you to target the wrapper from site.css like this:

    .htmlWrapperContent {
        background-color: #94CCE7;
    }


## "Match" Element

`Match` elements let you scope a particular set of `Place` tags. `Match` elements can have the following scope attributes:

* `DisplayType`.  Scopes the contained `Place` tags to a specific display type (such as `Detail` or `Summary`).
* `ContentType`. Scopes the contained `Place` tags to a specific content type (such as `BlogPost` or `Page`) or stereotype (such as `Widget`; this feature is new to Orchard 1.1).
* `Path`. Scopes the contained `Place` tags to a specific path or to a path and its children. For example, `Path="/About"` enables changes that only affect the About page (assuming you have one), and `Path="/MyBlog/*"` affects everything that is under the path _MyBlog_, such as _Myblog_ or _MyBlog/FirstPost_. The `Path` attribute is new to Orchard 1.1.

`Match` elements can be nested.

# Overriding Placement

Each module can define default placement for the parts and fields it provides by having a _placement.info_ file at the root of their directory. That default placement can be overridden by any theme by doing exactly the same thing. The current theme's placement will win over that of any module.
