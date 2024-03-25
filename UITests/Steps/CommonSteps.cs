using FluentAssertions;
using TechTalk.SpecFlow;

namespace UITests.Steps
{
    //Steps that can be used in any api test
    public class CommonSteps : BaseSteps
    {

        [When(@"I navigate to the '(.*)' page")]
        public void WhenINavigateToThePage(string pageName)
        {
            _driver.Navigate().GoToUrl(_configurations.BaseUrl + "/" + pageName);
            WaitUntil(() => IsPageLoaded());
        }

        [Then("the current page is the '(.*)' page")]
        public void ThenTheCurrentPageIsThePage(string expectedPage)
        {
            _driver.Url.Should().Be(_configurations.BaseUrl + "/" + expectedPage);
            _driver.Title.Should().Be(expectedPage);
        }
    }
}
