using Cignium.Contrib.GaugeSelenium;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0Completed.Steps
{
    class LogInFile
    {
        public IWebDriver _driver = Hooks.WebDriver;

        public string file = "C:\\PitDevelop\\C#\\HW0Refactor\\SingInRandomData\\txtfile\\TestFile.txt";
        public string email, passwd, fullName = null;

        [Step("Read File")]
        public void ReadFile()
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string[] lines = File.ReadAllLines(file);
                email = lines[0];
                passwd = lines[1];
                fullName = lines[2] + " " + lines[3];
            }
        }

        [Step("Fill email")]
        public void FillEmail()
        {
            _driver.FindElement(By.Id("email")).Clear();
            _driver.FindElement(By.Id("email")).SendKeys(email);
        }

        [Step("Fill password")]
        public void FillPassword()
        {
            _driver.FindElement(By.Id("passwd")).Clear();
            _driver.FindElement(By.Id("passwd")).SendKeys(passwd);
        }

        [Step("Check proper username is shown in the header")]
        public void CheckProperUsername()
        {
            _driver.FindElement(By.ClassName("account")).Text.Should().Be(fullName);
        }
    }
}
