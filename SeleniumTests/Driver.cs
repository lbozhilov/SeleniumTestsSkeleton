using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using SeleniumTests.Tests;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace SeleniumTests
{
    public class Driver
    {
        public static IWebDriver driver;
        public static IJavaScriptExecutor js;
        public static string browser;
        public static string url;
        public static string username;
        public static string password;
        
        private static IWebDriver getDriver(string browsr)
        {
            if (browsr.Equals("IE"))
            {
                return null;
            }
            else
            {
                return new FirefoxDriver();
            }
        }

        public static void loadConfigFile()
        {
            browser = ReadSetting("browser");
            url = ReadSetting("url");
            username = ReadSetting("username");
            password = ReadSetting("password");
        }

        static Int32 Main(string[] args)
        {
            loadConfigFile();
            driver = getDriver(browser);
            js = (IJavaScriptExecutor)driver;

            CourtFilingTests cft = new CourtFilingTests();
            cft.RunFirst();

            cleanup();
            Environment.Exit(0);
            return 0;
        }

        static List<string> ReadAllSettings()
        {
            List<string> allSettings = new List<string>();
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        allSettings.Add(key + ";" + appSettings[key]);
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            return allSettings;
        }

        public static string ReadSetting(string key)
        {
            string result = "";
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "Not Found";
                
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            return result;
        }

        public static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        public static void WriteLineToConsole(string text)
        {
            Console.WriteLine(text);
        }

        private static void cleanup()
        {
            //logout();
            driver.Close();
            Console.WriteLine(Logger.log);
        }

        public static string randomID(int length)
        {
            {
                string randomString = string.Empty;

                while (randomString.Length <= length)
                {
                    randomString += Path.GetRandomFileName();
                    randomString = randomString.Replace(".", string.Empty);
                }

                return randomString.Substring(0, length);
            }
        }

        public static IWebElement WaitUntilVisible(double maxSecondsToWait, string timeoutMessage, By locator)
        {
            Thread.Sleep(2000);
            WebDriverWait waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(maxSecondsToWait));
            waiter.Message = (String.IsNullOrWhiteSpace(timeoutMessage)) ? (waiter.Message) : (timeoutMessage);
            IWebElement elem = waiter.Until(ExpectedConditions.ElementIsVisible(locator));
            return elem;
        }
    }
}
