
Orchard is a modular web-based CMS that's designed to be extended by installing additional module packages and by enabling features contained in those modules. A module package consists of a ZIP file in the [.nupkg](http://nuget.codeplex.com) format. In Orchard, a theme is also a module. To facilitate sharing for modules and themes, Orchard lets you search for modules and themes online and install them directly to your site.

## Browsing the Gallery Web Site
To find available modules and themes and download them to your computer, you can browse the [Orchard Gallery](http://orchardproject.net/gallery) website.  For more information, see [Browsing the Gallery Website](Browsing-the-gallery-web-site).

## Installing Modules and Themes from the Gallery
You can also access the Gallery from within your Orchard site in order to download or install modules and themes. To do so, click **Themes** or **Modules** on the dashboard and then click the **Gallery** tab.  

> **Note:**  The **Gallery** feature is enabled by default. For more information about working with the **Gallery** feature, including how to enable or disable it, see [Installing Modules and Themes from the Gallery](Installing-modules-and-themes-from-the-gallery).

## Contributing a Module or Theme to the Gallery
If you are a developer who writes modules or themes for Orchard, you are probably interested in sharing your module with others in the gallery. For information about how to do this, see [Contributing a Module or Theme to the Gallery](Contributing-a-module-or-theme-to-the-gallery).

## Registering Additional Gallery Feeds
The Orchard Gallery is just one gallery that you can browse. By default, a single feed is exposed from [http://orchardproject.net/gallery/server/FeedService.svc](http://orchardproject.net/gallery/server/FeedService.svc/Packages). Orchard allows you to register additional feeds for other galleries. To register a feed, expand the dashboard **Settings** section and then click **Gallery**.  On the **Gallery Feeds** page you can add new feeds or delete existing ones. For more information, see [Registering Additional Gallery Feeds](Module gallery feeds).

If you want to set up your own gallery, a reference implementation for exposing a gallery feed and website is available on [OrchardGallery.CodePlex.com](http://orchardgallery.codeplex.com) and [GalleryServer.CodePlex.com](http://galleryserver.codeplex.com).  
  
  
  

# Change History
* Updates for Orchard 1.1
    * 3-22-11: Updated dashboard and UI references in the text. 
