Sometimes you may need to persist some global settings 
(eg. license code, service login, default width etc.)
to be reused across your module. Orchard makes it really 
simple and I'll show you how to do it.

Basically, there are two scopes you can define your settings in:

1. **Site scope** - for global site settings.
2. **Content type scope** - for settings common to all items of a given type
(eg. a Page, a Blog, a BlogPost and so on).

##Defining site scope settings (Orchard 1.8 Onwards)

Orchard 1.8 drastically simplifies creation of site settings, removing the previous need for "Part Records" and migration files. To create new site settings for your module you now only need three classes; A ```ContentPart```, a ```Handler``` and potentially a view file if you want the settings to be edited via the "Site Settings" area of Admin. For a real world example look for the ```RegistrationSettingsPart```, ```RegistrationSetttingsPartHandler``` and ```Users.RegistrationSettings.cshtml``` files in the ```Orchard.Users``` module.

###The Content Part

    public class ShareBarSettingsPart : ContentPart {
        public string AddThisAccount {
            get { return this.Retrieve(x=> x.AddThisAccount); }
            set { this.Store(x=> x.AddThisAccount, value); }
            }
        }

###The Handler

    [UsedImplicitly]
    public class ShareBarSettingsPartHandler : ContentHandler {
        public ShareBarSettingsPartHandler() {

            Filters.Add(new ActivatingFilter<ShareBarSettingsPart>("Site"));
            Filters.Add(new TemplateFilterForPart<ShareBarSettingsPart>("ShareBarSettings", "Parts/ShareBar.ShareBarSettings", "Modules"));
        }
    }
    
###The View

    @model Szmyd.Orchard.Modules.Sharing.Models.ShareBarSettingsPart
    <fieldset>
        <legend>@T("Content sharing settigs")</legend>
        <div>
            @Html.LabelFor(m => m.AddThisAccount, @T("AddThis service account"))
            @Html.EditorFor(m => m.AddThisAccount)
            @Html.ValidationMessageFor(m => m.AddThisAccount, "*")
        </div>
    </fieldset>

### Using site scope settings

Accessing your site setting is a simple one liner:
    
    var shareSettings = _services.WorkContext.CurrentSite.As<ShareBarSettingsPart>();

Where _services is the `IOrchardServices` object (eg. injected in the constructor).

## Defining site scope settings (Pre-Orchard 1.8)

Defining custom site scope settings for before Orchard 1.8 can be in [Adding Custom Settings pre Orchard 1.8](Adding-Custom-Settings-pre-1.8)


## Defining settings for Content Types

We're now going to create settings and defaults wired with specific content type (like Page, User, Blog etc.).

