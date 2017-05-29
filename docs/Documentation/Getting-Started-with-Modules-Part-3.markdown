## Introduction
This is part three of a four part course. It will get you started with a gentle introduction to extending Orchard at the code level. You will build a very simple module which contains a widget that shows an imaginary featured product. 

It will teach you some of the basic components of module development and also encourage you to use best-practices when developing for Orchard.

If you haven't read the previous parts of this course then you can go back to the overview to [learn about the Getting Started with Modules course](Getting-Started-with-Modules).

Now that we have built the widget and expanded it to use database storage for it's configuration we will turn to the Orchard API to make some decisions via code.

## Amending the widget through code
The second feature we have planned to add to the widget is some code that will detect when a user is viewing the featured product page and then make some changes to the display.

At the moment the widget is displayed site-wide with a big green "Click here to view it" link. When the user is on the product page it doesn't make sense to show a link back to itself.

In the previous part we added a configurable item to the widget. The widget read that setting in and updated itself. The same code is run no matter where you embed the widget. 

This time, we will expand the widget so that it is aware of its surroundings. When the page loads and the widget is asked to display, it will inspect the page as a whole, figure out what type of page it is on and then, if applicable, drill down to see what specific product page it's on. 

This information will then be passed through to the view so that we can change the display on the fly. 

## Setting up a ContentType to work with
The admin dashboard is quite powerful. If you have been using Orchard for long you'll likely have set up your own content types within the `Content Definition` section of the admin dashboard.

![](../Attachments/getting-started-with-modules-part-3/democontent-adminmenu.png)

This section allows you to combine pre-existing content parts together to form a custom content type that can be displayed in your site. 

It also has a section called **Fields**. When there isn't a content part that quite fits your needs you can turn to the **Fields** to add extra pieces of data to the content type on the fly.

We are going to quickly build a `Product` content type which has some of the common core content parts; a title, a URL, a menu entry and some body text. We will also add in single text field called `Product Id` to detect which particular product is being viewed:

  1. Navigate to the admin dashboard of your site.
  
  1. Click **Content Definition** in the menu down the side.
  
  1. Click **Create new type**.
  
  1. Enter `Product` for the `Display Name`. This should automatically fill out the `Content Type Id` field for you. Make sure the `Content Type Id` is also set to `Product`:
  
    ![](../Attachments/getting-started-with-modules-part-3/democontent-newtype.png)
  
  1. Click **Create**.
  
  1. In the **Add Parts to "Product"** section tick the following parts:
  
       * Autoroute
       * Body
       * Menu
       * Title

  1. Click **Save**. You will be taken to the **Edit Content Type** page and you should see several messages from the Orchard notifier system:
  
    ![](../Attachments/getting-started-with-modules-part-3/democontent-partsadded.png)
  
  1. Scroll down to the **Fields** section and then click the **Add Field** button:
  
    ![](../Attachments/getting-started-with-modules-part-3/democontent-addfield.png)
    
  1. On the **Add New Field To "Product"** page fill the form out like this:
  
      * Display Name: `Product Id`
      * Technical Name: `ProductId`
      * Field Type: `Input Field`

  ![](../Attachments/getting-started-with-modules-part-3/democontent-addnewfield.png) 
     
  1. Click **Save**.
  
  1. The main **Edit Content Type** page will reopen. Just for completeness lets configure the field so that it is flagged as required. If you scroll to the **Fields** section you will see your new field is now listed. The small `>` will expand out to show configuration properties for that field:
  
     ![](../Attachments/getting-started-with-modules-part-3/democontent-configurefield.png)
     
     Click the `>` to expand the field configuration pane.

  1. Tick the **Required** check box:
  
     ![](../Attachments/getting-started-with-modules-part-3/democontent-required.png)
     
     This will flag the field as requiring content when you create a new content item based off the `Product` content type. Orchard will automatically handle the validation for you and show a notification if the requirement is not met.
     
  1. To demonstrate the power of the configurable fields in Orchard we will also add a `Pattern` constraint. The `ProductId` should be in all caps, with only letters or numbers, no spaces or other punctuation. 
  
    To describe this pattern to the system we will use something called a regular expression (often shortened to a regex). At first these patterns can seem complex but they offer a succinct way to describe text patterns.
    
    To meet the requirement described above the regex will be: `^[A-Z0-9]+$`
    
    In the Pattern field enter the pattern `^[A-Z0-9]+$`.
    
  1. Click **Save**.

