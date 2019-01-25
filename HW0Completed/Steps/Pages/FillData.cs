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

namespace HW0Completed.Steps.Pages
{
    class FillData
    {
        IWebDriver _driver = Hooks.WebDriver;

        public static readonly Random random = new Random();
        public string firstName = RandomGenerate(10).ToString();
        public string lastName = RandomGenerate(10).ToString();

        [Step("Click on Mr")]
        public void ClickOnMr()
        {
            var id_gender = random.Next(0, 2);
            _driver.FindElements(By.Name("id_gender"))[id_gender].Click();
        }

        [Step("Fill first name in customer_firstname field")]
        public void FillFirstName()
        {
            _driver.FindElement(By.Id("customer_firstname")).Clear();
            _driver.FindElement(By.Id("customer_firstname")).SendKeys(firstName);
            Log.Information("firstName: " + firstName);
        }

        [Step("Fill last name in customer_lastname field")]
        public void FillLastName()
        {
            _driver.FindElement(By.Id("customer_lastname")).Clear();
            _driver.FindElement(By.Id("customer_lastname")).SendKeys(lastName);
            Log.Information("lastName: " + lastName);
        }

        [Step("Fill password in passwd field")]
        public void FillPassword()
        {
            string password = RandomGeneratePass(10).ToString();
            _driver.FindElement(By.Id("passwd")).Clear();
            _driver.FindElement(By.Id("passwd")).SendKeys(password);
            Log.Information("password: " + password);
        }

        [Step("Pick day in birthday day combobox")]
        public void PickBirthdayDay()
        {
            int day = random.Next(1, 31);
            var cbxBirthDays = _driver.FindElement(By.Id("days"));
            var selectElementBirthDays = new SelectElement(cbxBirthDays);
            selectElementBirthDays.SelectByValue(day.ToString());
        }

        [Step("Pick month in birthday month combobox")]
        public void PickBirthdayMonth()
        {
            int month = random.Next(1, 13);
            var cbxBirthMonth = _driver.FindElement(By.Id("months"));
            var selectElementBirthMonth = new SelectElement(cbxBirthMonth);
            selectElementBirthMonth.SelectByValue(month.ToString());
        }

        [Step("Pick year in birthday year combobox")]
        public void PickBirthdayYear()
        {
            int year = random.Next(1900, 2020);
            var cbxBirthYear = _driver.FindElement(By.Id("years"));
            var selectElementBirthYear = new SelectElement(cbxBirthYear);
            selectElementBirthYear.SelectByValue(year.ToString());
        }

        [Step("Check Sign up for our newsletter! and Receive special offers from our partners!")]
        public void CheckNewsletterandSpecialOffers()
        {
            _driver.FindElement(By.Id("newsletter")).Click();
            _driver.FindElement(By.Id("optin")).Click();
        }

        [Step("Fill Company name in company field")]
        public void FillCompanyName()
        {
            string company = RandomGenerate(10).ToString();
            _driver.FindElement(By.Id("company")).Clear();
            _driver.FindElement(By.Id("company")).SendKeys(company);
        }

        [Step("Fill first address in Address1 field")]
        public void FillFirstAddress()
        {
            string address1 = RandomGenerate(10).ToString();
            _driver.FindElement(By.Id("address1")).Clear();
            _driver.FindElement(By.Id("address1")).SendKeys(address1);
        }

        [Step("Fill second address in Address2 field")]
        public void FillSecondAddress()
        {
            string address2 = RandomGenerate(10).ToString();
            _driver.FindElement(By.Id("address2")).Clear();
            _driver.FindElement(By.Id("address2")).SendKeys(address2);
        }

        [Step("Fill city in City field")]
        public void FillCity()
        {
            string city = RandomGenerate(10).ToString();
            _driver.FindElement(By.Id("city")).Clear();
            _driver.FindElement(By.Id("city")).SendKeys(city);
        }

        [Step("Pick state in state combobox")]
        public void PickState()
        {
            int state = random.Next(1, 51);
            var cbxState = _driver.FindElement(By.Id("id_state"));
            var selectElementState = new SelectElement(cbxState);
            selectElementState.SelectByValue(state.ToString());
        }

        [Step("Fill post code in postcode field")]
        public void FillPostCode()
        {
            _driver.FindElement(By.Id("postcode")).Clear();
            _driver.FindElement(By.Id("postcode")).SendKeys(RandomGenerateNumber(5));
        }

        [Step("Pick country in country combobox")]
        public void PickCountry()
        {
            var cbxCountry = _driver.FindElement(By.Id("id_country"));
            var selectElementCountry = new SelectElement(cbxCountry);
            selectElementCountry.SelectByText("United States");
        }

        [Step("Fill additional information in other field")]
        public void FillAdditionalInformation()
        {
            string additional = RandomGenerate(10).ToString();
            _driver.FindElement(By.Id("other")).Clear();
            _driver.FindElement(By.Id("other")).SendKeys(additional);
        }

        [Step("Fill phone in phone field")]
        public void FillPhone()
        {
            string phone = "+" + RandomGenerateNumber(2).ToString() + " " + RandomGenerateNumber(9).ToString();
            _driver.FindElement(By.Id("phone")).Clear();
            _driver.FindElement(By.Id("phone")).SendKeys(phone);
        }

        [Step("Fill mobile phone in mobile phone field")]
        public void FillMobilePhone()
        {
            string mphone = "+" + RandomGenerateNumber(2).ToString() + " " + RandomGenerateNumber(9).ToString();
            _driver.FindElement(By.Id("phone_mobile")).Clear();
            _driver.FindElement(By.Id("phone_mobile")).SendKeys(mphone);
        }

        [Step("Fill Address in alias field")]
        public void FillAddress()
        {
            string address = RandomGenerate(10).ToString();
            _driver.FindElement(By.Id("alias")).Clear();
            _driver.FindElement(By.Id("alias")).SendKeys(address);
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
