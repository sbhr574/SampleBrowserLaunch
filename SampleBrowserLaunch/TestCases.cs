using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SampleBrowserLaunch
{
    public class Tests
    {
        public IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            //ChromeOptions options = new ChromeOptions();
            EdgeOptions options = new EdgeOptions();

            options.AddAdditionalEdgeOption("useAutomationExtension", false);
            options.AddArguments("--headless");
            options.AddArguments("--window-size=1325x744");
            options.AddArguments("--disable-popup-blocking");
            //var dir = AppDomain.CurrentDomain.BaseDirectory.Substring(0, Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).LastIndexOf("bin"));
            //string finalpth = dir + "BrowserDrivers";
            new DriverManager().SetUpDriver(new EdgeConfig());

            _driver = new EdgeDriver(options);
            _driver.Navigate().GoToUrl("https://www.facebook.com/");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("****************** Test has been Started ******************");
            string textMsg = _driver.FindElement(By.CssSelector("a[data-testid*='open-registration']")).Text;
            Assert.AreEqual("Create new account", textMsg);
        }

        [TearDown]
        public void closeBrowser()
        {
            _driver.Close();
        }
    }
}