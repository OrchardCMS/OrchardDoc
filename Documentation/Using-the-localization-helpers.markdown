
Orchard uses a simple API to allow for localization that takes the default language string (en-us) as its input (that string will be used as the key into the localization data) and returns the most accurate localized version available for the current culture.


# Simple usage - translated string is returned and output

    <%: T("This was a triumph!") %>


Use this for simple strings.

# Formatting user data

Sometimes, data needs to be injected into a localizable string.

Do not use concatenation as the position of the data might vary per language:

    
    BAD!!!
    <%: T("Welcome, ") + firstName + T(".") %>


Instead, use a parameterized format string:

    
    <%: T("Welcome, {0}.", firstName) %>


## Encoding data
Please note that the arguments will be encoded before being added. For example, if noteText in the following example contains "&lt;b&gt;huge&lt;/b&gt; success":

    
    <%: T("I'm writing a note here: {0}.", noteText) %>


Then the output in the default culture will be: "I'm writing a note here &lt;b&gt;huge&lt;/b&gt; success." with the markup visible to the end user.

This is *what you want* in 99% of cases. This automatic encoding is protecting you from nasty injection attacks.

In the rare cases where you absolutely know what you're doing and you want the unencoded string to be injected, you can do the following:

    
    <%: T("I'm writing a note here: {0}.", new HtmlString(noteText)) %>


This will result in "I'm writing a note here <b>huge</b> success."

> Note: any object of a type implementing IHtmlString will be injected unencoded as we assume it to already be properly encoded. This is the trick you are using when writing `new HtmlString(noteText)`.

For example, if you do the following:
    
    <%: T("{0}: We do what we must because {1}",
        Html.ItemDisplayLink(apertureScienceContentItem),
        justification) %>


Then the action link will not be encoded and will work as expected, while the justification string will be encoded.


It should also be noted that the format string itself is considered safe as it is provided by the module author, so the following will work as expected:

    
    <%: T("It's <em>hard</em> to overstate my <strong>{0}</strong>",
        emotion) %>


If emotion contains "&lt;satisfaction&gt;", the resulting string will be "It's <b>hard</b> to overstate my <b>&lt;satisfaction&gt;</b>".

## Injecting non-string values

Basic value types are not html encoded before formatting, and the current culture will be used to format them:

    
    <%: T("when {0} qty {1:#,##0.00} unit price{2:C}", _clock.UtcNow, 5.782, 87 ) %>


# Pluralization

Pluralization of resource strings (such as "{0} comment" or "{0} comments") can be tricky as the rules for pluralization or even how many strings you need for all cases wildly varies across languages. While Orchard does not yet implement all possible cases, the API is ready to support them in the future.

If a string needs to be pluralized, provide two strings for the default language and put the pluralization parameter first:

    
    <%: T.Plural("1 Comment", "{0} Comments", commentCount) %>
    <%: T.Plural("Deleted 1 item of type {1}", "Deleted {0} items of type {1}",
        deleteCount, contentType) %>


Do use "1" literally in the singular string to provide better context to translators.

The pluralization parameter must be an integer.

Do not use custom logic in the views to decide between strings, as that would put in the view logic that may vary by culture.

# &lt;%= %&gt; vs. &lt;%: %&gt;

&lt;%: %&gt; is to be used in all cases because it handles encoding automatically. Never use &lt;%= %&gt;. If you are sure you need unencoded strings injected, still use &lt;%: %&gt; with an HtmlString.
