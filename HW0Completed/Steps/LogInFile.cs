using Cignium.Contrib.GaugeSelenium;
using Cignium.Contrib.GaugeSelenium.Impl;
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
            SendDataString("Id", "email", email);
        }

        [Step("Fill password")]
        public void FillPassword()
        {
            SendDataString("Id", "passwd", passwd);
        }

        [Step("Check proper username is shown in the header")]
        public void CheckProperUsername()
        {
            _driver.FindElementBy("Class", "account").Text.Should().Be(fullName);
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
