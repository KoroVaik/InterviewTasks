using APITests.Mappers;
using APITests.Steps;
using AutoMapper;
using DB.Repositories;
using Domain.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Net;

namespace APITests.Tests
{
    [TestFixture]
    public class LoginTests : BaseApiTests
    {
        private readonly LoginFailApiSteps _loginFailApiSteps;
        private readonly UserInfoDbRepository _userInfoDbRepository;
        //I use an automapper to make it easy to check data from different sources like APIs,
        //databases, user interfaces, and so on, by bringing these models into a domain view.
        private readonly IMapper _mapper;

        public LoginTests()
        {
            _loginFailApiSteps = new LoginFailApiSteps(_configurations.BaseUrl);
            _userInfoDbRepository = new UserInfoDbRepository(_dbContext);
            _mapper = APIMapper.Configure();
        }

        [SetUp]
        public void SetUpTest()
        {
            //The DB must be filled with the number of users and failed login attempts
            //At least 5 users with failed login attempts in range 0 - 3
            //This can be achieved by deleting all test users from the DB
            //and re-creating the default users again
        }

        [Test]
        public void GetLoginFailTotalForAllUsers()
        {
            //Arrange
            var dbUsersData = _userInfoDbRepository.GetAllUserInfos();
            var expectedUsersData = _mapper.Map<List<UserInfoModel>>(dbUsersData);

            //Act
            var apiUsersData = _loginFailApiSteps.FetchAllLoginFailTotals();
            var actualUsersData = _mapper.Map<List<UserInfoModel>>(apiUsersData);

            //Assert
            //Validation of a positive status code takes place implicitly in the API service
            actualUsersData.Should().BeEquivalentTo(expectedUsersData);
        }

        [Test]
        public void GetLoginFailTotalForSpecificUser()
        {
            //Arrange
            var dbUserData = _userInfoDbRepository.GetAllUserInfos().First();
            var expectedUserData = _mapper.Map<UserInfoModel>(dbUserData);

            //Act
            var apiUsersData = _loginFailApiSteps.FetchAllLoginFailTotals(userName: dbUserData.UserName);
            var actualUsersData = _mapper.Map<List<UserInfoModel>>(apiUsersData);

            //Assert
            actualUsersData.Should().ContainSingle().Which.Should().Be(expectedUserData);
        }

        [Test]
        public void GetLoginFailTotalAboveFailCount()
        {
            //Arrange
            int failureThreshold = 3;
            var dbUsersData = _userInfoDbRepository.GetAllUserInfos()
                .Where(x => x.FailedLogins > failureThreshold);
            var expectedUsersData = _mapper.Map<List<UserInfoModel>>(dbUsersData);

            //Act
            var apiUsersData = _loginFailApiSteps.FetchAllLoginFailTotals(failCount: failureThreshold);
            var actualUsersData = _mapper.Map<List<UserInfoModel>>(apiUsersData);

            //Assert
            actualUsersData.Should().BeEquivalentTo(expectedUsersData);
        }

        [Test]
        public void GetLoginFailTotalWithFetchLimit()
        {
            //Arrange
            int fetchLimit = 4;
            var dbUsersData = _userInfoDbRepository.GetAllUserInfos().Take(fetchLimit);
            var expectedUsersData = _mapper.Map<List<UserInfoModel>>(dbUsersData);

            //Act
            var apiUsersData = _loginFailApiSteps.FetchAllLoginFailTotals(fetchLimit: fetchLimit);
            var actualUsersData = _mapper.Map<List<UserInfoModel>>(apiUsersData);

            //Assert
            actualUsersData.Should().BeEquivalentTo(expectedUsersData);
        }

