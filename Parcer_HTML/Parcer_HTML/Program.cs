using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Parcer_HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "STM32F103C8T6";

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");     //Делаем окно браузера невидимым

            IWebDriver driver = new ChromeDriver(options);     //Передаем флаг в браузер
            driver.Url = @"http://digikey.com";
            Delay();

            driver.FindElement(By.XPath(@".//div[@class='searchbox-inner-searchtext']/input[@name='keywords']")).SendKeys(str);  //AD5516ABCZ-1     STM32F103C8T6
            driver.FindElement(By.XPath(@".//div[@class='searchbox-inner-searchbutton']/button[@class='search-button']")).Click();
            Delay();

            try
            {
                driver.FindElement(By.XPath($@".//img[@title='{str}']")).Click();
                Delay();
            }
            catch (Exception)
            {
                Console.WriteLine("miss");
            }

            var links = driver.FindElements(By.XPath(@".//table[@id='product-attributes']/tbody/tr[1]"));   //@".//table[@id='product-attributes']/tbody/tr[@class='MuiTableRow-root']"        @".//li[@class='MuiBreadcrumbs-li']/a"
            foreach (IWebElement link in links)
            {
                Console.WriteLine(link.Text);
            }
        }
        static void Delay(int mils = 1000)
        {
            Thread.Sleep(mils);
        }
    }
}
