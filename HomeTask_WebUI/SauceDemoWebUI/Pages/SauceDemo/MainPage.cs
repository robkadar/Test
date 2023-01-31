using OpenQA.Selenium;
using SauceDemoWebUI.Entities;

namespace SauceDemoWebUI.Pages.SauceDemo
{
    internal class MainPage : AbstractPage
    {
        public MainPage(IWebDriver driver) : base(driver) { }
        public IWebDriver SeleniumDriver { get; internal set; }
        public string currentUrl { get; set; }
        private IWebElement UserNameTextBox => Driver.FindElement(By.Name("user-name"));
        private IWebElement UserPasswordTextBox => Driver.FindElement(By.Id("password"));
        private IWebElement LogInButton => Driver.FindElement(By.Id("login-button"));

        //SelectElement selectElement = new SelectElement(DriverHolder.Driver.FindElement())

        public MainPage LogIn(UserEntity userEntity)
        {
            return LogIn(userEntity.UserName, userEntity.Password);
        }
        public MainPage LogIn(string UserName, string Password)
        {
            UserNameTextBox.SendKeys(UserName);
            UserPasswordTextBox.SendKeys(Password);
            //LogInButton.Click();
            return this;
        }

        public MainPage EnterCredentials(UserEntity userEntity)
        {
            return EnterCredentials(userEntity.UserName, userEntity.Password);
        }
        public MainPage EnterCredentials(string UserName, string Password)
        {
            UserNameTextBox.SendKeys(UserName);
            UserPasswordTextBox.SendKeys(Password);
            //LogInButton.Click();
            return this;
        }
        public MainPage ClickLoginButton()
        {
            //WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf (UserPasswordTextBox));
            LogInButton.Click();
            return this;
        }
    }
}
