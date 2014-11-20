We apply selenium for UI automation test; please download selenium IDE and selenium RC from its official website. Please read the selenium document in the web site to learn its usage.

# Export test case to VSTT
Please export test cases as C# code in Selenium IDE, after you finished recording a test case. Although the generated C# code targets NUnit only, however, it is not difficult for you to do tiny modification to use the code in VSTT. Below are all modification you should make:

1. Changing \[TestFixture\] attribute to \[TestClass\] attribute\.
2. Changing \[Setup\] attribute to \[TestInitialize\] attribute
3. Changing \[TearDown\] attribute to \[TestCleanup\]\.
4. Changing \[Test\] attribute to \[TestMethod\]\.

# Encapsulate common test actions to functions & classes
Though Selenium does a great job for us to generate C# test code, however, many common actions exist in our test cases. For e.g. most of site administration functions require user logon, before making any actions. Actions like logon, create blog/post are good candidates to be rewritten as a common function.

If you see common steps/verifications in more 2 test cases, you'd better to think moving the steps to a helper class (classes derived from class HelperBase).

# Create a simple test by using the test framework
Let's say you are going to create a test which verifies a link named "Admin" is presented, for Administrators. Below is the tests based on the test framework:

    
    [TestMethod]
    public void CanNotAccessAdminPanelTestHelper()
    {
        TestLibrary.UserHelper.LogOn("Administrator", "0123456");
        Assert.IsFalse(selenium.IsElementPresent("link=Admin"));
    }


In above code, the UI actions required for logon actions are encapsulated to TestLibrary.UserHelper.LogOn method, which accepts logon user name as its first parameter, the password as its second parameter. This is the source code of TestLibrary.UserHelper.LogOn, you can see how the logic is applied:

    
    public void LogOn(string username, string password)
    {
        if (username == null)
            throw new CaseErrorException(new ArgumentNullException("username"));
        if (password == null)
            throw new CaseErrorException(new ArgumentNullException("password"));
    
        selenium.Open("/");
        selenium.Click("link=Log On");
        selenium.WaitForPageToLoad(TestLibrary.Consts.TimeToWaitForPageToLoad);
        selenium.Type("username", username);
        selenium.Type("password", password);
        selenium.Click("//input[@value='Log On']");
        selenium.WaitForPageToLoad(TestLibrary.Consts.TimeToWaitForPageToLoad);
    }


Because logon as default administrator is frequently used in test code, we created a handy method called TestLibrary.UserHelper.LogOnAsAdmin for this. Above code can be rewritten as below:

    
    [TestMethod]
    public void CanNotAccessAdminPanelTestHelper()
    {
        TestLibrary.UserHelper.LogOnAsAdmin();
        Assert.IsFalse(selenium.IsElementPresent("link=Admin"));
    }


# Description of Important Classes & Methods

## Class CaseErrorException
If you need throw an exception from your test code, indicates test code error. Please throw an instance of CaseErrorException, instead of throwing original exception directly. For e.g, in below test code:

    
    public Blog CreateBlog(string title, string menuText, string permalink,
        string description, bool addMainMenu, string owner)
    {
        // empty string is intendly left for testing purpose
        if (title == null)
            throw new CaseErrorException(new ArgumentNullException("title"));
        if (permalink != null)
            throw new CaseErrorException("Set menu Permalink is not implemented yet!");
        if (owner != null)
            throw new CaseErrorException("Set owner is not implemented yet!");
    
        ...
    }


If a null reference is passed to parameter "title", this is a bug in test code. In order to distinguish test bugs from product bugs, we'd better throw an instance of CaseErrorException, with the original exception as its inner exception. This is useful in controller test, because the test code calls controllers directly, we need a way to distinguish test bugs from product bugs, while investigate test failures.

## Class TestLibrary.Consts
Please put all constants to this class, for e.g. the default administrator name/password in the test database.

## Method TestLibrary.SetupTest
This static method launches different browsers according to predefined excel spreadsheet file. Because it is common for us to debug new test and test failures in local machine, the method is able to detect this.

# Data driven test approach

## Methodology of data driven tests
Please check the following article to understand how data driven tests is done in Visual Studio Team Test/Suite edition:
<http://www.julmar.com/blog/mark/PermaLink,guid,e47f09cc-e893-46a6-aa13-7202d4e50986.aspx>

## Running tests against different browsers
In order to run all tests on different browsers, and reuse the same test logics. The test code saves browsers settings in the excel file. Test team developed a script, which adds browser settings, such as "*opera", "*iexplore" and e.t.c to the excel files. So in test case automation phase, just put test data in the excel files is fine. The script is run before any tests, which adds browser settings to all excel files and copy the files to %TestOutputDir%.

There is another way to launch different browser, selenium remote control sever has a switch called -forcedBrowserMode, this switch overrides settings (hard code brower string) in ocde. This is also quite convenient while debugging test failures.

## Naming Convention
In order to keep test cases and test data are easy to read, please follow below guideline:  

1. One test class should have 1 excel file which saves test data. For e.g. If you need save test data for class CommentsTest, please name the excel file as CommentsTest.xls. Please note that only Excel 2003 file format is supported by Visual Studio Team Test Edition.
2. Each test method has its own worksheet to save test data, and the worksheet's name is same as test method name.
3. Please refer to test class Orchard.Test\Automation\Components\Comments\CommentsTest.cs for a sample of this guideline.

// TODO: add steps to create BVT.ordertest and other test suites  