In the next section we will create a demo product using this new content type.

> **Regular Expression breakdown:** If you're curious as to what different sections are in the regex we just used, it breaks down into this:

>  * `^` means match the start of the string (nothing before it)
>  * `[]` means match the pattern of characters inside these brackets
>  * `A-Z` means match any character between uppercase A to uppercase Z
>  * `0-9` means match any character between 0 to 9
>  * `+` means match one or more repetitions of this character set. This means any combination of the letters and numbers but there needs to be at least one.
>  * `$` means match the end of the string (nothing after it)
  
## Prepare a sample product
For this to work we need to create a dummy product that will act as the featured product:

  1. Navigate to the admin dashboard of your site.
  
  1. In the **New** section of the menu click **Product**:
  
     ![](../Attachments/getting-started-with-modules-part-3/demoproduct-new.png)

  1. Set the `Title` of the page to "Sprocket 9000".
  
  1. Leave the `Permalink` blank.
  
  1. You can optionally add some content in to the `Body` section just for something to preview. Here is some Lorem Ipsum sample data: 
  
        Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Nulla 
        quis lorem ut libero malesuada feugiat. Sed porttitor lectus nibh. 
        Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere
        cubilia Curae; Donec velit neque, auctor sit amet aliquam vel, ullamcorper.
  
  1. The `Product Id` is the custom field we created for the content type. Notice the red `*` which indicates a required field. If you try to create the `Product` with a blank `Product Id` you will see a validation error:
  
    ![](../Attachments/getting-started-with-modules-part-3/demoproduct-required.png)
    
    If you try to enter an incorrect value that doesn't match the pattern we specified you will also see an error:
    
    ![](../Attachments/getting-started-with-modules-part-3/demoproduct-badpattern.png)
  
    Enter `SPROCKET9000` into the `Product Id`.
    
  1. Tick the **Show on a menu** checkbox.
  
  1. Leave the menu selection on **Main Menu**.
  
  1. In the **Menu text** enter the product name, "Sprocket 9000".
  
  1. Click **Publish Now**.
  
The page will reload after Orchard has created the new content item in the background. You will see a green message saying "Your Page has been created":

![](../Attachments/getting-started-with-modules-part-3/demoproduct-created.png)
  
If you navigate back to the front-end of the website you should see a new menu item called **Sprocket 9000**. Clicking it will take you to the demo page you just created:

![](../Attachments/getting-started-with-modules-part-3/demoproduct-page.png)

If the menu option doesn't appear on the page you probably clicked **Save** instead of **Publish**. When we created the content type is defaults to being marked as _draftable_. This means that you can save a copy in the system before it's made available publicly. Until you click the **Publish Now** button it won't show on the website.

That's all the preparation we need to do before we can dive back into the code. 

> **Bonus Exercise:** Go back to the admin dashboard and add in another product. It's not required but will mean that you can demonstrate the code is correctly identifying the product id later on.

All of this could also have been done through code. We developed this content type via the admin dashboard to show that it's possible to work with content types via code whether created through classes in a module or in the admin dashboard.

> **Bonus Exercise:** Using the techniques learned in the first parts of this course, go back and create a clone of the `Product` content type but create it through code. Name the new content type `ProductViaCode` so that it doesn't clash with the `Product` we have just created.

> Hint: The [creating types from code](Creating-types-from-code) documentation should point you in the right direction if you get stuck.  

## Writing code against the Orchard API
At the moment the widget is displayed site-wide with a big green "Click here to view it" link. When the user is on the featured product page it doesn't make sense to show a link back to itself.

