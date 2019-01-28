using Cignium.Contrib.GaugeSelenium;
using Cignium.Contrib.GaugeSelenium.Impl;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0Completed.Steps.Pages
{
    class BasicSteps
    {
        IWebDriver _driver = Hooks.WebDriver;

        [Step("Go to <url>")]
        public void GoToAutomationpractice(string url)
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(url);
        }

        [Step("Click to button SingIn")]
        public void ClickToButtonSingIn()
        {
            _driver.FindElementBy("Class", "login").Click();            
        }

        [Step("Check my account page contains <urlSubString>")]
        public void CheckMyAccountPage(string urlSubString)
        {
            _driver.Url.Should().Contain(urlSubString);
        }

        [Step("Check Log out action is available showing <expectedT>")]
        public void CheckLogOut(string expectedT)
        {
            _driver.FindElementBy("Class", "logout").Text.Should().Be(expectedT);
        }

    }
}
