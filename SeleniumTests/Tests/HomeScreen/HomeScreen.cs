using OpenQA.Selenium;
using SeleniumWebdriverHelpers;
using Selenium.WebDriver.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTests.Tests
{
    class HomeScreen
    {
        private IWebDriver driver = Driver.driver;
        private IJavaScriptExecutor js = Driver.js;
        private string randID = Driver.randomID(6);


        public void clickResetButton()
        {
            driver.FindElement(By.XPath("//span[contains(text(),'Reset')]")).Click();
        }

        public void clickCancelButton()
        {
            driver.FindElement(By.XPath("//span[contains(text(),'Cancel')]")).Click();
        }

        public void clickUpdateButton()
        {
            driver.FindElement(By.XPath("//span[contains(text(),'Update')]")).Click();
        }
    }
}