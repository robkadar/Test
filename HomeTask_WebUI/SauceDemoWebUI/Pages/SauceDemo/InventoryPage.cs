using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoWebUI.Pages.SauceDemo
{
    internal class InventoryPage : AbstractPage
    {
        public InventoryPage(IWebDriver driver) : base(driver) { }
        private IReadOnlyCollection<IWebElement> _productsInventoryList => Driver.FindElements(By.ClassName("inventory_item"));
        //public IWebElement GetInventoryItemByName(string productName) => _productsInventoryList.Where(element => element.FindElement(By.ClassName("inventory_item_name")).Text.Contains(productName)).FirstOrDefault();

        public IWebElement GetInventoryItemByName(string productName) => _productsInventoryList.FirstOrDefault(element => element.FindElement(By.ClassName("inventory_item_name")).Text.Contains(productName.Trim('\"')));

        //public IWebElement GetInventoryItemByName(string productName) => _productsInventoryList.Where(item => item.Text.Contains(productName.Trim('\"'))).FirstOrDefault().FindElement(By.XPath("..")).Click();
        //public void ClickProductAddToCart(string productName) => GetInventoryItemByName(productName).FindElement(By.ClassName("btn_inventory")).Click();
        //public void ClickProductName(string productName) => GetInventoryItemByName(productName).Click();

        public int GetCartItemCount() => int.Parse(Driver.FindElement(By.ClassName("shopping_cart_badge")).Text);
        //public string GetButtonText() => Driver.FindElement(By.ClassName("btn_inventory")).Text;
        public void ClickProductAddToCart(string productName)
        {
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("inventory_item_name")));
            GetInventoryItemByName(productName).FindElement(By.ClassName("btn_inventory")).Click();
        }
        public void ClickProductName(string productName)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("inventory_item_name")));
            GetInventoryItemByName(productName).FindElement(By.ClassName("inventory_item_name")).Click();
        }
        public string GetButtonText(string productName)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //return Driver.FindElement(By.ClassName("btn_inventory")).Text;
            return GetInventoryItemByName(productName).FindElement(By.ClassName("btn_inventory")).Text;
        }
    }
}
