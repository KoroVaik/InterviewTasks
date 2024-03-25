using Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using UI;

namespace UITests.Steps
{
    [Binding]
    //This class creates a web driver instance before each test and dispose after the test is finished
    public class BaseSteps
    {
        protected IWebDriver _driver { get; private set; }

        protected UIConfigurations _configurations { get => GetUIConfigurations(); }

        [BeforeScenario]
        public void BeforeScenarioSetUp()
        {
            var uiConfigs = GetUIConfigurations();
            _driver = WebDriverFactory.CreateWebDriver(uiConfigs.BrowserType);

        }

        [AfterScenario]
        public void AfterScenarioTearDown()
        {
            _driver.Quit();
        }

        private UIConfigurations GetUIConfigurations()
        {
            return ConfigurationManager.Get<UIConfigurations>();
        }

        //This method checks if the web page has finished loading completely in the browser
        public bool IsPageLoaded()
        {
            var jsExecutor = (IJavaScriptExecutor)_driver;
            return (bool)jsExecutor.ExecuteScript("return document.readyState === 'complete'");
        }

        public bool WaitUntil(Func<bool> func)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(_ => func());
        }
    }
}
