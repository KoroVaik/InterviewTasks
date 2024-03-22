using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace UI
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(BrowserType browserType)
        {
            return browserType switch
            {
                BrowserType.Chrome => new ChromeDriver(GetChromeBinaryDirectory(), GetOptions()),
                _ => throw new NoSuchDriverException($"{browserType} browser is not supported")
            };
        }

        private static string GetChromeBinaryDirectory() => GetBinaryDirectory(new ChromeConfig());

        private static string GetBinaryDirectory(IDriverConfig driverConfig)
        {
            string binaryPath;
            try
            {
                binaryPath = new DriverManager().SetUpDriver(driverConfig, VersionResolveStrategy.MatchingBrowser);
            }
            catch
            {
                binaryPath = new DriverManager().SetUpDriver(driverConfig);
            }

            return Path.GetDirectoryName(binaryPath)!;
        }

        private static ChromeOptions GetOptions()
        {
            var driverOptions = new ChromeOptions();
            driverOptions.AddArgument("--start-maximized");
            return driverOptions;
        }
    }

    public enum BrowserType
    {
        Chrome,
    }
}