We're going to use Orchard's API so that when the widget is asked to display itself (in the driver) it will examine the current page that's being displayed (the content item), check if it's on a product page (content type of `Product`) and then check the product id of the product page to see if it's the current featured product (the `ProductId` field contains the product).

For the sake of visual comparison we will swap the green "Click here to view it" button out with a purple box that says "Read more about it on this page".

## Expanding out the display shape lambda
So, based on this blueprint of our plans, how do we take the first step? The decision about what the module should display when it's asked to comes from the code within the driver class. The `Display()` method in the `FeaturedProductDriver.cs` class currently looks like this:

    protected override DriverResult Display(FeaturedProductPart part, 
      string displayType, dynamic shapeHelper) {
        return ContentShape("Parts_FeaturedProduct", 
          () => shapeHelper.Parts_FeaturedProduct());
    }

The `shapeHelper` takes a lambda as it's parameter (`() => shapeHelper.Parts_FeaturedProduct()`) and because the code being run at the moment is just a single line statement it is using a short form version of it. To give ourselves some room to code we can expand out the lambda so that it wraps the code in curly braces and returns a shape at the end.

In the case of our current `Display()` method the code would go from this:

    return ContentShape("Parts_FeaturedProduct", 
      () => shapeHelper.Parts_FeaturedProduct());

To this:

    return ContentShape("Parts_FeaturedProduct", () => { // curly brace here
        
        // extra space to write additional lines of code here
      
        return shapeHelper.Parts_FeaturedProduct(); // return keyword and semicolon
    }); // curly brace here
 
An alternative solution to expanding out this `Display()` method would have been to do our preparation at the start of the method, something like this:

    protected override DriverResult DisplayCat(FeaturedProductPart part, 
      string displayType, dynamic shapeHelper) {
        // extra code here
        return ContentShape("Parts_FeaturedProduct", 
          () => shapeHelper.Parts_FeaturedProduct());
    }

What's the difference and why is this a bad idea? The `Display()` method gets called to prepare the shapes each time a visitor requests a page. With the modularity of the Orchard code you might still end up having something else on the page influencing its display so that the shape doesn't make it to the final output.

When the setup code is passed within the lambda it doesn't get run until it's actually needed. This means that if you need to do some "expensive" setup code you don't want to run it unless you're sure it's going to be used. In this context expensive means heavy resource usage (it could require complicated database calls or data crunching) or time consuming (you might rely on calling a 3rd party web service to get some information).

You don't want to waste your resources and slow down the page being displayed by running unnecessary setup code so that's why you should use the first solution above. It keeps all the setup code inside the curly braces of the lambda and only runs it when the shape is actually being displayed.

Let's implement what we have discussed so far:  

  1. Open up the `FeaturedProductDriver.cs` file located in the `.\Drivers\ ` folder.
  
  1. Replace the `Display()` method with the following:
  
        protected override DriverResult Display(FeaturedProductPart part, 
          string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_FeaturedProduct", () => {
              // extra space to write additional lines of code here
              return shapeHelper.Parts_FeaturedProduct();
            });
        }

## Getting the current ContentItem being displayed
Getting the current `ContentItem` from within the widget driver means using some of the built-in Orchard classes.

To look up the `ContentItem` we need to get the `Id` of the content out of the ASP.NET MVC route data, then convert this into a content item by requesting it via the content manager.

We could add a public property to the driver which looked like this:

    private IContent _currentContent = null;
    private IContent CurrentContent {
      get {
        if (_currentContent == null) {
          var itemRoute = _aliasService.Get(_workContextAccessor.GetContext()
            .HttpContext.Request.AppRelativeCurrentExecutionFilePath
            .Substring(1).Trim('/'));
            
            _currentContent = _contentManager.Get(Convert.ToInt32(itemRoute["Id"]));
        }

        return _currentContent;
      }
    }

But where do all of these supporting classes like `_aliasService` and `_contentManager` come from?

