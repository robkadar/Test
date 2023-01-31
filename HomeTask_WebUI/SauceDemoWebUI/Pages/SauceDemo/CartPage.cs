using OpenQA.Selenium;

namespace SauceDemoWebUI.Pages.SauceDemo
{
    internal class CartPage : AbstractPage
    {
        public CartPage(IWebDriver driver) : base(driver) { }
        private IWebElement CheckoutButton => Driver.FindElement(By.ClassName("checkout_button"));
        private IWebElement ContinueShoppingButton => Driver.FindElement(By.Id("continue-shopping"));
        private IReadOnlyCollection<IWebElement> ProductCardList => Driver.FindElements(By.ClassName("cart_item"));
        public void ClickCheckoutButton() => CheckoutButton.Click();
        public void ClickContinueShoppingButton() => ContinueShoppingButton.Click();
        public IWebElement GetCardItemByName(string productName) => ProductCardList.Where(element => element.FindElement(By.ClassName("inventory_item_name")).Text.Contains(productName)).FirstOrDefault();
        public void ClickProductRemove(string productName) => GetCardItemByName(productName).FindElement(By.ClassName("cart_button")).Click();
    }
}
