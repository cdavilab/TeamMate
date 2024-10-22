using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TMProject
{
    [TestClass]
    public class AssessmentTest
    {   
        private IWebDriver driver;
        private LoginPage loginPage;
        public AssessmentTest() { }
       


        
        [TestInitialize]
        public void Init() { 
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://qa-tmplus.wktmdev.com/TeamMate/Home/Login?returnUrl=%2FTeamMate%2F");
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
            
        }

        [TestCleanup]
        public void Cleanup() { 
            driver.Quit();
        }

          
        

        [TestMethod]
        public void createAssessment()
        {
            AssessmentPage auditPlanPage = new AssessmentPage(driver);
            HomePage homePage = loginPage.loginValidUser("cdavila", "123456789");

            homePage = auditPlanPage.goAssessmentPage();
            homePage = auditPlanPage.createAssessment("Assessment_CD", "Description CD", "Owner");
            homePage = auditPlanPage.goInsertAssessmentPage();
            homePage = auditPlanPage.createObjective("Objective CD Title", "Objective CD Description");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            homePage = auditPlanPage.createStrategicRisk("Strategic Risk CD Title", "Strategic Risk CD Description");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            homePage = auditPlanPage.createRisk("Risk CD Title", "Risk CD Description");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            homePage = auditPlanPage.createControl("Control CD Title", "Control CD Description");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            homePage = auditPlanPage.createProcedure("Procedure CD Title", "Procedure CD Description");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            homePage = auditPlanPage.createIssue("Issue CD Title", "Issue CD Description");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            //homePage = auditPlanPage.createRecommendation("Recommendation CD Title", "Recommendation CD Description");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            homePage = auditPlanPage.createCoachingNote("Coaching Note CD Title", "Coaching Note CD Description");

        }


        

    }
}
