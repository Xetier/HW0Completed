using Cignium.Contrib.GaugeSelenium;
using Cignium.Contrib.GaugeSelenium.Impl;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0Completed.Steps
{
    class SignIn
    {
        IWebDriver _driver = Hooks.WebDriver;

        public static readonly Random random = new Random();

        [Step("Fill Email address to create an account")]
        public void FillEmailAddress()
        {
            
            string emailKey = RandomGenerate(10).ToString() + "@" + RandomGenerate(5).ToString() + ".com";
            SendDataString("Id", "email_create", emailKey);
            Log.Information("email: " + emailKey);
        }

        [Step("Click Create an account")]
        public void ClickCreateAnAccount()
        {
            _driver.FindElementBy("Id", "SubmitCreate").Click();
        }

        [Step("Click Register button")]
        public void ClickOnButtonRegister()
        {
            _driver.FindElementBy("Id", "submitAccount").Click();
        }

        public static string RandomGenerate(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrsqtuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
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
