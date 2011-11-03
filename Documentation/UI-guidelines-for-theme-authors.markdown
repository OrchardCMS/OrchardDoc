> This topic was updated for the Orchard 1.0 release.

This article presents recommendations for coding and formatting HTML markup and CSS that will help you keep your themes organized.


# General Guidelines

This section contains guidelines for a number of design topics, such as browser testing, file names, HTML elements, JavaScript and images.

## Browser Testing

You should test all templates using the latest versions of the following browsers. For older versions of browsers, such as Internet Explorer 6, you should ensure that your site and templates remain functional, but don't attempt to resolve rendering issue that do not affect the user's ability to consume the content. 

* Microsoft Internet Explorer
* Google Chrome
* Mozilla Firefox
* Apple Safari
* Opera

## File Names

The following lists file naming rules followed by the Orchard development team.

* Include files use an underscore (_) as a prefix
* _.cshtml_, _.vbhtml_, HTML, and CSS files should be named using camel casing.

## HTML doctype Directive

Use the HTML5 `doctype` declaration, because it lets you use HTML5 markup but is also compatible with existing markup that complies to HTML 4.01 and XHTML.
 
    <!DOCTYPE html>

## HTML Elements

Orchard assumes the use of HTML5. Although you are not required to use HTML5, it is a strong recommendation. One reason is that templates from different modules and parent themes might be used on a single page, where there is only one `doctype` declaration. 

