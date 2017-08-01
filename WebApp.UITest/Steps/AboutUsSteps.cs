using Browser.Core.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebApp.AppFramework;

namespace WebApp.UITest.Steps
{
    [Binding]
   // [LocalSeleniumTestFixture(BrowserNames.Chrome)]
    public class AboutUsSteps 
    {
        HomePage HP;

        IWebDriver browser;
        [BeforeScenario]
        public void TestSetup1()
        {
            BrowserTest test = new BrowserTest("chrome");

            test.TestSetup();
            browser = test.Browser;

            // Uncomment the below line of code to debug any build server resolution issues
            //Browser.Manage().Window.Size = new System.Drawing.Size(1040, 784);
        }

        [AfterScenario]
        public void TearDown()
        {
            BrowserTest test = new BrowserTest("chrome");
            test.Browser= browser;
            test.TearDown();
        }

        [Given(@"User go to about us page")]
        public void GivenUserGoToAboutUsPage()
        {
            AboutPage AP = Navigation.GoToAboutPage(browser);
        }
        [Given(@"User navigated to home page")]
        public void GivenUserNavigatedToHomePage()
        {
            HP = Navigation.GoToHomePage(browser);
        }
        [Given(@"I have navigated back to the home page")]
        public void GivenIHaveNavigatedBackToTheHomePage()
        {
            AboutPage AP2 = EAPage.NavigateThroughMenuItems(browser, Bys.EAPage.Menu_About);
        }
        [Given(@"I have navigated to the Home page again")]
        public void GivenIHaveNavigatedToTheHomePageAgain()
        {
            Navigation.GoToHomePage(browser);
        }
        [When(@"User enter ""(.*)"" into the textbox")]
        public void WhenUserEnterIntoTheTextbox(string p0)
        {
            HP.EmailTxt.SendKeys("blah");
        }
        [Then(@"The text box should contain ""(.*)""")]
        public void ThenTheTextBoxShouldContain(string p0)
        {
            Assert.AreEqual("blah", HP.EmailTxt.GetAttribute("value"));
        }



    }
}
