using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace AutoTest
{
    class Test
    {
        IWebDriver webDriver;

        [SetUp]
        public void StartBrowser()
        {
            webDriver = new FirefoxDriver();
        }

        [Test]
        public void Testing()
        {
            webDriver.Url = "http://the-internet.herokuapp.com/add_remove_elements/";
        }

        [Test]
        public void IsAdded()
        {
            webDriver.Url = "http://the-internet.herokuapp.com/add_remove_elements/";

            for (int i = 0; i < 2; ++i)
            {
                Thread.Sleep(1000); // Задержка перед повторным нажатием.
                webDriver.FindElement(By.XPath("/html/body/div[2]/div/div/button")).Click();
            }

            var count = webDriver.FindElements(By.ClassName("added-manually")).Count;
            Assert.IsTrue(count == 2);
        }

        [Test]
        public void IsDeleted()
        {
            webDriver.Url = "http://the-internet.herokuapp.com/add_remove_elements/";
            // Добавляем 2 кнопки "Delete"
            for (int i = 0; i < 2; ++i)
            {
                Thread.Sleep(1000); // Задержка перед повторным нажатием.
                webDriver.FindElement(By.XPath("/html/body/div[2]/div/div/button")).Click();
            }
            // Удаляем 2 добавленные кнопки Delete.
            for (int i = 0; i < 2; ++i)
            {
                Thread.Sleep(1000);
                webDriver.FindElement(By.XPath("/html/body/div[2]/div/div/div/button")).Click();
            }

            var count = webDriver.FindElements(By.ClassName("added-manually")).Count;
            Assert.IsTrue(count == 0);
        }

        [TearDown]
        public void CloseBrowser()
        {
            webDriver.Close();
        }
    }
}

