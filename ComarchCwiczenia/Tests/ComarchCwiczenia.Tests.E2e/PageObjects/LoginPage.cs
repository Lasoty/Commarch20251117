using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ComarchCwiczenia.Tests.E2e.PageObjects;

public class LoginPage(IWebDriver driver)
{
    public IWebElement UserField => driver.FindElement(By.Id("username"));
    public IWebElement PasswordField => driver.FindElement(By.Id("password"));
    public IWebElement LoginBtn => driver.FindElement(By.XPath("//*[@id=\"login\"]/button"));
    public IWebElement ErrorMessage = driver.FindElement(By.CssSelector(".flash.error"));

    public void EnterUserName(string userName)
    {
        UserField.SendKeys(userName);
    }

    public void EnterPassword(string password)
    {
        PasswordField.SendKeys(password);
    }

    public void ClickLoginButton()
    {
        LoginBtn.Click();
    }

    public bool IsErrorMessageDisplayed()
    {
        return ErrorMessage.Displayed;
    }


}
