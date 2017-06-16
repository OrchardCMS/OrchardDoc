!!! attention "ARCHIVED"
    This chapter has not been updated for the current version of Orchard, and has been ARCHIVED.

##Adding Custom Settings pre Orchard 1.8
This document traces the process of defining and implementing and individual site setting for a live orchard module that can be added to your site to enable the webservice known as 'AddThis' [Content Sharing](http://orchardsharing.codeplex.com/)

The specific goal being **"to store my AddThis service login credentials so that all share bars across the site will be able to access my account"**

The first thing to understand is that our site setting is really just another form of the basic Orchard building blocks - the ContentPart/ContentPartRecord. While most ContentParts render visual elements to the site's visitor, they can also deliver non-visible chunks of data that can provide dynamic functionality to your pages. A great introduction to the construction of content types can be found 
[found here](http://www.szmyd.com.pl/blog/jumpstart-into-orchard-module-development)):
    
    public class ShareBarSettingsPart : ContentPart<ShareBarSettingsPartRecord> {
        public string AddThisAccount {
            get { return Record.AddThisAccount; }
            set { Record.AddThisAccount = value; }
            }
        }

When you create a Content Type you will almost always find yourself also creating a ContentTypeRecord which can be thought of as creating a new field in the database for storing the ContentType values.
    
    public class ShareBarSettingsPartRecord : ContentPartRecord {
        public virtual string AddThisAccount { get; set; }
    }

You can also decorate the content part AddThisAccount property with `[Required]` attribute
to make it a required field when editing site settings.

After creating the content part and record classes, you need to create appropriate
database mappings, called in Orchard - **Data Migration**.
You shouldn't do it by hand: there is a command-line,
`codegen datamigration <feature_name>`, which will create the appropriate file for you.
You can see how to use it [here](Using-the-Command-Line-Interface).

The next step is to create a corresponding driver, which will be responsible for displaying the editor that the end-user invokes when setting the posted values.
If you have already written some content parts, than this part of code should look familiar:

    [UsedImplicitly]
    public class ShareBarSettingsPartDriver :
        ContentPartDriver<ShareBarSettingsPart> {

        public ShareBarSettingsPartDriver(
            INotifier notifier,
            IOrchardServices services) {
                _notifier = notifier;
                T = NullLocalizer.Instance;
           }
    
        public Localizer T { get; set; }
        private const string TemplateName = "Parts/Share.Settings";
        private readonly INotifier _notifier;
    
        protected override DriverResult Editor(
            ShareBarSettingsPart part, dynamic shapeHelper) {

            return ContentShape("Parts_Share_Settings",
                       () => shapeHelper.EditorTemplate(
                           TemplateName: TemplateName,
                           Model: part,
                           Prefix: Prefix));
           }
    
        protected override DriverResult Editor(
            ShareBarSettingsPart part, IUpdateModel updater, dynamic shapeHelper) {

            if (updater.TryUpdateModel(part, Prefix, null, null)) {
                _notifier.Information(
                    T("Content sharing settings updated successfully"));
            }
            else {
                _notifier.Error(
                    T("Error during content sharing settings update!"));
            }
            return Editor(part, shapeHelper);
        }
    }

I omitted some code for checking permissions to edit the settings for better readability,
but you are free to take a look at the [full source code hosted on GitHub](https://github.com/OrchardCMS/Orchard).

To review, so far we have our Content Part (plus it's attendant Content Part Record) and this just added driver. Two more structures are required before we can implement our new site-wide property setting:
a Handler (controller) where we define the behavior of our Content Part, and the Shape (view)
that will render the HTML markup for our form's editor. The Handler looks like:
    
    [UsedImplicitly]
    public class ShareBarSettingsPartHandler : ContentHandler {
        public ShareBarSettingsPartHandler(
            IRepository<ShareBarSettingsPartRecord> repository) {

            Filters.Add(new ActivatingFilter<ShareBarSettingsPart>("Site"));
            Filters.Add(StorageFilter.For(repository));
        }
    }


In most cases its just that simple:

1. Add an activating filter. Tells Orchard which of the existing Content Types
our **ShareBarSettingsPart** should be attached to. Because **Site** is also a Content Type,
we can attach our part to it. **Basically, this is the point that differentiates the ordinary
content parts from site settings.**
2. Add the storage filter to register our settings repository - required because we want to be storing records in the database.

So if the above handler can be thought of as a 'controller' the obvious next step is creating the 'view'. Orchard's term is 'shape' and is nothing more than a .cshtml file that combines HTML markup with razor's ability to render database elements.
First, you have to create a .cshtml file under `/Views/EditorTemplates/Parts/`.
This file, as the [naming convention](Accessing-and-rendering-shapes)
informs us, should be named `Share.Settings.cshtml`.
This name corresponds to the `Parts_Share_Settings` shape used inside the driver above.

![](http://www.szmyd.com.pl/Media/BlogPs/Windows-Live-Writer/804b787519c9_1126C/image_thumb.png)

We've got only a single field (AddThisAccount) in our settings, so the markup inside
the `Share.Settings.cshtml` file will look like this:
    
    @model Szmyd.Orchard.Modules.Sharing.Models.ShareBarSettingsPart
    <fieldset>
        <legend>@T("Content sharing settigs")</legend>
        <div>
            @Html.LabelFor(m => m.AddThisAccount, @T("AddThis service account"))
            @Html.EditorFor(m => m.AddThisAccount)
            @Html.ValidationMessageFor(m => m.AddThisAccount, "*")
        </div>
    </fieldset>

Next, we need to tell Orchard where in the `Site -> Settings` pane our form should be displayed. 
To do this we create a `Placement.info` file in our module root:
    
    <Placement>
        <Place Parts_Share_Settings="Content:0"/>
    </Placement>

which tells Orchard to display our form field at the beginning.

Now that we've configured our settings we will look at what it takes to actually _use_ them.

## Using site scope settings

This part is basically a one-liner:
    
    var shareSettings = _services.WorkContext.CurrentSite.As<ShareBarSettingsPart>();

Where _services is the `IOrchardServices` object (eg. injected in the constructor).
Please note that you have to include "using Orchard.ContentManagement;" on the class.
Simple, isn't it? The full (simplified for readability) example from the ShareBarDriver
from [Content Sharing](http://orchardsharing.codeplex.com/) module:

    [UsedImplicitly]
    public class ShareBarPartDriver : ContentPartDriver<ShareBarPart> {
        private readonly IOrchardServices _services;
    
        public ShareBarPartDriver(IOrchardServices services) {
            _services = services;
        }
    
        protected override DriverResult Display(
            ShareBarPart part, string displayType, dynamic shapeHelper) {

            var shareSettings = _services.WorkContext.CurrentSite
                .As<ShareBarSettingsPart>();
    
            // Prevent share bar from showing if account is not set
            if (shareSettings == null ||
                string.IsNullOrWhiteSpace(shareSettings.AddThisAccount)) {

                return null;
            }
            
            return ContentShape("Parts_Share_ShareBar",
                () => shapeHelper.Parts_Share_ShareBar(
                    Account: shareSettings.AddThisAccount));
        }
    }
