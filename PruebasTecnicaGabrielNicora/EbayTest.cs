using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;


namespace PruebasTecnicaGabrielNicora
{
    class EbayTest
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver("C:\\Users\\gnico\\.nuget\\packages\\selenium.webdriver.chromedriver\\2.45.0\\driver\\win32");
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.ebay.com";
            Thread.Sleep(500);
        }

        [Test]
        public void test()
        {
            IWebElement searchText = driver.FindElement(By.Id("gh-ac"));
            IWebElement searchButton = driver.FindElement(By.Id("gh-btn"));
            searchText.SendKeys("Shoes");
            searchButton.Click();
            Thread.Sleep(500);

            /* Valido existencia de selector de MARCA */

            List<IWebElement> elementList = new List<IWebElement>();
            elementList.AddRange(driver.FindElements(By.Id("w3-w0-w2-w2-0[0]")));
                        
            if (elementList.Count > 0)
            {
                elementList[0].Click();    
            }
            else
            {
                IWebElement brandText = driver.FindElement(By.Id("e1-40"));
                brandText.Click();
            }
            /* Fin validacion MARCA*/
             
            /*Seleccion marca PUMA*/

            IWebElement pumaCheck = driver.FindElement(By.CssSelector("input[aria-label=PUMA]"));
            pumaCheck.Click();

            /*Seleccion talle 10 valido existencia de ID*/

            List<IWebElement> sizeList = new List<IWebElement>();
            sizeList.AddRange(driver.FindElements(By.Id("w3-w0-w2-multiselect[3]")));

            if (sizeList.Count > 0)
            {
                sizeList[0].Click();
            }
            else
            {
                IWebElement sizeShoes = driver.FindElement(By.Id("e1-29"));
                sizeShoes.Click();
            }

            /*Imprimo resultado de la busqueda con filtros*/
            

            List<IWebElement> countList = new List<IWebElement>();
            countList.AddRange(driver.FindElements(By.ClassName("srp-controls__count-heading")));

            if (countList.Count > 0)
            {
               var cantResultados = countList[0].Text;
                System.Console.WriteLine("Se encontraron: " + cantResultados);
            }
            else
            {
                IWebElement countElement = driver.FindElement(By.ClassName("rcnt"));
                var cantResultados = countElement.Text;
                System.Console.WriteLine("Se encontraron: " + cantResultados +  " resultados");
            }

            /*Ordeno por precio ascendente valido la existencia del element correcto*/

            List<IWebElement> dropDList = new List<IWebElement>();
            dropDList.AddRange(driver.FindElements(By.CssSelector("div.srp-controls--selected-value")));
            if (dropDList.Count > 0)
            {
                dropDList[0].Click();
                dropDList[0].Click();                
                IWebElement orberByPriceA = driver.FindElement(By.XPath("//*[@id='w4-w1']/div/div/ul/li[4]/a/span"));
                orberByPriceA.Click();
            }
            else
            {
                IWebElement orderList = driver.FindElement(By.XPath("//*[@id='DashSortByContainer']/ul[1]/li/div/a"));
                orderList.Click();
                orderList.Click();
                IWebElement orberByPriceA = driver.FindElement(By.XPath("//*[@id='SortMenu']/li[3]/a"));
                orberByPriceA.Click();
            }

            /*Print de los 5 primeros items con su respectivo precio*/

            List<IWebElement> topList = new List<IWebElement>();
            topList.AddRange(driver.FindElements(By.XPath("//*[@id='GalleryViewInner']/li/div/div[3]/div[2]/div/span[1]/span")));
            
            if (topList.Count == 0)
            {
                topList.AddRange(driver.FindElements(By.XPath("//*[@id='srp-river-results']/ul/li/div/div[2]/div[3]/div[1]/span")));
            }

        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
