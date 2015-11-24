Configuring Email
=================
Configuring Orchard to send email is done by enabling the **Email Messaging** module and adding the proper email settings. The Email Messaging module adds Email sending functionalities. This document will talk about setting up Orchard to be able to send emails using the localhost.

## Required Module ##

In order for Orchard to be able to send emails; The *Email Messaging* Module needs to be enabled.

![Orchard CMS Messaging modules](../Upload/Messaging/Messaging-Modules.PNG)

Click **Enable**

![Orchard CMS Messaging modules enabled](../Upload/Messaging/Messaging-Enabled.PNG)

## Configuring Email SMTP Settings ##

Once the *Email Messaging* module has been enabled the email settings can be configured.  To configure the email settings in Orchard, select 'Email' under the Settings section of the admin.

![Orchard CMS Email Settings Navigation](../Upload/Messaging/Email-Settings.PNG)

Emails can be sent from the local host with the below settings (be sure to replace the from address with an appropriate email address).

![Orchard CMS Messaging modules](../Upload/Messaging/Email-Settings-Updated.PNG)

And that's it!  Well, mostly...  Orchard is capable of sending emails now but how do we tell it to send email?  There's different reasons when it would be desirable for emails to be sent, one such reason would be when a new message is received from a site's *Contact Us* page.  Read how to create a [custom form](Creating-Custom-Forms "Custom Forms Module") and then use a rule or the new *Work Flow* to have Orchard send an email.

Change History
--------------

* Updates for Orchard 1.8
    * 9-8-14: Updated screen shots for email messaging module