The definition for content types, as well as the content itself, can be exported from one Orchard instance, and imported into another using this module. The format that is used for the transfer is the same XML format that is used in recipes.  The Import/Export module is shipped with Orchard by default but is also available in the [gallery](https://gallery.orchardproject.net/List/Modules/Orchard.Module.Orchard.ImportExport "Import/Export Module").

## Getting Started ##

The Import/Export module ships with Orchard but it is not enabled by default.  So, the first thing to do is enable the module. Once enabled, a new menu item will appear in the admin section.

![Enable the Import/Export module](../Attachments/Import-Export/Import-Export-enabled.png "Enable the Import/Export Module")

![Import/Export menu](../Attachments/Import-Export/Import-Export-menu.png "Import/Export menu")

## Export ##

The export process has two general questions: What type of content should be exported and of that content type, should the meta data and/or the data be output.  There is also an option that will include the site's settings in the XML file: site settings to an extent can be automatically exported and imported without module authors writing import/export logic for their site settings content parts.  This option is exactly what it sounds like; Any of the information under the settings menu in the admin will be included in the export.

The export process is a good way to copy the content structure from one Orchard instance to another.  A good example of that may be from a development site to a production site.  For example, let's say we want to create a new blog and add entries to the new blog on a dev site.  After all the powers that be have reviewed the blog and it's posts, all that information should then be pushed to the production site.  The Import/Export module is perfect for this.  But be warned, when exporting from a site and importing to another, the existing records may be updated.  We'll get into that in a bit.

Another example would be when creating a new content type on a dev site or local development machine and that new content type needs to be added to another instance of Orchard (or vise-verse).  One such situation could be where an account team member is ready to start entering copy but the site is not ready. In this case an empty version of Orchard could be created for them to enter content while the developer is still working on the site.  The developer would know what type of information needs to be entered ahead of time and can create the part on his/her development machine and export that content type to the dev site for the other team members to begin entering copy.  So while the developer is working on the main site, other team members are entering the copy in a different instance of Orchard.  Once the account team has entered all their copy, that information can be exported and imported into the proper instance of Orchard.

The export can also be used as a poor man's backup as well.  Simply exporting the data will provide a small XML file that can be kept in a safe location.

### When Existing Content is Updated ###

The export attempts to create individual ID's on each data item that it exports (a data item being a single content type record like a page or a blog post).  **The ID is used during the import process to find a match on an existing record.**  This way duplicates are not created and any existing items are updated with changes that have occurred to the data for a particular item.  The first way the ID is generated is using the Autoroute part.  The ID is further strengthened with the addition of the Identity part. The Identity part automatically generates a unique identity for the content item, which is required in import/export scenarios where one content item references another.

**If a Content Type does not have the Autoroute part or the Identity part no ID is given, Orchard will try to find a match based on date stamps, otherwise each import will insert the records as if they do not exist.**

## Import ##

The import process is quite simple.  In the import tab, select the XML file to be imported and click the *Import* button.  Orchard begins to process the file by first looking for metadata that contains any new content types or changes to existing content types and processes those.  It then looks for any data that has been included and processes that.

If there are any site settings included in the XML file those are also processed and applied.
