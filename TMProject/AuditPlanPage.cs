using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace TMProject
{
    public class AuditPlanPage
    {
        IWebDriver driver;

        private By mainMenuAuditPlanBy = By.CssSelector("a[id='menu-auditplan']"); 
        //private By createAuditPBy = By.CssSelector("button[aria-label='Create Audit Plan']");
        

        private By createAuditPBy = By.XPath("//button[contains(@aria-label,'Create Audit Plan')]");
        private By auditPlanTitleBy = By.Id("formAuditPlanAddEdit_AuditPlan_Title"); 
        private By auditPlanDescriptionBy = By.Id("formAuditPlanAddEdit_Description");
        private By roleBy = By.Id("UserRoleAssignments_Items_0__RoleId");        
        private By saveAuditPBy = By.CssSelector("button[aria-label='Save Changes']");
        private By tableBy = By.XPath("//table[@id='auditplans']/tbody/tr");
        private By tableTitleBy = By.XPath("//table[@id='auditplans']/tbody/tr[1]/td[1]");
        private By searchauditplanText = By.Id("auditplanText");
        private By forecastContainerBy = By.Id("popupAuditPlanForecastAuditPlanButtonContainer");                                               
        // By.XPath("//table[@id='auditplans']/tbody/tr[1]/td[1]");






        public AuditPlanPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public HomePage goAuditPlanPage() {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            driver.FindElement(mainMenuAuditPlanBy).Click();           
            return new HomePage(driver);
        }
        public HomePage createAuditPlan(String title,String description, String role) {
            //create
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            driver.FindElement(createAuditPBy).Click();

            // New feature Forecast container
            //verify if corecast container exist
            //driver.FindElement(forecastContainerBy).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementExists(forecastContainerBy));

                bool success1 = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(forecastContainerBy, "Create Audit Plan"));
                if (success1)
                {
                    driver.FindElement(forecastContainerBy).Click();
                }

            }
            catch { }     
            IWebElement comboBox = driver.FindElement(roleBy);
            driver.FindElement(auditPlanTitleBy).SendKeys(title);
            driver.FindElement(auditPlanDescriptionBy).SendKeys(description);
            SelectElement itemSelected = new SelectElement(comboBox);
            itemSelected.SelectByText(role);

            driver.FindElement(saveAuditPBy).Click();

            //search
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            IWebElement searchTextBox = driver.FindElement(searchauditplanText);
            searchTextBox.SendKeys(title);
            searchTextBox.SendKeys(Keys.Enter);
            var rows = driver.FindElements(tableBy);
            Console.WriteLine($"Number of rows loaded before a search: {rows.Count}");
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(tableBy));
            bool success = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(tableTitleBy, title));
            if (success)
            {
                Console.WriteLine("Audit Plan created successfully!");
                var rows1 = driver.FindElements(tableBy);
                Console.WriteLine($"Number of rows loaded after a search: {rows1.Count}");
            }

            //to get browser logs
            var logs = driver.Manage().Logs.GetLog(LogType.Browser);

            var jsException = logs.Where(log => log.Level == LogLevel.Severe).ToList();
            if (jsException.Count > 0)
            {
                Console.WriteLine("JavaScript Errors/Exceptions found:");
                foreach (var log in jsException)
                {
                    Console.WriteLine(log.Timestamp + " - " + log.Message);
                }

            }
            else
            {
                Console.WriteLine("No JavaScript Errors/Exceptions found:");
            }


            return new HomePage(driver);
        }


    }
}
