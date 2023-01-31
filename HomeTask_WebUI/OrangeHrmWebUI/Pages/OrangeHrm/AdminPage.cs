using OpenQA.Selenium;

namespace OrangeHrmWebUI.Pages.OrangeHrm
{
    internal class AdminPage : AbstractPage
    {
        public AdminPage(IWebDriver driver) : base(driver) { }
        private IWebElement JobItem => Driver.FindElement(By.XPath("//span[text() = 'Job ']"));
        private IWebElement PayGradesItem => Driver.FindElement(By.XPath("//a[contains(text(),'Pay Grades')]"));

        public void GoToPayGradesPage()
        {
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[text() = 'Job ']")));
            JobItem.Click();
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(),'Pay Grades')]")));
            PayGradesItem.Click();
        }
    }
}
