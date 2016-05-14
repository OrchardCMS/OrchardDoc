The choice of a doctype is such a choice that we have to make for our own default themes.
This page presents the main points and results of our debate about the choice of a doctype.

* Theme authors will ultimately be free to pick any DTD/doctype they want, this only describes the default ones and the ones that we'll build.
* Cross-browser compatibility is a must.
* HTML 5 is the future-proof choice.
* XHTML is important to many.
* IE6 support is hopefully on its way out but is probably still necessary for the front-end.
* For the back-end (the admin interface), we have decided to drop IE6 support.
* IE has never really supported XHTML at all but merely tolerated it (it just renders it because XHTML is constrained HTML with some extra stuff that is getting ignored).
* XHTML specs recommend serving XHTML with the right MIME type and discourage using several features such as custom namespaces unless that is the case. Unfortunately, that fails in IE.
* HTML 5 does have an XHTML 5 flavor, but it has been considerably scaled down and is now little more than a serialization format.
* The XHTML team at W3C is getting dissolved.
* No existing browser supports all of HTML5 yet.
* The part of HTML5 markup that is not new will just work on past, present and future browsers.
* HTML5 and past, present and future browsers are resilient to XHTML syntax such as self-closing tags. It will validate against HTML5.
* In reality, browsers ignore the doctype, they have only two modes: quirks and standard (except IE8, which also has IE7 mode, off topic here), pretty much determined by the presence of a doctype, not by its value.
* We are going to operate in standard mode no matter what our choice of doctype is.
* We should use the subset of HTML 5 that will work in today's browsers.
* We should use markup that is XHTML-compatible (self-closing tags, etc.) even if we don't use a true XHTML doctype.
* We should make sure our markup validates on the W3C validators.

In summary, we're recommending the use of the HTML 5 doctype, using the subset of HTML 5 that is compatible with today's browsers and using the XHTML-compatible style.

## References
1. [The future of XHTML explained as a comic book](http://media1.smashingmagazine.com/wp-content/uploads/images/xhtml2-html5/comic-960px.jpg)
