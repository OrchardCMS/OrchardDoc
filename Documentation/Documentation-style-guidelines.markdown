

# Structure
Topics should begin with a brief summary explaining what audience it targets and their key takeaways.

If the topic is not complete enough to fulfill its goals, the top of the document should specify \(\(\(Draft topic\)\)\).

After the summary, the table of contents should be included using \{TOC\}.

After the table of contents, the actual contents of the document should all be under section headers, and the top section headers should be in header 1 style: ==This is a top header==. Subsections should be one level deeper than their parent section.

Do use explicitly named anchors when building links to a specific section of the document. Anchors are created -preferably in a header- using the syntax ==How to build awesome documentation\[anchor|\#how\-to\-build\-awesome\-documentation\]==. To link to an anchor within the document, use the \[\#how\-to\-build\-awesome\-documentation|Follow this link to learn how to build awesome documentation\] syntax. If the anchor is in another document, use the \[name\-of\-the\-linked\-document\#how\-to\-build\-awesome\-documentation|Follow this link to learn how to build awesome documentation\] syntax.

The text within a section should be structured in short paragraphs. Don't forget to include an empty line in wiki markup between paragraphs.

# Styles
Topics should use standard [ScrewTurn wiki markup](http://www.screwturn.eu/Help.WikiMarkup.ashx) and should avoid inline HTML styles.

## Bolding and Italics
Do not use header styles for emphasis.

Use '''triple quotes''' for bold. Bold is applied to UI elements.

Use ''double quotes'' for emphasis/italics. Italics is applied to folder/file/path names and to new terms.

Use \(\(\(triple parentheses\)\)\) to highlight a whole paragraph -- that is, to create an alert paragraph.

## Code
Inline code should be surrounded by `double curly braces`, and multi-line code samples should be enclosed in     double at signs
.

Try to break code lines so that the code blocks do not have horizontal scroll bars.

### Escaping Wiki Markup
If you need to use sequences of characters in your text that would normally be parsed as wiki markup, such as `, == or @@ but that you want to appear as they are without being parsed, surround those sequences with {{&lt;nowiki&gt;` and `&lt;/nowiki&gt;`. You can look at the source for this document for many examples of this.

## Images
Images should not be wider than 675 pixels if they are going to be embedded into a topic. Wider images are acceptable as targets of a link from a page. The link to such a wide image should itself be a 675 pixel-wide thumbnail of the image. When including a large image, do it as a 675 pixels wide image linking to the high-resolution version. Images narrower than 675 pixels should be included with their natural width and should not be enlarged.

It is possible to let ScrewTurn resize images for you. To do that, click edit next to your uploaded image and choose the resize option. You can then enter a width of 675 and ScrewTurn will compute the height that will respect the original aspect ratio of your image. Uncheck "Save as new file" before you save so that the resized image replaces the full-resolution one.

Images should have a caption. If the document contains more than one image, the captions should include a figure number in the form "Figure 1. This is the caption."

The typical markup to include an image is \[imageauto|Figure 1\. This is the caption for my image|\{UP\}topic\-name/myImageSmall\.png|topic\-name/myImage\.png\] if it is a link to a higher resolution, and \[imageauto|Figure 1\. This is the caption for my image|\{UP\}topic\-name/myImage\.png\] otherwise. When using that markup, the caption will appear below the image.

Acceptable image formats are PNG, JPG and GIF. Images should be reasonably compressed.

## Links
References to other topics on this wiki can be made using \[topic\-name|Text for the link\]. Links to external content can be added using \[http://somesite/somepage|Text of the link\].

Do use links to specific sections of a document where relevant (see the [structure section](#structure))

## Capitalization
In topic titles and in section headings, use title-style capitalization (as opposed to sentence style).  When referring to UI elements, follow the capitalization style used in the UI elements themselves. 

## Tables
Tables should be built to fit into the standard width of pages on this site. The markup to create a table is this:\{| cellspacing="2" cellpadding="2" border="1"
\! Header A \!\! Header B \!\! Header C
|\-
| Cell A\.1 || Cell B\.1 || Cell C\.1
|\-
| Cell A\.2 || Cell B\.2 || Cell C\.2
|\-
| Cell A\.3 || Cell B\.3 || Cell C\.3
|\}

This markup will create the following table:

<table cellspacing="2" cellpadding="2" border="1">
<thead><tr>
<td>Header A</td>
<td>Header B</td>
<td>Header C</td>
</tr></thead>
<tr>
<td>Cell A.1</td>
<td>Cell B.1</td>
<td>Cell C.1</td>
</tr><tr>
<td>Cell A.2</td>
<td>Cell B.2</td>
<td>Cell C.2</td>
</tr><tr>
<td>Cell A.3</td>
<td>Cell B.3</td>
<td>Cell C.3</td>
</tr>
</table>

The style information in that markup is unfortunate and we'll work at making it unnecessary, but in the meantime it ensures that tables will have visible borders. For details of table syntax see [WikiMarkup Tables Reference](http://www.screwturn.eu/Help.WikiMarkup-Tables.ashx).
