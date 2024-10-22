using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace TMProject
{
    public class IssueTrackingnPage
    {
        IWebDriver driver;

        private By mainMenuIssueTrackingBy = By.CssSelector("a[id='menu-issuetracking']");
        private By expandTreeBy = By.CssSelector("svg[class='icon icon-tube-expander-close']");
                                                         

        private By treeNodeLocator = By.XPath("//div[@class='rowContainer js-tree-row unselectable']");
        private By expandButtonLocator = By.CssSelector("svg[class='icon icon-tube-expander-close']");


        
        private By containerBy = By.XPath("//div[@class='content rowBody gradient unselectable']");

        public IssueTrackingnPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public HomePage goAIssueTrackingPage() {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            driver.FindElement(mainMenuIssueTrackingBy).Click();           
            return new HomePage(driver);
        }
        /*public HomePage updateIssue() {
            //create
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);

            Actions actions = new Actions(driver);
            IWebElement parentRoot = driver.FindElement(By.XPath("//div[@class='rowContainer js-tree-row locked unselectable']"));
            Console.WriteLine($"Nodo Raiz: {parentRoot.GetAttribute("data-id")}");
            // Find the root of the treegrid
            //IWebElement treeGrid = driver.FindElement(treeGridLocator);

           

            try
            {
                IWebElement expandIcon = parentRoot.FindElement(expandTreeBy); // Adjust the XPath for the expand icon                
                actions.MoveToElement(expandIcon).Click().Perform();
            }
            catch { }


            string targetChildText = "Recommendation Recommendation in tree 1.1";

            // Start recursive traversal from the root nodes
            bool found = TraverseTreeNodes(driver, parentRoot, treeNodeLocator, expandButtonLocator, targetChildText);

            if (found)
            {
                Console.WriteLine($"Target node '{targetChildText}' found!");
            }
            else
            {
                Console.WriteLine($"Target node '{targetChildText}' not found.");
            }

            return new HomePage(driver);
        }

       */
        public  bool TraverseTreeNodes(IWebDriver driver, IWebElement parentNode, By treeNodeLocator, By expandButtonLocator, string targetChildText)
        {
            Actions actions = new Actions(driver);
            // Find all current child nodes of the parentNode
            IList<IWebElement> childNodes = parentNode.FindElements(By.XPath("//div[@class='rowContainer js-tree-row unselectable']"));
           
            Console.WriteLine($"CANTIDAD DE NODOS: {childNodes.Count}");

            foreach (var node in childNodes)
            {
                Console.WriteLine($"CHILD NODE: {node.GetAttribute("data-id")}{node.GetAttribute("aria-label")}");
                // Check if this node contains the target text
               /* if (node.Text.Contains(targetChildText))
                {
                    Console.WriteLine($"Found target node: {node.Text}");
                    return true;
                }*/

                // Check if this node is expandable
                try
                {
                    IWebElement expandButton = node.FindElement(expandButtonLocator);
                    if (expandButton.Displayed && expandButton.Enabled)
                    {
                        // Expand the node
                        actions.MoveToElement(expandButton).Click().Perform();
                        System.Threading.Thread.Sleep(500);  // Add a short delay to allow UI to update
                    }
                }
                catch (NoSuchElementException)
                {
                    // Node is not expandable or expand button not found
                }

                // Recursively check this node's children after expanding
               /* bool foundInChild = TraverseTreeNodes(driver, node, treeNodeLocator, expandButtonLocator, targetChildText);
                if (foundInChild)
                {
                    return true;
                }*/
            }

            // Return false if the target child is not found in this branch
            return false;
        }


        public HomePage updateIssue()
        {

            //create
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Actions actions = new Actions(driver);
            IWebElement parentRoot = driver.FindElement(By.XPath("//div[@class='rowContainer js-tree-row locked unselectable']"));
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

            IWebElement expandIcon = parentRoot.FindElement(expandTreeBy); // Adjust the XPath for the expand icon   
            actions.MoveToElement(expandIcon).Click().Perform();

            // Wait for the child nodes to appear after expanding
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='rowContainer js-tree-row unselectable']"))); // Adjust XPath for the child node

            // Locate all child nodes under this parent
            IList<IWebElement> childNodes = parentRoot.FindElements(By.XPath("//div[@class='rowContainer js-tree-row unselectable']")); // Adjust XPath based on your treegrid structure
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


            try
            {
                bool itemFound = FindItem(driver, "", wait);
            }
            catch (NoSuchElementException)
            {

                Console.WriteLine("Item not found!"); ;
            }

            return new HomePage(driver);
        }

        public bool FindItem(IWebDriver driver, string itemText, WebDriverWait wait) {
            Actions actions = new Actions(driver);
            IList<IWebElement> items = driver.FindElements(By.XPath("//div[@class='rowContainer js-tree-row locked unselectable']"));
            foreach (IWebElement item in items)
            {
                string rowText = item.Text;
                if (rowText.Contains(itemText)) {
                    Console.WriteLine("Item found ");
                    return true;
                }

                IWebElement expandIcon = null;
                try
                {
                    expandIcon = item.FindElement(expandTreeBy);
                }
                catch (NoSuchElementException)
                {

                    continue;
                }
                if (expandIcon != null) {
                    Console.WriteLine($"Expanding row: {item.GetAttribute("aria-label")}");                    
                    actions.MoveToElement(expandIcon).Click().Perform();
                    wait.Until(d => item.FindElement(By.XPath("//div[@class='rowContainer js-tree-row unselectable']")));
                    Console.WriteLine("Item found ");

                    // Recursively search the child rows
                    if (FindItem(driver, itemText, wait))
                    {
                        return true;
                    }
                }
            }
            return false;
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


            if (currentLevel == 4) { return; }
            IReadOnlyCollection<IWebElement> childNodes = node.FindElements(By.XPath("//div[@class='rowContainer js-tree-row unselectable']"));
            Console.WriteLine($"cantidad de nodos nietos: {childNodes.Count}");

            if (childNodes.Count > 0)
            {

                //actions.MoveToElement(expandIcon).Click().Perform();
                // IWebElement expandIcon1 = node.FindElement(expandTreeBy); // Adjust the XPath for the expand icon
                //expandIcon.Click();
                //Actions actions1= new Actions(driver);
                //actions1.MoveToElement(expandIcon1).Click().Perform();
               // IWebElement expander = null;
               /* try
                {
                    expander = node.FindElement(expandTreeBy);
                    actions.MoveToElement(expander).Click().Perform();
                }
                catch { }*/

                foreach (var childNode in childNodes)
                {
                    Console.WriteLine($"nieto recursivo : {childNode.GetAttribute("aria-label")}");
                    if (childNode.GetAttribute("data-type") == "50")
                    {
                        

                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                        var rtest = wait.Until(ExpectedConditions.ElementExists(expandTreeBy));

                        Console.WriteLine($"lo q hay: {rtest.Text}");

                        actions.MoveToElement(childNode).Click().Perform();

                        /* expander = childNode.FindElement(expandTreeBy);
                         actions.MoveToElement(expander).Click().Perform();

                         bool success = wait.Until(ExpectedConditions.TextToBePresentInElementLocated(containerBy, "Issue in tree 1.1"));

                         if (success)
                         {
                             Console.WriteLine("Issue found!");
                             var rows1 = driver.FindElements(tableBy);
                             Console.WriteLine($"Number of rows loaded after a search: {rows1.Count}");
                             //Open Assessment
                             driver.FindElement(openAssessmentPBy).Click();

                         }*/
                        Console.WriteLine($"entidad libre : {childNode.GetAttribute("aria-label")}");
                        break;
                    }
                    //childNode.Click();

                    ClickOnTreeGrid(childNode, currentLevel + 1);

                }

            }

        }


    }
}
