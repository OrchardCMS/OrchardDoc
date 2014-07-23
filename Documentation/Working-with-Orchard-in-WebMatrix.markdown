
وب ماتریکس (http://www.microsoft.com/web/webmatrix/)  یک ابزار توسعه وب سایت ، که امکان ایجاد، ویرایش، و انتشار وب سایت را با سهولت فراهم می کند.
وب ماتریکس شامل یک وب سرور (IIS Express) همراه با یک ویرایشگر ساده برای ویرایش و سفارشی کردن برنامه های کاربردی مانند اورچارد . هنگام نصب اورچارد بوسیله وب پلتفرم شما گزینه ای برای نصب وب ماتریکس دارید بجای iis.
.
نصب و راه اندازی WebMatrix 
برای راه اندازی مایکروسافت وب پلت فرم آنرا دانلود ، سپس بر روی دکمه Add کلیک کنید و با کلیک بر روی نصب ماکروسافت وب ماتریکس را نصب نمایید.
دانلود و راه اندازی مایکروسافت وب پلت فرم
با قبول شرایط و راه اندازی وب ماتریکس فرایند نصب به پایان می رسد.

استفاده از وب ماتریکس برای ایجاد یک وب سایت اورچارد
برای ایجاد یک وب سایت اورچارد بوسیله وب ماتریکس در صفحه راه اندازی وب ماتریکس بر روی App Gallery کلیک نمایید.

![](../Upload/screenshots/Install_selectorWebMatrix.png)

![](../Upload/screenshots_675/webmatrix_select_orchard_675.png)

از قسمت پایین Orchard CMS را انتخاب نمایید. یک نام وارد نمایید به عنوان پوشه ای برای سایت شما مورد استفاده قرار می گیرد.برای مثال، اگر شما نام “Orchard cms”  را وارد نمایید، پوشه ای به این نام در مسیر زیر ساخته می شود. "Documents/My Websites/Orchard CMS" . بر روی دکمه Next کلیک نمایید.

Click **I Accept** to accept the EULA agreement

با کلیک بر روی I Accept  موافقت خود را با قوانین اعلام نمایید.

![](../Upload/screenshots_675/webmatrix_orchard_eula_675.png)

پوشه فایل سایت شما به زیرمجموعه "Orchard CMS" اضافه می شود. بر روی ok کلیک نمایید. پس از این مرحله سایت اورچارد شما خود در وب ماتریکس باز خواهد شد و صفحه تنظیمات اورچارد در یک مرورگر جدید راه اندازی می شود.

![](../Upload/screenshots_675/webmatrix_orchard_project_675.png)

اطلاعات عمومی در مورد سایت خود را در صفحه راه اندازی اورچارد وارد نمایید.
به طور خاص: نام سایت ، نام یک کاربر سایت ، رمز عبور، یک نوع دیتابیس برای داده های سایت و دستورالعمل اورچارد(Orchard recipe).


If you are just starting out using Orchard, we recommend that you select **SQL Compact Server** for the database and **Default** for the recipe. Enter the information and click **Finish Setup**.

![](../Upload/screenshots/setup_new_site.png)

![](../Upload/screenshots_675/webmatrix_finish_setup_675.png) 

Orchard sets up your initial site and then opens a browser window with the site's home page.  You will automatically be logged in with the user name you specified in setup (in this case, *admin*).  At this point, clicking on **Dashboard** 
will take you to the [Orchard Dashboard](Getting-around-the-dashboard) where website changes can be made.

![](../Upload/screenshots_675/new_default_site_675.png) 

## Running your website from Web Matrix

At any point in time, you can run your website from WebMatrix by selecting the project node and clicking **Run**.

![](../Upload/screenshots/webmatrix_run.png)

## Working with Files

You can use WebMatrix to edit the files in your Orchard installation. WebMatrix provides a simple editor that includes colorization for HTML, CSS, JavaScript, and code files. 

Although WebMatrix does not provide a build system for compiling code files, Orchard itself provides dynamic compilation for code files when they are edited. For more information, see [Orchard Dynamic Compilation](Orchard-module-loader-and-dynamic-compilation).

![](../Upload/screenshots_675/webmatrix_files_675.png)

You can change the editor WebMatrix uses by following these [instructions](http://sybak.com/blog/2011/02/changing-the-file-types-that-open-with-webmatrix/). 
 
As an example, you may find it helpful to use the XML editor (which provides colorization) on the placement.info file.  To do this you must change the setting for *.info* files in the WebMatrix file **filetypes.xml** (which can be found in the following locations):

    32-bit machines: C:\Program Files\Microsoft WebMatrix\config\filetypes.xml
    64-bit machines: C:\Program Files (x86)\Microsoft WebMatrix\config\filetypes.xml

1) Add the .info file extension to the list of XML file types:


    <FileType extension=".info;.config;.csproj;.vbproj;.resx;.settings;.sitemap;.user;.wsdl;.browser;.xaml;.xml;.xoml;.xsd;.xsl;.xslt;.mxml;.dbml;.wstemplate">
        <OpenAs>XML</OpenAs>
        <TabColor>Yellow</TabColor>
        <Icon>XMLFileIcon</Icon>
        <EmitUtf8BomByDefault>True</EmitUtf8BomByDefault>
        <Description>An XML File</Description>
    </FileType>

2) Remove the .info file extension from the list of Text file types:

    <FileType extension=".ashx;.export;.po;.blogtemplate;.yml;.yaml;.manifest;.pl;.json;.csv">
        <OpenAs>Text</OpenAs>
        <TabColor>Gray</TabColor>
        <Icon>DefaultFileIcon</Icon>
        <EmitUtf8BomByDefault>False</EmitUtf8BomByDefault>
        <Description>Unknown file type</Description>
    </FileType>
    
