
## Supported Browsers

All templates will be tested against and support the following browsers. For Internet Explorer 6 and below, we will strive to ensure the site and templates remain functional, but will not put effort into resolving any rendering issues that does not affect the ability for the user to consume the content.

* IE7+
* Chrome 5+
* Firefox 3.5+
* Safari 4+ 
* Opera 10+

## File Names

The following rules should be observed when naming files:

* **Include files** will use "_" at the beginnings
* All **cshtml, vbhtml, HTML and CSS** files should be named using camel case.

**Examples:** BlogPage.vbhtml, APageWithAReallyLongName.cshtml, About.html, Style.css

## HTML Doctype

We will standardize on the HTML5 doctype as it allows the use of HTML5 markup while being compatible with existing content that applies to HTML 4.01 and XHTML. 

    <!DOCTYPE html>

## Tags

In addition to all non- deprecated HTML4 tags, you may optionally use all the "New Elements" tags listed in section 3.1 as specified at <http://www.w3.org/TR/html5-diff/> which allow progressive enhancement in all browsers.

The following are common new elements have been introduced for better structure:

* `<section>` Section represents a generic document or application section. It can be used together with the h1, h2, h3, h4, h5, and h6 elements to indicate the document structure.
* `<article>` Article represents an independent piece of content of a document, such as a blog entry or newspaper article.
* `<aside>` Aside represents a piece of content that is only slightly related to the rest of the page.
* `<hgroup>` Hgroup represents the header of a section.
* `<header>` Header represents a group of introductory of navigational aids.
* `<footer>` Footer represents a footer for a section and can contain information about the author, copyright information, et cetera.
* `<nav>` Represents a section of the document intended for navigation.
* `<figure>` Figure represents a piece of self-contained flow content, typically referenced as a single unit from the main flow of the document.
  
Example:

    <figure>
        <video src="ogg"></video>
        <figcaption>Example</figcaption>
    </figure>

## Using "New Elements" in IE8 and lower

If you're using any of the new tags listed in section 3.1, use the following workaround to allow this markup to not break script libraries in older versions of IE. [http://bit.ly/biRqQ0](http://bit.ly/biRqQ0)

## Javascript

**All pages should work with Javascript disabled or not available.** Scripts should be purely additive and used enhance the existing experience of the page. The term used for this is progressive enhancement. For more information see: [http://bit.ly/Y5Gp2](http://bit.ly/Y5Gp2)

_jQuery comes built-in into Orchard so we will standardize on it as our Javascript framework across templates and admin pages._

## Images

Strive to use the appropriate image format for each situation.

* Photos and gradients should use the jpeg format.
* Graphical elements should use png.
* Alpha transparency via 24-bit png is allowed.
* Use sprites where possible to improve load time and reduce the amount of requests made to the server. [http://www.alistapart.com/articles/sprites](http://www.alistapart.com/articles/sprites)</td>

## Accessibility

HTML and CSS templates need to pass the accessibility tests at: [http://wave.webaim.org/](http://wave.webaim.org/) Templates will satisfy all requirements of WCAG 2.0 level AA.

## Validation

We strive for standards compliance. All templates both admin and theme need to pass validation using validation tools located at [http://validator.w3.org/](http://validator.w3.org/).

## CSS Organization

Standardize on a structure and coding format to allow users to easily find and read styles for modification.

* Do not use "Hacks" such as conditional if (IE), etc. 
* CSS Markup will be valid CSS 2.1 + Optional progressively enhanced CSS 3 markup

### Structure

This structure was partly adapted from suggestions provided made by Dan Cederholm from Simple Bits. All this resides in the Style.css file. The file will comprise of the following sections:

1. **Info** - This section contains a commented section for the theme the style is associated with, the author, website and any copyright information.
2. **Color Palette** - This section will be a commented section that defines the overall color scheme for the theme. It allows a single place to define colors and makes it easy for users to find, replace and modify color definitions.
3. **Reset** - CSS definitions used to normalize settings across browsers.
4. **Clearing Floats** - Contains CSS definitions used to clear parent items that contained floated children.
5. **Typography (This is optional)** - Allows you to add any CSS code or import a typography reset framework such as YUI Fonts used to normalize font sizes across browsers.
6. **General** - Contains definitions for global html elements such as body, headings levels, links and any other elements in which you would like to apply a different styling and override the reset. This would include UL, P's, etc.
7. **Structure** - This includes layout definitions for major structural components of your templates such as containers, headers, footers, etc. _This section may be sub divided with comments into specific sections such as navigation, header, etc._
8. **Main** - Main styles related to your theme. This may contains things like definitions for blog posts, tags, etc.
9. **Secondary** - Secondary styles related to your theme. This may contain secondary styling definitions for things like stylize text, errors, etc.
10. **Forms** - All styling related to forms items. _This section may be sub divided with comments into specific sections such as comment form, etc._
11. **Misc** - This contains any misc or specific definitions that you may need to use to render your desired look.
