This walkthrough provides a glimpse of the features that Orchard has to offer, provided as a step-by-step guide. If this is your first time using Orchard, this document is for you!

اين ورود  در يک نظر ارائه مي کند به طور بخصوص  orchard پيشنهاد مي کند
, اماده کردن قدم به قدم.
  
 اگر اين اولين باري است که ار orchard استفاده مي کنيد اين مدرک براي شماست
 



This topic assumes that you have already installed Orchard and set up your website. If you haven't, follow the instructions in [Installing Orchard](Installing-Orchard).


 اين مبحث فرض مي کند شما orchard را نصب کرده ايد و سايت خود را راه اندازي کرده ايد
 در غير اين صورت ساختار را در  [Installing Orchard](Installing-Orchard). دنبال کنيد
 









### Changing the layout of the Home Page

Out of the box, Orchard applies a theme to your website known as the "Theme Machine".  The Theme Machine includes CSS styles and a layout. Orchard allows you to selectively include or exclude portions (zones) of the layout on each page of your website. 
By default, the zones highlighted in blue are enabled on the home page.

![](../Upload/screenshots_675/ThemeZonePreview_homepage_675.png)




تغيير طرح صفحه اصلي

خارج از جبعه orchard ,  يک زمينه براي سايت شما به عنوان   theme machine قبول مي کند.
theme machine  شامل طرح ها و  سبک هاي css است.
ارچارد به شما اجازه مي دهد به صورت انتخابي شامل يا مانع از بخشي  (منطقه اي ) ازطرح روي هر صفحه از سايت شويد.
به طور پيش فرض , بخش هايي که به رنگ آبي برجسته شده اند در صفحه اصلي قادر هستند.
![](../Upload/screenshots_675/ThemeZonePreview_homepage_675.png)






The **Navigation** zone contains a menu with a single tab, *Home*. The **TripelFirst, TripleSecond** and **TripleThird** zones at the bottom of the page are populated with dummy text in the *First Leader Aside*, *Second Leader Aside* and *Third Leader Aside* paragraphs.  

منطقه**  Navigation  **شامل يک فهرست با  جدول تکي  , Home .  ** TripelFirst, TripleSecond** و ** Triple Third** منطقه  هایی در پایین صفحه ای که با نوشته های مصنوعی شلوغ شده در  ** First Leader Third** ,*Second Leader Aside* و *Third Leader Aside*


In addition to zones, every page has a central region (In this case, the text from *"Welcome to Orchard"* to *"Thank you for using Orchard"*) which, for this tutorial, will be referred to as the **Body** of the page. 

![](../Upload/screenshots_675/homepage_before_contextual_edits_675.png)

علاوه بر این منطقه ها , هر صفحه دارای قلمرو مرکزی ( در این باره , متن  از *به ارچارد خوش آمدید*  تا * تشکر می کنیم برای استفاده از ارچارد*)
که , برای این  آموزش ,  عطف داده می شود به عنوان **  بدنه ** از صفحه.

	![](../Upload/screenshots_675/homepage_before_contextual_edits_675.png)


Although the Theme Machine has many possible zones defined, on a given page the only zones visible will be zones that have had widgets added to them (you can learn more about widgets [here](Managing-Widgets)). The Navigation, TripelFirst, TripelSecond and TripelThird zones are visible on the home page because they contain widgets.
 با این حال theme machine  دارای منطقه های تعریف پذیر  زیادی ,  در صفحه داده شده تنها منطقه های  قابل رویت منطقه هایی هستند که  ویجت ها به آنها  افزوده شده .(می توانید در (here)  بیشتر درباره ویجت ها مطالعه کنید[ مدیریت ویجت ها])
منطقه های اولین سه گانه, دومین سه گانه ,  سومین سه گانه در صفحه اصلی چون دارای ویجت ها هستند آشکار هستند.



**1)** Select **Widgets** from the Dashboard.  