## Dependency injection in Orchard
The modular design of Orchard means that each feature of Orchard tries to be as independent as it can. This means that when the Widget is building its shape it doesn't automatically know about the wider context of the page being requested. It is a specialized unit of code which completes its task as efficiently and simply as possible.

When it's required, the module can request access to parts of the larger Orchard system through the use of Orchard's service classes.

Orchard provides service classes that allow you to leverage Orchard features at the code level. When you need to do things like pulling content out of the content manager, displaying notifications, logging or working with the URL, you can turn to these services classes.

These classes are grouped together by a common inheritance; they implement `IDependency`. When you need one of them you simply need to add it to your constructor and an instance will be injected into your class at run-time. This is called dependency injection. You can get many frameworks that will enable this but in Orchard the service is provided by `Autofac`.

Each of these support classes specialize in providing a single feature. This means you only open communication channels to the main system for the parts which you actually need, keeping the system decoupled.

## Constructor injection
When you want to get access to one of Orchard's service classes you need to add a reference to the class to the default constructor. However, instead of requesting the class directly you will always work with the interface that the service you want implements.

The advantage of dependency injection is that you don't depend on concrete implementations (the actual class). Working with an interface means that you or a module can swap out the implementation of a specific class if it needs to. By always working with an interface instead of the actual service it means you don't need to know which particular implementation you are working with, preventing you from being tied to it.

So if you wanted a copy of the content manager then you would request `IContentManager contentManager` in your constructor.

