
دو راه براي افزودن زمينه به اورچارد وجود دارد. اولين و ساده ترين راه  استفاده از تب **Gallery** در صفحه **Theme** در داشبورد جهت جستوجو و نصب  زمينه از زمينه هاي موجود در سایت اورچارد. دومين راه به صفحه **Theme** بروید و با کليک بر روي لينک نصب زمينه ,که به شما اجازه از سیستم خود پکیج زمینه را به سایت ارسال و نصب نمایید.
> **Note** If your site is running under IIS, make sure you have granted read/write permissions to the _~/Themes_ folder under the root of your site for the service account that is being used as the IIS application pool identity. However, you should remove the write permissions on a production server.
> **نکته:** اگر سايت شما تحت IIS  اجرا مي شود  , مطمئن شويد که شما …………………………پوشه _/Themes_  بر پايه  سايت شما براي  سرويس 

# Installing a Theme from the Gallery
When the gallery feature is enabled, as it is by default in Orchard, a **Gallery** tab appears at the top of the both the **Themes** screen and the **Modules** screen in the dashboard. 

![](../Upload/screenshots/Themes_gallery_enabled.png)

> Note:  If the gallery feature has been disabled, there will be no **Gallery** tab visible in the **Themes** or **Modules** dashboard screens. To enable a disabled gallery, click **Modules** in the dashboard, and click **Enable** on the Gallery feature. 
#نصب زمينه از گالري
زماني که خاصيت گالري فعال است , هنگامي که به طور پيش فرض در ارچارد ,  تب  **Gallery** در بالاي هر دو صفحه **Theme**  و صفحه **Modules** در داشبورد ظاهر مي شود.
يادداشت: اگر ويژگي گالري غيرفعال شده باشد , هيچ تب **Gallery**  در داشبورد **Theme** يا **Module** ظاهر نمي شود.براي فعال کردن گالري غير فعال , **Module** در داشبورد را انتخاب کنيد ,  و ويژگي گالري** Enable** را بر گزينيد

In the **Themes** screen of the dashboard, click the **Gallery** tab. A set of themes appears with a pair of **Install** and **Download** links next to each theme. 

در صفحه  **Theme** از داشبورد , تب **Gallery** را انتخاب کنيد. يک مجموعه از زمينه ها در کنار هر دو لينک **Install** و**Download** در کنار يکديگر ظاهر مي شوند.
![](../Upload/screenshots_675/Gallerythemes_installing_675.png)

To install a theme in your site, click the **Install** link next to the theme. Installing a theme adds it to your site in the **Available** list of themes on the **Themes** page in the dashboard. From there, you can preview a theme or set it as the current site theme, as described [Previewing and Applying a Theme](Previewing-and-applying-a-theme).
براي نصب زمينه در سايت خود ,  لينک **Install**  در کنار زمينه انتخاب کنيد .  نصب کردن زمينه آن را به سايت شما در ليست زمينه هاي **Available**   در صفحه **Theme** در داشبورد اضافه مي کند.از آنجا شما مي توانيد زمينه را مشاهده يا آن را به عنوان زمينه سايت انتخاب کنيد,   همانطور که در[Previewing and Applying a Theme](Previewing-and-applying-a-theme)   شرح داده شده.

# Installing a Theme from your Local Computer
To install a theme from your local computer, in the **Themes** screen of the dashboard, click the link to **Install a theme from your computer**. This displays a screen that lets you install a theme.
![](../Upload/screenshots/themes_installnew_upload.png)
Browse to a local package file that contains a theme (, select it, and then click **Install**.  The theme package is installed in your site, and you will see the theme listed in the **Available** section of the **Themes** screen. 

#نصب يک زمينه  براي رايانه 
براي نصب يک زمينه از زايانه خود ,  در صفحه **Theme**  از داشبورد , لينک **install a theme  from your compuer** را انتخاب کنيد.اين يک صفحه که به شما اجازه مي دهد يک زمينه را  نصب کنيد نمايش مي دهد.
جست و جو يک بسته پرونده  که شامل  زمينه the file will have a _.nupkg_ extension))  آن را انتخاب کنيد, و **Install** را انتخاب کنيد. بسته زمينه در سايت شما نصب مي شود, و شما مي توانيد ليست زمينه ها را در قسمت **Available** در صفحه **Themes** مشاهده کنيد



> **Note**  A theme contains a number of files and folders packaged in a ZIP file that has a _.nupkg_ file extension. The packaging feature is provided by the NuGet package management system. Packaging themes and other add-ons is beyond the scope of this topic, but you can learn more at [http://nuget.codeplex.com/](http://nuget.codeplex.com/).

The following illustration shows the Terra theme, which was previously downloaded to the local computer from the Gallery, after clicking the **Install a theme from your computer** link and installing it to an Orchard site. The installed theme appears in the **Available** section.

![](../Upload/screenshots_675/theme_addLocal_install_675.png)

يادداشت :
يک زمينه شامل تعدادي  پرونده و پوشه مي شود که در يک پرونده ZIP   که فرمت _.nupkg_    را دارد. 
بسته هاي ويژگي ها توسط بسته هاي مديريت سيستم NuGet  ارائه شده است.بسته هاي زمينه ها و  ………………. 
؟
؟
؟
؟
؟

مثال زير نشان مي دهد زمينه Terra  را ,  که به تازگي از  Gallery  بر روي رايانه دانلود شده , بعد ار انتخاب لينک ** Install a theme from your computer**  و نصب آن بر روي سايت ارچارد  , زمينه نصب شده در قسمت **Available** طاهر مي شود.



To use an example theme to test this feature, download an existing theme from the **Gallery** tab on the **Themes** page, then browse to the saved _.nupkg_ file on your computer and install it as described previously.

When a theme is installed, the theme files are placed in the _~/Themes_ folder. You can see the installed themes in your site by checking the **Available** section on the **Themes** page in the dashboard. For more information about how to preview themes and apply them to your site, see [Previewing and Applying a Theme](Previewing-and-applying-a-theme).
  
براي استفاده از زمينه     براي امتحان کردن اين ويژگي ,  زمينه موجود را  از تب  **Gallery** در صفحه **Themes**   دانلود کنيد ,  سپس فايل ذخيره شده  _.nupkg_ در رايانه را جست و جو کنيد و آن را به عنوان معرفي شده نصب کنيم.

زماني که زمينه نصب شد ,  پرونده هاي زمينه در پوشه     _~/Themes_قرار مي گيرند. شما مي توانيد زمينه هاي نصب شده خود را با بررسي کردن قسمت**Availabe**    در صفحه **Themes** در داشبورد مشاهده کنيد. براي اطلاعات بيشتر درباره چگونگي پيش نمايش  زمينه ها  و اعمال کردن آن در سايت ,  [Previewing and Applying a Theme](Previewing-and-applying-a-theme). را مشاهده کنيد.
  

# Change History
* Updates for Orchard 1.1
    * 3-21-11:  Updated screen shots and text for installing themes. 