The Widgets management page opens with the *Default* layer selected.  Any zone that is visible in the Default layer will appear on all pages. Therefore, the *Navigation* zone is visible on
all web pages and has a **Main Menu** widget.  The Main Menu widget is annotated in green because it has been added to a zone in the **current layer**.  

![](../Upload/screenshots_675/widgets_default_layer_675.png)


**1**)   انتخاب ویجت از داشبورد.
صفحه مدیریت ویجت ها با * پیش فرض * لایه انتخاب  شده باز می شود. هر منطقه ای که در لایه پیش فرض آشکار است در همه صفحه ها ظاهر می شود.از این رو منطقه  *navigation*  در همه صفحات وب  ظاهر می شود و دارای ویجت  **صفحه اصلی** می باشد.
ویجت صفحه اصلی به رنگ سبز شرح داده می شود زیرا  به یک منطقه  در **current layer** اضافه خواهد شد
![](../Upload/screenshots_675/widgets_default_layer_675.png)

**2)** Select the **HomePage** layer to see which zones are visible for the home page.  

Widgets which have been added to zones in the selected layer will be annotated in green (FirstLeaderAside, SecondLeaderAside and ThirdLeaderAside).  Widgets which have been added to zones in other layers will be annotated in gray (Main Menu).

![](../Upload/screenshots_675/homepage_layer_selection_675.png)


2) انتخاب لایه  **صفحه اصلی**   که ببینید کدام  منطقه  برای صفحه اصلی آشکار است.
ویجت هایی که به منطقه هایی لایه های انتخاب شده اضافه می شوند با رنگ سبز شرح داده می شود
(FirstLeaderAside, SecondLeaderAside و ThirdLeaderAside).
ویجت هایی که اضافه شدند در لایه های دیگر با رنگ  خاکستری شرح داده می شوند.(صفحه اصلی)
![](../Upload/screenshots_675/homepage_layer_selection_675.png)
 
The TripelFirst, TripelSecond, and TripelThird zones on the home page have widgets in them and are visible. Removing all of the widgets in a zone will make the zone invisible.  
منطقه های سه گانه اول, سه گانه دوم و سه گانه سوم در صفحه اصلی دارای ویجت هایی در خودشان هستند و آشکار هستند.
پاک کردن  تمام ویجت ها در یک منطقه  آن منطقه را مخفی می کند



**3)** Select **Remove** for the **Third Leader Aside** widget.

![](../Upload/screenshots_675/homepage_tripelthird_675.png)

The TripelThird zone will no longer be visible on the home page.
![](../Upload/screenshots_675/homepage_remove_tripelthird_675.png)

3)انتخاب  **حذف** برای  ویجت **Leader Aside**  
![](../Upload/screenshots_675/homepage_tripelthird_675.png)
 منطقه سومین سه گانه  دیگر در صفحه الی قابل مشاهده نخواهد بود


![](../Upload/screenshots_675/homepage_remove_tripelthird_675.png)


**4)** Select **Add** for the TripelThird zone to add a widget to the zone.
![](../Upload/screenshots_675/homepage_add_tripelthird_675.png)


4) انتخاب ** افزودن ** برای اضافه کردن ویجت به منطقه سومین سه گانه
 ![](../Upload/screenshots_675/homepage_remove_tripelthird_675.png)




**5)** Select the **HTML Widget** to add this type of widget to the TripelThird zone.
![](../Upload/screenshots_675/homepage_choose_widget_675.png)

5) انتخاب ** ویجت HTML** برای افزودن  این نوع از ویجت ها به منطقه سومین سه گانه
![](../Upload/screenshots_675/homepage_choose_widget_675.png)


**6)** Enter a title for your widget and some content.

![](../Upload/screenshots_675/homepage_new_thirdleaderaside_675.png)


6) انتخاب عنوان برای ویجت شما و برخی از مطالب
	![](../Upload/screenshots_675/homepage_new_thirdleaderaside_675.png)
