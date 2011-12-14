When you upload images using the rich-text editor in Orchard
(or using an XML-RPC client, such as [Windows Live Writer](http://explore.live.com/windows-live-writer)),
the images are saved in a _Media_ folder under the root of your Orchard installation.
The _Media_ folder must be writable (by the user process that's running the website) in order
for image uploads to succeed.
If you installed Orchard using the [Web Platform Installer](http://www.microsoft.com/web/downloads/platform.aspx),
the _Media_ folder write permissions are configured automatically.

To add and delete media folders, click **Media** in the dashboard. 

![](../Upload/screenshots_675/manage_media_675.png)

Browse to a media image file and view the details. The properties of a media file are:

* **Screenshot**. A thumbnail preview of the image content.
* **Size** and **Added on**. Properties of the media file.
* **Embed**. The URL of the media file, which you can copy to the HTML view of the rich-text editor
in order to embed the media image into content.
* **Name**. The name of the media file.

![](../Upload/screenshots/edit_media_1.png)

To manage the subfolders for your media folder, click **Media** again on the dashboard.
Then click a folder to display the **Manage Folder** screen. 

![](../Upload/screenshots_675/manage_media_folders_675.png)

This screen gives you the options to add or delete media files and to create subfolders.

Click **Add a folder** to create a new subfolder.

Name the new subfolder (for example, name the subfolder "Pictures") and save it.   

![](../Upload/screenshots_675/manage_folders_add_subfolder_675.png)

Browse to the new subfolder and click **Add media**.

![](../Upload/screenshots_675/add_media_1_675.png)

Orchard lets you upload single media files as well as uploading a _.zip_ file that contains multiple image files.
If you have a large set of images to upload, it can be more efficient to first add them all to a _.zip_ file
and then just upload the _.zip_ file instead of uploading the images one by one. 

To see how this works, create a _.zip_ file on your computer that contains several image files,
and then click **Upload**. The **Extract zip** checkbox is selected by default,
which will cause the uploaded images in the _.zip_ to be extracted and added to the folder.

![](../Upload/screenshots_675/upload_zip_media_675.png)

The uploaded and extracted images are displayed in their parent folder.

![](../Upload/screenshots_675/upload_zip_media_2_675.png)

To see or edit the details of an individual uploaded image, click it. 

![](../Upload/screenshots_675/upload_zip_media_3_675.png)

### Change History
* Updates for Orchard 1.1
    * 3-16-11: Updated all screen shots and menu choices text.
