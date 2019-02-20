using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;


namespace SeleniumTemplate
{
    [Binding]
    public class StepDefinition
    {
        private PageObject _pageObject;
        public PageObject PageObject => _pageObject ?? (_pageObject = new PageObject());
        public static IWebDriver Driver;
        public class Browser

        {
            public IWebDriver Chrome;

            public Browser()
            {
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                Chrome = new ChromeDriver(options);
            }
        }

        public StepDefinition(Browser browser)
        {
            Driver = browser.Chrome;
            PageFactory.InitElements(Driver, PageObject);
        }

        [Given(@"I navigate to claims")]
        public void GivenINavigateToClaims()
        {
            Driver.Url = "https://claim.skycop.com";
        }

        [Then(@"I set Kaunas as departure airport")]
        public void ThenISetKaunasAsDepartureAirport()
        {
            Thread.Sleep(2000);
            PageObject.departureAirportField.SendKeys(Constants.departureAirportField);
            Thread.Sleep(2000);
            PageObject.kaunasSelection.Click();
        }
        [Then(@"I set London Gatwick as arrival airport")]
        public void ThenISetLondonGatwickAsArrivalAirport()
        {
            Thread.Sleep(2000);
            var arriveAirportField = Driver.FindElement(By.XPath("(//Input[@class='Select-input'])[2]"));
            arriveAirportField.SendKeys("London");
            Thread.Sleep(2000);
            var londonSelection = Driver.FindElement(By.XPath("//div[@title='London Gatwick Airport']"));
            londonSelection.Click();
        }
        [Then(@"I select Ryanair Airlines")]
        public void ThenISelectRyanairAirlines()
        {
            Thread.Sleep(2000);
            var airlinesField = Driver.FindElement(By.XPath("(//Input[@class='Select-input'])[3]"));
            airlinesField.SendKeys("Ryanair");
            Thread.Sleep(2000);
            var airlinesSelection = Driver.FindElement(By.XPath("//div[@title='Ryanair Sun']"));
            airlinesSelection.Click();
        }
        [Then(@"I Choose flight number")]
        public void ThenIChooseFlightNumber()
        {
            Thread.Sleep(2000);
            var flightNumber = Driver.FindElement(By.XPath("//Input[@class='form-control js-flightDigits js-checkable data-hj-whitelist sc-kkGfuU eUxbsH']"));
            flightNumber.SendKeys("154");
        }
        [Then(@"I choose the flight date")]
        public void ThenIChooseTheFlightDate()
        {
            Thread.Sleep(2000);
            var failedFlightDate = Driver.FindElement(By.XPath("//Input[@class='form-control form-control--datepicker js-datepicker js-checkable bg-white needsclick data-hj-whitelist']"));
            failedFlightDate.Click();
        }
        [Then(@"I choose the flight date (.*)")]
        public void ThenIChooseTheFlightDate(int p0)
        {
            var failedFlightDate = Driver.FindElement(By.XPath("//td[@data-value='18']"));
            failedFlightDate.Click();
        }
        [Then(@"I choose Flight delayed")]
        public void ThenIChooseFlightDelayed()
        {
            var Flightdelayed = Driver.FindElement(By.XPath("//label[@class='mobile-mb-15 js-checkable sc-eqIVtm buildE']"));
            Flightdelayed.Click();
        }
        [Then(@"I choose more then (.*) hours")]
        public void ThenIChooseMoreThenHours(int p0)
        {
            Thread.Sleep(2000);
            var reason2 = Driver.FindElement(By.XPath("(//label[@class='mobile-mb-15 js-checkable sc-eqIVtm buildE'])[5]"));
            reason2.Click();
        }
        [Then(@"I choose reason Strike")]
        public void ThenIChooseReasonStrike()
        {
            Thread.Sleep(2000);
            var reason4 = Driver.FindElement(By.XPath("//span[@id='react-select-6--value']"));
            reason4.Click();
            Thread.Sleep(2000);
            var reason5 = Driver.FindElement(By.XPath("//div[text()='Strike']"));
            reason5.Click();
        }










    }
}