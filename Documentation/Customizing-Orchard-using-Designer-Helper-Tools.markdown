
Orchard provides a designer tool named **Shape Tracing** that enables you to customize the appearance of your site. The **Shape Tracing** module provides tools that you can use to select sections of your website and discover information about the rendering code.

## Getting Started with Shape Tracing
To use **Shape Tracing**, first enable the **Shape Tracing** feature in the dashboard. The **Shape Tracing** feature comes with the [Designer Tools](http://orchardproject.net/gallery/List/Modules/Orchard.Module.Orchard.DesignerTools) module, that you may have to install. After you enable the feature, you will notice a narrow frame across the bottom of the web page when you navigate to your site, similar to the following illustration:

![](../Upload/screenshots_675/ShapeTracing_ExpandFrame_675.png)

When the **Shape Tracing** frame is collapsed, your site functions as it would normally. However, when you click the icon, the frame expands and displays **Shape Tracing** features.

## Shape Information
When the **Shape Tracing** frame is expanded, you can hold the mouse pointer over a section of a page and that section is highlighted. Click the highlighted section to display information about the shape and how it is rendered.

![](../Upload/screenshots_675/ShapeTracing_HighlightShape_675.png)

The left side of the frame displays which shape is selected. It also enables you to select which shape to highlight by providing a navigable tree for the shapes.

![](../Upload/screenshots/ShapeTracing_SelectShape.png)

The right side displays information about the selected shape and enables you to select which type of information to display.

![](../Upload/screenshots/ShapeTracing_ShapeInfo.png)

The **Shape Tracing** pane displays the following information:

* **Shape**. Information about the shape and the template to render the shape. Includes the option of creating alternates as described later in this article.
* **Model**. Information about the model for this shape.
* **Placement**. The _placement.info_ file.
* **Template**. The code in the template file
* **HTML**. The HTML for rendering this shape.

## Creating Alternate Templates
The **Shape Tracing** interface displays links that let you automatically create alternate templates for a shape. The interface displays the available alternate templates and includes a link titled **Create** to generate that template.

![](../Upload/screenshots_675/ShapeTracing_CreateAlternate_675.png)

The **Create** option only creates the template in the specified directory. You must customize the template to render the shape as needed. If you are using Visual Studio, you must include the template in your project by selecting **Add** &gt; **Existing Item** in **Solution Explorer**. 

For more information about how to create alternates, see [Alternates](Alternates).
