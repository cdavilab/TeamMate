using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace TMProject
{
    public class LoginPage
    {
        private IWebDriver driver;
        private By usernameBy = By.Name("username"); //myDriver.FindElement(By.CssSelector("input[id='username']"))
        private By passwordBy = By.Name("password");//myDriver.FindElement(By.CssSelector("#password"))
        private By loginBy = By.XPath("//button[@type='submit']");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        //Page Elements

        private IWebElement Username => driver.FindElement(By.Id("username"));
        private IWebElement Password => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement ErrorMessage => driver.FindElement(By.CssSelector("div.js-loginform>div>div>span"));

        private By tableBy = By.CssSelector("#dashboard-tab-mydashboard > div>div>div>div>div>div>div>table");
        private By errorBy = By.CssSelector("div.js-loginform>div>div>span");

        //Methods for interacting with elements
        public void EnterUserName(string userName) => Username.SendKeys(userName);
        public void EnterPassword(string password)=>Password.SendKeys(password);
        public void ClickOnLoginButton()=>LoginButton.Click();
        
        //Explicit wait
        public void WaitTable() {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(tableBy));driver.PageSource.Contains("");
        }
        public void WaitErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(errorBy)).First();
            driver.FindElement(errorBy).Click();
            Console.WriteLine("Mensaje de error en la espera : " + driver.FindElement(errorBy).Text);

        }
        public string GetErrorMessage()=>ErrorMessage.Text;

        public HomePage loginValidUser(String userName, String password) {
            driver.FindElement(usernameBy).SendKeys(userName);
            driver.FindElement(passwordBy).SendKeys(password);
            driver.FindElement(loginBy).Click();

            return new HomePage(driver);
        }
    }
}
