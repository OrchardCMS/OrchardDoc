1.	Make sure the Orchard project can be deployed as individual .NET-based CMS application.
2.	Make sure it is easy for 3rd party developer to customize Orchard through extensions and themes. 
3.	Make sure it is easy for 3rd party developers to build similar applications by re-usable components provided by Orchard.
4.	Avoid any security and spam holes. 

# Component Overview
The component overview and specs are listed on:
http://www.orchardproject.net/docs/?AspxAutoDetectCookieSupport=1

# Test Methodology
We'll use Visual Studio Team Test edition as the major platform for testing. We try to automate as much test cases as possible, so VSTT is used to support the following test:
1.	Code coverage
The instrumented build of Orchard is going to be created by VSTT, we can get code coverage information by running automation tests and manual tests on instrumented build.

2.	Functionality & unit testing
Existing unit test cases are automated by NUnit framework. Creating unit test of actions in all controllers, to verify correct view data is passed to views.

Model validation logics are also tested by NUnit tests. 

3.	Data driven tests
A MVC application are driven by data, for e.g. url requests are routed to correct actions, views are bound to correct models.  

In order to randomize the test scenarios with correct data, a data driven test approach is applied to perform test.  There are two approaches to generate test data:
a)	Save predefined data in an Excel file, and utilize data driven test features in VSTT to perform tests.
b)	Randomly generating test data by a data generating tool, and combine with the power of pair-wise generation. We are able to generate as many valid data as possible on the fly. 
We'll use the approach a) to perform data generating operation, because we are not able to share tools to public community yet. 
4.	Controller test
Actions in all controllers have unit tests. Parameters of action methods are generated based on approach described in "Data driven tests". 

5.	Manual test.
Manual tests are designed to perform usability testing, to see whether the operation work flow make sense to users. These manual tests documents are maintained in VSTT, in this way we are able to combine manual & automation test result in a single test pass.

6.	Stress test & Performance test

# Communication Plan
Bugs are tracked in "Issue Tracker" of http://orchard.codeplex.com. Everyday testers get latest code from codeplex by subversion, and perform the tests. Since bugs are tracked in codeplex, we are able to export bug status to Excel, view the bug trends, and make the sign-off decision.

In the beginning few iterations, testers are not familiar with product features. Testing are started 1 iteration behind development, that is, testers perform testing on features finished, while developers work on features in next iteration.  Latest finished features are fed to testers in iteration post-mortems.  In the later iterations, while testers get familiar with product features, testers should be able to work in the same iteration as developers.  Ideally, testing works just 1 or 2 days behind development.

# Stress Test Methodology
1)	Use VSTT WebTests to record key scenarios.
2)	Create two databases. One contains normal volume of data, another contains huge data.
3)	Use VSTT LoadTests to configure web browser, User Count, network bandwidth, run time.

