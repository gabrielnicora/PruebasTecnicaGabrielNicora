using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasTecnicaGabrielNicora
{
    class EbayTest
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver("C:\\Users\\gnico\\.nuget\\packages\\selenium.webdriver.chromedriver\\2.45.0\\driver\\win32");
        }

        [Test]
        public void test()
        {
            driver.Url = "http://www.ebay.com";
            IWebElement searchText = driver.FindElement(By.Id("gh-ac"));
            IWebElement searchButton = driver.FindElement(By.Id("gh-btn"));
            searchText.SendKeys("Shoes");
            searchButton.Click();
            IWebElement brandText = driver.FindElement(By.Id("w3-w0-w2-w2-0[0]"));
            brandText.SendKeys("Puma");
            IWebElement pumaCheck = driver.FindElement(By.Id("e1-54"));
            pumaCheck.Click();
        }

        [TearDown]
        public void CloseBrowser()
        {

        }
    }
}
