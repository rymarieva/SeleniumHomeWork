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
    }
}
