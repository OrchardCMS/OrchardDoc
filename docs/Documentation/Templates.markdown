
Layout templates are aspx files with includes and calls to helpers.


## Template markup
Currently, we have only content zones, so a template can look like this:

    
    <html>
      <head>
        <link rel="stylesheet" type="text/css"
              href="<%= ResolveUrl("~/Content/StyleSheet.css") %>" />
      </head>
      <body>
        <div class="header">
          <%= Html.Include("header") %>
        </div>   
        <div class="centerContentZone">
          <%= Html.IncludeZone("Content") %>
        </div>   
        <div class="rightSidebar">
          <%= Html.IncludeZone("Right sidebar") %>
        </div>
        <div class="footer">
          <%= Html.Include("footer") %>
        </div>
        <%= Html.IncludeAdmin() %>
      </body>
    </html>


The helpers used above are:
* Html.Include(string includeName) includes the partial view whose name is specified.
* Html.IncludeZone(string zoneName) includes a named content zone.
* Html.RenderAdmin() includes the admin link if the user is logged in as administrator.

## Template Meta-data
Template meta-data is stored directly in the template file as server comments. They are in a simple key-value format. Keys and values are separated by a colon character:

    
    <%@Page %>
    <%--
    name: Two column layout
    description: This has a main content area and a sidebar on the right.
    zones: Content, Right sidebar
    author: Jon
    --%>


The keys in the meta-data are case-insensitive.

Meta-data values can be on multiple lines.

The syntax for meta-data is YAML.

The fields that are not recognized are put in a dictionary so that they are still accessible from code.

The last piece of meta-data, which is optional, is the thumbnail representation for it that is used in the template selection screen and in the edit page screen. This is a PNG or GIF image that has the same name as the template file and that is stored in the same directory.
