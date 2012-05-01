> This topic has been updated for the Orchard 1.4 release.

Data access in an Orchard project is different than data access in a traditional web application, because the data model is built through code rather than through a database management system. You define your data properties in code and the Orchard framework builds the database components to persist the data. If you need to change the data structure, you write code that specifies the changes, and those changes are then propagated by that code to the database system. This code-centric model includes layers of abstraction that permit you to reuse components in different content types and to add or change behaviors without breaking other layers.

The key concepts of data access are the following:

* Records
* Data migrations
* Content handlers
* Content drivers

## Records
A record is a class that represents the database schema for a content part. To create a record, you define a class that derives from `ContentPartRecord` and add the properties that you need in order to store data for the content part. Each property must be virtual. For example, a `Map` part might include the following record:

    
    namespace Map.Models {
        public class MapRecord : ContentPartRecord {
            public virtual double Latitude { get; set; }
            public virtual double Longitude { get; set; }
        }
    }


Typically, the record class resides in a folder named Models. The parent class, `ContentPartRecord`, also includes a property named `id` and a reference to the content item object. Therefore, an instance of the `MapRecord` class includes not just `Latitude` and `Longitude` but also the `id` property and the content item object that is used to maintain the relationships between the part and other content.

When you define a content part, you use the record as shown below:

    
    namespace Map.Models {
        public class MapPart : ContentPart<MapRecord> {
            [Required]
            public double Latitude
            {
                get { return Record.Latitude; }
                set { Record.Latitude = value; }
            }
    
            [Required]
            public double Longitude
            {
                get { return Record.Longitude; }
                set { Record.Longitude = value; }
            }
        }
    }


Notice that only data that's relevant to the part is defined in the `MapPart` class. You do not define any properties that are needed to maintain the data relationships between `MapPart` and other content.

For a complete example of the MapPart, see [Writing a Content Part](Writing-a-content-part).

## Data Migrations
Creating the record class does not create the database table; it only creates a model of the schema. To create the database table, you must write a data migration class.

A data migration class enables you to create and update the schema for a database table. The code in a migration class is executed when an administrator chooses to enable or update the part. The update methods provide a history of changes to the database schema. When an update is available, the site administrator can choose to run the update.

You can create a data migration class by running the following command from the Orchard command line:

    
    codegen datamigration <feature_name>


This command creates a _Migrations.cs_ file in the root of the feature. A `Create` method is automatically created in the migration class. In the `Create` method, you use the `SchemaBuilder` class to create the database table, as shown below for the `MapPart` feature.

    
    namespace Map.DataMigrations {
        public class Migrations : DataMigrationImpl {
    
            public int Create() {
                // Creating table MapRecord
    			SchemaBuilder.CreateTable("MapRecord", table => table
    				.ContentPartRecord()
    				.Column("Latitude", DbType.Double)
    				.Column("Longitude", DbType.Double)
    			);
    
                ContentDefinitionManager.AlterPartDefinition(
                    typeof(MapPart).Name, cfg => cfg.Attachable());
    
                return 1;
            }
        }
    }


By including `.ContentPartRecord()` with your properties in the definition of the database schema, you ensure that other essential fields are included in the table. In this case, an `id` field is included with `Latitude` and `Longitude`.

The return value is important, because it specifies the version number for the feature. You will use this version number to update the schema.

You can update the database table by adding a method with the naming convention `UpdateFromN`, where _N_ is the number of the version to update. The following code shows the migration class with a method that updates version by adding a new column.

    
    namespace Map.DataMigrations {
        public class Migrations : DataMigrationImpl {
    
            public int Create() {
                // Creating table MapRecord
    			SchemaBuilder.CreateTable("MapRecord", table => table
    				.ContentPartRecord()
    				.Column("Latitude", DbType.Double)
    				.Column("Longitude", DbType.Double)
    			);
    
                ContentDefinitionManager.AlterPartDefinition(
                    typeof(MapPart).Name, cfg => cfg.Attachable());
    
                return 1;
            }
            
            public int UpdateFrom1() {
                SchemaBuilder.AlterTable("MapRecord", table => table
                    .AddColumn("Description", DbType.String)
               );
                return 2;
            }
    
        }
    }


The update method returns 2, because after the column is added, the version number is 2. If you have to add another update method, that method would be called `UpdateFrom2()`.

After you add the update method and run the project the module will be silently & automatically upgraded.

## Content Handlers
A content handler is similar to a filter in ASP.NET MVC. In the handler, you define actions for specific events. In a simple content handler, you just define the repository of record objects for the content part, as shown in the following example:

    
    namespace Map.Handlers {
        public class MapHandler : ContentHandler {
            public MapHandler(IRepository<MapRecord> repository) {
                Filters.Add(StorageFilter.For(repository));
            }
        }
    }


In more advanced content handlers, you define actions that are performed when an event occurs, such as when the feature is published or activated. For more information about content handlers, see [Understanding Content Handlers](Understanding-content-handlers).

## Content Drivers
A content driver is similar to a controller in ASP.NET MVC. It contains code that is specific to a content part type and is usually involved in creating data shapes for different conditions, such as display or edit modes. Typically, you override the **Display** and **Editor** methods to return the **ContentShapeResult** object for your scenario.

For an example of using a content driver, see [Accessing and Rendering Shapes](Accessing-and-rendering-shapes).
