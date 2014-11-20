> This topic has been updated for the Orchard 1.1 release.

In Orchard, a _widget_ is a piece of reusable UI that can be arbitrarily positioned on the pages of a web site. Examples of widgets could include a tag cloud, a search form, or a Twitter feed. A widget is a content type, which enables you to reuse existing code and UI.

This article describes how to write a widget by first creating a content part and then turning that part into a widget.

# Creating a Content Part
For this example, you will use the `Map` part that is described in [Writing a content part](Writing-a-content-part). If you did not create the `Map` part, do so now. 

# Turning a Part into a Widget
To turn a content part into a widget, you must update the database with your widget's type definition. You do this by adding an `UpdateFrom{version}` method to the part's _Migrations.cs_ file.

The following example shows the `Map` part's _Migrations.cs_ file with the `UpateFrom1` method added.

    
    using System.Data;
    using Maps.Models;
    using Orchard.ContentManagement.MetaData;
    using Orchard.Core.Contents.Extensions;
    using Orchard.Data.Migration;
    
    namespace Maps
    {
        public class Migrations : DataMigrationImpl
        {
            public int Create()
            {
                // Creating table MapRecord
                SchemaBuilder.CreateTable("MapRecord", table => table
                    .ContentPartRecord()
                    .Column("Latitude", DbType.Single)
                    .Column("Longitude", DbType.Single)
                );
    
                ContentDefinitionManager.AlterPartDefinition(typeof(MapPart).Name, cfg => cfg
                    .Attachable());
    
                return 1;
            }
    
            public int UpdateFrom1()
            {
                // Create a new widget content type with our map
                ContentDefinitionManager.AlterTypeDefinition("MapWidget", cfg => cfg
                    .WithPart("MapPart")
                    .WithPart("WidgetPart")
                    .WithPart("CommonPart")
                    .WithSetting("Stereotype", "Widget"));
    
                return 2;
            }
        }
    }
 

In this example, the `UpdateFrom1` method creates `MapWidget` by combining `MapPart`, `WidgetPart`, and `CommonPart`, and then setting the widget stereotype. The `WidgetPart` and `CommonPart` objects are built into Orchard. The method returns 2, which is the new version number.

The part has now been transformed into a widget.

# Displaying the Widget

After you create the new widget, open the Orchard **Dashboard** and click **Widgets**. You can then select the layer and zone where you want to display the widget. The following image shows the **Manage Widgets** page.

![](../Upload/screenshots_675/manage_widgets_675.png)

For information about how to display your widget, see [Managing Widgets](Managing-widgets).

# Sharing Your Widget
To share the widget with others or to upload it to the widget gallery, you first need to package you widget to a module _.zip_ file. This is done the same way any module is packaged in Orchard. For information, see [Packaging and sharing a module](Packaging-and-sharing-a-module).
