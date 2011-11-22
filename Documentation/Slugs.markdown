
The slug admin UI shows the first part of the URL as read only and follows that immediately with a textbox that is wide enough to accommodate long slugs.

We should explain what a slug is and what it's used for right in the admin UI as many users will not be familiar with that notion:
"A ‘slug' is what Orchard uses to build a unique and readable address for your pages. You can usually trust the system to build one for you from the title or you can tweak it to make it shorter or more or less explicit, at your convenience. An example of slug is 'about-us'."

## Validation

* A slug can't be empty. The slug that we store in the database should never be empty, but the user is allowed to not enter a slug. In that case, we generate one for him (see below).
* A slug can't be more than (some arbitrariness here) 1000 characters, which allows for some reasonable additions such as /json or the first parts of the url without a great risk of hitting IE's 2048 char limit for the URL. Message: "Please keep the slug under a thousand characters."
* A slug can have international characters and should conform to the RFC for IRI (International Resource Identifier): [RFC 3987](http://tools.ietf.org/html/rfc3987), which is supported by all modern browsers. A slug can include slashes (/) but each token between slashes must conform to RFC 3987 and not include any of the following characters: ":", "/", "?", "\#", "\[", "\]", "@", "\!", "$", "&", "'", "\(", "\)", "\*", "\+", ",", ";", "=", " ".
"Please do not use any of the following characters in your slugs: ":", "?", "\#", "\[", "\]", "@", "\!", "$", "&", "'", "\(", "\)", "\*", "\+", ",", ";", "=". No spaces are allowed (please use dashes or underscores instead)."

## Slug generation

When JavaScript is enabled, we should generate a slug after the title field has been entered. When a character is outside of the range of allowed characters, we should replace them with dashes. The generated slug should be converted to lowercase during generation, but if it's manually entered, we should leave it as is. In other words, we should only generate a slug if it was previously empty.

When JavaScript is not enabled, the user will have to type a slug himself or leave the field empty. When the form is submitted with an empty slug, we generate one from the title.

The slug can be changed even after the resource has been created. This is somewhat dangerous because internal and external links to that page might get out of sync as a result, so we should display a warning in that case: "You changed the slug of this page from "{0}" to "{1}", which changes its address. Links to this page may get broken as a result."

Note that we allow forward slashes into the slug, which allows the user to manually introduce some hierarchy even though we don't support parent pages.

The slug prefix is built from the application path and the currently configured routes for the module. For example, if the application URL is "http://mydomain/mysite" and the URL for the resource with slug "my-slug" is "~/pages/my-slug", we prefix the slug input field with "http://mydomain/mysite/pages/".

When the generated or manually entered slug is discovered by the server to not be unique, it should be made unique by adding a number after it.
