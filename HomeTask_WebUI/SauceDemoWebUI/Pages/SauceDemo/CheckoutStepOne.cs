using OpenQA.Selenium;
using SauceDemoWebUI.Entities;

namespace SauceDemoWebUI.Pages.SauceDemo
{
    internal class CheckoutStepOne : AbstractPage
    {
        public CheckoutStepOne(IWebDriver driver) : base(driver) { }
        private IWebElement CancelButton => Driver.FindElement(By.ClassName("cart_cancel_link"));
        private IWebElement ContinueButton => Driver.FindElement(By.ClassName("cart_button"));
        private IWebElement FirstName => Driver.FindElement(By.Id("first-name"));
        private IWebElement LastName => Driver.FindElement(By.Id("last-name"));
        private IWebElement PostCode => Driver.FindElement(By.Id("postal-code"));
        public string RetrieveErrorMessage() => Driver.FindElement(By.CssSelector("*[data-test=\"error\"]")).Text;

        public CheckoutStepOne Customer(CustomerEntity customerEntity)
        {
            return Customer(customerEntity.FirstName, customerEntity.LastName, customerEntity.ZipCode);
        }
        public CheckoutStepOne Customer(string firstName, string lastName, string postCode)
        {
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            PostCode.SendKeys(postCode);
            return this;
        }
        public void PressButton(string button)
        {
            if (button == "Continue" || button == "Finish")
            {
                ContinueButton.Click();
            }
            if (button == "Cancel")
            {
                CancelButton.Click();
            }
        }
    }
}
