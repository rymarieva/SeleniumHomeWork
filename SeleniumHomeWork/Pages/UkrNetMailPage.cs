using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

namespace SeleniumHomeWork.Pages
{
    class UkrNetMailPage : BasePage
    {
        public string massegeFrameId = "mce_0_ifr";


        [FindsBy(How = How.CssSelector, Using = "button.default.compose")]
        public IWebElement writeLetterButton;

        [FindsBy(How = How.CssSelector, Using = "input[name = 'toFieldInput']")]
        public IWebElement sendToField;

        [FindsBy(How = How.CssSelector, Using = "input[name='subject']")]
        public IWebElement subjectField;

        [FindsBy(How = How.CssSelector, Using = "#file-to-upload")]
        public IWebElement fileInputField;

        [FindsBy(How = How.CssSelector, Using = "#tinymce")]
        public IWebElement messageField;

        [FindsBy(How = How.CssSelector, Using = "button.default.send")]
        public IWebElement sendLetterButton;

        [FindsBy(How = How.CssSelector, Using = ".sendmsg__ads-ready")]
        public IWebElement letterSendingResultMessage;



        //driver.FindElement(By.CssSelector("input[name='toFieldInput']")).SendKeys(sendTo);
        //test
        //driver.FindElement(By.CssSelector("input[name='subject']")).SendKeys(subject);
        //driver.FindElement(By.CssSelector("#file-to-upload")).SendKeys("C:/Users/oli4k/Documents/test.txt");
        //driver.SwitchTo().Frame("mce_0_ifr");
        //driver.FindElement(By.CssSelector("#tinymce")).SendKeys(messageText);
        //driver.SwitchTo().DefaultContent();
        //driver.FindElement(By.CssSelector("button.default.send")).Click();


        public UkrNetMailPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
