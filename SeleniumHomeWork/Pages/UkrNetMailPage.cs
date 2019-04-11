using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumHomeWork.Pages
{
    class UkrNetMailPage : BasePage
    {
        public string massegeFrameId = "mce_1_ifr";
        public string massgeFrameId = "#tinymce > div";


        [FindsBy(How = How.CssSelector, Using = "button.default.compose")]
        public IWebElement writeLeterButton;

        [FindsBy(How = How.CssSelector, Using = "input[name='to']:nth-child(1)")]
        public IWebElement sendToField;

        [FindsBy(How = How.CssSelector, Using = "input[name='subject']")]
        public IWebElement subjectField;


        public UkrNetMailPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
