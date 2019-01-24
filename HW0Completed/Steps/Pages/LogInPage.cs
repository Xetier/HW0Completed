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
    public class LogInPage
    {
        public IWebDriver _driver = Hooks.WebDriver;

        [Step("Fill email with <email>")]
        public void FillEmail(string email)
        {
            _driver.FindElement(By.Id("email")).Clear();
            _driver.FindElement(By.Id("email")).SendKeys(email);
        }

        [Step("Fill password with <pswrd>")]
        public void FillPassword(string pswrd)
        {
            _driver.FindElement(By.Id("passwd")).Clear();
            _driver.FindElement(By.Id("passwd")).SendKeys(pswrd);
        }

        [Step("Click Sign in button")]
        public void ClickSignIn()
        {
            _driver.FindElement(By.Id("SubmitLogin")).Click();
        }

        [Step("Check proper username is shown in the header with <expectedT>")]
        public void CheckProperUsername(string expectedT)
        {
            _driver.FindElement(By.ClassName("account")).Text.Should().Be(expectedT);
        }
    }
}
