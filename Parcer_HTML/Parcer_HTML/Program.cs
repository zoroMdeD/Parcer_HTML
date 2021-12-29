using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using LinqToExcel;

namespace Parcer_HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Кер. ЧИП Конд. 0.01 мкф X7R 50В 10% 0603, Конденсатор керамический SMD";

            ChromeDriverService chromeservice = ChromeDriverService.CreateDefaultService();            
            ChromeOptions options = new ChromeOptions();

            chromeservice.HideCommandPromptWindow = true;    //Спрятать консоль
            //options.AddArguments("--headless");     //Делаем окно браузера невидимым
            IWebDriver driver = new ChromeDriver(chromeservice, options);     //Передаем флаг в браузер


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));    //Инициализация задержки в 3 секунды

            driver.Url = @"https://www.chipdip.ru/";
        
            driver.FindElement(By.XPath(@".//input[@name='searchtext']")).SendKeys(str);  //AD5516ABCZ-1     STM32F103C8T6
            driver.FindElement(By.XPath(@".//button[@class='btn-reset header__button header__search-button']")).Click();
            Delay();
        
            try
            {
                //driver.FindElement(By.XPath($@".//main/tbody/tr[2]/td/div/a[@class='link']")).Click();  //img[@title='{str}']
                driver.FindElement(By.XPath(@".//a[@class='link']/b")).Click();     //Очень не точно!!! нужно оптимизировать
                Delay();
            }
            catch (Exception)
            {
                Console.WriteLine("miss");
            }
        
            var links1 = driver.FindElements(By.XPath(@".//div[@class='product_main-ids ptext']/div[@class='product_main-id'][1]/span[2]"));   //@".//table[@id='product-attributes']/tbody/tr[@class='MuiTableRow-root']"        @".//li[@class='MuiBreadcrumbs-li']/a"
            foreach (IWebElement link in links1)
            {
                Console.WriteLine(link.Text);
            }
            var links2 = driver.FindElements(By.XPath(@".//div[@class='product_main-ids ptext']/div[@class='product_main-id'][3]/span[@itemprop='mpn']"));   //@".//table[@id='product-attributes']/tbody/tr[@class='MuiTableRow-root']"        @".//li[@class='MuiBreadcrumbs-li']/a"
            foreach (IWebElement link in links2)
            {
                Console.WriteLine(link.Text);
            }
            Console.ReadLine();
        }
        static void Delay(int mils = 500)
        {
            Thread.Sleep(mils);
        }
    }
}
