using OpenQA.Selenium;

namespace UI.Pages
{
    public class LoginPage : Page
    {
        public IWebElement UserNameInput => _driver.FindElement(By.XPath("//form[@id='loginForm']/input[1]"));

        public IWebElement PasswordInput => _driver.FindElement(By.XPath("//form[@id='loginForm']/input[2]"));
        
        public IWebElement SubmitButton => _driver.FindElement(By.XPath("//input[@id='submit']"));

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
