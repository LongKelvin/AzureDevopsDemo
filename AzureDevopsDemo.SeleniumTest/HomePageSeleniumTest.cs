using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace AzureDevopsDemo.SeleniumTest
{
    [TestFixture("Chrome")]
    [TestFixture("Firefox")]
    [TestFixture("Edge")]
    public class HomePageSeleniumTest
    {
        private IWebDriver driver;
        private string browser;
        private string SITE_URL = "https://azuredevops-test-env.azurewebsites.net/";

        public HomePageSeleniumTest(string browser)
        {

            this.browser = browser;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            // Create the driver for the current browser.
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    throw new ArgumentException($"'{browser}': Unknown browser");
            }
        }

        [TestCase("btnShowModal", "welcomeModal")]
        public void ClickLinkById_ShouldDisplayModalById(string linkId, string modalId)
        {
            if (driver == null) throw new ArgumentNullException("The driver for selenium test not found exception");

            driver.Navigate().GoToUrl(SITE_URL);

            driver.FindElement(By.Id(linkId)).Click();
            var modalById = driver.FindElement(By.Id(modalId));

            var modal = driver.FindElement(By.Id(modalId));
            bool modalIsDisplay = modal != null;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            if (modalIsDisplay)
            {

                IWebElement closeElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("close")));
                closeElement.Click();
                driver.FindElement(By.TagName("body"));
            }
            else
            {
                Trace.TraceError("modal not display");
            }

            Assert.That(modalIsDisplay, Is.True);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}