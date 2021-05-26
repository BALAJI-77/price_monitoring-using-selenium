
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace seleniumTest
{
    class Program
    {
        static void Main(String[] args)
        {
            var options = new FirefoxOptions();
            //options.AddArguments("-headless");
            IWebDriver driver = new ChromeDriver(@"C:\Users\Balaji");
            //var driver = new FirefoxDriver(options);
            //var driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.olx.in/");
            Thread.Sleep(2000);
            var searchbtn = driver.FindElement(By.XPath("/html/body/div/div/header/div/div/div[2]/div/div/div[2]/div/form/fieldset/div/input"));
            searchbtn.SendKeys("honda car 2010" + Keys.Enter);
            Thread.Sleep(2000);
            while (true)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                    IWebElement aBtn = wait.Until(e => e.FindElement(By.ClassName("JbJAl")));
                    aBtn.Click();
                }
                catch
                {
                    break;
                }
                finally
                {
                    Console.WriteLine("success");
                }
            }
            var titles = driver.FindElements(By.XPath("/html/body/div/div/main/div/div/section/div/div/div[4]/div[2]/div/div[2]/ul/li/a/div/span[3]"));
            var prices = driver.FindElements(By.XPath("/html/body/div/div/main/div/div/section/div/div/div[4]/div[2]/div/div[2]/ul/li/a/div/span[1]"));
            var Kilometers = driver.FindElements(By.XPath("/html/body/div/div/main/div/div/section/div/div/div[4]/div[2]/div/div[2]/ul/li/a/div/span[2]"));
            for (int i = 0; i < titles.Count; i++)
            {
                Console.WriteLine((i + ". " + titles[i].Text) + "  =  " + (prices[i].Text) + "=" + " Kilometers : " + Kilometers[i].Text);

            }


            List<String> productprices = new List<String>();
            foreach (IWebElement prices22 in prices)
            {
                productprices.Add(prices22.Text);
            }
            List<String> sortedProductNames = new List<String>(productprices);
            sortedProductNames.Sort();
            

            /*List<String> highest = new List<String>(productprices);
            highest.Sort();
            highest.Reverse();*/
            Console.WriteLine(" ============================================ ");
            Console.WriteLine(" ============================================ ");
            Console.WriteLine(" THE LOWEST PRICES=" + sortedProductNames[0]);
            Console.WriteLine(" THE HIGHEST PRICES=" + sortedProductNames[sortedProductNames.Count - 1]);
            //Console.WriteLine(" THE HIGHEST PRICES="+highest[0]);


            List<IWebElement> Kilometer22 = driver.FindElements(By.XPath("/html/body/div/div/main/div/div/section/div/div/div[4]/div[2]/div/div[2]/ul/li/a/div/span[2]")).ToList();
            List<String> kilometer33 = new List<String>();
            foreach (IWebElement li1 in Kilometer22)
            {
                string s = li1.Text.Remove(0,7);
                string c = s.Replace("km", "");
                string d = c.Replace(",", "");
                kilometer33.Add(d);
            }
            List<String> averagekm = new List<String>();
            int sum = 0;
            for (int x = 0; x < kilometer33.Count; x++)
            {
                //var b = Convert.ToInt32(kilometer33[x]);
                int b = Convert.ToInt32(kilometer33[x]);
                var n=sum += b;
                string o = Convert.ToString(n);
                averagekm.Add(o);
                Console.Write("," + o);
               
            }
            Console.Write("THE AVERAGE:" + averagekm[averagekm.Count-1]);
        }

    }
}