**7)** **Save** the new widget.

**8)** Select **Your Site** in the upper-left side of the Dashboard to view the modified home page with the new TripelThird zone.
![](../Upload/screenshots_675/homepage_modified_thirdleaderaside_675.png)
7) ذخیره کردن ویجت جدید
8) انتخاب **سایت خودتان ** در گوشه بالایی سمت چپ داشبورد برای برای دیدن صفحه اصلی اصلاح شده با منطقه جدید سومین سه گانه
![](../Upload/screenshots_675/homepage_modified_thirdleaderaside_675.png)


### Editing the content of the Home Page
Orchard provides a feature that makes it easy for you to edit the content in a zone or the page body.  To turn on this feature you must enable the **Content Control Wrapper** and **Widget Control Wrapper** modules 

##اصلاح کردن محتوای صفحه اصلی
ارچارد  ویژگی ای ارائه می کند که برای شما اصلاح کردن محتوای یک منطقه در بدنه صفحه را راحت می کند.
برای فعال کردن این ویژگی شما باید  مدل های **Content Control Wrapper** و **Widget Control Wrapper**   فراهم کنید



**1)** Select **Modules** on the Dashboard.

**2)** Enable **Content Control Wrapper**

**3)** Enable **Widget Control Wrapper**

![](../Upload/screenshots_675/enable_content_control_675.png)
Once these modules are enabled, you can edit the contents of an individual zone by clicking the **Edit** link (at the top right) in the zone.  
![](../Upload/screenshots_675/home_page_675.png)

**4)** Select the **Edit** link for the *TripelFirst* zone of the home page. 

**5)** Change the title, and optionally, change or remove the existing body text for the zone.  


**6)** Select **Insert/Update Media**. 

![](../Upload/screenshots_675/edit_widget_media_1_675.png)

**7)** Browse to an image file on your computer and select **Upload** to upload it to your Orchard site.

![](../Upload/screenshots/pick_image.png)


1)	انتخاب ** مدل ها ** در داشبورد
2)	فراهم کردن **Content Contol wrapper** 
3)	فراهم کردن **Widget Control Wrapper**
4)	![](../Upload/screenshots_675/enable_content_control_675.png)

در ابتدا این مدل ها  فعال شده اند , شما می توانید محتوای  هر منطقه منحصر به فرد را  با کلیک کردن لینک در منطقه **اصلاح**(در بالا سمت راست ) اصلاح کنید
![](../Upload/screenshots_675/home_page_675.png)
4)لینک**اصلاح** را  برای منطقه از صفحه اصلی   **اولین سه گانه** انتخاب کنید.
5)تغییر دادن عنوان, به صورت اختیاری, تغییر دادن یا حذف بدنه  متن موجود برای منطقه 

6)انتخاب  افزودن/به روز رسانی رسانه
![](../Upload/screenshots_675/edit_widget_media_1_675.png)

7) پیدا کردن فایل یک عکس در رایانه وانتخاب **آپلود** برای آپلود کردن آن در سایت ارچاردتان.
![](../Upload/screenshots/pick_image.png)

**8)** Select **Insert** to insert it into the TriplelFirst zone.

> **Note:** Before you insert the uploaded image, it is helpful to specify width and height attributes for the image, for example 200 pixels wide by 150 pixels high, so that the image fits correctly into its zone. 

**9)** Select **Save** to save the changes to the widget. The home page is automatically displayed with the updated zone.

![](../Upload/screenshots_675/edit_widget_tulip_675.png)

8) انتخاب **افزودن** برای افزودن به منطقه اولین سه گانه
یادداشت:
قبل از افزودن عکس های آپلود شده , مشخص کردن  ویژگی پهنا و ارتفاع برای عکس مفید است, برای مثال 200پیکسل پهنا و 150 پیکسل ارتفاع,  پس عکس  دقیقآ در منطقه خودش نصب می شود.


