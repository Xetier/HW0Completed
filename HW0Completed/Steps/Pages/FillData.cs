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

namespace HW0Completed.Steps.Pages
{
    class FillData
    {

        public static readonly Random random = new Random();
        public string firstName = RandomGenerate(10).ToString();
        public string lastName = RandomGenerate(10).ToString();

        public IWebDriver _driver = Hooks.WebDriver;


        [Step("Click on Mr")]
        public void ClickOnMr()
        {
            try
            {
                int id_gender = random.Next(1, 3);
                _driver.FindElementBy("Id", "uniform-id_gender" + id_gender.ToString()).Click();
                _driver.SaveScreenShot();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex.Message);
            }
            
        }

        [Step("Fill first name in customer_firstname field")]
        public void FillFirstName()
        {
            SendDataString("Id", "customer_firstname", firstName);
            Log.Information("firstName: " + firstName);
        }

        [Step("Fill last name in customer_lastname field")]
        public void FillLastName()
        {
            SendDataString("Id", "customer_lastname", lastName);
            Log.Information("lastName: " + lastName);
        }

        [Step("Fill password in passwd field")]
        public void FillPassword()
        {
            string password = RandomGeneratePass(10).ToString();
            SendDataString("Id", "passwd", password);
            Log.Information("password: " + password);
        }

        [Step("Pick day in birthday day combobox")]
        public void PickBirthdayDay()
        {
            int day = random.Next(1, 31);
            SendDataCmbx("Id", "days", day.ToString());
            Log.Information("BirthdayDay: " + day.ToString());
        }

        [Step("Pick month in birthday month combobox")]
        public void PickBirthdayMonth()
        {
            int month = random.Next(1, 13);
            SendDataCmbx("Id", "months", month.ToString());
            Log.Information("BirthdayMonth: " + month.ToString());
        }

        [Step("Pick year in birthday year combobox")]
        public void PickBirthdayYear()
        {
            int year = random.Next(1900, 2020);
            SendDataCmbx("Id", "years", year.ToString());
            Log.Information("BirthdayYear: " + year.ToString());
        }

        [Step("Check Sign up for our newsletter! and Receive special offers from our partners!")]
        public void CheckNewsletterandSpecialOffers()
        {
            _driver.FindElementBy("Id", "newsletter").Click();
            _driver.FindElementBy("Id", "optin").Click();
        }

        [Step("Fill Company name in company field")]
        public void FillCompanyName()
        {
            string company = RandomGenerate(10).ToString();
            SendDataString("Id", "company", company);
            Log.Information("CompanyName: " + company);
        }

        [Step("Fill first address in Address1 field")]
        public void FillFirstAddress()
        {
            string address1 = RandomGenerate(10).ToString();
            SendDataString("Id", "address1", address1);
            Log.Information("address1: " + address1);
        }

        [Step("Fill second address in Address2 field")]
        public void FillSecondAddress()
        {
            string address2 = RandomGenerate(10).ToString();
            SendDataString("Id", "address2", address2);
            Log.Information("address2: " + address2);
        }

        [Step("Fill city in City field")]
        public void FillCity()
        {
            string city = RandomGenerate(10).ToString();
            SendDataString("Id", "city", city);
            Log.Information("city: " + city);
        }

        [Step("Pick state in state combobox")]
        public void PickState()
        {
            int state = random.Next(1, 51);
            SendDataCmbx("Id", "id_state", state.ToString());
            Log.Information("State: " + state.ToString());
        }

        [Step("Fill post code in postcode field")]
        public void FillPostCode()
        {
            string randPostCode = RandomGenerateNumber(5);
            SendDataString("Id", "postcode", randPostCode);
            Log.Information("PostCode: " + randPostCode);
        }

        [Step("Pick country in country combobox")]
        public void PickCountry()
        {
            SendDataCmbx("Id", "id_country", "United States");
            Log.Information("Country: " + "United States");
        }

        [Step("Fill additional information in other field")]
        public void FillAdditionalInformation()
        {
            string additional = RandomGenerate(10).ToString();
            SendDataString("Id", "other", additional);
            Log.Information("Additional: " + additional);
        }

        [Step("Fill phone in phone field")]
        public void FillPhone()
        {
            string phone = "+" + RandomGenerateNumber(2).ToString() + " " + RandomGenerateNumber(9).ToString();
            SendDataString("Id", "phone", phone);
        }

        [Step("Fill mobile phone in mobile phone field")]
        public void FillMobilePhone()
        {
            string mphone = "+" + RandomGenerateNumber(2).ToString() + " " + RandomGenerateNumber(9).ToString();
            SendDataString("Id", "phone_mobile", mphone);
        }

        [Step("Fill Address in alias field")]
        public void FillAddress()
        {
            string address = RandomGenerate(10).ToString();
            SendDataString("Id", "alias", address);
        }

        [Step("Check Proper username is shown in the header")]
        public void CheckProperUsername()
        {
            string expectedT = firstName + " " + lastName;
            _driver.FindElementBy("Class", "account").Text.Should().Be(expectedT); 
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

        public static void SendDataString(string type, string selectorValue, string data)
        {
            IWebDriver _driver = Hooks.WebDriver;

            var element = _driver.FindElementBy(type, selectorValue);
            element.Clear();
            element.SendKeys(data);
        }

        public static void SendDataCmbx(string type, string selectorValue, string data)
        {
            IWebDriver _driver = Hooks.WebDriver;
            var cbx = _driver.FindElementBy(type, selectorValue);
            var selectElementState = new SelectElement(cbx);
            selectElementState.SelectByValue(data);
        }
    }
}
