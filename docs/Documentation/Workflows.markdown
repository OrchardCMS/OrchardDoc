*This topic targets, and was tested with, the Orchard 1.8 release.*

<br/>

The **Orchard.Workflows Module** in Orchard provides us tools to create custom workflows for events or activities like **Content Created, Content Published, Content Removed, Send Email, Timer** and many more.  

*Dependencies : Orchard.Tokens, Orchard.Forms, Orchard.jQuery*

![](/Upload/workflows/workflowsmodule.PNG)

In this particular demo , we'll be creating a **Contact us Email Notification Workflow**. The **Orchard.EmailMessaging** Module needs to be enabled in order to send email notifications using the **Orchard.Workflows** Module.

## Email.Messaging

*Learn how to [Configuring Email](/Documentation/Configuring-Email)*

![](/Upload/workflows/emailmodule.PNG)

## Custom Form

*Learn how to [Creating Custom Content Types](/Documentation/Creating-custom-content-types)*

*Learn how to [Create Custom Forms](/Documentation/Creating-Custom-Forms "Use Custom Form to create subscribe and contact us pages in Orchard")*

![](/Upload/workflows/contactform.PNG)

## Workflows Demo

**1.** **Creating Workflow**

![](/Upload/workflows/createnewworkflow.PNG)

**2.** **Contact Us Email Notification Workflow**

![](/Upload/workflows/contactnotification.PNG)

**3.** **Editing Contact Us Email Notification Workflow**

![](/Upload/workflows/workflowcreated.PNG)

**4.** **Workflow Starting State**

*The workflow needs at least one activity to be set as a starting state.*

![](/Upload/workflows/workflowstartingstate.PNG)

**5.** **Editing Workflow Activity (Form Submitted)**

![](/Upload/workflows/editingworkflowactivity.PNG)

**6.** **Adding a Timer Activity**

*The Timer Activity adds a delay so that the processing thread doesn't get blocked*

![](/Upload/workflows/addingtimer.PNG)

**7.** **Editing Timer Activity**

![](/Upload/workflows/editingtimer.PNG)

**8.** **Adding Send Email Activity**

![](/Upload/workflows/addingsendemail.PNG)

**9.** **Editing Send Email Activity**

*Using Tokens to access the form posted values by the end-user*

	New Contact Request by {Content.Fields.ContactUs.Name}

	<p>New Contact Request by {Content.Fields.ContactUs.Name}</p>

	<p>Email : {Content.Fields.ContactUs.EmailAddress}</p>

	<p>Message : {Content.Fields.ContactUs.Message}</p>

![](/Upload/workflows/editingsendemail.PNG)

**10.** **Submitting Form**

![](/Upload/workflows/submittingform.PNG)

**11.** **Workflow Running**

![](/Upload/workflows/workflowrunning.PNG)

**12.** **Blocking Activity**

*The timer (Blocking Activity) has a delay period of 2 mins*

![](/Upload/workflows/blockingactivity.PNG)

**13.** **Contact Us Email Notification Sent**

![](/Upload/workflows/emailsent.PNG)

![](/Upload/workflows/emailsent1.PNG)

*for more on Workflows browse to the [Orchard Tutorials Area](/Documentation/Orchard-TV)*
