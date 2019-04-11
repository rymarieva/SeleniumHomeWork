using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumHomeWork.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void IFrameSendKey(string frameName, string cssSelectorWebElement, string text)
        {
            Driver.SwitchTo().Frame(frameName);
            Driver.FindElement(By.CssSelector(cssSelectorWebElement)).SendKeys(text);
            Driver.SwitchTo().DefaultContent();
        }

        public void IFrameClickElement(string frameName, string cssSelectorWebElement)
        {
            Driver.SwitchTo().Frame(frameName);
            Driver.FindElement(By.CssSelector(cssSelectorWebElement)).Click();
            Driver.SwitchTo().DefaultContent();
        }

        public string IFrameGetElementText(string frameName, string cssSelectorWebElement)
        {
            Driver.SwitchTo().Frame(frameName);
            string text = Driver.FindElement(By.CssSelector(cssSelectorWebElement)).Text.Trim();
            Driver.SwitchTo().DefaultContent();
            return text;
        }


    }
}
