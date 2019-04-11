using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace SeleniumHomeWork.Pages
{
    public class RozetkaHomePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "button.menu-toggler")]
        public IWebElement catalogButton;

        [FindsBy(How = How.CssSelector, Using = "a[class= 'menu-categories__link'][href = 'https://rozetka.com.ua/computers-notebooks/c80253/']")]
        public IWebElement menuCategoriesNotebooks;

        [FindsBy(How = How.CssSelector, Using = "a[href = 'https://rozetka.com.ua/notebooks/asus/c80004/v004/']")]
        public IWebElement menuLinkAsusNotebooks;
        
        [FindsBy(How = How.XPath, Using = "//a[@href = 'https://rozetka.com.ua/cart/']/..")]
        public IWebElement basketButton;

        [FindsBy(How = How.CssSelector, Using = "[class='header-actions__dummy-content header-actions__dummy-content_type_cart'] p")]
        public IList<IWebElement> basketPopupMessageText;

        public RozetkaHomePage(IWebDriver driver) : base(driver)
        {
        }
    }
}
