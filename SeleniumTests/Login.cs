using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriverHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace SeleniumTests
{
    class Login : Driver
    {
        public static void LoginPortal()
        {
            Driver.loadConfigFile();
            WriteLineToConsole(string.Format("Running test with browser = {0}", browser));
            WriteLineToConsole("Navigating to " + ConfigurationManager.AppSettings["BaseURL"]);
            driver.Navigate().GoToUrl(url);
            // check : if logged on, log off
            try
            {
                IWebElement logout = driver.FindElement(By.XPath("//*[@id='divMainWrapper']/header/div[6]/a[3]"));

                if (logout != null)
                {
                    WriteLineToConsole("User logged on - log off first");
                    logout.Click();
                    driver.Navigate().GoToUrl(url);
                }
            }
            catch { }
            try
            {
                WriteLineToConsole("Waiting for email input to appear");
                WaitUntilVisible(20,"User email input not found",By.Id("txtUserEmail"));

                WriteLineToConsole("Entering User Email");
                IWebElement loginName2 = driver.FindElement(By.Id("txtUserEmail"));
                loginName2.SendKeys(username);

                WriteLineToConsole("Entering User Password");
                IWebElement loginPass2 = driver.FindElement(By.Id("txtPassword"));
                loginPass2.SendKeys(password);

                WriteLineToConsole("Clicking the Login button");
                loginPass2.SendKeys(OpenQA.Selenium.Keys.Enter);

                WriteLineToConsole("Checking for login");
                IWebElement result = WaitUntilVisible(60, "Welcome message not found. Login Failed.",By.Id("parWelcome"));
            }
            catch (Exception ex)
            {
                //su.Msg = string.Format("{0}. {1}.", ConfigurationManager.AppSettings["TestFailedMessage"], ex.Message);
                //WriteLineToConsole(su.Msg);
                //su.Error = 99;
            }
        }

        public static void Logout()
        {
            driver.FindElement(By.CssSelector("div[class*='menu-button']")).Click();
            driver.FindElement(By.XPath("//div[contains(text(),'Logout')]"));
        }
    }
}
