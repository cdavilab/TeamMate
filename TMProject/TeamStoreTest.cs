using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.CodeDom.Compiler;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TMProject
{
    [TestClass]
    public class TeamStoreTest
    {   
        private IWebDriver driver;
        private TeamStorePage teamStorePage;

        public TestContext TestContext { get; set; }
        public TeamStoreTest() { }
       


        
        [TestInitialize]
        public void Init() {
            
             //This configuration is part of the first way to get JavaScript Exception
            ChromeOptions options = new ChromeOptions();
            //options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            driver = new ChromeDriver(options);
            
            //driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://qa-tmplus.wktmdev.com/TeamMate/Home/Login?returnUrl=%2FTeamMate%2F");
            driver.Manage().Window.Maximize();
            teamStorePage = new TeamStorePage(driver);

            
           

        }

        [TestCleanup]
        public  void Cleanup() {
            //verify if the test has failed.
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                string testName = TestContext.TestName;
                string errorMessage = TestContext.CurrentTestOutcome.ToString();

                Console.WriteLine($"Test '{testName}'failed with error {errorMessage} ");
                //Capture Screebshot

                string screenShotPath = JiraHelper.GetScreenshot(testName, driver);

                string summary = $"Test failure: {testName}";
                string description = $"Test failed with the following message\n{errorMessage}\n\n Screenshot: {screenShotPath}";
                Console.WriteLine($"Test '{testName}'failed with error {errorMessage} {screenShotPath}");

              Task.Run(()=> JiraHelper.CreateJiraDefectAsync(summary, description)).Wait();

            }

           // driver.Quit();
        }

          



        [TestMethod]
        public void CreateSurveyTemplate() {
            //Arrange
            string title = "Survey Template CD";
            string description = "Description CD";
            string instructions = "This is a short instruction to describe the objectives of the survey template";

            
            //Act
            LoginPage loginPage = new LoginPage(driver);                       
            HomePage homePage = loginPage.loginValidUser("cdavila", "123456789");

            
            homePage = teamStorePage.goTeamStoreSurveyPage();
            homePage = teamStorePage.goCreateTemplatePage();
            homePage = teamStorePage.createSurveyTemplate();
            JiraHelper.createVector();

            // string errorMessage = "Invalid credentials supplied.";
            //Console.WriteLine("Mensaje de error: " + loginPage.GetErrorMessage());
            //Assert.IsTrue(loginPage.GetErrorMessage().Contains(errorMessage));

        }

        [TestMethod]
        public void GoFolderTemplateHistory()
        {
            //Arrange
           // string title = "Survey Template CD";
          //  string description = "Description CD";
          //  string instructions = "This is a short instruction to describe the objectives of the survey template";


            //Act
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.loginValidUser("cdavila", "123456789");


            homePage = teamStorePage.goTeamStoreFolderTemplatePage();
            
            homePage = teamStorePage.displayFolderHistory();
            //verify if the test has failed.
           

            //string errorMessage = "Invalid credentials supplied.";
            //Console.WriteLine("Mensaje de error: " + loginPage.GetErrorMessage());
            //Assert.IsTrue(loginPage.GetErrorMessage().Contains(errorMessage));

        }


    }
}
