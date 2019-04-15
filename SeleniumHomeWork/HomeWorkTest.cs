using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumHomeWork.Pages;
using System;
using System.Threading;

namespace SeleniumHomeWork
{
    public class HomeWorkTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void GoogleSearch_SeleniumCriteria_SeleniumHQPageFound()
        {
            //Arrange
            string link = "https://www.seleniumhq.org/";

            //Act
            driver.Navigate().GoToUrl("https://www.google.com/");
            var googleHomePage = new GoogleHomePage(driver);
            googleHomePage.searchField.SendKeys("Selenium");
            googleHomePage.searchButton.Click();

            GoogleSearchResultPage googleSearchResultPage = new GoogleSearchResultPage(driver);
            IWebElement element = googleSearchResultPage.FindSearcResultByUrl(link);
            if (element != null)
            {
                element.Click();
            }

            // Assert
            Assert.AreEqual(link, driver.Url, $"Selenium home page '{link}' is not opened. Current page is '{driver.Url}'");
        }

        [Test]
        public void OldQALightPage_SocialLinksCount_7Links()
        {
            //Arrange
            int expectedSocialLinksCount = 7;

            //Act
            driver.Navigate().GoToUrl("http://old.qalight.com.ua/zapisatsya-na-kursy");
            var oldQALightPage = new OldQALightPage(driver);
            int actualSocialLinksCount = oldQALightPage.soialLinks.Count;

            // Assert
            Assert.AreEqual(expectedSocialLinksCount, actualSocialLinksCount, $"An expected count of social linqs is {expectedSocialLinksCount}, but actual is {actualSocialLinksCount}");
        }

        [Test]
        public void Rozetka_CatalogButton_GoToAsusNotebook()
        {
            //Arrange
            string expectedLink = "https://rozetka.com.ua/notebooks/c80004/filter/producer=asus/";

            //Act
            driver.Navigate().GoToUrl("https://rozetka.com.ua/");
            var rozetkaHomePage = new RozetkaHomePage(driver);
            Actions actions = new Actions(driver);
            actions.MoveToElement(rozetkaHomePage.menuCategoriesNotebooks).Perform();
            Thread.Sleep(3000);
            actions.Click(rozetkaHomePage.menuLinkAsusNotebooks).Perform();
            string actualLink = driver.Url;

            //Assert
            Assert.AreEqual(expectedLink, actualLink, $"An expected linqs is {expectedLink}, but actual is {actualLink}");
        }

        [Test]
        public void Rozetka_GetBasketInfo()
        {
            //Arrange
            string expectedText = "Ваша корзина пуста\r\nДобавляйте понравившиеся товары в корзину";

            //Act
            driver.Navigate().GoToUrl("https://rozetka.com.ua/");
            var rozetkaHomePage = new RozetkaHomePage(driver);
            Actions actions = new Actions(driver);
            actions.MoveToElement(rozetkaHomePage.basketButton).Build().Perform();
            string actualtText = rozetkaHomePage.basketPopupMessageText.Text.Trim();
            Console.WriteLine(actualtText);

            //Assert
            Assert.AreEqual(expectedText, actualtText, $"An expected basket text is {expectedText}, but actual is {actualtText}");
        }

        [Test]
        public void UkrNet_InvalidLoginData_GettingErrorMassage()
        {
            //Arrange
            string login = "olha.rymarieva";
            string invalidPassword = "fgdfgdfgkk";
            string expectedErrorMassage = "Неправильні дані";

            //Act
            driver.Navigate().GoToUrl("https://www.ukr.net/");
            var ukrNetHomePage = new UkrNetHomePage(driver);
            ukrNetHomePage.IFrameSendKey(ukrNetHomePage.loginFrameName, ukrNetHomePage.loginFieldId, login);
            ukrNetHomePage.IFrameSendKey(ukrNetHomePage.loginFrameName, ukrNetHomePage.passwordFieldId, invalidPassword);
            //ukrNetHomePage.IFrameClickElement(ukrNetHomePage.loginFrameName, ukrNetHomePage.submitButton);
            driver.SwitchTo().Frame("mail widget");
            ukrNetHomePage.SubmitButton3.Click();
            driver.SwitchTo().DefaultContent();

            //driver.SwitchTo().Frame("mail widget");
            //ukrNetHomePage.SubmitButton2.Click();
            //driver.SwitchTo().DefaultContent();

            string actualErrorMassage = ukrNetHomePage.IFrameGetElementText(ukrNetHomePage.loginFrameName, ukrNetHomePage.errorMassage);


            //Assert
            Assert.AreEqual(expectedErrorMassage, actualErrorMassage, $"Expected massage is '{expectedErrorMassage}', but actual is '{actualErrorMassage}'");

        }

        [Test]
        public void UkrNet_ValidLoginData_UkrNet_ValidLoginData_SuccessfulMailSend()
        {
            //Arrange
            string login = "olha.rymarieva";
            string validPassword = "uSJEBBYkmkuX4cs";
            string sendTo = "terraco_kiev@ukr.net";
            string subject = "Sending message - test";
            string messageText = "Hello, Andrey!";

            //Act
            driver.Navigate().GoToUrl("https://www.ukr.net/");
            var ukrNetHomePage = new UkrNetHomePage(driver);
            ukrNetHomePage.IFrameSendKey(ukrNetHomePage.loginFrameName, ukrNetHomePage.loginFieldId, login);
            ukrNetHomePage.IFrameSendKey(ukrNetHomePage.loginFrameName, ukrNetHomePage.passwordFieldId, validPassword);
            ukrNetHomePage.IFrameClickElement(ukrNetHomePage.loginFrameName, ukrNetHomePage.submitButton);
            ukrNetHomePage.IFrameClickElement(ukrNetHomePage.loginFrameName, ukrNetHomePage.incomingMailLink);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("button.default.compose")).Click();
            //var ukrNetMailPage = new UkrNetMailPage(driver);
            //ukrNetMailPage.writeLeterButton.Click();

            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("input[name='toFieldInput']")).SendKeys(sendTo);
            driver.FindElement(By.CssSelector("input[name='subject']")).SendKeys(subject);
            driver.FindElement(By.CssSelector("#file-to-upload")).SendKeys("C:/Users/oli4k/Documents/test.txt");
            driver.SwitchTo().Frame("mce_0_ifr");
            driver.FindElement(By.CssSelector("#tinymce")).SendKeys(messageText);
            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.CssSelector("button.default.send")).Click();



            //var ukrNetMailPage = new UkrNetMailPage(driver);
            //ukrNetHomePage.writeLetterButton.Click();
            //ukrNetMailPage.sendToField.SendKeys(sendTo);
            //ukrNetHomePage.subjectField.SendKeys(subject);




            Thread.Sleep(3000);


            //Assert
            //  Assert.AreEqual(expectedErrorMassage, actualErrorMassage, $"Expected massage is '{expectedErrorMassage}', but actual is '{actualErrorMassage}'");

        }

    }
}
