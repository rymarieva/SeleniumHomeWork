using OpenQA.Selenium;

namespace SeleniumHomeWork.Pages
{
    public class GoogleSearchResultPage : BasePage
    {
        public GoogleSearchResultPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement FindSearcResultByUrl(string url)
        {
            try
            {
                return Driver.FindElement(By.CssSelector($"div.r a[href = '{url}']"));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
            
        }
    }
}
