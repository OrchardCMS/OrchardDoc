> Draft topic 

This document targets Orchard developers. Using only the admin dashboard, you will create a gallery that renders thumbnails of images that you select from the Media folder. Afterward, you can customize the gallery with CSS and an alternate HTML template.

# Create the Image Gallery Content Type

- From the admin dashboard, click **Content Definition**.
- The Manage Content Types page will open.
- Click **Create new type**.
- Give the new type a Display Name (e.g. *My Image Gallery*).
- Click **Create**.

![New content type](/Attachments/Creating-an-image-gallery/new-content-type.jpg)

- When you click create, Orchard will open the Add Parts page.
- Check **Widget**, then click **Save**.
- The Edit Content Type page will now show.
- Change the **Stereotype** to Widget and click **Save**.
- Then click **Add Field**.
- The Add New Field page will open.
- Choose **Media Library Picker Field**.
- Name the field (e.g. *My Media Library Picker Field*.)
- Click **Save**.

![Add a new field](/Attachments/Creating-an-image-gallery/add-new-field.jpg)

- After you click save, click on the down carat beside the new field.
- Check "**Allow multiple content items**."
- Click **Save** at the bottom of the page.
- You will now have the following Content Type. It has both a Widget Part and a Media Library Picker Field.

![Finished content type](/Attachments/Creating-an-image-gallery/finished-content-type.jpg)

# Add the Widget a Zone

- From the admin dashboard, click on **Widgets**.
- Click **Add** beside any zone (e.g. BeforeContent.)
- The Choose a Widget page will open.
- Choose the Widget that you just created (i.e. *My Image Gallery*.)
- The Add Widget page will open.
- Give the Widget a Title (e.g. *My Gallery Widget*.)
- Click the **Add** button below the "My Media Library Picker Field" label.
- The Media Library Picker modal will show.

In this screen shot, we have already imported some images and created some folders. You can create folders using the **Create Folder** button. You can import images by opening a folder and clicking the **Import** button. This tutorial assumes you know how to do that.

 ![Finished content type](/Attachments/Creating-an-image-gallery/modal-popup.jpg)

- Select the images that you want to display.
	- Tip: Use ctrl + click to select multiple images at once.
- Then click the **Select** button in the lower left of the modal (it's a bit hidden.)
- The Add Widget page will again display. Click **Save**.
- Visit the front end of your site to see the scaffolding of an image gallery.

# Customize the Look of the Gallery

- Turn on Shape Tracing
- Create an Alternate for the Fields_MediaPickerLibrary
- Edit the HTML and add CSS.
- Here are example alternate templates, courtesy of Bertrand Le Roy's [Codeplex Reply](https://orchard.codeplex.com/discussions/454808) 

Fields.MediaLibraryPicker.cshtml

    @using Orchard.ContentManagement
    @using Orchard.MediaLibrary.Fields
    @using Orchard.Utility.Extensions;    
    @{
    	var field = (MediaLibraryPickerField) Model.ContentField;
    	string name = field.DisplayName;
    	var contents = field.MediaParts;
    }
    <section class="media-library-picker-field media-library-picker-field @name.HtmlClassify()">
    @foreach(var content in contents) 
	{
   	 	<div>
    		@Display(BuildDisplay(content, "Summary"))
    	</div>
	}
    </section>

Media.Summary.cshtml
    
    @using Orchard.MediaLibrary.Models
    @using Orchard.Utility.Extensions;
    @{
    	MediaPart mediaPart = Model.ContentItem.MediaPart;
    }
    <a href="@mediaPart.MediaUrl">
    <img 
		src="@Display.ResizeMediaUrl(Width: 200, Height: 200, Mode: "crop", 	Alignment: "middlecenter", Path: mediaPart.MediaUrl)" 	
		alt="@mediaPart.Caption" class="thumbnail"/>
    </a>