This looks much different comparing to the previous one, but also requires less coding.
There are just two classes and one shape involved and that's all.
As before, we'll use the simplified examples taken from the
[Orchard Sharing](http://orchardsharing.codeplex.com/) project.

The goal:
> "I want all of my Blog Posts to have ShareBar with the same look."

Imagine that you're writing posts via LiveWriter (like me).
Do you want to log in and edit every post after publishing just to change the share bar?
I don't. I want to have it defined upfront.

The first thing you have to do is to create a class holding your settings:

    public class ShareBarTypePartSettings {
        public ShareBarMode Mode { get; set; }
        public IEnumerable<dynamic> AvailableModes { get; set; }
    }


This class has one property - `Mode`, which holds the default mode for all ShareBarParts
attached to some content items of a given type.
`ShareBarMode` is just an enum type defining the display modes.
For the sake of brevity, I won't paste the code here.
This could be any type you want.
The second property is just used for the display purposes (holds items for display in drop-down list),
as this class is also used as a ViewModel. It is not being persisted.

The second class can be thought of as a kind of a driver for the settings.
It's not the Orchard ContentDriver we wrote previously, but also it's responsible
for rendering the edit form and saving the posted data:
    
    public class ShareBarSettingsHooks : ContentDefinitionEditorEventsBase {
        public override IEnumerable<TemplateViewModel> TypePartEditor(
            ContentTypePartDefinition definition) {
            
            if (definition.PartDefinition.Name != "ShareBarPart") yield break;
            var model = definition.Settings.GetModel<ShareBarTypePartSettings>();
    
            model.AvailableModes = Enum.GetValues(typeof(ShareBarMode))
                .Cast<int>()
                .Select(i =>
                    new {
                        Text = Enum.GetName(typeof(ShareBarMode), i),
                        Value = i
                    });
    
            yield return DefinitionTemplate(model);
        }
    
        public override IEnumerable<TemplateViewModel> TypePartEditorUpdate(
            ContentTypePartDefinitionBuilder builder,
            IUpdateModel updateModel) {
            
            if (builder.Name != "ShareBarPart") yield break;
    
            var model = new ShareBarTypePartSettings();
            updateModel.TryUpdateModel(model, "ShareBarTypePartSettings", null, null);
            builder.WithSetting("ShareBarTypePartSettings.Mode",
                ((int)model.Mode).ToString());
            yield return DefinitionTemplate(model);
        }
    }

This class overrides the `ContentDefinitionEditorEventsBase` which defines two overridable methods:
`TypePartEditor` and `TypePartEditorUpdate`.
The first one gets called when the edit form is being rendered (GET) and the second one
when the edit form data gets posted (POST).
Unlike the generic content part drivers, this class is not bound to the specific content type
(as the content types are just a list of names for a collection of parts),
so each of the methods we just defined will be called for every content type and for every part.
This is why the `yield break` statement is used - to filter only the ones containing the part we need, `ShareBarPart`.

By convention, as shown in the TypePartEditorUpdate method, settings should be named as
`<prefix>.<propertyName>` when passing to `builder.WithSetting(...)`,
where `prefix` is the string passed to the updateModel.TryUpdateModel.
`Prefix` can be anything, but has to be unique. Remember though,
when you use string other than your settings class name,
you cannot use `Settings.GetModel<Your_Settings_Type>()`
(as shown in the TypePartEditor method above).
In this case you have to use `Settings.GetModel<Your_Settings_Type>(prefix)` instead.

1. It should be considered best practice to use your settings class name as a `prefix` (as in the code above).
2. Settings are persisted within the content type definition in the db in the string form.
You have to be sure that the properties you define are convertible to and from the string representation.

> Notice the usage of `Enum.GetValues(typeof(someEnum)), Enum.GetNames(typeof(someEnum))`
and `Enum.GetName(typeof(someEnum), i)`.
This methods get very useful when you want to iterate over the names/values of an enum.

If you're done with the code above, there's only one thing left:
creating a .cshtml view (shape) to render our form.

![](http://www.szmyd.com.pl/Media/BlogPs/Windows-Live-Writer/Using-custom-settings-in-Orchard-Part-2-_AE9C/image_thumb.png)

Shapes defining edit forms for content type settings has to be placed under
`/Views/DefinitionTemplates/` with the name `<settingsClassName>.cshtml`.
So in our case it'll look like on the picture above.
Inside, it's just like any other Razor view file:
    
    @model Szmyd.Orchard.Modules.Sharing.Settings.ShareBarTypePartSettings
    <fieldset>
        <div>
            @Html.LabelFor(m => m.Mode, T("Share bar display style"))
            @Html.DropDownListFor(m => m.Mode,
                new System.Web.Mvc.SelectList(
                    Model.AvailableModes, "Value", "Text", (int)Model.Mode))
        </div>
    </fieldset>


This renders the dropdown list so user can choose one of the predefined Modes.
`Model.AvailableModes` contains the available ones: we populated the property with appropriate
data in `TypePartEditor` method above.

Hooray, we're done!

Now you possibly wonder, where will this edit form be shown?
Orchard will render settings form when you'll try to edit the content type containing your part.
The steps are like this: `Content Types -> Edit the type you want -> Add your part -> Voila!`
There is a nice arrow image next to your part. If you click it - the form shows.

![](http://www.szmyd.com.pl/Media/BlogPs/Windows-Live-Writer/Using-custom-settings-in-Orchard-Part-2-_AE9C/image_thumb_4.png)


## Using settings for content type

As for site-scoped settings, this section is also a one-liner.
The part below is some content part (in this case a ShareBarPart from the
[Orchard Sharing](http://orchardsharing.codeplex.com/) project).
    
    var typeSettings = part.Settings.GetModel<ShareBarTypePartSettings>();

You can retrieve and use the settings wherever you have access to your part
(particularly in the driver Display/Editor methods, but also shapes, handlers and so on).
I used it in the ShareBarPart driver Display method to change the look of a share bar part.
