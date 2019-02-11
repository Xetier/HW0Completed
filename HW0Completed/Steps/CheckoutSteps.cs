using Cignium.Contrib.GaugeSelenium;
using Cignium.Contrib.GaugeSelenium.Impl;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW0Completed.Steps
{
    class CheckoutSteps
    {
        public IWebDriver _driver = Hooks.WebDriver;

        [Step("Click Women button in the header")]
        public void ClickWomenButton()
        {
            _driver.FindElement(By.CssSelector("[href*='http://automationpractice.com/index.php?id_category=3&controller=category']")).Click();
        }

        [Step("Click the product with name Faded Short Sleeve T-shirts")]
        public void ClickProductT_shirts()
        {
            _driver.FindElementBy("XPath", "(//a[@title='Faded Short Sleeve T-shirts'])[2]").Click();
        }

        [Step("Click Add to card")]
        public void ClickAddToCard()
        {
            _driver.FindElementBy("Id", "add_to_cart").Click();
        }

        [Step("Click Proceed to checkout0")]
        public void ClickProceedToCheckout0()
        {
            _driver.FindElementBy("XPath", "(//a[@title='Proceed to checkout'])").Click();
        }

        [Step("Click Proceed to checkout1")]
        public void ClickProceedToCheckout1()
        {
            _driver.FindElementBy("XPath", "(//a[@title='Proceed to checkout'])[2]").Click();
        }

        [Step("Click Proceed to checkout2")]
        public void ClickProceedToCheckout2()
        {
            _driver.FindElementBy("XPath", "//*[@id='center_column']/form/p/button/span").Click();
        }

        [Step("Click by Terms of service to agree")]
        public void ClickByTSA()
        {
            _driver.SaveScreenShot();
            _driver.FindElementBy("Id", "uniform-cgv").Click();
            _driver.SaveScreenShot();
        }

        [Step("Click Proceed to checkout3")]
        public void ClickProceedToCheckout3()
        {
            _driver.FindElementBy("XPath", "//*[@id='form']/p/button").Click();
        }

        [Step("Click by payment method Pay by bank wire")]
        public void ClickPaymentMethodBankWire()
        {
            _driver.FindElementBy("Class", "bankwire").Click();
        }

        [Step("Click I confirm my order")]
        public void ClickConfirmOrder()
        {
            _driver.FindElementBy("XPath", "//*[@id='cart_navigation']/button/span").Click();
        }

        [Step("Check Order confirmation page contains <urlSubString>")]
        public void CheckOrderConfirmation(string urlSubString)
        {
            _driver.Url.Should().Contain(urlSubString);
        }

        [Step("Check The order is <status>")]
        public void CheckTheOrderComplete(string status)
        {
            _driver.FindElementBy("Class", "cheque-indent").Text.Should().Contain(status);
        }

        [Step("Check Current page is the last step of ordering")]
        public void CheckCurrentPageIsTheLastStep()
        {
            var color = _driver.FindElementBy("Id", "step_end").GetCssValue("background");
            color.ToString().Should().Contain("rgb(67, 171, 84)");
        }
    }
}
