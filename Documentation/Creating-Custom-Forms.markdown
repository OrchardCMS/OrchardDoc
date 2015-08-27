> **Deprecated:** This module is deprecated as of v1.9. We recommend you use the `Orchard.DynamicForms` module instead.

The Custom Forms module is used to capture information from site visitors on the front end.  Custom Forms works in combination with a Content Type.  Custom Forms can be used to create *Contact Us* and *Subscribe* widgets/pages to name a couple. The information is then stored in Orchard and can be exported later.

### Enable the Custom Forms Module ###

The Custom Forms module works in combination with a Content Type to capture input on the front-end.  The information submitted is stored and can be exported using the Import-Export-Module.  Let's start by enabling the Custom Forms module that is shipped with Orchard by going to the Modules section in the admin.

![Enabling Custom Forms in Orchard CMS](../upload/custom-forms/enable-custom-forms.png "Enable the Custom Forms module")

Once the module has been enabled the feature can be browsed to in the admin with the new **Forms** link in the left hand navigation.

As stated before, the Custom Forms module works with a content type in order to create submission forms on the front-end of the site.  In the *Forms* section of the admin, if the button *Add a new Custom Form* were selected, a drop-down list in the next screen for the content types will show all of the default content types that exist currently in the CMS. However, let's say we are looking to add a new widget that will live in the right rail (AsideSecond zone) that is a call for visitors to join a mailing list.  The only input that will be captured will be the users email address.

### Create a New Content Type ###

In order for Custom Forms to capture and save an email address from a visitor we need to create a new content type in Orchard.  In the admin, browse to the *Content Types* tab and select the *Create new type* button in the upper right. (NOTE: the *Content Types* tab is located in the content area for version 1.6 and lower or by selecting the *Content Definition* link in the admin for version 1.7 and higher.  Let's call the new type 'Subscribe Form'.

![Subscribe Form content type](../upload/custom-forms/custom-forms-new-content-type-subscribe-form.png "New Orchard CMS content type")

The next screen asks if we'd like to save any Parts to the new *Subscribe Form* content type.  Since all we are looking to capture is an email address, click on the save button without selecting any of these options.  Now that we have our new content type we'll want to add an **input field** for the email.

![Subscribe Form email field](../upload/custom-forms/subscribe-form-email-field.png "Add Email input field the Subscribe Form content type")

After adding and saving the input field with the name 'Email' we can now customize the type of validation the new input field should have by selecting an input type of 'Email'.  Feel free to fill in the other information for the field as well.

![Subscribe Form](../upload/custom-forms/subscribe-form.png "Subscribe Form content type")

At this point we have all the pieces we need to create out new widget in the right rail (AsideSecond zone).  We've enabled the *Custom Forms* module and we've created a new content type (Subscribe Form) that will be used to capture the email address of visitors looking to enroll in the mailing list.  All that's left is to create the Widget.

### Create a Custom Forms Widget ###

 Select **Widgets** in the left menu of the admin and find the appropriate *Add* button for the AsideSecond zone and add a Custom Forms Widget.

![Add Widget to AsideSecond](../upload/custom-forms/subscribe-form.png "Add new Widget to AsideSecond zone")

The only thing left to do is to adjust the settings on our new *Custom Forms Widget*.  In this example, the [layer](Managing-widgets#AddingaLayer) is set to 'Default' and the position is set to '1'.  This will render the widget on the top of the right rail (AsideSecond zone) for all pages.  These are some example settings:

![Custom Forms Widget](../upload/custom-forms/news-letter-widget.png "Custom Forms Widget")

After saving the widget browse to a page on the site and check out the new feature!

![Page view with new widget](../upload/custom-forms/page-view.png "Page view with new widget")


**NOTE**: If the input field for the owner is visible remove it by un-checking the 'Show editor for owner' option under the Common part of the Subscribe Form content type.
![Common Part](../upload/custom-forms/remove-owner.png "Remove owner option from Common Part")

### View Submitted Custom Forms Data ###

At this point, we have enabled the Custom Forms module, created a new content type for the Custom Forms to use and added a Custom Forms widget to draw the Subscribe Form content type in the right rail (AsideSecond zone) of all the pages.  The submissions are being saved in Orchard because the option in the Custom Forms widget 'Save the item once the form is submitted' was checked.  So where are they being saved?  There are two ways to see the submissions in the CMS.  The first is to select the 'Forms' link on the left in the admin section of Orchard. 

![Custom Forms Admin Page](../upload/custom-forms/custom-forms.png "Custom Forms submissions can be viewed by selecting the submissions link")

The second being to view the Subscribe Form content type.

![Subscribe Form Content Type](../upload/custom-forms/subscribe-form-entries.png "Custom Forms viewed by content type - Subscribe Form")

### Export Custom Forms Data ###

The only thing left to do is to export our list of submissions so that the email addresses can be used by services like Publicaster, Campaign Monitor, MailChimp and the like.  The easiest way to export anything and everything from the Orchard CMS is to use the Import/Export module.  The Import/Export module is shipped with Orchard by default in version 1.6 and on but is not enabled by default.  Let's enable the Import/Export module.

![Import/Export module](../upload/custom-forms/import-export-enabled.png "Enable the Import/Export module")

The Import/Export functions are now available in the admin via the left navigation.  Selecting the 'Export' tab at the top of the Import/Export section of the admin shows all of the available content types in Orchard.  To export the list of emails that have been submitted check the box next to the **Subscribe Form** content type.  Towards the bottom of the page there are a few options for export.  The first option, **Metadata**, will include the definition of the content type.  One use for this option would be an easy way to copy a content type and it's records from one Orchard CMS site to another.  A prime example of this would be to move a new content type and data from a development site to a production site.  When importing an XML file that contains both the metadata and data, Orchard will create the content type copy in the included data.  

In the current situation we are only interested in exporting the data so there is no need to check the Metadata option.  Also, be sure to bullet 'Draft Only' since none of the items submitted from the front end would have a published state.

![Export the Subscribe Form content](../upload/custom-forms/export.png "Export the emails by checking the Subscribe Form content type")

The exported file is and XML file that can be opened in MS Excel and manipulated to be made ready for the email campaign platform of your choice.  And that's it... The site is now able to collect visitor's email addresses and save them for export later for a newsletter.  The Custom Forms is also a great way to implement a Contact Us page or any other number of types of information a site should collect from it's users.
