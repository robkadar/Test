using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace OrangeHrmWebUI.Core
{
    internal class DriverHolder
    {
        private static IWebDriver _driver;
        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver();
                    _driver.Manage().Window.Maximize();
                }
                return _driver;
            }
            private set => _driver = value;
        }
    }
}
