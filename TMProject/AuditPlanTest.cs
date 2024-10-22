using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace TMProject
{
    [TestClass]
    public class AuditPlanTest
    {   
        private IWebDriver driver;
        private AuditPlanPage auditPlanPage;
        public AuditPlanTest() { }
       


        
        [TestInitialize]
        public void Init() {
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://qa-tmplus.wktmdev.com/TeamMate/Home/Login?returnUrl=%2FTeamMate%2F");
            driver.Manage().Window.Maximize();
            auditPlanPage = new AuditPlanPage(driver);
            
            
        }

        [TestCleanup]
        public void Cleanup() { 
           // driver.Quit();
        }

          



        [TestMethod]
        public void CreateAuditPlan() {
            //Arrange
            string title = "Audit Plan CD";
            string description = "Description CD";
            string role = "Owner";

            
            //Act
            LoginPage loginPage = new LoginPage(driver);                       
            HomePage homePage = loginPage.loginValidUser("cdavila", "123456789");

            
            homePage = auditPlanPage.goAuditPlanPage();
            homePage = auditPlanPage.createAuditPlan(title,description,role);

            // string errorMessage = "Invalid credentials supplied.";
            //Console.WriteLine("Mensaje de error: " + loginPage.GetErrorMessage());
            //Assert.IsTrue(loginPage.GetErrorMessage().Contains(errorMessage));
           

        }


    }
}