The standard process for incorporating a new service into the class is as follows (you don't need to do this now):

  1. Create a new private, read-only variable to hold the injected class. It should start with an underscore like `_contentManager`.
   
  1. Update the default constructor to include the service as a parameter.
  
  1. Assign the injected class to the private variable for later use.

We will use this three step theory in the next section.

## Implementing CurrentContent
Based on the service requirements in our demo implementation above of the `CurrentContent` property we know that we will need `IContentManager`, `IWorkContextAccessor`, `IAliasService` to turn the route data into an instance of the current `ContentItem`.

Taking what we have learned about dependency injection and knowing our service requirements we can now implement the next stage of the `FeaturedProductDriver` class:

  1. Open up the `FeaturedProductDriver.cs` file located in the `.\Drivers\ ` folder.
  
  1. Add the following properties to the top of the `FeaturedProductDriver` class:
  
        private readonly IContentManager _contentManager;
        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly IAliasService _aliasService;

    `IAliasService` will need its namespace but when you try to add it via `Ctrl-.` you will see Visual Studio doesn't know where to find it.
  
     We need to add a reference and update the dependencies of our module.

  1. _Right click_ on the **References** entry in the module's project within the **Solution Explorer** window and choose **Add Reference...**.
  
  1. Click the **Projects** tab on the left. `Orchard.Alias` should already be visible. _Hover_ your mouse over it and a checkbox will appear. Click the checkbox for `Orchard.Alias`. Click **OK**.
  
     ![](../Attachments/getting-started-with-modules-part-3/orchardalias-ref.png)
     
  1. Now we have to update our dependencies straight away so they don't get forgotten. Open up the `Module.txt` file located in the project root.
  
  1. The last line of the file should contain the `Orchard.Widgets` dependency that we created in part one. This field will take a comma separated list detailing each dependency a modules has.
  
    Update the line to add `Orchard.Alias`, ensuring that the line keeps its indentation, so that the line now looks like this:
    
                Dependencies: Orchard.Widgets, Orchard.Alias

  1. Go back to the `FeaturedProductDriver.cs` file. You can now add the missing namespace via `Ctrl-.`.
  
  1. Below the private properties, add in a default constructor:
  
        public FeaturedProductDriver(IContentManager contentManager,
          IWorkContextAccessor workContextAccessor,
          IAliasService aliasService) {
            _contentManager = contentManager;
            _workContextAccessor = workContextAccessor;
            _aliasService = aliasService;
        }
         
     You can see that we are following the standard pattern of defining a private property, adding an instance to the constructor parameters and then assigning the injected class to the private variable.
     
  1. The Driver now has all of the requirements implemented to support the `CurrentContent` property. 
  
    Add this code in between the first batch of private properties and the constructor:
  
        private IContent _currentContent = null;
        private IContent CurrentContent {
          get {
            if (_currentContent == null) {
              var itemRoute = _aliasService.Get(_workContextAccessor.GetContext()
                .HttpContext.Request.AppRelativeCurrentExecutionFilePath
                .Substring(1).Trim('/'));                 
              _currentContent = _contentManager.Get(Convert.ToInt32(itemRoute["Id"]));
            }
            return _currentContent;
          }
        }
  
  1. If you have cleaned up your `using` statements then you might need to add a namespace using `Ctrl-.` for the `Convert.ToInt32()`.
  
The complete `FeaturedProductDriver.cs` should now look like this:

    using System;
    using Orchard.Alias;
    using Orchard.ContentManagement;
    using Orchard.ContentManagement.Drivers;
    using Orchard.LearnOrchard.FeaturedProduct.Models;
    
    namespace Orchard.LearnOrchard.FeaturedProduct.Drivers {
      public class FeaturedProductDriver : ContentPartDriver<FeaturedProductPart>{    
        private readonly IContentManager _contentManager;
        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly IAliasService _aliasService;
    
        private IContent _currentContent = null;
        private IContent CurrentContent {
          get {
            if (_currentContent == null) {
              var itemRoute = _aliasService.Get(_workContextAccessor.GetContext()
                .HttpContext.Request.AppRelativeCurrentExecutionFilePath
                .Substring(1).Trim('/'));
    
              _currentContent = _contentManager.Get(
                Convert.ToInt32(itemRoute["Id"]));
            }
            return _currentContent;
          }
        }
    
        public FeaturedProductDriver(IContentManager contentManager,
          IWorkContextAccessor workContextAccessor,
          IAliasService aliasService) {
            _contentManager = contentManager;
            _workContextAccessor = workContextAccessor;
            _aliasService = aliasService;
        }
    
        protected override DriverResult Display(FeaturedProductPart part, 
          string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_FeaturedProduct", () => {
              // extra space to write additional lines of code here
              return shapeHelper.Parts_FeaturedProduct();
            });
        }
    
        protected override DriverResult Editor(FeaturedProductPart part, 
          dynamic shapeHelper) {
            return ContentShape("Parts_FeaturedProduct_Edit",
              () => shapeHelper.EditorTemplate(
                TemplateName: "Parts/FeaturedProduct",
                Model: part,
                Prefix: Prefix));
        }
    
        protected override DriverResult Editor(FeaturedProductPart part, 
          IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
      }
    }
  
## Passing data to the view
We have already passed data to the view in previous parts but we didn't stop to examine it in detail:

    return ContentShape("Parts_FeaturedProduct_Edit",
      () => shapeHelper.EditorTemplate(
        TemplateName: "Parts/FeaturedProduct",
        Model: part,
        Prefix: Prefix));

These parameters are dynamic which means you can add any parameter you want. This means that we could update the `Display()` method to pass through a value by changing the code to:

    shapeHelper.Parts_FeaturedProduct(FavoriteColor: "Green");
    
The view would then be able to use this by using `@Model.FavoriteColor`.

We want to implement some logic into the `Display()` method which will result in answering the question `IsOnFeaturedProductPage` so that this can be passed through to the view.

We will do this by declaring `bool isOnFeaturedProductPage = false;` at the top of the method. It will be given a default value of `false` to start with. Then throughout the next few sections we will perform tests to see if it is in fact `true`.

Modify the first `Display()` method by following these steps:

  1. Open up the `FeaturedProductDriver.cs` file located in the `.\Drivers\ ` folder.
  
  1. Locate the `Display()` method and replace it with the following:
  
        protected override DriverResult Display(FeaturedProductPart part, 
          string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_FeaturedProduct", () => {
              bool isOnFeaturedProductPage = false;
              // detecting current product code will go here
              return shapeHelper.Parts_FeaturedProduct(
                IsOnFeaturedProductPage: isOnFeaturedProductPage);
            });
        }

