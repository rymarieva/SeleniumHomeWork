using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHomeWork.Pages
{
    public class OldQALightPage:BasePage
    {
        [FindsBy(How=How.CssSelector,Using = "#footer_social li a")]
        public IList<IWebElement> soialLinks;

        public OldQALightPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
