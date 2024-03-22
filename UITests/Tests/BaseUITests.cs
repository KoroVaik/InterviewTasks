using Core;
using NUnit.Framework;
using OpenQA.Selenium;
using UI;

namespace UITests.Tests
{
    public class BaseUITests
    {
        protected IWebDriver _driver { get; private set; }

        protected UIConfigurations _configurations { get => GetUIConfigurations(); }

        [SetUp]
        public void SetUp()
        {
            var uiConfigs = GetUIConfigurations();
            _driver = WebDriverFactory.CreateWebDriver(uiConfigs.BrowserType);
            _driver.Navigate().GoToUrl(uiConfigs.BaseUrl);
            //explicit wait for the page is loaded could be introduced if needed
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        private UIConfigurations GetUIConfigurations()
        {
            return ConfigurationManager.Get<UIConfigurations>();
        }
    }
}
