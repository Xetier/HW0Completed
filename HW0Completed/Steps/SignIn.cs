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
        public string firstName = RandomGenerate(10).ToString();
        public string lastName = RandomGenerate(10).ToString();

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


        [Step("Fill all fields with correct data")]
        public void FillFields()
        {
            try
            {
                var random = new Random();

                var id_gender = random.Next(0, 2);
                _driver.FindElements(By.Name("id_gender"))[id_gender].Click();

                _driver.FindElement(By.Id("customer_firstname")).Clear();
                _driver.FindElement(By.Id("customer_firstname")).SendKeys(firstName);
                Log.Information("firstName: " + firstName);

                _driver.FindElement(By.Id("customer_lastname")).Clear();
                _driver.FindElement(By.Id("customer_lastname")).SendKeys(lastName);
                Log.Information("lastName: " + lastName);

                string password = RandomGeneratePass(10).ToString();
                _driver.FindElement(By.Id("passwd")).Clear();
                _driver.FindElement(By.Id("passwd")).SendKeys(password);
                Log.Information("password: " + password);

                int day = random.Next(1, 31);
                var cbxBirthDays = _driver.FindElement(By.Id("days"));
                var selectElementBirthDays = new SelectElement(cbxBirthDays);
                selectElementBirthDays.SelectByValue(day.ToString());

                int month = random.Next(1, 13);
                var cbxBirthMonth = _driver.FindElement(By.Id("months"));
                var selectElementBirthMonth = new SelectElement(cbxBirthMonth);
                selectElementBirthMonth.SelectByValue(month.ToString());

                int year = random.Next(1900, 2020);
                var cbxBirthYear = _driver.FindElement(By.Id("years"));
                var selectElementBirthYear = new SelectElement(cbxBirthYear);
                selectElementBirthYear.SelectByValue(year.ToString());

                _driver.FindElement(By.Id("newsletter")).Click();
                _driver.FindElement(By.Id("optin")).Click();

                string company = RandomGenerate(10).ToString();
                _driver.FindElement(By.Id("company")).Clear();
                _driver.FindElement(By.Id("company")).SendKeys(company);

                string address1 = RandomGenerate(10).ToString();
                _driver.FindElement(By.Id("address1")).Clear();
                _driver.FindElement(By.Id("address1")).SendKeys(address1);

                string address2 = RandomGenerate(10).ToString();
                _driver.FindElement(By.Id("address2")).Clear();
                _driver.FindElement(By.Id("address2")).SendKeys(address2);

                string city = RandomGenerate(10).ToString();
                _driver.FindElement(By.Id("city")).Clear();
                _driver.FindElement(By.Id("city")).SendKeys(city);

                int state = random.Next(1, 51);
                var cbxState = _driver.FindElement(By.Id("id_state"));
                var selectElementState = new SelectElement(cbxState);
                selectElementState.SelectByValue(state.ToString());

                _driver.FindElement(By.Id("postcode")).Clear();
                _driver.FindElement(By.Id("postcode")).SendKeys(RandomGenerateNumber(5));

                var cbxCountry = _driver.FindElement(By.Id("id_country"));
                var selectElementCountry = new SelectElement(cbxCountry);
                selectElementCountry.SelectByText("United States");

                string additional = RandomGenerate(10).ToString();
                _driver.FindElement(By.Id("other")).Clear();
                _driver.FindElement(By.Id("other")).SendKeys(additional);

                string phone = "+" + RandomGenerateNumber(2).ToString() + " " + RandomGenerateNumber(9).ToString();
                _driver.FindElement(By.Id("phone")).Clear();
                _driver.FindElement(By.Id("phone")).SendKeys(phone);

                string mphone = "+" + RandomGenerateNumber(2).ToString() + " " + RandomGenerateNumber(9).ToString();
                _driver.FindElement(By.Id("phone_mobile")).Clear();
                _driver.FindElement(By.Id("phone_mobile")).SendKeys(mphone);

                string address = RandomGenerate(10).ToString();
                _driver.FindElement(By.Id("alias")).Clear();
                _driver.FindElement(By.Id("alias")).SendKeys(address);

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }
        }

        [Step("Click Register button")]
        public void ClickOnButtonRegister()
        {
            _driver.FindElement(By.Id("submitAccount")).Click();
        }

        [Step("Check Proper username is shown in the header")]
        public void CheckProperUsername()
        {
            string expectedT = firstName + " " + lastName;
            _driver.FindElement(By.ClassName("account")).Text.Should().Be(expectedT);
        }

        public static string RandomGenerateNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomGenerate(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrsqtuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomGeneratePass(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrsqtuvwxyz!#$%&/()=?¡¿' ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
