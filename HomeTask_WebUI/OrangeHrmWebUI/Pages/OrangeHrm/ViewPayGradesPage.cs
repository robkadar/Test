using OpenQA.Selenium;

namespace OrangeHrmWebUI.Pages.OrangeHrm
{
    internal class ViewPayGradesPage : AbstractPage
    {
        public ViewPayGradesPage(IWebDriver driver) : base(driver) { }
        private IWebElement AddButton => Driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary']"));
        private IWebElement ConfirmDeleteButton => Driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--label-danger orangehrm-button-margin']"));
        private IReadOnlyCollection<IWebElement> _productsInventoryList => Driver.FindElements(By.ClassName("\"oxd-table-card\""));
        //public IWebElement GetInventoryItemByName(string productName) => _productsInventoryList.Where(element => element.FindElement(By.ClassName("inventory_item_name")).Text.Contains(productName)).FirstOrDefault();

        public IWebElement GetInventoryItemByName(string productName) => _productsInventoryList.FirstOrDefault(element => element.FindElement(By.ClassName("oxd-table-cell")).Text.Contains(productName.Trim('\"')));
        public void AddPayGrades()
        {
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary']")));
            AddButton.Click();
        }
        public void RemovePayGrades(string productName)
        {
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("bi-trash")));
            IWebElement webElement = GetInventoryItemByName(productName).FindElement(By.ClassName("oxd-table-cell"));
            if (webElement != null)
            {
                GetInventoryItemByName(productName).FindElement(By.ClassName("bi-trash")).Click();
            }
        }
    }
}
