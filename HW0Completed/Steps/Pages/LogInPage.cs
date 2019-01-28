using Cignium.Contrib.GaugeSelenium;
using Cignium.Contrib.GaugeSelenium.Impl;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using HW0Completed;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW0Completed.Steps.Pages
{
    class LogInPage
    {
        public IWebDriver _driver = Hooks.WebDriver;

        [Step("Fill email with <email>")]
        public void FillEmail(string email)
        {
            SendDataString("Id", "email", email);
        }

        [Step("Fill password with <pswrd>")]
        public void FillPassword(string pswrd)
        {
            SendDataString("Id", "passwd", pswrd);
        }

        [Step("Click Sign in button")]
        public void ClickSignIn()
        {
            _driver.FindElementBy("Id", "SubmitLogin").Click();
        }

        [Step("Check proper username is shown in the header with <expectedT>")]
        public void CheckProperUsername(string expectedT)
        {
            _driver.FindElementBy("Class", "account").Text.Should().Be(expectedT);
        }

        public static void SendDataString(string type, string selectorValue, string data)
        {
            IWebDriver _driver = Hooks.WebDriver;

            var element = _driver.FindElementBy(type, selectorValue);
            element.Clear();
            element.SendKeys(data);
        }
    }
}
