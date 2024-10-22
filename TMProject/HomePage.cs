using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMProject
{
    public class HomePage
    {
        protected IWebDriver driver;

        public HomePage(IWebDriver driver) { 
            this.driver = driver;
            if (!driver.Title.Contains("")) {
                throw new Exception("This is not the Home Page of Logged in user," + " currente page is: " + driver.Url);
            }
        }

        public HomePage manageProfile() { 
            return new HomePage(driver);
        }

    }
}
