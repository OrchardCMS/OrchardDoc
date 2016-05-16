*This topic targets, and was tested with, the Orchard 1.8 release.*

The **Orchard.Projections Module** Provides methods to control how lists of content items are filtered and displayed.

*Dependencies : Orchard.Tokens, Orchard.Forms, Feeds, Title*

In this particular demo, we'll create an **External Post** functionality using **Query , Projection Page and Projection Widget**.

## Creating External Post Content Type

*Learn how to [Create Custom Content Types](/Documentation/Creating-custom-content-types)*

1.**External Post** *Content Type*

![](../Upload/projections/CreateContentType.PNG)

2.**Adding 3 Fields Title, Author, Url** and **1 Part BodyPart**

![](../Upload/projections/addingfieldsnparts.PNG)

3.Click on **Edit Placement** to place fields and parts accordingly

![](../Upload/projections/editingplacement.PNG)

4.Creating **External Post**

![](../Upload/projections/creatingexternalpost.PNG)

![](../Upload/projections/externalpostcreated.PNG)

## Creating a Query 

1.Creating a **Query** "ExternalPostQuery"

![](../Upload/projections/addingquery.PNG)


![](../Upload/projections/querycreated.PNG)

## Editing a Query : **Filter, Sort, Layouts**


![](../Upload/projections/editingquery.PNG)

2.Click **Add a new Filter**

![](../Upload/projections/addfilter.PNG)

Select **External Post** as the *Content Type*

![](../Upload/projections/externalpostfilter.PNG)

3.Click **Add a new Sort Criteria** and Select **Publication Date**


![](../Upload/projections/sortpublication.PNG)

4.Click **Add a new Layout** and Select **Html List**

![](../Upload/projections/selectlayout.PNG)

5.Save the Layout with Display Type as **Detail**

![](../Upload/projections/savelayout.PNG)

5.Previewing the query result

![](../Upload/projections/clickpreview.PNG)

![](../Upload/projections/queryresult.PNG)

## Adding Properties to the Html List Layout

Change **Display Mode** to **Properties**

![](../Upload/projections/changedisplaymode.PNG)

1.**Title Property**


![](../Upload/projections/titleproperty.PNG)

Open Rewrite Results -> Select **Rewrite output**

Rewriting the output for the Title Property and using **Tokens** to the Title and Url fields.

	<h1><a href="{Content.Fields.ExternalPost.Url}" target="_blank">{Content.Fields.ExternalPost.Title}</a></h1>

![](../Upload/projections/titlerewrite.PNG)

2.**Author Property**

![](../Upload/projections/addingproperties.PNG)

Rewriting the output for the Author Property and using **Tokens**

	<p>Posted By <b>{Content.Fields.ExternalPost.Author}</b> on {Content.Date}</p>

![](../Upload/projections/authorrewrite.PNG)

## Creating a Projection Page for ExernalPostQuery(Unordered Html List)


![](../Upload/projections/projectionpage.PNG)

Select the **Show Pager** check box to add a pager to the list.

![](../Upload/projections/creatingprojectionpage.PNG)


## Rendering Results using Projection Widget


![](../Upload/projections/projectionwidget.PNG)

Select **ExernalPostQuery(Unordered Html List)** For Query

![](../Upload/projections/creatingprojectionwidget.PNG)

Rendered Result 

![](../Upload/projections/renderedresult.PNG)