
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
        private static void greenMessage(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void Redmessage(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void cyanmessage(string Message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Main(String[] args)
        {
            //var options = new FirefoxOptions();
            //var options = new ChromeOptions();
            //options.AddArguments("--ignore-certificate-errors", "enable-precise-memory-info");
            //IWebDriver driver = new ChromeDriver(@"C:\Users\Balaji");
            IWebDriver driver = new ChromeDriver(@"C:\Users\Balaji");
            //var driver = new FirefoxDriver(options);
            //var driver = new FirefoxDriver();
            //driver.Manage().Window.Maximize();
            driver.Manage().Window.Minimize();
            driver.Navigate().GoToUrl("https://www.olx.in/");
            Thread.Sleep(1000);
            var searchbtn = driver.FindElement(By.XPath("/html/body/div/div/header/div/div/div[2]/div/div/div[2]/div/form/fieldset/div/input"));
            Thread.Sleep(3000);
            Console.Clear();
            Console.Write("ENTER CAR NAME: ");
            var car_name = Console.ReadLine();
            Console.Write("ENTER YEAR: ");
            var year = Console.ReadLine();
            Thread.Sleep(2000);
            //searchbtn.SendKeys("swift car 2010" + Keys.Enter);
            searchbtn.SendKeys(car_name + " " + year + Keys.Enter);
            Thread.Sleep(3000);

            while (true)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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
            Console.Clear();
            List<int> productprices = new List<int>();
            Console.ForegroundColor = ConsoleColor.Green;
            var textToEnter="We're counting our blessings and that means customers like you";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0,-5} {1,-72} {2,-12} {3,-20}", "S.NO", "     TITLES     ", " PRICES ", "KILOMETERS");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < titles.Count; i++)
            {
                if (Kilometers[i].Text.Contains(" km"))
                {
                    Console.WriteLine("{0,-5} {1,-72} {2,-12} {3,-20}", (i + "."), (titles[i].Text), (prices[i].Text), (Kilometers[i].Text));
                    string n = prices[i].Text.Remove(0, 1);
                    string s = n.Replace(",", "");
                    int v = Convert.ToInt32(s);
                    productprices.Add(v);
                }
            }

            List<int> sortedProductNames = new List<int>(productprices);
            sortedProductNames.Sort();
            List<String> kilometer33 = new List<String>();

            foreach (IWebElement li1 in Kilometers)
            {
                if (li1.Text.Contains(" km"))
                {
                    string c = li1.Text.Replace("km", "");
                    string d = c.Replace(",", "");
                    string result = string.Join(" ", d.Split().Skip(1));
                    string u = result.Replace("- ", "");
                    kilometer33.Add(u);
                }
            }

            List<String> averagekm = new List<String>();
            int sum = 0;
            for (int x = 0; x < kilometer33.Count; x++)
            {
                int b = Convert.ToInt32(kilometer33[x]);
                var n = sum += b;
                averagekm.Add("," + n);
            }

            var averagevalue = (averagekm[averagekm.Count - 1]);
            var e = averagevalue.Replace(",", "");
            int p = Convert.ToInt32(e);
            int val = averagekm.Count();
            Convert.ToInt32(val);
            int m = (p / val);

            Redmessage(" MINIMUM PRICE= RS " + (String.Format("{0:n0}", sortedProductNames[0])));
            greenMessage(" MAXIMUM PRICE= RS " + (String.Format("{0:n0}", sortedProductNames[sortedProductNames.Count - 1])));
            cyanmessage(" AVERAGE KM: " + (String.Format("{0:n0}", m)));
            Console.WriteLine(" TOTAL COUNT: " + val);

            driver.Quit();
        }
    }
}
