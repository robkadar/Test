using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHrmWebUI.Entities;

namespace OrangeHrmWebUI.Pages.OrangeHrm
{
    internal class EditPayGradePage : AbstractPage
    {
        public EditPayGradePage(IWebDriver driver) : base(driver) { }
        private IWebElement SaveButton => Driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary orangehrm-left-space']"));
        private IWebElement CancelButton => Driver.FindElement(By.XPath("//div[@class='orangehrm-background-container']/div[@class='orangehrm-card-container']//button[1]"));
        private IWebElement ProductNameTextBox => Driver.FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space']/div/input"));
        private IWebElement AddButton => Driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary']"));
        //private IWebElement AddCurrencyButton => Driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary orangehrm-left-space']"));
        private IWebElement AddCurrencyButton => Driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary']"));
        private IWebElement CancelCurrencyButton => Driver.FindElement(By.XPath("//form[./div/div/div/div/div/div[@class='oxd-select-wrapper']]//button[1]"));
        private IWebElement SaveCurrencyButton => Driver.FindElement(By.XPath("//form[./div/div/div/div/div/div[@class='oxd-select-wrapper']]//button[2]"));
        private IWebElement CurrencyName => Driver.FindElement(By.XPath("//div[@class='oxd-select-text-input']"));
        private IWebElement MinSalaryInput => Driver.FindElement(By.XPath("//form/div[2][@class='oxd-form-row']/div/div[1]//input"));
        private IWebElement MaxSalaryInput => Driver.FindElement(By.XPath("//form/div[2][@class='oxd-form-row']/div/div[2]//input"));
        private IWebElement MinSalaryTxt => Driver.FindElement(By.XPath("//div[@class='oxd-table-cell oxd-padding-cell'][3]/div"));
        private IWebElement MaxSalaryTxt => Driver.FindElement(By.XPath("//div[@class='oxd-table-cell oxd-padding-cell'][4]/div"));

        public void EnterNewSalaryData(string name, int minSalary, int maxSalary)
        {
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--secondary']")));
            AddCurrencyButton.Click();
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='oxd-select-text-input']")));
            CurrencyName.Click();
            Driver.FindElement(By.XPath($"//span[contains(text(),'{name.ToString()}')]")).Click();
            new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            MinSalaryInput.SendKeys(minSalary.ToString());
            MaxSalaryInput.SendKeys(maxSalary.ToString());
            
        }

        public void SaveSalaryData()
        {
            SaveCurrencyButton.Click();
        }

        public SalaryEntity GetSalary()
        {
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='oxd-table-cell oxd-padding-cell'][4]/div")));
            SalaryEntity result = new SalaryEntity();
            double min, max;
            if (double.TryParse(MinSalaryTxt.Text, out min))
            {
                result.MinSalary = min;
            }
            else result.MinSalary = -1;
            if (double.TryParse(MaxSalaryTxt.Text, out min))
            {
                result.MaxSalary = min;
            }
            else result.MaxSalary = -1;
            return result;
        }
    }
}
