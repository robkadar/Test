using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace OrangeHrmWebUI.Pages.OrangeHrm
{
    internal abstract class AbstractPage
    {
        protected IWebDriver Driver;
        protected WebDriverWait WebDriverWait => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        protected AbstractPage(IWebDriver driver)
        {
            Driver = driver;
        }
        protected void SwitchToFrameWithWait(By Locator)
        {
            WebDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(Locator));
        }
    }
}