9) انتخاب ** ذخیره ** برای ذخیره کردن  تغییرات در ویجت ها. صفحه اصلی  به صورت خودکار منطقه به روز شده را نمایش می دهد
![](../Upload/screenshots_675/edit_widget_tulip_675.png)



**10)** Select the **Edit** link for the **Body** of the page.

![](../Upload/screenshots_675/edit_body_675.png)

 Orchard will display the **Edit Page** screen.
 > **Note:** The Edit Page screen can also be reached from the Dashboard by selecting **Content** on the Dashboard and then selecting **Edit** for the page you are interested in.

10) انتخاب لینک** ویرایش** برای **بدنه** صفحه.
 ![](../Upload/screenshots_675/edit_body_675.png)
ارچارد صفحه **ویرایش صفحه**را نمایش می دهد
یادداشت:
می توان از صفحه **صفحه ویرایش** به داشبورد رسید با انتخاب **محتوا** در داشبورد و سپس انتخاب ** ویرایش** برای صفحه ای که مورد نظر است.


 **11)** Enter some text for the content. 

![](../Upload/screenshots_675/edit_homepage_675.png)
 **12)** Select **Publish Now** at the bottom of the page to make the updates to the page visible immediately.

![](../Upload/screenshots_675/publishnow_homepage_675.png)

11) نوشته ای را به عنوان محتوا   وارد کنید
![](../Upload/screenshots_675/edit_homepage_675.png)
12) در پایین صفحه **چاپ هم اکنون **   برای ظاهر کردن به روز رسانی فوری را انتخاب کنید  
![](../Upload/screenshots_675/publishnow_homepage_675.png)

### Adding a New Page to Your Site

**1)** In the Orchard Dashboard, under **New**, select **Page**.

**2)** Enter a title for the page.  When you enter a title for the page (for example, "Download"), the permalink (URL) for the page is filled in automatically ("download").  You can edit this link if you prefer a different URL.

###افزودن یک صفحه جدید به سایت شما
1)در داشبورد ارچارد , پایین ** جدید** ,**صفحه** را انتخاب کنید
2) یک عنوان برای صفحه انتخاب کنید. زمانی که یک عنوان برای صفحه وارد کردید ( برای مثال "Download") ,
یک لینک (URL) به صورت خوکار برای صفحه  ("Download") اختصاص داده می شود.
شما می توانید اگر URl  دیگری را ترجیح می دهید این لینک را ویرایش کنید,


**3)** Enter some text for the content page body.

![](../Upload/screenshots_675/create_new_page_0_1_675.png)


3) برای بدنه صفحه  مطلبی را وارد کنید
![](../Upload/screenshots_675/create_new_page_0_1_675.png)


**4)**  In the **Tags** field, add comma-separated tags such as "download" and "Orchard" so that you can search and filter using those tags later. 

4)در برچسب ها  پر شده, اضافه کنید ویرگول-برچسب ها را جدا می کند مانند “download”  و “orchard”   پس شما می توانید جستوجو کنید واستفاده از آن برچسب ها را  فیلتر کنید 

**5)** Check **Show on main menu** and enter the menu text ("Downloads") to use in the site's main menu.
5) بررسی ** نمایش در منود اصلی** و وارد کردن نوشته منو (“Download”) برای استفاده در منوی اصلی سایت

**6)** Select **Publish Now** to make the page to make the updates to the page visible immediately. You can also save the page as a draft (to edit later before publishing), or you can choose to publish the page at a specific date and time.
6) ** چاپ هم اکنون ** را انتخاب کنید تا صفحه فورآ به روز رسانی ها را آشکار کند
شما می توانید همچنین  صفحه را به عنوان پیش نویس(برای به تعویق انداختن ویرایش قبل از انتشار), یا شما می توانید انتخاب کنید که  صفحه را در تاریخ و ساعت خاصی  منتشر کند
![](../Upload/screenshots_675/create_new_page_1_1_675.png)

 When you publish the page, you will be offered the opportunity to create a new Widget Layer for the page.

