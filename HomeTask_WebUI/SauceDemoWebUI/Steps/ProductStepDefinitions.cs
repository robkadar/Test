using NUnit.Framework;
using SauceDemoWebUI.Core;
using SauceDemoWebUI.Pages.SauceDemo;
using System;
using TechTalk.SpecFlow;

namespace SauceDemoWebUI.Steps
{
    [Binding]
    public class ProductStepDefinitions
    {
        private MainPage mainpage;
        private InventoryPage inventoryPage;
        private ProductPage productPage;

        [BeforeScenario]
        public void Setup()
        {
            mainpage = new MainPage(DriverHolder.Driver);
            inventoryPage = new InventoryPage(DriverHolder.Driver);
            productPage = new ProductPage(DriverHolder.Driver);
        }

        [Given(@"I am on the mainpage of the \[""([^""]*)""] website")]
        public void GivenIAmOnTheMainpageOfTheWebsite(string webPage)
        {
            DriverHolder.Driver.Navigate().GoToUrl(webPage);
        }

        [Given(@"I have logged in as (.*) with the password (.*)")]
        public void GivenIHaveLoggedInAsWithThePassword(string username, string password)
        {
            mainpage.LogIn(username, password);
            mainpage.ClickLoginButton();
        }

        [When(@"I click on the item (.*)")]
        public void WhenIClickOnTheItem(string productname)
        {
            inventoryPage.ClickProductName(productname);
        }

        [Then(@"I should redirect to the product detail page")]
        public void ThenIShouldRedirectToTheProductDetailPage()
        {
            Assert.That(DriverHolder.Driver.Url, Is.AtLeast("https://www.saucedemo.com/inventory-item.html"));
        }

        [Then(@"I should add the product to the cart")]
        public void ThenIShouldAddTheProductToTheCart()
        {
            productPage.AddOrRemoveButtonClick();
            Assert.That(productPage.GetNumberOfItemsInCart(), Is.EqualTo(1));
        }
    }
}
