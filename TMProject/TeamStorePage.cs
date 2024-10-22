using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V125.Debugger;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V127.Log;



namespace TMProject
{
    public class TeamStorePage
    {
        IWebDriver driver;

        private By mainMenuTeamStoreBy = By.CssSelector("a[id='menu-teamstores']");        
        private By menuSurveyBy = By.CssSelector("a[id='menu-teamstores-survey']");
        private By createTemplatePBy = By.CssSelector("button[aria-label='Templates']");
        private By createNewTemplatePBy = By.CssSelector("button[aria-label='Add New Survey Template']");
        private By saveButtonPBy = By.CssSelector("button[aria-label='Save Changes and Close']");
       

        private By templateTitleBy = By.Id("Survey_Title");

        //Folder Template
        private By menuFolderTemplateBy = By.CssSelector("a[id='menu-teamstores-foldertemplate']"); 

        // Survey.Description
        //  Survey.Instructions


        private By assessmentDescriptionBy = By.Id("Assessment_Description");
        private By roleBy = By.Id("UserRoleAssignments_Items_0__RoleId");
        private By saveAssessmentBy = By.CssSelector("button[aria-label='Save Changes']");
        /*private By tableBy = By.XPath("//table[@id='auditplans']/tbody/tr");
        private By tableTitleBy = By.XPath("//table[@id='auditplans']/tbody/tr[1]/td[1]");
        private By searchauditplanText = By.Id("auditplanText");
           */
        //Expand TreeGrid
        private By rootNode = By.XPath("//div[@class='rowContainer js-tree-row AssessmentTreeGrid locked unselectable']");
        private By expandTreeBy = By.CssSelector("svg[class='icon icon-tube-expander-active-close']");
                                                             



        private By expandFolderBy = By.CssSelector("svg[class='icon icon-tube-expander-close']");
                                                               
        private By expandThBy = By.CssSelector("div[class='rowToggle unselectable']");
        private By childBy = By.XPath("//div[@data-collapsible='false']");

        
        private By expandFolderTreeBy = By.CssSelector("svg[class='icon icon-tube-expander-close']");
        

        private By openDetailPaneButtonBy = By.CssSelector("button[aria-label='Open Details']");
      
        private By goHistoryTabBy = By.CssSelector("a[id='ui-id-5']");

   
        private By folderTemplateTabBy = By.CssSelector("div[id='UIGenericTab-FolderTemplate']");

        private By newFolderButtonBy = By.XPath("//div[@id='UIGenericTab-FolderTemplate']//button[@aria-label='Add New Folder']");
        
        private By newCabinetButtonBy = By.XPath("//div[@id='UIGenericTab-FolderTemplate']//button[@aria-label='Add New Cabinet']");
        
        private By titleCabinetBy = By.Name("Cabinet.Title");
        private By closeButtonBy = By.XPath("//div[@id='UIGenericTab-FolderTemplate']//button[aria-label='Close']");
        //div[@id='UIGenericTab-FolderTemplate']//button[@aria-label = 'Add New Cabinet']




        //m-detailbox-header__close js-panel-close






        public TeamStorePage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public HomePage goTeamStoreSurveyPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            driver.FindElement(mainMenuTeamStoreBy).Click();
            driver.FindElement(menuSurveyBy).Click();
            return new HomePage(driver);
        }

        public HomePage createSurveyTemplate()
        {
            // tsworksheet
            Actions actions = new Actions(driver);

            IWebElement parentRoot = driver.FindElement(By.XPath("//div[@class='rowContainer locked unselectable']"));
            Console.WriteLine($"Nodo Raiz: {parentRoot.GetAttribute("data-title")}");
            parentRoot.Click();
            IWebElement expandIcon = parentRoot.FindElement(expandTreeBy); // Adjust the XPath for the expand icon                
            actions.MoveToElement(expandIcon).Click().Perform();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='rowContainer unselectable']"))); // Adjust XPath for the child node


            IList<IWebElement> childNodes = parentRoot.FindElements(By.XPath("//div[@class='rowContainer unselectable']")); 
             Console.WriteLine($"cantidad de nodos hijos: {childNodes.Count}");