زمانی که صفحه را منتشر میکنید به شما فرصت ساختن  لایه ویجت جدید برای صفحه پیشنهاد می شود 

**7)** Select **add a widget layer** to add a new layer for this page which will allow you to customize the layout for the new page at a later point in time.
7) *افزودن لایه ویجتی* را  برای افزودن لایه جدید برای ابن صفحه که  به شما اجازه می دهد طرح بندی سفارشی سازی  را برای صفحه جدید بعداٌ انتخاب کنید
![](../Upload/screenshots_675/create_new_page_1_2_675.png)

**8)** Select **Save** which will create the new layer with the default settings.
8) **ذخیره سازی** که لایه جدید را با تننظیمات پیش فرض می سازد انتخاب کنید
![](../Upload/screenshots_675/create_new_page_2_2_675.png)

**9)** Select **Your Site** in the upper-left side of the Dashboard to view the updated website.
9) **سایت خود ** را در بالا سمت چپ داشبورد انتخاب کنید تا سایت بروز شده را ببینید
Notice that the **Downloads** tab has been added to the main menu, and that you can select the tab to view your page. Also notice that the new page has a different layout from the home page.  The only zones visible on the new page are the zones (Navigation) made visible by the Default layer.  To make additional zones visible only on the Download page, you must add widgets to zones in the Download layer.

![](../Upload/screenshots_675/website_new_page_added_675.png)

 توجه داشته باشید  تب **Download** به منوی اصلی افزوده می شود که می توانید تب را انتخاب کنید که صفحه خود را ببنید
همچنین توجه داشته باشید  که صفحه جدید با صفحه اصلی لایه متفاوتی خواهد داشت.
تنها منطقه  هایی آشکار هستند  در صفحه جدید منطقه های (Navigation)  ای که آشکار می کند با لایه های پیش فرض.
برای افزودن منطقه های آشکار فقط در صفحه Download  , شما باید ویجت ها را به لایه های Download  اضافه کنید.



### Selecting a Theme

To customize the look and feel of the Orchard website you change the theme. 

**1)** On the Orchard Dashboard, select **Themes**.  The currently installed themes are listed. 

**2)** To download new themes, select the **Gallery** tab.

**3)** Search for **Contoso** to find the Contoso Theme. Install the **Contoso** theme.
**4)** Select the **Installed** tab. 


###انتخاب زمینه
شما زمینه را برای سفارشی کردن ظاهر سایت ارچارد  تغییر  می دهید.
1) در داشبورد ارچارد ** زمینه ** را انتخاب کنید. زمینه های نصب شده در حال حاضر لیست شده اند.
2) برای دانلود زمینه های جدید , **گالری ** را انتخاب کنید
3)**contoso**  را جستوجو کنید برای یافتن زمینه های contoso . زمینه های contoso  را نصب کنید.
4) تب نصب شده را انتخاب کنید
 







After a theme has been installed it appears as an option in the **Available** section on the **Installed** tab. In the following illustration, the **Contoso** theme has been installed so it appears in the **Available** section. (The current theme for the site is **The Theme Machine**.) 


بعد از اینکه زمینه نصب شد به صورت خاصیت  در بخش ** دسترس**در تب **نصب شده** ظاهر می شود . 
در تصویر زیر , زمینه **contoso ** نصب شده  پس ظاهر می شود در بخش **در دسترس**.(زمینه برای سایت در حال حاضر   **The Theme Machine* است)


**5)** To see how your site will look with an available them,  select **Preview** for the theme.  To apply an available theme to your site select **Set Current** for the theme. For more details, see [Previewing and Applying a Theme](Previewing-and-applying-a-theme) and [Installing Themes](Installing-themes).

![](../Upload/screenshots_675/themes_manage_1_675.png)


