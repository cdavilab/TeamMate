using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V125.FedCm;
using OpenQA.Selenium.Interactions;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Numerics;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;



namespace TMProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void importUser()
        {

            // to review on web 
            // $x("//a[@title='Setup']")
            IWebDriver myDriver = new ChromeDriver(@"C:\Users\Cristina.Davila\Downloads\chromedriver");
            myDriver.Navigate().GoToUrl("https://qa-tmplus.wktmdev.com/TeamMate/Home/Login?returnUrl=%2FTeamMate%2F");
            myDriver.Manage().Window.Maximize();
            // myDriver.FindElement(By.Id("username")).SendKeys("cdavila");
            // myDriver.FindElement(By.Name("password")).SendKeys("123456789");
            //  myDriver.FindElement(By.CssSelector("#username")).SendKeys("cdavila"); 
            /*myDriver.FindElement(By.CssSelector("input[id='username']")).SendKeys("admin");
            myDriver.FindElement(By.CssSelector("#password")).SendKeys("password");

            myDriver.FindElement(By.XPath("//button[@type='submit']")).Click();
            myDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);

            myDriver.FindElement(By.CssSelector("a[id='menu-setups']")).Click();
            // myDriver.FindElement(By.CssSelector("#menu-setups")).Click();
            myDriver.FindElement(By.CssSelector("#menu-users")).Click();
            myDriver.FindElement(By.CssSelector("a#menu-users-user")).Click();

            WebElement item = (WebElement)myDriver.FindElement(By.Id("usertext"));
            myDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);*/
            //yDriver.FindElement(By.CssSelector("div[data-action='User.Import']")).Click();//click on Import button
            //myDriver.FindElement(By.CssSelector("svg[class='icon icon-import']")).Click();
            //Console.WriteLine("antes del modal ");
            /*if (!myDriver.FindElement(By.CssSelector("div[aria-describedby='tm-errordialog']")).Displayed)//is visible //aria-describedby="tm-errordialog"
            {
                Console.WriteLine("entró al model de error : ");
                item.SendKeys(Keys.Escape); 
            }*/
            
            // myDriver.FindElement(By.XPath("//button[@type='button']")).Click();
           /* IWebElement fileInput = myDriver.FindElement(By.CssSelector("input[type='file']"));
            fileInput.SendKeys("C:\\Users\\Cristina.Davila\\Downloads\\UserTemplate.xlsx");
            int size = 0;

            myDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            //myDriver.FindElement(By.Id("file-submit")).Click();
            size = myDriver.FindElements(By.XPath("//table[@id='users']/tbody/tr")).Count;
            Console.WriteLine("Este es el mensaje de la primera vez : " + size);
            myDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);*/
            //String successMessage = myDriver.FindElement(By.Id("flashMessageContentId")).Text;
            //Console.WriteLine("Este es el mensaje de : "+successMessage);

            /*if ( myDriver.FindElement(By.CssSelector("div[aria-describedby='tm-errordialog']")).Displayed )//is visible
            {
                item.SendKeys(Keys.Escape);
            } */
            /*WebDriverWait wait = new WebDriverWait(myDriver, TimeSpan.FromSeconds(15));
            //WebElement item = (WebElement)myDriver.FindElement(By.Id("usertext"));
            item.SendKeys("Luciana2");
            item.SendKeys(Keys.Enter);
            item.Clear();           

            item.SendKeys("Luciana1");
            item.SendKeys(Keys.Enter);

            //myDriver.FindElement(By.Id("usertext")).SendKeys("Megan4");
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//table[@id='users']/tbody/tr")));
            var rows = myDriver.FindElements(By.XPath("//table[@id='users']/tbody/tr"));
            //WebElement items = (WebElement)wait.Until(ExpectedConditions.ElementExists(By.XPath("//table[@id='users']/tbody/tr")));
            Console.WriteLine($"Number of rows loaded after a search: {rows.Count}");*/
            /*bool success = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath("//table[@id='users']/tbody/tr[1]/td[2]"),"Megan14"));
            if (success)
            {
                Console.WriteLine("User imported successfully!");            
            }*/

            //myDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            //WebDriverWait wait = new WebDriverWait(myDriver, TimeSpan.FromMilliseconds(10000));
            //WebElement table = wait.Until(ExpectedExceptionAttribute.IsDefined)



            /*importErrorMsg class
            id div tm-errordialog

            div id tm-flashmessage
            div id flashMessageContentId*/


            //*[@id="menu-setups"]



            /*myDriver.FindElement(By.XPath("//a[@id='menu-setups']")).Click();
            myDriver.FindElement(By.XPath("//a[@id='menu-users']")).Click();
            myDriver.FindElement(By.XPath("//a[@id='menu-users-user']")).Click();
            */

            // driver.FindElement(By.Xpath("//input[@value='f']"));

            //myDriver.Quit();



            // myDriver.FindElement(By.XPath("//button[@id='menuheader-menu']")).Click();
            //myDriver.FindElement(By.XPath("//*[name()='svg' and @class='icon icon-setup']")).Click();

            //myDriver.FindElement(By.Id("menu-home")).Click();



            //myDriver.FindElement(By.XPath("//li//a[text()='My Home']")).Click();

            /* WebElement svgObject = (WebElement)myDriver.FindElement(By.XPath("//*[local-name()='svg']"));
             Actions builder = new Actions(myDriver);
             builder.MoveToElement(svgObject).Click().Build().Perform();*/

            //builder.Click(svgObject).Build().Perform();
            // myDriver.FindElement(By.XPath("/*[name()='svg']/*[name()='icon icon-setup']")).Click();
            /* WebElement svgObject = (WebElement)myDriver.FindElement(By.XPath("/*[name()='svg']/*[name()='icon icon-setup']"));

             //WebElement svgObject = (WebElement)myDriver.FindElement(By.CssSelector("#globalmenu > svg"));
             Actions builder = new Actions(myDriver);
             builder.Click(svgObject).Build().Perform();
             menuheader - menu
             menuheader - menu

                 myDriver.FindElement(By.CssSelector("#globalmenu > svg"));*/

            /* buttonmenu menuheader-menu
             * 

                 svg class icon icon-setup
             svg class icon icon-splash-users


            <svg aria-label="Messenger" class="_8-yf5 " color="#262626" fill="#262626" height="24" role="img" viewBox="0 0 24 24" width="24">

             svg class icon icon-import*/

            
            LoginPage loginPage = new LoginPage(myDriver);
            UserPage userPage = new UserPage(myDriver);
            HomePage homePage = loginPage.loginValidUser("admin", "password");
            homePage = userPage.goToUserPage();
            homePage = userPage.importUser("Cristina","cdavila@gmail.com");//set new user name added
        }

        [TestMethod]
        public void createAuditPlan() {

            IWebDriver myDriver = new ChromeDriver(@"C:\Users\Cristina.Davila\Downloads\chromedriver");
            myDriver.Navigate().GoToUrl("https://qa-tmplus.wktmdev.com/TeamMate/Home/Login?returnUrl=%2FTeamMate%2F");
            myDriver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(myDriver);
            UserPage userPage = new UserPage(myDriver);
            AuditPlanPage auditPlanPage = new AuditPlanPage(myDriver);
            HomePage homePage = loginPage.loginValidUser("cdavila", "123456789");

            homePage = auditPlanPage.goAuditPlanPage();
            homePage = auditPlanPage.createAuditPlan("Audit Plan CD","Description CD","Owner");            

        }

        [TestMethod]
        public void createAssessment()
        {

            IWebDriver myDriver = new ChromeDriver(@"C:\Users\Cristina.Davila\Downloads\chromedriver");
            myDriver.Navigate().GoToUrl("https://qa-tmplus.wktmdev.com/TeamMate/Home/Login?returnUrl=%2FTeamMate%2F");
            myDriver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(myDriver);
            UserPage userPage = new UserPage(myDriver);
            AssessmentPage auditPlanPage = new AssessmentPage(myDriver);
            HomePage homePage = loginPage.loginValidUser("cdavila", "123456789");

            homePage = auditPlanPage.goAssessmentPage();
            homePage = auditPlanPage.createAssessment("Assessment_CD", "Description CD", "Owner");
            homePage = auditPlanPage.goInsertAssessmentPage();
            homePage = auditPlanPage.createObjective("Objective CD Title","Objective CD Description");
            myDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            homePage = auditPlanPage.createStrategicRisk("Strategic Risk CD Title", "Strategic Risk CD Description");
            myDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            homePage = auditPlanPage.createRisk("Risk CD Title", "Risk CD Description");
            myDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            homePage = auditPlanPage.createControl("Control CD Title", "Control CD Description");
            myDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            homePage = auditPlanPage.createProcedure("Procedure CD Title", "Procedure CD Description");
            myDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            homePage = auditPlanPage.createIssue("Issue CD Title", "Issue CD Description");
            myDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            //homePage = auditPlanPage.createRecommendation("Recommendation CD Title", "Recommendation CD Description");
            myDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            homePage = auditPlanPage.createCoachingNote("Coaching Note CD Title", "Coaching Note CD Description");

        }
        

        [TestMethod]
        public void createProject()
        {

            IWebDriver myDriver = new ChromeDriver(@"C:\Users\Cristina.Davila\Downloads\chromedriver");
            myDriver.Navigate().GoToUrl("https://qa-tmplus.wktmdev.com/TeamMate/Home/Login?returnUrl=%2FTeamMate%2F");
            myDriver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(myDriver);
            UserPage userPage = new UserPage(myDriver);
            ProjectPage projectPage = new ProjectPage(myDriver);
            AssessmentPage assessmentPage = new AssessmentPage(myDriver);
            HomePage homePage = loginPage.loginValidUser("cdavila", "123456789");

            homePage = assessmentPage.goAssessmentPage();
            homePage = assessmentPage.searchAssessmentPage("Assessment_CD");
            homePage = projectPage.createProject("Project_Code", "Project_CD", "Owner");

        }

       /* [TestMethod]
        public void createControl()
        {

            IWebDriver myDriver = new ChromeDriver(@"C:\Users\Cristina.Davila\Downloads\chromedriver");
            myDriver.Navigate().GoToUrl("https://qa-tmplus.wktmdev.com/TeamMate/Home/Login?returnUrl=%2FTeamMate%2F");
            myDriver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(myDriver);
            UserPage userPage = new UserPage(myDriver);
            AssessmentPage auditPlanPage = new AssessmentPage(myDriver);
            HomePage homePage = loginPage.loginValidUser("cdavila", "123456789");

            homePage = auditPlanPage.goAssessmentPage();
            homePage = auditPlanPage.createAssessment("Aseessment CD", "Description CD", "Owner");

        }

        [TestMethod]
        public void createProcedure()
        {

            IWebDriver myDriver = new ChromeDriver(@"C:\Users\Cristina.Davila\Downloads\chromedriver");
            myDriver.Navigate().GoToUrl("https://qa-tmplus.wktmdev.com/TeamMate/Home/Login?returnUrl=%2FTeamMate%2F");
            myDriver.Manage().Window.Maximize();
            LoginPage loginPage = new LoginPage(myDriver);
            UserPage userPage = new UserPage(myDriver);
            AssessmentPage auditPlanPage = new AssessmentPage(myDriver);
            HomePage homePage = loginPage.loginValidUser("cdavila", "123456789");

            homePage = auditPlanPage.goAssessmentPage();
            homePage = auditPlanPage.createAssessment("Aseessment CD", "Description CD", "Owner");

        }*/
    }
}
