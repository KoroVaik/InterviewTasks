using APITests.Steps;
using Core;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.TestData;

namespace APITests.Tests
{
    [TestFixture]
    public class LoginTests : BaseApiTests
    {
        private LoginFailApiSteps _loginFailApiSteps;

        private UserDataProvider _userDataProvider = new();

        public LoginTests()
        {
            _loginFailApiSteps = new LoginFailApiSteps(_configurations.BaseUrl);
        }

        [SetUp]
        public void SetUpTest()
        {
            //The DB must be filled with user data and failed attempts to login
        }

        [Test]
        public void GetLoginFailTotalForAllUsers()
        {
            //the list of users data has to be taken directely from the DB
            var expectedUsersData = new List<string>(); 

            var actualUsersData = _loginFailApiSteps.FetchAllLoginFailTotals();

            actualUsersData.Should().BeEquivalentTo(expectedUsersData);
        }

        [Test]
        public void GetLoginFailTotalForSpecificUser()
        {
            //the users data has to be taken directely from the DB
            var expectedUsersData = new List<string>();
            var userAlias = "validUser";
            var userData = _userDataProvider.GetUserData(userAlias);

            var actualUsersData = _loginFailApiSteps.FetchAllLoginFailTotals(userName: userData.UserName);

            actualUsersData.Should().BeEquivalentTo(expectedUsersData);
        }

        [Test]
        public void GetLoginFailTotalAboveFailCount()
        {
            int failureThreshold = 3;
            //the list of users data has to be taken directely from the DB filtered by failureThreshold
            var expectedUsersData = new List<string>();

            var actualUsersData = _loginFailApiSteps.FetchAllLoginFailTotals(failCount: failureThreshold);

            actualUsersData.Should().BeEquivalentTo(expectedUsersData);
        }

        [Test]
        public void GetLoginFailTotalWithFetchLimit()
        {
            int fetchLimit = 3;
            //the list of users data has to be taken directely from the DB filtered by fetchLimit
            var expectedUsersData = new List<string>();

            var actualUsersData = _loginFailApiSteps.FetchAllLoginFailTotals(fetchLimit: fetchLimit);

            actualUsersData.Should().BeEquivalentTo(expectedUsersData);
        }

        [Test]
        public void GetLoginFailTotalAboveFailCountWithFetchLimit()
        {
            int fetchLimit = 3;
            int failureThreshold = 3;
            //the list of users data has to be taken directely from the DB filtered by fetchLimit and failureThreshold
            var expectedUsersData = new List<string>();

            var actualUsersData = _loginFailApiSteps.FetchAllLoginFailTotals(failCount: failureThreshold, fetchLimit: fetchLimit);

            actualUsersData.Should().BeEquivalentTo(expectedUsersData);
        }

        [Test]
        public void GetLoginFailTotalAboveFailCountWithFetchLimitForSpecificUser()
        {
            int fetchLimit = 3;
            int failureThreshold = 3;
            var userAlias = "validUser";
            var userData = _userDataProvider.GetUserData(userAlias);
            //the user data has to be taken directely from the DB filtered by fetchLimit and failureThreshold
            var expectedUsersData = new List<string>();

            var actualUsersData = _loginFailApiSteps.FetchAllLoginFailTotals(userName: userData.UserName, failCount: failureThreshold, fetchLimit: fetchLimit);

            actualUsersData.Should().BeEquivalentTo(expectedUsersData);
        }

        [Test]
        public void GetLoginFailTotalInvalidParameters()
        {
            var expectedError = "Error that indicates wrong parameters are passed in the request";

            //The number of test cases could be increased by using different variations of arguments
            var actualUsersData = _loginFailApiSteps.FetchLoginFailTotalWithError(null, null, null);
                
            actualUsersData.Should().Be(expectedError);
        }

        [Test]
        public void GetLoginFailTotalForNotExistingUserName()
        {
            var userName = "invalidUserName";
            var expectedError = "The error indicates that not existing user has been passes in the request";

            var actualUsersData = _loginFailApiSteps.FetchLoginFailTotalWithError(userName);

            actualUsersData.Should().Be(expectedError);
        }

        [Test]
        public void ResetLoginFailTotalForSpecificUser()
        {
            var userAlias = "validUser";
            var userData = _userDataProvider.GetUserData(userAlias);

            _loginFailApiSteps.ResetLoginFailTotalForUser(userData.UserName);

            //Assert that the user in the DB doesn't have failed attempts
        }

        [Test]
        public void ResetLoginFailTotalMissingUsername()
        {
            var userName = "1111";
            var expectedErrorResponse = "An error indicates a wrong user name provided";
            var errorResponse = _loginFailApiSteps.ResetLoginFailTotalWithError(userName);

            //Assert that the user in the DB does have failed attempts
            errorResponse.Should().Be(expectedErrorResponse);
        }

        [Test]
        public void ResetLoginFailTotalUnauthorizedAccess()
        {
            var userAlias = "invalidUser";
            var userData = _userDataProvider.GetUserData(userAlias);
            var expectedErrorResponse = "An error indicates that access for the user is forbidden";

            var errorResponse = _loginFailApiSteps.ResetLoginFailTotalWithError(userData.UserName);

            errorResponse.Should().Be(expectedErrorResponse);
        }
    }
}
