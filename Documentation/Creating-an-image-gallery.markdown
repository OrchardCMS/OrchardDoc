> Draft topic 

This document targets Orchard developers who want to create an image gallery.

# Create the Image Gallery Content Type

- Content Definition
- Create new type
- Choose a Display Name (e.g. My Image Gallery)
- Click Create
- Orchard will create the new Content Type
- The Add Parts page will open.
- Check Widget and click Save.
- Orchard will add the Widget part to the Content Type

![New content type](/Attachments/Creating-an-image-gallery/new-content-type.jpg)

- The Edit Content Type page will now show.
- Change the Stereotype to Widget
- Then click Add Field
- Choose Media Library Picker Field
- Name the field (e.g. My Media Library Picker Field)
- Click Save

![Add a new field](/Attachments/Creating-an-image-gallery/add-new-field.jpg)

- Click on the down carat beside the new field
- Check "Allow multiple content items"
- Click Save at the bottom of the page.
- You will now have the following Content Type

![Finished content type](/Attachments/Creating-an-image-gallery/finished-content-type.jpg)

# Add the Image Gallery Content Type to a Zone

- Widgets
- Click Add beside any zone (e.g. BeforeContent)
- The Choose a Widget page will open
- Choose the Widget that you just created (i.e. My Image Gallery)
- The Add Widget page will open
- Give the Widget a Title (e.g. My Gallery Widget)
- Click the Add button below "My Media Library Picker Field"
- The Media Library Picker modal will show

 ![Finished content type](/Attachments/Creating-an-image-gallery/modal-popup.jpg)

In the screen shot, we already have imported some images and created some folders. Create folders using the Create Folder button. Import images by opening a folder and clicking the Import button. This tutorial does not currently cover importing images.

- Select the images that you want to display in the gallery 
- (Use ctrl + click to select multiple images at once)
- Then, click the Select button in the lower left of the modal (it's a bit hidden)
- Orchard will add the images and again show the Add Widget page
- Click Save
- Visit the front end of your site to see the image gallery

# Customize the Look of the Image Gallery with Shape Tracing

- Create a new Alternate using Shape Tracing
- Add CSS
- See also