The following tables lists some commonly used HTML5 elements that provide for better structure in web pages than earlier versions of HTML did. For more information about HTML5, see the W3C article [HTML5 difference from HTML4](http://dev.w3.org/html5/html4-differences/).

* `<section>`
* `<article>`
* `<aside>`
* `<hgroup>`
* `<header>`
* `<footer>`
* `<nav>`
* `<figure>`
* `<figcaption>`

Example:
    
    <figure>
          <video src="tgif.vid"></video>
          <figcaption>Example</figcaption>
    </figure>


If you are using any of these new elements, in order to avoid breaking script libraries in older versions of Internet Explorer, we recommend that you use the workaround described in [Styling New HTML5 Elements](http://blogs.msdn.com/b/ie/archive/2010/06/10/same-markup-explaining-quot-jscript-version-quot-and-styling-new-html5-elements.aspx).

## JavaScript and jQuery

Your web pages should work even if JavaScript is disabled in the browser. Scripts should be used only to enhance the experience of the page, which is referred to as _progressive enhancement_. For more information, see [Progressive Enhancement with JavaScript](http://www.alistapart.com/articles/progressiveenhancementwithjavascript/).

Orchard has jQuery built in. The Orchard team has standardized on jQuery as its JavaScript framework. 


## Images

Use the appropriate image format for the scenario, as described in the following list:

* Photos and gradients should use the _jpeg_ format.
* Graphical elements should use the _png_ format.
* Use alpha transparency via the _24-bit png_ format.
* Use sprites where possible to improve load time and to reduce the number of requests made to the server.

For more information about sprites, see [CSS Sprites: Image Slicing's Kiss of Death](http://www.alistapart.com/articles/sprites).

## Accessibility

Your HTML and CSS templates should pass the accessibility tests provided by [Wave the web accessibility evaluation tool](http://wave.webaim.org/). Your templates should satisfy the requirements of WCAG 2.0 level AA.

## Markup Validation

We recommend that you always strive for standards compliance. Ensure that your templates pass validation by using the [W3C Markup Validation Service](http://validator.w3.org/).

# CSS Organization

To allow users to easily find and read styles for modification, we recommend that you standardize on a structure and coding format. The organizational structure that is introduced in this section is used by the Orchard team.

To help you abide by the CSS standards, keep the following guidelines in mind:

* Do not use workarounds like conditional `if` statements in stylesheets. 
* CSS markup should be valid CSS 2.1 or higher. You can also use optional progressively enhanced CSS 3 markup.

## CSS Format Rules

The following list contains guidelines for formatting CSS markup.

* Use four spaces instead of tabs for indentation. (This is the default setting in Visual Studio.)
* Use a hyphen (-) between words in selectors.
* Remove unused CSS selections (except for reset styles).
* Use lowercase for color definitions.
* Use shorthand notation where possible, such as for color codes; use collapsed properties when practical.
* Use IDs instead of classes where possible. Using IDs for template elements makes it easy to identify the important selectors in CSS and HTML.
* Use one line per property definition.
* Use "tab-nested" selectors. For more information, see [CSS DIY Organization](http://net.tutsplus.com/tutorials/html-css-techniques/css-diy-organization/).

## CSS File Structure

The recommended CSS structure was partly adapted from suggestions provided by Dan Cederholm of SimpleBits. This structure resides in the Style.css file. The file comprises the following sections:

1. **Info** - A commented section for the theme that the style is associated with, the author, website, and any copyright information. 
2. **Color Palette** - A commented section that defines the overall color scheme for the theme. It provides a single place to define colors and makes it easy for users to find, replace, and modify color definitions. 
3. **Reset** - Definitions that are used to normalize settings across browsers. 
4. **Clearing Floats** - Definitions that are used to clear parent items that contain children that float. 
5. **Typography** - (Optional) Contains CSS code or a reference to a typography reset framework (such as YUI Fonts) that normalizes font sizes across browsers.  
6. **General** - Definitions for global HTML elements such as `<body>`, headings, links, and any other elements where you want to apply a different style and override the reset. This can include styles for elements like `<ul>`, `<p>`, etc. 
7. **Structure** - Layout definitions for major structural components of your templates, such as containers, headers, footers, etc. This section can be subdivided with comments into sections such as navigation, header, etc. 
8. **Main** - Main styles related to your theme. This can contain definitions for blog posts, tags, etc. 
9. **Secondary** - Secondary styles related to your theme for things like stylized text, errors, etc. 
10. **Forms** - All styling related to form items.
11. **Misc** - Miscellaneous definitions that are needed to render the look of your template. 

The following example shows this structure applied to a CSS file.

    
    /*
    Theme: My Sample Theme
    Author: 
    Copyright: 
    */
    
    /* Colors Palette
    Background: #fff
    Text: #434343
    Main Accent: #999
    Links: #443444
    */
    
    /* Reset
    ***************************************************************/
    YOUR CSS RESET CODE GOES HERE
    
    /* Clearing Float
    ***************************************************************/
    group:after {
        content: ".";
        display: block;
        height: 0;
        clear: both;
        visibility: hidden;
    }
    
    .group {display: inline-block;}  /* for IE/Mac */
    
    /* Typography (Optional)
    ***************************************************************/
    @import url(http://yui.yahooapis.com/2.8.1/build/fonts/fonts-min.css);
    
    
    /* General
    ***************************************************************/
    body {}
    
    a {}
    a:link {}
    a:hover{}
    a:visited{}
    
    h1,h2,h3,h4,h5,h6 {}
    
    /* Structure
    ***************************************************************/
    #container {}
    
    #header {}
           #logo {}
    
    #footer {}
    
    /* Main
    ***************************************************************/
    
    /* Secondary
    ***************************************************************/
    
    /* Forms
    ***************************************************************/
    
    /* Misc
    ***************************************************************/
    


## CSS Reset

You should always use a reset to normalize styling between browsers and then apply default markup manually. For more information about resets, see [Reset Reloaded](http://meyerweb.com/eric/thoughts/2007/05/01/reset-reloaded/). You can optionally use a reset library. 

**To reset a global style**

1. Apply the reset.
2. Apply a default style to any global element (defined in the general section).

Example:    
    p {
       padding: 0 10px;
       line-height: 150%;  
    }	


## Typography

Use relative font sizes and set a default base size to ensure consistent font sizes across browsers, and to allow browser users to increase font size to enhance readability. However, remember that relative sizes are cumulative. For example, if you set the size of div tags to `2em`, then you then embed a `<div>` element inside another `<div>` element and another inside that, you'll end up with an effective setting of `8em` for the innermost `<div>` element.

The following list shows the methods by which you can enhance readability.

* (Method 1) Use ems and set the base font size on the `<body>` element. The default size for medium text in all modern browsers is `16px`. First, reduce this size for the entire document by setting font size in the `<body>` element to 62.5%. You can then think in pixels but still set sizes in terms of ems: 1em is 10px, 0.8em is 8px, 1.6em is 16px, etc. For more information, see [How to size text using ems](http://clagnut.com/blog/348/).
* (Method 2) Use a framework reset such as [YUI 2 Fonts CSS](http://developer.yahoo.com/yui/fonts/).

## Clearing Floats

There are two methods you can use to clear floats without adding markup.

* (Method 1) Us the _position if everything_ method with semantic modification as suggested by [SimpleBits](http://simplebits.com/). This method involves applying a `clear` property to any parent element that contains items that you want to float.<br /><br />The SimpleBits modification changes the class name to `group`, which adds semantic value because you often float related items as a group.
* (Method 2) Apply the `overflow:auto` property to the parent container.<br /><br />Certain combinations of margin and padding can force internal scrollbars. If you can't tweak things to remove the scrollbars, you can try using `overflow:hidden`, which has virtually the same effect without the scrollbars. The only drawback of `hidden` seems to be that some images are cropped if they're placed lower in the page.

## Forms

Mark up form elements using the "ordered-list" method. This method describes form elements as a sequential list of inputs that the user needs to fill in. It provides both semantic meaning and order to the form, which aids accessibility. When forms are rendered without style sheets, they are clearly labeled in sequential order and have a count associated with them. The ordered list provides additional information for some screen readers that announce the number of list items when they first encounter the list.
    
    <fieldset>
      <legend>Delivery Details</legend>
      <ol>
        <li>
          <label for="name">Name<em>*</em></label>
          <input id="name" />
        </li>
        <li>
          <label for="address1">Address<em>*</em></label>
          <input id="address1" />
        </li>
        <li>
          <label for="town-city">Town/City</label>
          <input id="town-city" />
        </li>
        <li>
          <fieldset>
            <legend>Is this address also your invoice address?<em>*</em></legend>
            <label><input type="radio" name="invoice-address" /> Yes</label>
            <label><input type="radio" name="invoice-address" /> No</label>
          </fieldset>
        </li>
      </ol>
    </fieldset>


## Progressive Enhancements

Base your designs on modern browsers that implement up-to-date patterns, but without handicapping the experience of older browsers. If you feel it is important to the design, use known CSS techniques such as sliding door to achieve the desired effect.

1. Border radius
2. Multiple background images 
3. Gradient 
4. Transparency (RGBA and opacity)
5. Shadows 
6. Text-Shadows