3) Restart WebMatrix to apply the change.


## Working with the Database

If you selected **SQL Server Compact** for the the database option in Orchard setup, you can open the **Orchard.sdf** database in WebMatrix by selecting **Databases**.
 
![](../Upload/screenshots_675/webmatrix_opendatabase_675.png)

Once the database window is opened, you can view the contents of a table by selecting the table in the explorer pane.

![](../Upload/screenshots_675/webmatrix_databasetable_675.png)

(If you were already in the **Databases** workspace, you might need to right-click the Orchard node and then click **Refresh** in order to display the database and tables.)

![](../Upload/screenshots_675/webmatrix_database_refresh_675.png)

## Publishing Your Web Site

When you're ready to upload the local copy of your website to the Internet, click the **Publish** button in the WebMatrix ribbon.

![](../Upload/screenshots/webmatrix_publish.png)

The first time you publish, the **Publish Your Site** dialog box is displayed. 

![](../Upload/screenshots_675/webmatrix_publish_firsttime_675.png)

 To publish a website, you must have an account with a web hosting provider. If you don't have one yet, you can select either **Get Started with Windows Azure** or **Find Windows Web Hosting**. 
 If you select Windows Azure, you will have the option of creating your website as either an Azure Website or Azure Web Role. For instructions on working with Azure see ?????
 ![](../Upload/screenshots_675/webmatrix_AzurePortal_675.png) 

After you've set up an account with a hosting provider, the provider will typically send you an email with your user name, server name, and other information. To save you the extra step of entering this information manually, the provider might send you a "Profile XML" file (named with the _.publishsettings_ extension) that contains this information. 
You can use these settings by selecting **Import publish profile** and then selecting the file provided by your hoster. Otherwise, you can enter the settings manually. 

 ![](../Upload/screenshots_675/webmatrix_import_settings_675.png)  
 
After you've published your site, you might want to make changes to it and republish it.  When you subsequently select **Publish**, WebMatrix will list the local files that have been changed since the last time the local site was published.
At this point you can select which files you want to upload to the remote stie and select **Continue** or cancel.
 ![](../Upload/screenshots_675/webmatrix_publish_preview_675.png) 

 
Once you have published your website, you can view the files in the remote site by opening the **Remote View**.

![](../Upload/screenshots_675/webmatrix_remote_view_675.png)

More information about using WebMatrix to publish websites can be found [here](http://www.microsoft.com/web/post/how-to-publish-a-web-application-using-webmatrix).

# Change History
* Updates for Orchard 1.6
	* 11-14-12:  Updated screens and workflow.
