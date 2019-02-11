using Cignium.Contrib.GaugeSelenium;
using Cignium.Contrib.GaugeSelenium.Impl;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0Completed.Steps
{
    public class Hooks
    {
        public static IWebDriver _driver;
        [BeforeSuite]
        public void Init()
        {
            RetryHelper.RetryOnException(3, TimeSpan.FromSeconds(10), () => {
                _driver = DriverFactory.GetDriver();
            });
        }
        public static IWebDriver WebDriver
        {
            get { return _driver; }
        }
        [AfterSuite]
        public void AfterSuite()
        {
            RetryHelper.RetryOnException(2, TimeSpan.FromSeconds(5), () => {
                _driver?.Quit();
            });
        }
    }
}
