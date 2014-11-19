وب ماتریکس (http://www.microsoft.com/web/webmatrix/)  یک ابزار توسعه وب سایت ، که امکان ایجاد، ویرایش، و انتشار وب سایت را با سهولت فراهم می کند.
وب ماتریکس شامل یک وب سرور (IIS Express) همراه با یک ویرایشگر ساده برای ویرایش و سفارشی کردن برنامه های کاربردی مانند اورچارد . هنگام نصب اورچارد بوسیله وب پلتفرم شما گزینه ای برای نصب وب ماتریکس دارید بجای iis.
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

اگر شما می خواهید فقط از اورچارد شروع کنید. ما توصیه می کنیم که برای دیتابیس SQL Compact Server را انتخاب نمایید. برای دستورالعمل هم Default را انتخاب نمایید. اطلاعات را وارد نمایید و بر روی اتمام تنظیمات (Finish Setup) کلیک نمایید.
![](../Upload/screenshots/setup_new_site.png)

![](../Upload/screenshots_675/webmatrix_finish_setup_675.png) 


پس از انجام تنظیمات اولیه سایت صفحه اول سایت در مرورگر باز نمایید.به صورت خودکار با نام کاربری که قبلا مشخص نموده اید وارد صفحه تنظیمات (به عبارت دیگر وارد admin (  می شوید. در این جا بر روی داشبورد کلیک نمایید.

در داشبورد می توانید تغییرات مورد نظر خود را در سایت اعمال نمایید.

![](../Upload/screenshots_675/new_default_site_675.png) 

وب سایت خود را از طریق وب ماتریکس اجرا نمایید.

در هر زمان شما می توانید با انتخاب پروژه سایت خود را از وب ماتریکس اجرا نمایید.

![](../Upload/screenshots/webmatrix_run.png)


کار با فایل ها 


شما می توانید از وب ماتریکس برای ویرایش فایل ها و نصب اورچارد استفاده نمایید. وب ماتریکس یک ویرایشگر ساده را فراهم می کند برای رنگ دهی     HTML, CSS, JavaScript و کد فایل ها.

اگرچه در وب ماتریکس امکان اجرا کردن کدها وجود ندارد خود اورچارد زمانی که در حال ویرایش فایلها هستیم امکان اجرا فایلها را به صورت پویا فراهم می کند.برای اطلاعات بیشتر این مطالب را ببینید
 [Orchard Dynamic Compilation]
(Orchard-module-loader-and-dynamic-compilation

![](../Upload/screenshots_675/webmatrix_files_675.png)

می توان با استفاده از این دستورالعمل ویرایشگر وب ماتریکس را تغییر داد.

 [instructions](http://sybak.com/blog/2011/02/changing-the-file-types-that-open-with-webmatrix/). 

به عنوان مثال ممکن است شما ادیتور XML را مفید ببینید (که امکان رنگ دهی را) بر روی فایل placement.info فراهم می نماید. برای انجام این کار باید تنظیمات فایلهای  .info را در وب ماتریکس و filetypes.xml تغییر دهید .
که این فایل را از طریق مسیر های زیر میتوانید پیدا نمایید.
32-bit machines: C:\Program Files\Microsoft WebMatrix\config\filetypes.xml
64-bit machines: C:\Program Files (x86)\Microsoft WebMatrix\config\filetypes.xml

1) اضافه کردن اطلاعات فایلهای که پسوند .info دارند به لیست انواع فایلهای xml

<FileType extension=".info;.config;.csproj;.vbproj;.resx;.settings;.sitemap;.user;.wsdl;.browser;.xaml;.xml;.xoml;.xsd;.xsl;.xslt;.mxml;.dbml;.wstemplate">
    <OpenAs>XML</OpenAs>
    <TabColor>Yellow</TabColor>
    <Icon>XMLFileIcon</Icon>
    <EmitUtf8BomByDefault>True</EmitUtf8BomByDefault>
    <Description>An XML File</Description>
</FileType>


2) حذف اطلاعات فایلهای با فرمت .info از لیست انواع فایلهای  Text.

    <FileType extension=".ashx;.export;.po;.blogtemplate;.yml;.yaml;.manifest;.pl;.json;.csv">
    <OpenAs>Text</OpenAs>
    <TabColor>Gray</TabColor>
    <Icon>DefaultFileIcon</Icon>
    <EmitUtf8BomByDefault>False</EmitUtf8BomByDefault>
    <Description>Unknown file type</Description>
</FileType>
    
3) برای انجام تغییرات وب ماتریکس را ریست نمایید.

کار با دیتابیس
اگر شما در تنظیمات اورچارد برای دیتابیس SQL Server Compact را انتخاب نموده اید ، شما می توانید با انتخاب پایگاه داده در وب ماتریکس Orchard.sdf را باز نمایید.

![](../Upload/screenshots_675/webmatrix_opendatabase_675.png)

هنگامی که پنجره دیتابیس باز شود می توان محتویات یک جدول با انتخاب جدول در پنجره اکسپلورر مشاهده نمود.

![](../Upload/screenshots_675/webmatrix_databasetable_675.png)

اگر شما معمولا در صفحه کاری دیتابیس هستید به منظور نشان دادن و بروز رسانی اطلاعات دیتابیس نیاز دارید که کلیک راست نمایید و Refresh را انتخاب نمایید.

![](../Upload/screenshots_675/webmatrix_database_refresh_675.png)

انتشار وب سایت شما
هنگامی که شما آمادگی لازم برای upload وب سایت از  local بر روی اینترنت را دارید، بر روی دکمه انتشار ( Publish) بر روی نوار وب ماتریکس کلیک نمایید.

![](../Upload/screenshots/webmatrix_publish.png)

برای اولین باری که سایت را منتشر می نمایید کادر محاوره ای نمایش داده می شود.
![](../Upload/screenshots_675/webmatrix_publish_firsttime_675.png)


برای انتشار وب سایت ، باید یک اکانت ارائه دهنده خدمات میزبانی وب (hosting)  داشته باشد، اگر شما به هاست دسترسی ندارید می توانید چیز دیگری انتخاب نمایید، می توانید با ویندوز Azure شروع به کار نمایید یا از وب سایت های میزبانی وب ویندوز استفاده نمایید.
اگر شما Windows Azure را انتخاب می نمایید. شما گزینه ای برای ایجاد وب سایت دارید. اگر Windows Azure را انتخاب نمایید، گزینه ای برای ایجاد وب سایت یا Azure Web Role دارید  به دستورالعمل های مربوط به کار با  Azure  نگاه کنید.


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
