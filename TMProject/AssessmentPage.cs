using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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


namespace TMProject
{
    public class AssessmentPage
    {
        IWebDriver driver;

        private By mainMenuAssessmentBy = By.CssSelector("a[id='menu-assessment']");
        private By createAssessmentPBy = By.CssSelector("button[aria-label='Add Assessment']");
        private By assessmentTitleBy = By.Id("Assessment_Title");
        private By assessmentDescriptionBy = By.Id("Assessment_Description");
        private By roleBy = By.Id("UserRoleAssignments_Items_0__RoleId");
        private By saveAssessmentBy = By.CssSelector("button[aria-label='Save Changes']");
        /*private By tableBy = By.XPath("//table[@id='auditplans']/tbody/tr");
        private By tableTitleBy = By.XPath("//table[@id='auditplans']/tbody/tr[1]/td[1]");
        private By searchauditplanText = By.Id("auditplanText");
           */
        //Expand TreeGrid
        private By rootNode = By.XPath("//div[@class='rowContainer js-tree-row AssessmentTreeGrid locked unselectable']");
        private By expandTreeBy = By.CssSelector("svg[class='icon icon-tube-expander-close']");
        private By expandThBy = By.CssSelector("div[class='rowToggle unselectable']");
        private By childBy = By.XPath("//div[@data-collapsible='false']");



        private By perspectiveBy = By.Id("ddlPerspectives");
        private By searchAssessmentBy = By.Id("assessmentText");
        private By tableBy = By.XPath("//table[@id='assessments']/tbody/tr");
        private By tableTitleBy = By.XPath("//table[@id='assessments']/tbody/tr[1]/td[1]");
        private By openAssessmentPBy = By.CssSelector("button[aria-label='Open Selected Assessment']");
        
        //Go to Insert tab
        private By menuInsertBy = By.CssSelector("a[id='tabs-ui-id-3']");
        private By newObjectivePBy = By.CssSelector("button[aria-label='Add New Objective']");


        private By detailPaneCloseBtnBy = By.XPath("//button[@class = 'm-detailbox-header__close js-panel-close']");
        private By genericExpanderBy = By.CssSelector("button[class='m-button m-button--treenode-detail-panel-expander js-row-expander rowExpandIconHolder']");

        private By newWorkPaperBy = By.CssSelector("button[aria-label='Add New Workpaper']");


        //Objective Fields
        private By objectiveTitleBy = By.Name("Objective.Title");
        private By objectiveDescriptionBy = By.XPath("//*[@class = 'cke_editable cke_editable_themed cke_contents_ltr cke_show_borders']");
        //private By objectiveCloseBtnBy = By.XPath("//button[@class = 'm-detailbox-header__close js-panel-close']");


        //StrategicRisk Fields
        private By newStrategicRiskBy = By.CssSelector("button[aria-label='Add New Strategic Risk']"); 
        private By strategicRiskTitleBy = By.Name("StrategicRisk.Title");
        private By strategicRiskDescriptionBy = By.XPath("//*[@class = 'cke_editable cke_editable_themed cke_contents_ltr cke_show_borders']");
        //private By strategicRiskCloseBtnBy = By.XPath("//button[@class = 'm-detailbox-header__close js-panel-close']");


        //Risk Fields
        private By newRiskBy = By.CssSelector("button[aria-label='Add New Risk']");
        private By riskTitleBy = By.Name("Risk.Title");
        private By riskDescriptionBy = By.XPath("//*[@class = 'cke_editable cke_editable_themed cke_contents_ltr cke_show_borders']");
        //private By riskCloseBtnBy = By.XPath("//button[@class = 'm-detailbox-header__close js-panel-close']");


        //Control Fields        
        private By newControlBy = By.CssSelector("button[aria-label='Add New Control']");
        private By controlTitleBy = By.Name("Control.Title");
        private By controlDescriptionBy = By.XPath("//*[@class = 'cke_editable cke_editable_themed cke_contents_ltr cke_show_borders']");
        //private By controlCloseBtnBy = By.XPath("//button[@class = 'm-detailbox-header__close js-panel-close']");

        //Procedure Fields        
        private By newProcedureBy = By.CssSelector("button[aria-label='Add New Procedure']");
        private By procedureTitleBy = By.Name("Procedure.Title");
        private By procedureDescriptionBy = By.XPath("//*[@class = 'cke_editable cke_editable_themed cke_contents_ltr cke_show_borders']");
        //private By procedureCloseBtnBy = By.XPath("//button[@class = 'm-detailbox-header__close js-panel-close']");
                    