        [Test]
        public void GetLoginFailTotalAboveFailCountWithFetchLimit()
        {
            //Arrange
            int fetchLimit = 3;
            int failureThreshold = 2;
            var dbUsersData = _userInfoDbRepository.GetAllUserInfos()
                .Where(x => x.FailedLogins > failureThreshold)
                .Take(fetchLimit);
            var expectedUsersData = _mapper.Map<List<UserInfoModel>>(dbUsersData);

            //Act
            var apiUsersData = _loginFailApiSteps.FetchAllLoginFailTotals(failCount: failureThreshold, fetchLimit: fetchLimit);
            var actualUsersData = _mapper.Map<List<UserInfoModel>>(apiUsersData);

            //Assert
            actualUsersData.Should().BeEquivalentTo(expectedUsersData);
        }

        [Test]
        //This test is questionable because it is not known how filtering occurs
        //when all parameters are specified
        public void GetLoginFailTotalAboveFailCountWithFetchLimitForSpecificUser()
        {
            //Arrange
            int fetchLimit = 3;
            int failureThreshold = 2;
            var dbUserData = _userInfoDbRepository.GetAllUserInfos()
                .Where(x => x.FailedLogins > failureThreshold)
                .Take(fetchLimit)
                .First();
            var expectedUserData = _mapper.Map<List<UserInfoModel>>(dbUserData);

            //Act
            var apiUsersData = _loginFailApiSteps.FetchAllLoginFailTotals(
                userName: dbUserData.UserName, 
                failCount: failureThreshold, 
                fetchLimit: fetchLimit);
            var actualUsersData = _mapper.Map<List<UserInfoModel>>(apiUsersData);

            //Assert
            actualUsersData.Should().ContainSingle().Which.Should().Be(expectedUserData);
        }

        [Test]
        //The number of test cases could be increased by using different variations of arguments
        public void GetLoginFailTotalWithInvalidParameters()
        {
            //Arrange
            var expectedErrorMessage = "Error that indicates wrong parameters were passed in the request";
            var userName = "#$%";
            var fetchLimit = -1;
            var failureThreshold = -3;

            //Act
            var actualResponse = _loginFailApiSteps.FetchLoginFailTotalWithError(userName, fetchLimit, failureThreshold);
            
            //Assert
            actualResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            actualResponse.Content.Should().Be(expectedErrorMessage);
        }

        [Test]
        public void GetLoginFailTotalForNotExistingUserName()
        {
            //Arrange
            var userName = "invalidUserName";
            var expectedErrorMessage = "User not found";

            //Act
            var actualResponse = _loginFailApiSteps.FetchLoginFailTotalWithError(userName);

            //Assert
            actualResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
            actualResponse.Content.Should().Be(expectedErrorMessage);
        }

        [Test]
        public void ResetLoginFailTotalForSpecificUser()
        {
            //Arrange
            var dbUserData = _userInfoDbRepository.GetAllUserInfos().First(x => x.FailedLogins > 0);

            //Act
            _loginFailApiSteps.ResetLoginFailTotalForUser(dbUserData.UserName);
            var actualUserData = _userInfoDbRepository.GetUserInfo(dbUserData.UserName);

            //Assert
            actualUserData.FailedLogins.Should().Be(0);
        }

        [Test]
        //The number of test cases could be increased by using different user names
        public void ResetLoginFailTotalMissingUsername()
        {
            //Arrange
            var userName = "userName!@#";
            var expectedErrorMessage = "Bad request";

            //Act
            var actualResponse = _loginFailApiSteps.ResetLoginFailTotalWithError(userName);

            //Assert
            actualResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            actualResponse.Content.Should().Be(expectedErrorMessage);
        }

        [Test]
        public void ResetLoginFailTotalUnauthorizedAccess()
        {
            //Arrange
            var userName = "invalidUser";
            var expectedErrorMessage = "User not found";

            //Act
            var actualResponse = _loginFailApiSteps.ResetLoginFailTotalWithError(userName);

            //Assert
            actualResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
            actualResponse.Content.Should().Be(expectedErrorMessage);
        }
    }
}
