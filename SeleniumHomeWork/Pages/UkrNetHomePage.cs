using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
//using OpenQA.Selenium. Extras

namespace SeleniumHomeWork.Pages
{
    internal class UkrNetHomePage : BasePage
    {

        public string loginFrameName = "mail widget";
        public string loginFieldId = "#id-input-login";
        public string passwordFieldId = "#id-input-password";
        public string submitButton = "button.form__submit";
        public string errorMassage = "p.form__error.form__error_wrong.form__error_visible";
        public string incomingMailLink = "a.service__entry.service__entry_mail";

        [FindsBy(How = How.CssSelector, Using = "button.form__submit")]
        public IWebElement submitButton1;

        public IWebElement SubmitButton2 => Driver.FindElement(By.CssSelector("button.form__submit"));

        public IWebElement SubmitButton3
        {
            get
            {
                return Driver.FindElement(By.CssSelector("button.form__submit"));
            }
        }


        public UkrNetHomePage(IWebDriver driver) : base(driver)
        {
        }

    }
}
