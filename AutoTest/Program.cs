﻿using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace AutoTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Создаём и запускаем Веб-Драйвер по адресу URL.
            IWebDriver webDriver = new FirefoxDriver();
            webDriver.Url = "http://the-internet.herokuapp.com/add_remove_elements/";

            // Задержка для полной загрузки страницы.
            Thread.Sleep(1000);

            // 2 разa нажимаем кнопку "Add Element".
            for (int i = 0; i < 2; ++i)
            {
                Thread.Sleep(1000); // Задержка перед повторным нажатием.
                webDriver.FindElement(By.XPath("//button[contains(text(), \"Add Element\")]")).Click();
            }

            // Подсчёт количества элементов в Классе.
            var count = webDriver.FindElements(By.XPath("//button[contains(text(), \"Delete\")]")).Count;

            // Удаляем ВСЕ добавленные кнопки Delete.
            for (int i = 0; i < count; ++i)
            {
                Thread.Sleep(1000);
                webDriver.FindElement(By.XPath("//button[contains(text(), \"Delete\")]")).Click();
            }

            // Повторно проверяем количество элементов в Классе.
            count = webDriver.FindElements(By.XPath("//button[contains(text(), \"Delete\")]")).Count;

            Thread.Sleep(1000);

            // Закрываем Веб-Драйвер.
            webDriver.Close();
        }
    }
}
