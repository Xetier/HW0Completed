using Cignium.Contrib.GaugeSelenium;
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
            _driver.FindElement(By.Id("email_create")).Clear();
            string emailKey = RandomGenerate(10).ToString() + "@" + RandomGenerate(5).ToString() + ".com";
            _driver.FindElement(By.Id("email_create")).SendKeys(emailKey);
            Log.Information("email: " + emailKey);
        }

        [Step("Click Create an account")]
        public void ClickCreateAnAccount()
        {
            _driver.FindElement(By.Id("SubmitCreate")).Click();
        }

        [Step("Click Register button")]
        public void ClickOnButtonRegister()
        {
            _driver.FindElement(By.Id("submitAccount")).Click();
        }

        public static string RandomGenerate(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrsqtuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