             foreach (var childNode in childNodes)
             {
                Console.WriteLine($"hijo de: {childNode.GetAttribute("data-title")}");              
                childNode.Click();
             }

            
             driver.FindElement(createNewTemplatePBy).Click();
            //to do create new template
            return new HomePage(driver);
        }

        public HomePage goCreateTemplatePage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            driver.FindElement(createTemplatePBy).Click();
            driver.FindElement(createNewTemplatePBy).Click();
            return new HomePage(driver);
        }


        public HomePage goTeamStoreFolderTemplatePage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            driver.FindElement(mainMenuTeamStoreBy).Click();
            driver.FindElement(menuFolderTemplateBy).Click();
            return new HomePage(driver);
        }

        

        public HomePage displayFolderHistory()
        {
            Actions actions = new Actions(driver);


            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript(@"
                window.jsErrors = [];
                window.onerror = function(msg,url,lineNo,columnNo, error){
                    var errorMsg = 'Message: '+msg+', URL: '+url+',Line: '+lineNo+' ,Column: '+columnNo+', Error: '+(error ? error.stack:'');
                    window.jsErrors.push(errorMsg);
                };
        
             ");

            System.Threading.Thread.Sleep(5000);

            var jsErrors = (System.Collections.ObjectModel.ReadOnlyCollection<object>)jsExecutor.ExecuteScript("return window.jsErrors;");
            if (jsErrors.Count > 0)
            {
                Console.WriteLine("JavaScript Errors/Exceptions found ");
                foreach (var error in jsErrors)
                {
                    Console.WriteLine(error.ToString());
                }
            }
            else { Console.WriteLine("No JavaScript Exception found. "); }
            /*
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //IWebElement button = driver.FindElement(newCabinetButtonBy);
            IWebElement button = wait.Until(ExpectedConditions.ElementToBeClickable(newCabinetButtonBy)); // Adjust XPath for the child node
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", button);
            button.Click();

            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
           
            driver.FindElement(titleCabinetBy).Clear();
            driver.FindElement(titleCabinetBy).SendKeys("Cabinet CD");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(closeButtonBy).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(newFolderButtonBy).Click();
           */

            IWebElement parentRoot = driver.FindElement(By.XPath("//div[@class='rowContainer locked ui-draggable unselectable']"));
            Console.WriteLine($"Nodo Raiz: {parentRoot.GetAttribute("aria-label")}");
            parentRoot.Click();
            IWebElement expandIcon = parentRoot.FindElement(expandTreeBy); // Adjust the XPath for the expand icon                
            actions.MoveToElement(expandIcon).Click().Perform();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='rowContainer ui-draggable unselectable']"))); // Adjust XPath for the child node


            IList<IWebElement> childNodes = parentRoot.FindElements(By.XPath("//div[@class='rowContainer ui-draggable unselectable']"));
            Console.WriteLine($"cantidad de nodos hijos: {childNodes.Count}");

            foreach (var childNode in childNodes)
            {
                Console.WriteLine($"hijo de: {childNode.GetAttribute("aria-label")}");
                childNode.Click();
            }

            new Actions(driver).SendKeys(Keys.PageDown).Perform();
            //driver.FindElement(objectiveDescriptionBy).SendKeys(description);

            new Actions(driver).MoveByOffset(0, 0).Click().Perform();
            //driver.FindElement(newFolderButtonBy).Click();
            driver.FindElement(goHistoryTabBy).Click();


            //1st way to get browser logs
            //Using LogEntries, Selenium's logging feature.
            /*var logs = driver.Manage().Logs.GetLog(LogType.Browser);

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
            }*/


            //2nd Way inject JavaScript into the browser page to listen for exceptions directly within the page context
            


            //3rd Way using DevTools Protocol CDP Just Chrome and Edge
            var devTools = ((ChromeDriver)driver).GetDevToolsSession();

            devTools.Domains.Log.Enable();

            devTools.Domains.Log.EntryAdded += (sender, e) =>
            {

                Console.WriteLine($"JavaScript Error: {e.Entry.ToString()}");
                Console.WriteLine($"Line: {e.Entry.Message}");

            };




            return new HomePage(driver);


        }


       

    }
}