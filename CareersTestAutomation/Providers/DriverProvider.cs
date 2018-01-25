using System;
using System.IO;
using CareersTestAutomation.Common;
using CareersTestAutomation.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace CareersTestAutomation.Providers
{
    public class DriverProvider
    {
        public static IWebDriver CreateWebDriverInstance(BrowserType browserType)
        {
            IWebDriver driver;
            bool projectPathExists = !string.IsNullOrWhiteSpace(SettingsProvider.ProjectPath)
                && Directory.Exists(SettingsProvider.ProjectPath);
            driver = CreateLocalDriver(browserType, projectPathExists);
            driver.MaximizeBrowserWindow();
            return driver;
        }

        private static IWebDriver CreateLocalDriver(BrowserType browserType, bool projectPathExists)
        {
            switch (browserType)
            {
                case BrowserType.IE:
                    if (projectPathExists)
                    {
                        var options = new InternetExplorerOptions { IgnoreZoomLevel = true, EnsureCleanSession = true };
                        return new InternetExplorerDriver(options);
                    }
                    DesiredCapabilities capabilities = DesiredCapabilities.InternetExplorer();
                    capabilities.SetCapability("requireWindowFocus", true);
                    return new InternetExplorerDriver();
                case BrowserType.Chrome:
                    if (projectPathExists)
                    {
                        var options = new ChromeOptions();
                        return new ChromeDriver(options);
                    }
                    return new ChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
