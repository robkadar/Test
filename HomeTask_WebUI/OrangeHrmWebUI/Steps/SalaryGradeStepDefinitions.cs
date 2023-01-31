using NUnit.Framework;
using OrangeHrmWebUI.Core;
using OrangeHrmWebUI.Entities;
using OrangeHrmWebUI.Pages.OrangeHrm;
using System;
using TechTalk.SpecFlow;

namespace OrangeHrmWebUI.Steps
{
    [Binding]
    public class SalaryGradeStepDefinitions
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;
        private AdminPage adminPage;
        private ViewPayGradesPage viewPayGradesPage;
        private PayGradePage payGradePage;
        private EditPayGradePage editPayGradePage;
        private string testName = "TestGrade03";
        private double testMinSalary = 500;
        private double testMaxSalary = 5000;

        [BeforeScenario]
        public void Setup()
        {
            loginPage = new LoginPage(DriverHolder.Driver);
            dashboardPage = new DashboardPage(DriverHolder.Driver);
            adminPage = new AdminPage(DriverHolder.Driver);
            viewPayGradesPage = new ViewPayGradesPage(DriverHolder.Driver);
            payGradePage = new PayGradePage(DriverHolder.Driver);
            editPayGradePage = new EditPayGradePage(DriverHolder.Driver);
        }

        [Given(@"start Google Chrome and load the ""([^""]*)"" webpage")]
        public void GivenStartGoogleChromeAndLoadTheWebpage(string baseURL)
        {
            DriverHolder.Driver.Navigate().GoToUrl(baseURL);
        }

        [Given(@"I am logged in to the website")]
        public void GivenIAmLoggedInToTheWebsite()
        {
            loginPage.LogIn("Admin", "admin123");
            loginPage.ClickLoginButton();
        }

        [Given(@"I add a new product with its currency data")]
        public void GivenIAddANewProductWithItsCurrencyData()
        {
            dashboardPage.ClickOnAdminButton();
            adminPage.GoToPayGradesPage();
            viewPayGradesPage.RemovePayGrades(testName);
            viewPayGradesPage.AddPayGrades();
            payGradePage.SaveProduct(testName);
            editPayGradePage.EnterNewSalaryData("HUF", 500, 5000);
        }

        [When(@"I click on the Save Currency button")]
        public void WhenIClickOnTheSaveCurrencyButton()
        {
            editPayGradePage.SaveSalaryData();
        }

        [Then(@"the entered currency info should be saved and displayed")]
        public void ThenTheEnteredCurrencyInfoShouldBeSavedAndDisplayed()
        {
            //throw new PendingStepException();
            SalaryEntity result = editPayGradePage.GetSalary();
            Assert.AreEqual(testMinSalary, result.MinSalary);
            Assert.AreEqual(testMaxSalary, result.MaxSalary);
        }
    }
}
