using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TMProject
{
    [TestClass]
    public class LoginTests
    {   
        private IWebDriver driver;
        private LoginPage loginPage;
        public LoginTests() { }
       


        
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
        public void TestValidLogin()
        {   
            //Arrange
            string validUserName = "cdavila";
            string validaPassword = "123456789";

            //Act
            loginPage.EnterUserName(validUserName);
            loginPage.EnterPassword(validaPassword);
            
            loginPage.ClickOnLoginButton();
            loginPage.WaitTable();
            Console.WriteLine("" + driver.Title);                   

            //Assert
            Assert.AreEqual("Home - TeamMate", driver.Title);

        }

        [TestMethod]
        public void TestInValidLogin() {
            //Arrange
            string validUserName = "cdavila";
            string validaPassword = "12345678";

            //Act
            loginPage.EnterUserName(validUserName);
            loginPage.EnterPassword(validaPassword);

            loginPage.ClickOnLoginButton();
            loginPage.WaitErrorMessage();
            string errorMessage = "Invalid credentials supplied.";
            Console.WriteLine("Mensaje de error: " + loginPage.GetErrorMessage());
            Assert.IsTrue(loginPage.GetErrorMessage().Contains(errorMessage));

        }

        [TestMethod]
        public void TestImportUsers()
        {
           
            UserPage userPage = new UserPage(driver);
            HomePage homePage = loginPage.loginValidUser("admin", "password");
            homePage = userPage.goToUserPage();
            homePage = userPage.importUser("Cristina", "cdavila@gmail.com");//set new user name added
        }
    }
}
