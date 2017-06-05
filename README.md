# WebApiOwinTesting

A simple example of how to use the self-hosted Owin test server when testing against an ASP.NET Web Api, where the Web Api project is configured to use IIS server. Using the Owin test server means you don't need your site to be actively running on IIS in order to execute your tests.

The class [ApiTests](https://github.com/seanvander/WebApiOwinTesting/blob/master/WebApplication.Test/ApiTests.cs) shows how the test server is created and used.
