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
    public class UserPage
    {
        IWebDriver driver;

        private By mainMenuUserBy = By.CssSelector("a[id='menu-setups']");
        private By menuUserBy = By.CssSelector("#menu-users");
        private By subMenuUserBy = By.CssSelector("a#menu-users-user");
       
        // to import user
        private By uploadFileBY = By.CssSelector("input[type='file']");
        private String userFile = "C:\\Users\\Cristina.Davila\\Downloads\\UserTemplate.xlsx";

        //to search a user
        private By searchUserBy = By.Id("usertext");
        private By tableBy = By.XPath("//table[@id='users']/tbody/tr");
        private By tableTitleBy = By.XPath("//table[@id='users']/tbody/tr[1]/td[2]");
        private By tableEmailBy = By.XPath("//table[@id='users']/tbody/tr[1]/td[3]");



        public UserPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public HomePage goToUserPage() {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            driver.FindElement(mainMenuUserBy).Click();
            driver.FindElement(menuUserBy).Click();
            driver.FindElement(subMenuUserBy).Click();

            return new HomePage(driver);
        }
        public HomePage importUser(String user, String email) {
            //import
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            IWebElement fileInput = driver.FindElement(uploadFileBY);
            fileInput.SendKeys(userFile);            
           

            //search
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            IWebElement item = driver.FindElement(searchUserBy);           
            item.SendKeys(user);
            item.SendKeys(Keys.Enter);
            //item.Clear();

            // item.SendKeys("Megan10");
            // item.SendKeys(Keys.Enter);
            var rows = driver.FindElements(tableBy);
            Console.WriteLine($"Before a search: {rows.Count}");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(tableBy));


            bool success = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(tableTitleBy, user));
            bool success1 = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(tableEmailBy, email));
            if (success && success1)
            {
                Console.WriteLine("Audit Plan created successfully!");
                var rows1 = driver.FindElements(tableBy);
                Console.WriteLine($"Number of rows loaded after a search: {rows1.Count}");
            }

            return new HomePage(driver);
        }


    }
}
