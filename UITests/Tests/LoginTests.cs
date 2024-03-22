using NUnit.Framework;
using UITests.Steps;
using UITests.TestData;
using FluentAssertions;

namespace UITests.Tests
{
    [TestFixture]
    public class LoginTests : BaseUITests
    {
        private LoginPageSteps _loginPageSteps => new(_driver);

        private UserDataProvider _userDataProvider = new();

        [Test]
        public void LoginScreenDisplayedWhenNotLoggedIn()
        {
            var userAlias = "invalidUser";
            var expectedUrl = _configurations.BaseUrl + "/login";
            var userData = _userDataProvider.GetUserData(userAlias);

            _loginPageSteps.SubmitDataToLoginForm(userData.UserName, userData.Password);

            _driver.Url.Should().Be(expectedUrl);
        }

        [Test]
        public void SuccessfulLoginWithValidCredentials()
        {
            var userAlias = "invalidUser";
            var expectedUrl = _configurations.BaseUrl + "/main";
            var userData = _userDataProvider.GetUserData(userAlias);

            _loginPageSteps.SubmitDataToLoginForm(userData.UserName, userData.Password);

            _driver.Url.Should().Be(expectedUrl);
        }
    }
}
