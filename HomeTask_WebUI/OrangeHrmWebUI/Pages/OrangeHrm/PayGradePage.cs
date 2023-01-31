using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OrangeHrmWebUI.Pages.OrangeHrm
{
    internal class PayGradePage : AbstractPage
    {
        public PayGradePage(IWebDriver driver) : base(driver) { }
        private IWebElement SaveButton => Driver.FindElement(By.XPath("//div[@class='orangehrm-background-container']/div[@class='orangehrm-card-container']//button[2]"));
        private IWebElement CancelButton => Driver.FindElement(By.XPath("//div[@class='orangehrm-background-container']/div[@class='orangehrm-card-container']//button[1]"));
        private IWebElement ProductNameTextBox => Driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space']/div/input"));


        public void SaveProduct(string prodName)
        {
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space']/div/input")));
            ProductNameTextBox.SendKeys(prodName.ToString());
            new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            SaveButton.Click();
        }
        public void CancelProduct()
        {
            CancelButton.Click();
        }
    }
}
