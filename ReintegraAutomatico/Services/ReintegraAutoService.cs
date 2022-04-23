using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReintegrationSelf.Services
{
    class ReintegraAutoService
    {

        ChromeDriver driver = new ChromeDriver();

        public bool GoToScremLogin()
        {
            try
            {
                string url = "http://localhost:49915/";
                driver.Navigate().GoToUrl(url);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool CheckScreamLogin()
        {
            try
            {
                driver.FindElement(By.Id("UserName"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void LogaAuto(string login, string password)
        {
            bool scremLogin = CheckScreamLogin();

            if (scremLogin == true)
            {
                var fieldLogin = driver.FindElement(By.Id("UserName"));
                var fieldSenha = driver.FindElement(By.Id("Password"));
                var loginButton = driver.FindElement(By.CssSelector("#login-box > div > div.widget-main > form > fieldset > div.clearfix > input"));

                fieldLogin.SendKeys(login);
                fieldSenha.SendKeys(password);
                loginButton.Click();
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("ATENÇÃO");
                Console.WriteLine("Você não esta na tela de login, reinicie o programa");
                Console.WriteLine("--------------------------------------------");
            }
        }

        public void GoToReintegrationScrem()
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);
            string url = "http://localhost:49915/Reintegracao";
            driver.Navigate().GoToUrl(url);
        }

        public void ReintegraAuto()
        {
            //var abaReintegra = driver.FindElement(By.CssSelector("#sidebar > ul > li.open > ul > li > ul > li.open > ul > li:nth-child(1) > a"));
            //abaReintegra.Click();
            string results = "#_reintegracaoresult > div > div.row-fluid";
            
            int count = 0;

            while (count < 30)
            {
                if (!ElementExist(results))
                {
                    count = 0;
                    var reintegraButton = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div[1]/div[2]/div/div/div/div/div/label/form/button"));
                    reintegraButton.Click();
                    Thread.Sleep(20000);
                    driver.Navigate().Refresh();
                }
                else
                {
                    Thread.Sleep(6000);
                    driver.Navigate().Refresh();
                    count = count + 1;
                }
            }
        }

        public bool ElementExist(string cssElement)
        {
            try
            {
                driver.FindElement(By.CssSelector(cssElement));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void CloseWindowns()
        {
            driver.Close();
        }
    }
}
