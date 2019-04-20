using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
//using OpenQA.Selenium. Extras

namespace SeleniumHomeWork.Pages
{
    internal class UkrNetHomePage : BasePage
    {

        public string loginFrame = "mail widget";

        [FindsBy(How = How.CssSelector, Using = "#id-input-login")]
        public IWebElement loginField;

        [FindsBy(How = How.CssSelector, Using = "#id-input-password")]
        public IWebElement passwordField;

        [FindsBy(How = How.CssSelector, Using = "button.form__submit")]
        public IWebElement submitButton;

        [FindsBy(How = How.CssSelector, Using = "p.form__error.form__error_wrong.form__error_visible")]
        public IWebElement errorMassage;

        [FindsBy(How = How.CssSelector, Using = "a.service__entry.service__entry_mail")]
        public IWebElement incomingMailLink;

        //[FindsBy(How = How.CssSelector, Using = "button.form__submit")]
        //public IWebElement submitButton1;

        //public IWebElement SubmitButton2 => Driver.FindElement(By.CssSelector("button.form__submit"));

        //public IWebElement SubmitButton3
        //{
        //    get
        //    {
        //        return Driver.FindElement(By.CssSelector("button.form__submit"));
        //    }
        //}


        public UkrNetHomePage(IWebDriver driver) : base(driver)
        {
        }

    }
}
