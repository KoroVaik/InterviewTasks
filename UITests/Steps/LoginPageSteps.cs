using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UI.PageActions;
using Common;
using FluentAssertions;

namespace UITests.Steps
{
    [Binding]
    public class LoginPageSteps : BaseSteps
    {
        private readonly LoginPageActions _actions;
        private UserDataProvider _userDataProvider = new();

        public LoginPageSteps(IWebDriver webDriver)
        {
            _actions = new(webDriver);
        }

        [When("I submit the login form with credentials of the user with '(.*)' alias on the Login page")]
        public void SubmitCredentialsOfUserWithAliasToLoginForm(string userAlias)
        {
            var userData = _userDataProvider.GetUserCredentials(userAlias);
            _actions.SetUserName(userData.UserName);
            _actions.SetUserName(userData.Password);
            _actions.SubmitData();
        }

        [Then(@"the login form is displayed on the Login page")]
        public void ThenTheLoginFormIsDisplayedOnTheLoginPage()
        {
            var isLoginFormDisplayed = _actions.IsLoginFormDisplayed();
            isLoginFormDisplayed.Should().BeTrue();
        }
    }
}
