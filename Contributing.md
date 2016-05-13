# Contributing #

The documentation is built using [MkDocs](http://mkdocs.org/) and [markdown](https://daringfireball.net/projects/markdown/), and then hosted by [ReadTheDocs](http://orcharddoc.readthedocs.org/).

## Testing the Docs on your local machine ##

Once you have cloned the Docs to your local machine, the following instructions will walk you through installing the tools necessary to build and test.

1. [Download python](https://www.python.org/downloads/) version 3.4 or higher.

2. If you are installing on Windows, ensure both the Python install directory and the Python scripts directory have been added to your `PATH` environment variable. For example, if you install Python into the c:\python34 directory, you would add `c:\python34;c:\python34\scripts` to your `PATH` environment variable.

3. Install MkDocs by opening a command prompt and running the following Python command. (Note that this operation might take a few minutes to complete.)

    ```pip install mkdocs```

4. Go to the docs folder and run ``mkdocs serve`` 

    ```mkdocs serve```

5. Simply open the [http://127.0.0.1:8000](http://127.0.0.1:8000) in your browser to see the docs.

## Adding Content ##

Before adding content, submit an issue with a suggestion for your proposed article. Provide detail on what the article would discuss, and how it would relate to existing documentation.

Create a .markdown file in the Documentation folder.

Add a corresponding entry in mkdocs.yml in the table of content, below the 'pages:' section under an appropriate sub-section. Ex :
```
- Sub section title:
    - Page title: Documentation/Page-Title.markdown     
```

## Process for Contributing ##

**Step 1:** Open an Issue describing the article you wish to write and how it relates to existing content.

**Step 2:** Fork the `/orchardcms/orcharddoc` repo.

**Step 3:** Create a `branch` for your article.

**Step 4:** Write your article, placing the article in /Documentation folder and any needed images in a folder like /upload/my-article.

**Step 5:** Submit a Pull Request from your branch to `orchardcms/orcharddoc/master`.

**Step 6:** Discuss the Pull Request with the team; make any requested updates to your branch. When they are ready to accept the PR, they will add a :shipit: (`:shipit:`) comment.

## Common Pitfalls ##

Below are some common pitfalls you should try to avoid:

- Don't forget to submit an issue before starting work on an article
- Don't forget to create a separate branch before working on your article
- Don't update or `merge` your branch after you submit your pull request