using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0Completed
{
    public class Hooks
    {
        const int timeout = 60;
        public static IWebDriver _driver;

        [BeforeSuite]
        public void Initialize()
        {
            string browser = Environment.GetEnvironmentVariable("browser");
            Console.WriteLine(browser);
            if (browser.Equals("chrome"))
            {
                _driver = new ChromeDriver();
            }
            else if (browser.Equals("firefox"))
            {
                _driver = new FirefoxDriver();
            }
            
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }

        [AfterSuite]
        public void AfterSuite()
        {
            _driver?.Quit();
        }
        public static IWebDriver WebDriver
        {
            get { return _driver; }
        }
    }
}
