﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.IO;

[SetUpFixture]
public abstract class Base
{
    protected ExtentReports _extent;
    protected ExtentTest _test;

    [OneTimeSetUp]
    protected void Setup()
    {
        var dir = TestContext.CurrentContext.TestDirectory + "\\test-output\\";
        Directory.CreateDirectory(dir);
        var fileName = this.GetType().ToString() + ".html";
        var htmlReporter = new ExtentHtmlReporter(Path.Combine(dir, fileName));

        _extent = new ExtentReports();
        _extent.AttachReporter(htmlReporter);
    }

    [OneTimeTearDown]
    protected void TearDown()
    {
        _extent.Flush();
    }

    [SetUp]
    public void BeforeTest()
    {
        _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
    }

    [TearDown]
    public void AfterTest()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
        Status logstatus;

        switch (status)
        {
            case TestStatus.Failed:
                logstatus = Status.Fail;
                break;
            case TestStatus.Inconclusive:
                logstatus = Status.Warning;
                break;
            case TestStatus.Skipped:
                logstatus = Status.Skip;
                break;
            default:
                logstatus = Status.Pass;
                break;
        }

        _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
        _extent.Flush();
    }
}