This has laid the groundwork for us. The next piece of code will detect the content type, read the product id and update `isOnFeaturedProductPage` if required.

## Detecting the content type
The `CurrentContent` property that we implemented doesn't exactly return the current content item, it returns an `IContent`. This contains a property called `ContentItem` which then gives us access to everything related to the current content item.

You can explore the `ContentItem` class by navigating around using IntelliSense, or by navigating to the class itself with `F12`. There are lots of interesting properties to use.

The content type is stored as a string inside a `ContentTypeDefinition` property called `TypeDefinition`. You can get to it using this notation:

    var itemTypeName = CurrentContent.ContentItem.TypeDefinition.Name;
    
The `itemTypeName` variable will then contain a string version of the content type. The `Product` content type was created via the admin dashboard. This means that there isn't a concrete class for us to use in a `typeof(T).Name` call so we will have to work with the string "Product" when we're checking the type of the current content item.

Putting the code together is just a case of a standard .NET string comparison:

  1. Open up the `FeaturedProductDriver.cs` file located in the `.\Drivers\ ` folder.
  
  1. Locate the `Display()` method and replace it with the following:
  
        protected override DriverResult Display(FeaturedProductPart part, 
          string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_FeaturedProduct", () => {
              bool isOnFeaturedProductPage = false;
              // new code
              if(CurrentContent != null) {
                var itemTypeName = CurrentContent.ContentItem.TypeDefinition.Name;
                if (itemTypeName.Equals("Product",
                  StringComparison.InvariantCultureIgnoreCase)) {
                  // final product id check will go here
                }				
              }
              // end of new code
              return shapeHelper.Parts_FeaturedProduct(
                IsOnFeaturedProductPage: isOnFeaturedProductPage);
            });
        }
          
     You don't need to include the comments in your module, they are just for guidance.

## Using fields
Fields are a great way to quickly surface data. We added one to our `Product` content type in the admin dashboard in just a minute or two. We didn't need write a `ContentPart` or work with Visual Studio at all. When creating websites in Orchard you will find plenty of occasions where using a field is appropriate.

If you look in forums and chat rooms you will find that they've been known to confuse first time users.

It's not that they are complicated to use, far from it. It's just that the correct way to access them isn't discoverable through IntelliSense so developers hit a brick wall.

We are going to cover the two important things you need to learn about fields so that you find them just as easy to work with in code as you have done in the admin dashboard.

The first important thing to understand is: `Fields` are *always* in a `ContentPart`.

To be fair, it looked like you had just created the field outside of the content type:

![](../Attachments/getting-started-with-modules-part-3/fields-hiddencontentpart.png)

But in truth, Orchard created an invisible `ContentPart` for you and attached those fields to that. The name of that content part is the name of the content type. So for our `Product` content type, the content part would be `Product`. For a `HtmlWidget` it would be `HtmlWidget`, if you added a field to the `Page` you would access it with `Page`.

So the way to access our `ProductId` field which is on the `ContentType` of `Product` we would write:

    var productId = CurrentContent.ContentItem.Product.ProductId.Value;
    
Where did the `.Value` come from? Well, your field is not just a simple string. You defined it as a `"Text Field"` when you filled out the form. This maps to the `Orchard.Fields.Fields.InputField` class and you can access its data through the `.Value` property.

> As you build up your skills as an Orchard module developer one of the important ones will be digging through the code to discover this sort of thing for yourself. As I was writing this I didn't know what the class was called. To find it out I put a breakpoint on the line of code, started a debug session and inspected the field to see what class it was and how to get at its data.

