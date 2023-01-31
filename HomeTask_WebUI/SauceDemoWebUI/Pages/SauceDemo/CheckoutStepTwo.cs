using OpenQA.Selenium;

namespace SauceDemoWebUI.Pages.SauceDemo
{
    internal class CheckoutStepTwo : AbstractPage
    {
        public CheckoutStepTwo(IWebDriver driver) : base(driver) { }
        public IWebElement ItemName => Driver.FindElement(By.ClassName("inventory_item_name"));
        public IWebElement FinishButton => Driver.FindElement(By.ClassName("cart_button"));
        public IWebElement CancelButton => Driver.FindElement(By.ClassName("cart_cancel_link"));
        public void ClickOnItem()
        {
            ItemName.Click();
        }
        public void ClickOnFinishButton()
        {
            FinishButton.Click();
        }
        public void ClickOnCancelButton()
        {
            CancelButton.Click();
        }
    }
}
