using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TMProject
{
    [TestClass]
    public class ProjectTest
    {   
        private IWebDriver driver;
        private LoginPage loginPage;
        public ProjectTest() { }
       


        
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
        public void createProject()
        {            
            ProjectPage projectPage = new ProjectPage(driver);
            AssessmentPage assessmentPage = new AssessmentPage(driver);
            HomePage homePage = loginPage.loginValidUser("cdavila", "123456789");

            homePage = assessmentPage.goAssessmentPage();
            homePage = assessmentPage.searchAssessmentPage("Assessment_CD");
            homePage = projectPage.createProject("Project_Code", "Project_CD", "Owner");

        }


    }
}