> This is a useful skill to have in your repertoire when working with Orchard but in this case you also have a useful resource that has been put together by Sebastien Ros. He has created an [Orchard Cheatsheet](http://sebastienros.github.io/CheatSheet/) which covers common properties that you might want to access on each of the built-in Orchard content fields.

The second important thing to understand with accessing fields is that if you tried that line above you wouldn't get very far, and this is the reason why new developers have had so much trouble with it. The fields are injected into the class at run-time using .NET `dynamic` features. 

This means you don't get IntelliSense for dynamic properties. It also means that unless the class is marked as `dynamic` the code won't compile. So before you can use code to access your field you need to cast your `ContentItem` to `dynamic`:

    var dynamicContentItem = (dynamic)CurrentContent.ContentItem;
    var itemProductId = dynamicContentItem.Product.ProductId.Value;

Once you have the product id in a string it's just a case of comparing it against the known value and setting `isOnFeaturedProductPage = true` if it's a match:

  1. Open up the `FeaturedProductDriver.cs` file located in the `.\Drivers\ ` folder.
  
  1. Locate the `Display()` method and replace it with the following:
  
        protected override DriverResult Display(FeaturedProductPart part, 
          string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_FeaturedProduct", () => {
              bool isOnFeaturedProductPage = false;
              var itemTypeName = CurrentContent.ContentItem.TypeDefinition.Name;
              if (itemTypeName.Equals("Product", 
                StringComparison.InvariantCultureIgnoreCase)) {
                  // new code
                  var dynamicContentItem = (dynamic)CurrentContent.ContentItem;
                  var itemProductId = dynamicContentItem.Product.ProductId.Value;
                  if(itemProductId.Equals("SPROCKET9000",
                    StringComparison.InvariantCulture)) {
                      isOnFeaturedProductPage = true;
                  }
                  // end of new code
              }
              return shapeHelper.Parts_FeaturedProduct(
                IsOnFeaturedProductPage: isOnFeaturedProductPage);
            });
        }

That's all the code that's needed to detect the page content type and check the product id field.

You might have noticed that this time around we just used `StringComparison.InvariantCulture`. This is because we have already enforced uppercase so we can be sure that the case doesn't conflict with the test value.

Now that we have completed the code to identify the current page and passed that through to the shape it will be accessible in the view as `@model.IsOnFeaturedProductPage`. 

In the last section of this lesson we will update the view to make use of this information.  

## Updating the view
Once you have done the work in the driver it's simple for you to make decisions based on the value passed to the model. In part two we looked at using conditionals and reading values from the `Model`. 

Now we are going to re-use these skills:

  1. Open up the view file located at `.\Views\Parts\FeaturedProduct.cshtml`
  
  1. Copy this CSS snippet into the `<style>` block at the top of the view:

        .box-purple {
          padding: 1em;
          text-align: center;
          color: #fff;
          background-color: #7b4f9d;
          font-size: 2em;
          display: block;
        }
  
  1. Find this line of markup (it should be the last line in the view):
  
        <p><a href="~/sprocket-9000" class="btn-green">Click here to view it</a></p>
          
     And replace it with:
     
        @if (!Model.IsOnFeaturedProductPage) {
          <p>
            <a href="~/sprocket-9000" class="btn-green">Click here to view it.</a>
          </p>
        } else {
          <p class="box-purple">Read more about it on this page.</p>
        }
          
  1. Save and close the file.

