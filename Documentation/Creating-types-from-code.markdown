A Content Type is the blueprint for all content.
Content Types are created by combining multiple *Parts*

Creating a Content Type from code can be done from your migrations.cs. We'll use the *AlterTypeDefintion* to create or change a content type definition. The *WithPart* allows us to add multiple parts.

# Creating a Content Type

Here we are creating a simple content type with a title

    ContentDefinitionManager.AlterTypeDefinition("Training", builder =>
        builder
            .WithPart("CommonPart")
            .WithPart("TitlePart")
            .Creatable()
            .Draftable());

# Creating a more Complex Content Type

In this example we are also changing some of the settings of one of the included parts

    ContentDefinitionManager.AlterTypeDefinition("Training", builder =>
        builder
            .WithPart("CommonPart")
            .WithPart("TitlePart")
            .WithPart("AutoroutePart", builder => builder
                .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name:'Title', Pattern: '{Content.Slug}', Description: 'my-blog'}]")
                .WithSetting("AutorouteSettings.DefaultPatternIndex", "0"))
            .WithPart("MenuPart")
            .WithPart("TagsPart")
            .Creatable()
            .Draftable());