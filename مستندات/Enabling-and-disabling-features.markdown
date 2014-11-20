
You can add additional functionality to your site by enabling and disabling features exposed by the modules that are installed to Orchard.  To view the available features, click **Features** under the **Configuation** heading in the Orchard admin panel.

![](../Upload/screenshots_675/features_admin_675.png)

The **Manage Features** screen displays the available features that can be enabled or disabled. Depending on which features are enabled or disabled, your site will have different admin panel options, front-end user interface elements, and other behaviors. The default view of available features displays in "Box" view (to maximize the number of features displayed at a glance).

You can also switch views to "List" view if you prefer to see your features as a list of items with more verbose descriptions.

![](../Upload/screenshots_675/features_admin_list_675.png)

To enable a feature, simply click **Enable** for that feature.

![](../Upload/screenshots_675/enable_localization.png)

When a feature is enabled a message appears at the top of the **Manage Features** screen telling you the feature was enabled successfully.

![](../Upload/screenshots_675/enable_localization2.png)

A feature can depend on one or more other features (listed under the feature name). When a feature with dependencies is enabled, the dependencies are also automatically enabled.  For example, the **Gallery** feature depends on the **Packaging** feature, which in turn depends on **Packaging Services**. 

![](../Upload/screenshots_675/enable_gallery_675.png)

Enabling **Gallery** will enable **Packaging** and **Packaging Services**.

![](../Upload/screenshots_675/gallery_enabled_675.png)

Enabling a feature (such as **Gallery**), will sometimes add additional menu items in the admin panel, as shown in the previous image.

Orchard also provides a command-line interface, from which you can also list, enable, and disable features. You can find the Orchard command-line tool in the bin directory of the application, and run it from the root of the website by typing `bin\orchard.exe` at the Windows command-prompt.  To list available features, type `feature list`  or `feature list /Summary:true` at the command-prompt. 

![](../Upload/screenshots_85/features_cmd.png)

Enable a feature from the command-line by `typing feature enable &lt;feature-name&gt;`, for example: `feature enable Gallery`.

![](../Upload/screenshots_85/features_cmd2.png)

For more information about the Orchard command-line interface, see [Using the command-line interface](Using-the-command-line-interface).