5) برای اینکه مشاهده کنید سایت شما با زمینه موجود چگونه است, **preview** را برای زمینه انتخاب کنید.
برای برگزیدن زمینه موجود برای سایت **set current**  را انتخاب کنید. برای مدل های بیشتر , [Previewing and Applying a Theme](Previewing-and-applying-a-theme)  و[Installing Themes](Installing-themes).  را مشاهده کنید.
### Extending Orchard with Modules and Features

A key feature of Orchard is the ability to add new features in order to extend the functionality of your site. The primary way to do this is by installing modules. You can think of a module as a package of files (in a .zip folder) that can be installed on your site. To view the modules that are included with Orchard, in the Orchard Dashboard, click **Modules** and then click the **Installed** tab in the **Modules** screen.

### توسعه دادن ارچارد با مدل ها و ویژگی ها
ویژگی اصلی ارچارد توانایی افزودن ویژگی جدید  به منظور  توسعه قابلیت های سایت شما است.
اولین راه برای انجام آن نصب کردن مدل ها است. شما می توانید مدل ها را به عنوان بسته هایی از فایل  ها (در پوشه های  .zip) که می تواند بر روی سایت شما نصب شود. برای مشاهده  مدل هایی که ارچارد شامل آنها می شود , در داشبورد ارچارد , **مدل ها** را برگزینید و تب **نصب** را در صفحه **مدل ها** انتخاب کنید.
 

![](../Upload/screenshots_675/installed_modules_1_675.png)

Orchard provides some built-in modules, and you can install new modules. For details, see [Installing and Upgrading Modules](Installing-and-upgrading-modules) and [Registering additional gallery feeds](Module gallery feeds).

ارچارد  برخی مدل های ساخته شده را ارائه می کند, و شما می توانید مدل های دیگر را نصب کنید.
برای جزئیات  , [Installing and Upgrading Modules](Installing-and-upgrading-modules)  [Registering additional gallery feeds](Module gallery feeds).   را مشاهده کنید .

Individual modules can expose features that can be independently enabled or disabled. To view the features exposed by the built-in modules in Orchard, click the **Features** tab in the **Modules** screen.  

مدل های فردی می توانند ویژگی هایی را  که می توانند به شکل مستقل فعال یا غیر فعال شده را نمایش دهند. برای مشاهده ویژگی های نمایش داده شده توسط مدل های ساخته شده در ارچارد , تب **Features** را در صفحه **Modules** برگزینید.
![](../Upload/screenshots_675/features_link_675.png)





Each feature has an **Enable** or **Disable** link (depending on its current state), as well as an optional list of dependencies that must also be enabled for a specific feature. The documentation throughout this site describes the variety of features in Orchard and how you can use them to customize your site's user interface and behavior.
  
هر ویژگی یک لینک **Enable** یا **Disable**  (وابسته به حالت کنونی) , به خوبی لیست خصوصیات   از وابستگی ها که همچنین باید برای ویژگی خاصی فعال باشد. مستندات در سرار این سایت گستردگی ویجت ها را در ارچارد توصیف می کند وو چگونه می توانید آنها را استفاده کنید تا رابط ها و رفتار های کاربران سایتتان را سفارشی کنید. 

### Change History
* Updates for Orchard 1.6
	* 11-25-12:  Added section describing how to change the layout for a page by enabling/disabling zones.  Removed section on Creating a Blog (which already has it's own topic).
* Updates for Orchard 1.1
    * 3-14-11:  Updated screen shots showing updated menus, and updated dashboard and settings options.

###تغییر دادن پیشینه
•	برای ارچارد 1.6 به روز شده
•	*11-25_12 : اضافه شده قسمت شرح چگونه تغییر  لایه برای صفحه با فعال / غیر فعال کردن منطقه.
•	قسمت حذف شده در ساختن وبلاگ(که اکنون  سرفصل مخصوص خود را دارد)
•	به روز رسانی برای ارچارد 1.1
•	*3-14-11: صفحه به روز شده منو,داشبورد و خصوصیات تنظیمات را نمایش می دهد.
