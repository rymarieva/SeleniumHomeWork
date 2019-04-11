using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumHomeWork.Pages
{
    public class GoogleHomePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "input.gLFyf.gsfi")]
        public IWebElement searchField;

        [FindsBy(How = How.CssSelector, Using = "div.aajZCb input[name='btnK']")]
        public IWebElement searchButton;

        public GoogleHomePage(IWebDriver driver) : base(driver)
        {
        }

    }
}
