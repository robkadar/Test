using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoWebUI.Pages.SauceDemo
{
    internal class ProductPage : AbstractPage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }
        private IWebElement AddRemoveCartButton => Driver.FindElement(By.ClassName("btn_inventory"));
        private IWebElement CartBadgeNumber => Driver.FindElement(By.ClassName("shopping_cart_badge"));
        private IWebElement CartLink => Driver.FindElement(By.ClassName("shopping_cart_link"));
        private IWebElement BackButton => Driver.FindElement(By.ClassName("inventory_details_back_button"));
        public void AddOrRemoveButtonClick()
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            AddRemoveCartButton.Click();
        }

        public void BackToProductsList() => BackButton.Click();
        public string GetButtonText() => AddRemoveCartButton.Text;
        public void GoToCart()
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(CartLink));
            CartLink.Click();
        }
        public int GetNumberOfItemsInCart()
        {
            try
            {
                return int.Parse(CartBadgeNumber.Text);
            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {
                return 0;
            }
        }
    }
}
