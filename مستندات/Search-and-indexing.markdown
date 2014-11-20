
Orchard provides the ability to index and search content items in the application. The indexing functionality is provided by enabling the **Indexing** feature, along with a specific implementation of indexing (Lucene-based is included by default). In addition to the **Indexing**, the **Search** feature provides the ability to query the index (by keyword or using Lucene query syntax) to return a list of content items matching the query on the front end.

Before enabling these features, you must install them from the **Gallery**. Select **Modules** under **Gallery** in the navigation pane to navigate to the **Browse Gallery - Modules** page. On this page, install the following features: **Search**, **Indexing**, and **Lucene**.

![](../Upload/screenshots_675/Search_install.png)

Because search depends on indexing, enabling search will automatically enable indexing as well.  Note that you must also enable Lucene before search and indexing will work.

![](../Upload/screenshots_675/Search_enable.png)

![](../Upload/screenshots_675/search2.png)

When the indexing feature is enabled, a new **Search Index** item becomes available under the **Configuration** section of the dashboard. The indexer runs as a background task, once per minute by default, and you can optionally update or rebuild the index from this screen.  The **Search Index** screen also displays the number of documents (content items) indexed, as well as the indexed fields.

![](../Upload/screenshots/Search_searchindex.png)

![](../Upload/screenshots_675/search4.png)

When the search feature is enabled, the **Settings** screen in the dashboard displays the fields that will be queried from the index, and it is possible to update this list to include additional fields (listed on the Search Index screen).  By default, only **Body** and **Title** fields are indexed.

![](../Upload/screenshots/Search_settings.png)

![](../Upload/screenshots_675/Search_selectsettings.png)

The front end of the site does not have the searching UI yet at this point. To add it, you need to add a widget. Click **Widgets** in the admin menu. With the default layer selected, click **Add to zone** next to **SearchForm** in the list of available widgets.

Keep "Header" selected as the zone and "Default" as the layer so that your search widget appears on top of all pages (the default layer applies to all pages in the site).

Give it a title such as "Search" and click the **Save** button.

> For more information about widgets, see [Managing widgets](Managing-widgets).

If you navigate now to any page in the front end of the site, you will see the search form.

![](../Upload/screenshots/search_displaywidget.png)

When you type a keyword or query into this input box, a list of matching content items is displayed.

![](../Upload/screenshots_675/search_displayresult.png)