For reference, your complete `FeaturedProductDriver.cs` class should now look like this:

    using System;
    using Orchard.Alias;
    using Orchard.ContentManagement;
    using Orchard.ContentManagement.Drivers;
    using Orchard.LearnOrchard.FeaturedProduct.Models;
    
    namespace Orchard.LearnOrchard.FeaturedProduct.Drivers {
        public class FeaturedProductDriver : ContentPartDriver<FeaturedProductPart> {
            private readonly IContentManager _contentManager;
            private readonly IWorkContextAccessor _workContextAccessor;
            private readonly IAliasService _aliasService;
    
            private IContent _currentContent = null;
            private IContent CurrentContent {
                get {
                    if (_currentContent == null) {
                        var itemRoute = 
                          _aliasService.Get_workContextAccessor.GetContext()
                            .HttpContext.Request.AppRelativeCurrentExecutionFilePath
                            .Substring(1).Trim('/'));
                        _currentContent = _contentManager.Get(
                          Convert.ToInt32(itemRoute["Id"]));
                    }
                    return _currentContent;
                }
            }
    
            public FeaturedProductDriver(IContentManager contentManager, 
              IWorkContextAccessor workContextAccessor, IAliasService aliasService) {
                _contentManager = contentManager;
                _workContextAccessor = workContextAccessor;
                _aliasService = aliasService;
            }
    
            protected override DriverResult Display(FeaturedProductPart part,
              string displayType, dynamic shapeHelper) {
                return ContentShape("Parts_FeaturedProduct", () => {
                    bool isOnFeaturedProductPage = false;
    
                    if (CurrentContent != null) {
                        var itemTypeName = 
                          CurrentContent.ContentItem.TypeDefinition.Name;
    
                        if (itemTypeName.Equals("Product",
                          StringComparison.InvariantCultureIgnoreCase)) {
    
                            var dynamicContentItem = 
                              (dynamic)CurrentContent.ContentItem;
                            var itemProductId = 
                              dynamicContentItem.Product.ProductId.Value;
    
                            if (itemProductId.Equals("SPROCKET9000",
                              StringComparison.InvariantCulture)) {
                                isOnFeaturedProductPage = true;
                            }
                        }
                    }
    
                    return shapeHelper.Parts_FeaturedProduct( 
                      IsOnFeaturedProductPage: isOnFeaturedProductPage);
                });
            }
    
            protected override DriverResult Editor(FeaturedProductPart part, 
              dynamic shapeHelper) {
                return ContentShape("Parts_FeaturedProduct_Edit",
                  () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/FeaturedProduct",
                    Model: part,
                    Prefix: Prefix));
            }
            
            protected override DriverResult Editor(FeaturedProductPart part, 
              IUpdateModel updater, dynamic shapeHelper) {
                updater.TryUpdateModel(part, Prefix, null, null);
                return Editor(part, shapeHelper);
            }
        }
    }

## Trying the module out in Orchard
This is the part where it all pays off. If you run Orchard in the browser you will see the updates we have been working on in action:

  1. Within Visual Studio, press `Ctrl-F5` on your keyboard to start the website without debugging enabled (it's quicker and you can attach the debugger later if you need it).
  
  1. You will start off on the homepage. The widget should look the same as it did at the end of part two:
  
    ![](../Attachments/getting-started-with-modules-part-3/testing-homepage.png)
    
  1. Click on the **Sprocket 9000** menu item to go to your product page. You should see a purple notification box instead of a link:
  
    ![](../Attachments/getting-started-with-modules-part-3/testing-sprocket.png)
    
  1. If you followed the **Bonus Exercise** section and created additional demo product pages you can also navigate to those and you will see the same view as the homepage:
  
    ![](../Attachments/getting-started-with-modules-part-3/testing-testproduct.png)
    
    This is because it matches the content type but not the product id. 

## Download the code for this lesson
You can download a copy of the module so far at this link:

  * [Download Orchard.LearnOrchard.FeaturedProduct-Part3-v1.0.zip](../Attachments/getting-started-with-modules-part-3/Orchard.LearnOrchard.FeaturedProduct-Part3-v1.0.zip)
  
To use it in Orchard simply extract the archive into the modules directory at `.\src\Orchard.Web\Modules\ `. If you already have the module installed from a previous part then delete that folder first.

> For Orchard to recognize it the folder name should match the name of the module. Make sure that the folder name is `Orchard.LearnOrchard.FeaturedProduct` and then the modules files are located directly under that.

## Conclusion
In this part we have learned valuable skills that will allow us to create content types in the admin dashboard and add fields to them. We have learned about dependency injection, how to request access to Orchard's various service classes, how to examine the current content item and make decisions based on it. Finally we looked at how we can create and surface custom information from the code of the module up to the view.

In the next and [final part of this getting started with modules course](Getting-Started-with-Modules-Part-4) we will refine the existing module and apply some development best-practices that haven't been covered yet.