        //Issue Fields
        
        private By newIssueBy = By.CssSelector("button[aria-label='Add Issue to the Selected Item']");
        private By issueTitleBy = By.Name("Issue.Title");
        private By issueDescriptionBy = By.XPath("//*[@class = 'cke_editable cke_editable_themed cke_contents_ltr cke_show_borders']");



        //Recommendation Fields
        private By newRecommendationBy = By.CssSelector("button[aria-label='Add Recommendation']");
        private By recommendationTitleBy = By.Name("Recommendation.Title");
        private By recommendationDescriptionBy = By.XPath("//*[@class = 'cke_editable cke_editable_themed cke_contents_ltr cke_show_borders']");


        //Coaching Notes
        private By newCoachingNoteBy = By.CssSelector("button[aria-label='Add New Coaching Note']");
        private By coachingNoteTitleBy = By.Name("CoachingNote.Title");
        private By coachingNoteDescriptionBy = By.XPath("//*[@class = 'cke_editable cke_editable_themed cke_contents_ltr cke_show_borders']");




        //m-detailbox-header__close js-panel-close



        //private By objectiveDescriptionBy = By.Name("Objective.Text1");


        //cke_editable cke_editable_themed cke_contents_ltr cke_show_borders



        /* icon icon-tube-expander-active-close

         indent expander nonAudit ui-selector unselectable

             icon icon-tube-expander-close
             indent expander nonAudit unselectable ui-selector

             svg icon icon-tube-expander-active-open

             indent expander nonAudit unselectable ui-selector ui-selected

             icon icon-tube-expander-active-close


         */




        public AssessmentPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public HomePage goAssessmentPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            driver.FindElement(mainMenuAssessmentBy).Click();
            return new HomePage(driver);
        }

        public HomePage searchAssessmentPage(string assessmentName)
        {
            //search
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            IWebElement item = driver.FindElement(searchAssessmentBy);
            item.SendKeys(assessmentName);
            item.SendKeys(Keys.Enter);
 
            var rows = driver.FindElements(tableBy);
            Console.WriteLine($"Before a search: {rows.Count}");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(tableBy));

