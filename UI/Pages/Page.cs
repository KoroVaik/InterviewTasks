using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Pages
{
    public abstract class Page
    {
        protected readonly IWebDriver _driver;

        public Page(IWebDriver driver)
        {
            _driver = driver;
        }
        public string GetTitle() => _driver.Title;

        public string GetUrl() => _driver.Url;
    }
}
