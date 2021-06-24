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
            IWebDriver driver = new ChromeDriver();
            driver.Url = @"http://digikey.com";
            Delay();

            driver.FindElement(By.XPath(@".//div[@class='searchbox-inner-searchtext']/input[@name='keywords']")).SendKeys("STM32F103C8T6");  //AD5516ABCZ-1     STM32F103C8T6
            driver.FindElement(By.XPath(@".//div[@class='searchbox-inner-searchbutton']/button[@class='search-button']")).Click();
            Delay();

            try
            {
                driver.FindElement(By.XPath(@".//img[@title='STM32F103C8T6']")).Click();
                Delay();
            }
            catch (Exception e)
            {
                Console.WriteLine("miss");
            }

            var links = driver.FindElements(By.XPath(@".//li[@class='MuiBreadcrumbs-li']/a"));   //@".//table[@id='product-attributes']/tbody/tr[@class='MuiTableRow-root']"
            foreach (IWebElement link in links)
            {
                Console.WriteLine(link.Text);
            }
        }
        static void Delay(int mils = 3000)
        {
            Thread.Sleep(mils);
        }
    }
}