            bool success = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(tableTitleBy, assessmentName));
           
            if (success)
            {
                Console.WriteLine("Assesement found!");
                var rows1 = driver.FindElements(tableBy);
                Console.WriteLine($"Number of rows loaded after a search: {rows1.Count}");
                //Open Assessment
                driver.FindElement(openAssessmentPBy).Click();

            }
            return new HomePage(driver);
        }

        public HomePage goInsertAssessmentPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            driver.FindElement(menuInsertBy).Click();
            return new HomePage(driver);
        }
        public HomePage createAssessment(String title, String description, String role)
        {
            //create
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            driver.FindElement(createAssessmentPBy).Click();
            driver.FindElement(assessmentTitleBy).SendKeys(title);
            driver.FindElement(assessmentDescriptionBy).SendKeys(description);

            IWebElement comboBox = driver.FindElement(roleBy);
            SelectElement itemSelected = new SelectElement(comboBox);
            itemSelected.SelectByText(role);

            driver.FindElement(saveAssessmentBy).Click();

            //open assessment

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            //driver.FindElement()
            IWebElement comboPerspective = driver.FindElement(perspectiveBy);
            SelectElement perspectiveSelected = new SelectElement(comboPerspective);
            perspectiveSelected.SelectByText("Control and Process Assessment");

            // IWebElement divElement = driver.FindElement(expandTreeBy);
            //wait.Until(ExpectedConditions.ElementToBeClickable(expandTreeBy));

            //Actions actions = new Actions(driver);
            // actions.MoveToElement(divElement).Click().Perform();
            IWebElement parentRoot = driver.FindElement(By.XPath("//div[@class='rowContainer js-tree-row AssessmentTreeGrid locked unselectable']"));
            Console.WriteLine($"Nodo Raiz: {parentRoot.GetAttribute("data-id")}");
            // Locate all parent nodes in the treegrid
            //IList<IWebElement> parentNodes = driver.FindElements(By.XPath("//div[@class='rowContainer js-tree-row AssessmentTreeGrid unselectable']")); // Adjust the XPath to match your parent node structure
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //Console.WriteLine($"cantidad de nodos: {parentNodes.Count}");

            //foreach (var parentNode in parentNodes)
            //{
            // Expand the parent node if it's collapsible
            // Assuming there is an icon or button to expand the node
            //  string dataId = parentNode.GetAttribute("data-id");
            //  Console.WriteLine($"1er hijo: {dataId}"  );

            /*IWebElement expandIcon = parentNode.FindElement(expandTreeBy); // Adjust the XPath for the expand icon
            //expandIcon.Click();
            Actions actions = new Actions(driver);
            actions.MoveToElement(expandIcon).Click().Perform();*/

            // Wait for the child nodes to appear after expanding
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='rowContainer js-tree-row AssessmentTreeGrid unselectable']"))); // Adjust XPath for the child node

            // Locate all child nodes under this parent
            IList<IWebElement> childNodes = parentRoot.FindElements(By.XPath("//div[@class='rowContainer js-tree-row AssessmentTreeGrid unselectable']")); // Adjust XPath based on your treegrid structure
            Console.WriteLine($"cantidad de nodos hijos: {childNodes.Count}");

            // Click on each child node
            foreach (var childNode in childNodes)
            {
                // Click the child node (you can also get the text or any other action)
                Console.WriteLine($"hijo: {childNode.GetAttribute("data-id")}");
                //childNode.Click();


                ClickOnTreeGrid(childNode, 1);
            }
            //}




            return new HomePage(driver);
        }
        public void ClickOnTreeGrid(IWebElement node, int currentLevel)
        {

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            Actions actions = new Actions(driver);

            try
            {
                IWebElement expandIcon = node.FindElement(expandTreeBy); // Adjust the XPath for the expand icon                
                actions.MoveToElement(expandIcon).Click().Perform();
            }
            catch { }


            if (currentLevel == 3) { return; }
            IReadOnlyCollection<IWebElement> childNodes = node.FindElements(By.XPath("//div[@class='rowContainer js-tree-row AssessmentTreeGrid unselectable']"));
            Console.WriteLine($"cantidad de nodos nietos: {childNodes.Count}");

            if (childNodes.Count > 0)
            {

                //actions.MoveToElement(expandIcon).Click().Perform();
                // IWebElement expandIcon1 = node.FindElement(expandTreeBy); // Adjust the XPath for the expand icon
                //expandIcon.Click();
                //Actions actions1= new Actions(driver);
                //actions1.MoveToElement(expandIcon1).Click().Perform();
                IWebElement expander = null;
                try
                {
                    expander = node.FindElement(expandTreeBy);
                    actions.MoveToElement(expander).Click().Perform();
                }
                catch { }

                foreach (var childNode in childNodes)
                {
                    Console.WriteLine($"nieto recursivo : {childNode.GetAttribute("data-id")}");
                    if (childNode.GetAttribute("data-collapsible") == "false")
                    {
                        actions.MoveToElement(childNode).Click().Perform();
                        Console.WriteLine($"entidad libre : {childNode.GetAttribute("data-id")}");
                        break;
                    }
                    //childNode.Click();

                    ClickOnTreeGrid(childNode, currentLevel + 1);

                }

            }

        }

        public HomePage createObjective(string title, string description)
        {
            /*IWebElement treegrid = driver.FindElement(rootNode);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight", treegrid);*/

            

            driver.FindElement(newObjectivePBy).Click();
            driver.FindElement(objectiveTitleBy).SendKeys(title);
           
            new Actions(driver).SendKeys(Keys.PageDown).Perform();
            //driver.FindElement(objectiveDescriptionBy).SendKeys(description);

            new Actions(driver).MoveByOffset(0, 0).Click().Perform();

            driver.FindElement(detailPaneCloseBtnBy).Click();

            return new HomePage(driver);
        }

        public HomePage createStrategicRisk(string title, string description)
        {
            /*IWebElement treegrid = driver.FindElement(rootNode);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight", treegrid);*/



            driver.FindElement(newStrategicRiskBy).Click();
            driver.FindElement(strategicRiskTitleBy).SendKeys(title);

            new Actions(driver).SendKeys(Keys.PageDown).Perform();
            //driver.FindElement(objectiveDescriptionBy).SendKeys(description);

            new Actions(driver).MoveByOffset(0, 0).Click().Perform();

            driver.FindElement(detailPaneCloseBtnBy).Click();

            return new HomePage(driver);
        }

        public HomePage createRisk(string title, string description)
        {
            /*IWebElement treegrid = driver.FindElement(rootNode);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight", treegrid);*/



            driver.FindElement(newRiskBy).Click();
            driver.FindElement(riskTitleBy).SendKeys(title);

            new Actions(driver).SendKeys(Keys.PageDown).Perform();
            //driver.FindElement(objectiveDescriptionBy).SendKeys(description);

            new Actions(driver).MoveByOffset(0, 0).Click().Perform();

            driver.FindElement(detailPaneCloseBtnBy).Click();

            return new HomePage(driver);
        }

        public HomePage createControl(string title, string description)
        {
            /*IWebElement treegrid = driver.FindElement(rootNode);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight", treegrid);*/



            driver.FindElement(newControlBy).Click();
            driver.FindElement(controlTitleBy).SendKeys(title);

            new Actions(driver).SendKeys(Keys.PageDown).Perform();
            //driver.FindElement(objectiveDescriptionBy).SendKeys(description);

            new Actions(driver).MoveByOffset(0, 0).Click().Perform();

            driver.FindElement(detailPaneCloseBtnBy).Click();

            return new HomePage(driver);
        }


        public HomePage createProcedure(string title, string description)
        {
            /*IWebElement treegrid = driver.FindElement(rootNode);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight", treegrid);*/



            driver.FindElement(newProcedureBy).Click();
            driver.FindElement(procedureTitleBy).SendKeys(title);

            new Actions(driver).SendKeys(Keys.PageDown).Perform();
            //driver.FindElement(objectiveDescriptionBy).SendKeys(description);

            new Actions(driver).MoveByOffset(0, 0).Click().Perform();

            driver.FindElement(detailPaneCloseBtnBy).Click();

            return new HomePage(driver);
        }
        public HomePage createIssue(string title, string description)
        {
            /*IWebElement treegrid = driver.FindElement(rootNode);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight", treegrid);*/



            driver.FindElement(newIssueBy).Click();
            driver.FindElement(issueTitleBy).SendKeys(title);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            new Actions(driver).SendKeys(Keys.PageDown).Perform();
            //driver.FindElement(objectiveDescriptionBy).SendKeys(description);

            new Actions(driver).MoveByOffset(0, 0).Click().Perform();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            driver.FindElement(detailPaneCloseBtnBy).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            return new HomePage(driver);
        }

        public HomePage createRecommendation(string title, string description)
        {
            /*IWebElement treegrid = driver.FindElement(rootNode);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight", treegrid);*/


            Console.WriteLine("ingresó a crear recommendation");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            //driver.FindElement(newRecommendationBy).Click();


            string rowTitle = "New";
            // If detail panel is not opened, open it
            /*if (!driver.FindElement(By.XPath($".//div[contains(@class,'rowContainer') and .//span[text()='{rowTitle}']]")).GetAttribute("class").Contains("js-open-details"))
            {
                Console.WriteLine("ingresó a abrir el detailpane");
                string xpath = $".//div[contains(@class,'rowContainer') and .//span[text()='{rowTitle}']]";
                driver.FindElement(By.XPath($"{xpath}//button[@class='m-button m-button--treenode-detail-panel-expander js-row-expander rowExpandIconHolder' or @class='rowExpandIcon unselectable' ]")).Click();
                Console.WriteLine("ya abrió detailpane");
            }*/

            driver.FindElement(recommendationTitleBy).Click();

            string xpath = $".//div[contains(@class,'rowContainer') and .//span[text()='{rowTitle}']]";
            driver.FindElement(By.XPath($"{xpath}//button[@class='m-button m-button--treenode-detail-panel-expander js-row-expander rowExpandIconHolder' and @class='rowExpandIcon unselectable' ]")).Click();

            //driver.FindElement(recommendationTitleBy).SendKeys(title);

            new Actions(driver).SendKeys(Keys.PageDown).Perform();
            //driver.FindElement(objectiveDescriptionBy).SendKeys(description);

            new Actions(driver).MoveByOffset(0, 0).Click().Perform();
            Console.WriteLine("despues de escribir el title de recommendation");
            //driver.FindElement(detailPaneCloseBtnBy).Click();

            return new HomePage(driver);
        }

        public HomePage createCoachingNote(string title, string description)
        {
            /*IWebElement treegrid = driver.FindElement(rootNode);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollTop = arguments[0].scrollHeight", treegrid);*/



            driver.FindElement(newCoachingNoteBy).Click();
            driver.FindElement(coachingNoteTitleBy).SendKeys(title);

            new Actions(driver).SendKeys(Keys.PageDown).Perform();
            //driver.FindElement(objectiveDescriptionBy).SendKeys(description);

            new Actions(driver).MoveByOffset(0, 0).Click().Perform();

            driver.FindElement(detailPaneCloseBtnBy).Click();

            return new HomePage(driver);
        }

    }
}