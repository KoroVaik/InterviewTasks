using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Pages;

namespace UI.PageActions
{
    public class LoginPageActions
    {
        private readonly LoginPage _loginPage;

        public LoginPageActions(IWebDriver webDriver)
        {
            _loginPage = new(webDriver);
        }

        public void SetUserName(string userName) => _loginPage.UserNameInput.SendKeys(userName);

        public void SetPassword(string password) => _loginPage.PasswordInput.SendKeys(password);
        
        public void SubmitData() => _loginPage.SubmitButton.Click();
    }
}
