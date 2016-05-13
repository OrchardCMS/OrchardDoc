
Orchard provides the ability to index and search content items in the application. The indexing functionality is provided by enabling the **Indexing** feature, along with a specific implementation of indexing (Lucene-based is included by default). In addition to the **Indexing**, the **Search** feature provides the ability to query the index (by keyword or using Lucene query syntax) to return a list of content items matching the query on the front end.

You must enable all the following Modules **Search**, **Indexing**, and **Lucene**.

![](../Upload/screenshots_675/enable_lucene.png)

Because search depends on indexing, enabling search will automatically enable indexing as well.  Note that you must also enable Lucene before search and indexing will work.


![](../Upload/screenshots_675/search2.png)

When the indexing feature is enabled, a new **Search** and **Indexes** item becomes available under the **Settings** section of the dashboard. The indexer runs as a background task, once per minute by default, and you can optionally update or rebuild the index from this screen.  The **Indexes** screen also displays the number of documents (content items) indexed and the **Search** screen displays the indexed fields.


![](../Upload/screenshots_675/indexnsearch.PNG)

![](../Upload/screenshots_675/indexcreated.PNG)

![](../Upload/screenshots_675/indexupdated.PNG)

After enabling the **Search** feature goto the **Content Definition** section and click on any Content Type which you want to index and then check the check box for the available index. For e.g. Page Content Type

![](../Upload/screenshots_675/indexcontenttype.PNG)


When the search feature is enabled, the **Settings** screen in the dashboard displays the fields that will be queried from the index (listed on the Search screen).  




![](../Upload/screenshots_675/searchfield.PNG)


The front end of the site does not have the searching UI yet at this point. To add it, you need to add a widget. Click **Widgets** in the admin menu. With the default layer selected, click **Add to zone** next to **SearchForm** in the list of available widgets.

Keep "Header" selected as the zone and "Default" as the layer so that your search widget appears on top of all pages (the default layer applies to all pages in the site).

Give it a title such as "Search" and click the **Save** button.

> For more information about widgets, see [Managing widgets](Managing-widgets).

If you navigate now to any page in the front end of the site, you will see the search form.


![](../Upload/screenshots_675/searchformwidget.PNG)

When you type a keyword or query into this input box, a list of matching content items is displayed.

![](../Upload/screenshots_675/searchwidgetfrontend.PNG)

# Change History
* Updates for Orchard 1.8
    * 9-05-14: Updated all screen shots for Search , Indexing and Lucene
