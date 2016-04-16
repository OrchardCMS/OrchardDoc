Projection
==========
*This topic targets, and was tested with, the Orchard 1.8 release.*

The **Orchard.Projections Module** Provides methods to control how lists of content items are filtered and displayed.

*Dependencies : Orchard.Tokens, Orchard.Forms, Feeds, Title*

In this particular demo, we'll create an **External Post** functionality using **Query , Projection Page and Projection Widget**.

## Creating External Post Content Type

*Learn how to [Create Custom Content Types](Creating-custom-content-types.html)*

1.**External Post** *Content Type*

![](../Upload/Projections/CreateContentType.png)

2.**Adding 3 Fields Title, Author, Url** and **1 Part BodyPart**

![](../Upload/Projections/addingfieldsnparts.png)

3.Click on **Edit Placement** to place fields and parts accordingly

![](../Upload/Projections/editingplacement.png)

4.Creating **External Post**

![](../Upload/Projections/creatingexternalpost.png)

![](../Upload/Projections/externalpostcreated.png)

## Creating a Query 

1.Creating a **Query** "ExternalPostQuery"

![](../Upload/Projections/addingquery.png)


![](../Upload/Projections/querycreated.png)

## Editing a Query : **Filter, Sort, Layouts**


![](../Upload/Projections/editingquery.png)

2.Click **Add a new Filter**

![](../Upload/Projections/addfilter.png)

Select **External Post** as the *Content Type*

![](../Upload/Projections/externalpostfilter.png)

3.Click **Add a new Sort Criteria** and Select **Publication Date**


![](../Upload/Projections/sortpublication.png)

4.Click **Add a new Layout** and Select **Html List**

![](../Upload/Projections/selectlayout.png)

5.Save the Layout with Display Type as **Detail**

![](../Upload/Projections/savelayout.png)

5.Previewing the query result

![](../Upload/Projections/clickpreview.png)

![](../Upload/Projections/queryresult.png)

## Adding Properties to the Html List Layout

Change **Display Mode** to **Properties**

![](../Upload/Projections/changedisplaymode.png)

1.**Title Property**


![](../Upload/Projections/titleproperty.png)

Open Rewrite Results -> Select **Rewrite output**

Rewriting the output for the Title Property and using **Tokens** to the Title and Url fields.

	<h1><a href="{Content.Fields.ExternalPost.Url}" target="_blank">{Content.Fields.ExternalPost.Title}</a></h1>

![](../Upload/Projections/titlerewrite.png)

2.**Author Property**

![](../Upload/Projections/addingproperties.png)

Rewriting the output for the Author Property and using **Tokens**

	<p>Posted By <b>{Content.Fields.ExternalPost.Author}</b> on {Content.Date}</p>

![](../Upload/Projections/authorrewrite.png)

## Creating a Projection Page for ExernalPostQuery(Unordered Html List)


![](../Upload/Projections/projectionpage.png)

Select the **Show Pager** check box to add a pager to the list.

![](../Upload/Projections/creatingprojectionpage.png)


## Rendering Results using Projection Widget


![](../Upload/Projections/projectionwidget.png)

Select **ExernalPostQuery(Unordered Html List)** For Query

![](../Upload/Projections/creatingprojectionwidget.png)

Rendered Result 

![](../Upload/Projections/renderedresult.png)