using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.PageActions;

namespace UITests.Steps
{
    public class LoginPageSteps
    {
        private readonly LoginPageActions _actions;

        public LoginPageSteps(IWebDriver webDriver)
        {
            _actions = new(webDriver);
        }

        public void SubmitDataToLoginForm(string userName, string password)
        {
            _actions.SetUserName(userName);
            _actions.SetUserName(password);
            _actions.SubmitData();
        }
    }
}
