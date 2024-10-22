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
    public class ProjectPage
    {
        IWebDriver driver;

        private By mainMenuAuditPlanBy = By.CssSelector("a[id='menu-auditplan']"); 
        //private By createAuditPBy = By.CssSelector("button[aria-label='Create Audit Plan']");
        

        private By createProjectBy = By.XPath("//button[contains(@aria-label,'Add Project to the Selected Item')]");

        private By projectCodeBy = By.Id("Project_Code"); 
        private By projectTitleBy = By.Id("Project_Title");
        private By roleBy = By.Id("UserRoleAssignments_Items_0__RoleId");        
        private By saveProjectBy = By.CssSelector("button[aria-label='Save and Close']");

        private By perspectiveBy = By.Id("ddlPerspectives");

        
        /*private By tableBy = By.XPath("//table[@id='auditplans']/tbody/tr");
        private By tableTitleBy = By.XPath("//table[@id='auditplans']/tbody/tr[1]/td[1]");
        private By searchauditplanText = By.Id("auditplanText");
        private By forecastContainerBy = By.Id("popupAuditPlanForecastAuditPlanButtonContainer");

        // By.XPath("//table[@id='auditplans']/tbody/tr[1]/td[1]");
        */




        public ProjectPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        
        public HomePage createProject(String code,String title, String role) {

           
            /*
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            //driver.FindElement()
            IWebElement comboPerspective = driver.FindElement(perspectiveBy);
            SelectElement perspectiveSelected = new SelectElement(comboPerspective);
            perspectiveSelected.SelectByText("Control and Process Assessment");
            */

            string rowTitle = "Compliance (HIPAA)";
            //select row item
            string xpath = $".//div[contains(@class,'rowContainer') and .//span[text()='{rowTitle}']]";
            driver.FindElement(By.XPath(xpath)).Click();
            //create
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            driver.FindElement(createProjectBy).Click();

           

            IWebElement comboBox = driver.FindElement(roleBy);
            driver.FindElement(projectCodeBy).Clear();
            driver.FindElement(projectCodeBy).SendKeys(code);
            driver.FindElement(projectTitleBy).Clear();
            driver.FindElement(projectTitleBy).SendKeys(title);
            SelectElement itemSelected = new SelectElement(comboBox);
            itemSelected.SelectByText(role);

            driver.FindElement(saveProjectBy).Click();

           


            return new HomePage(driver);
        }


    }
}
