using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V140.Network;

namespace ComarchCwiczenia.Tests.E2e;

[TestFixture]
public class SeleniumTests
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        new WebDriverManager.DriverManager().SetUpDriver(
            new WebDriverManager.DriverConfigs.Impl.ChromeConfig());

        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [TearDown]
    public void Teardown()
    {
        driver.Quit();
        driver.Dispose();
    }


    [Test]
    public async Task CheckPageTitle()
    {
        await driver.Navigate().GoToUrlAsync("https://the-internet.herokuapp.com");

        Assert.That(driver.Title, Is.EqualTo("The Internet"));
    }

    [Test]
    public async Task CorrectLoginTest()
    {
        await driver.Navigate().GoToUrlAsync("https://the-internet.herokuapp.com/login");

        var usernamerField = driver.FindElement(By.Id("username"));
        var passwordField = driver.FindElement(By.Id("password"));

        usernamerField.SendKeys("tomsmith");
        passwordField.SendKeys("SuperSecretPassword!");

        var loginBtn = driver.FindElement(By.XPath("//*[@id=\"login\"]/button"));
        loginBtn.Click();

        var successMsg = driver.FindElement(By.Id("flash"));
        Assert.That(successMsg.Text, Does.Contain("You logged into a secure area!"));
    }

    [Test]
    public async Task IncorrectLoginTest()
    {
        await driver.Navigate().GoToUrlAsync("https://the-internet.herokuapp.com/login");

        var usernameField = driver.FindElement(By.Id("username"));
        var passwordField = driver.FindElement(By.Id("password"));

        usernameField.SendKeys("wrongUser");
        passwordField.SendKeys("wrongPassword");

        var loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));
        loginButton.Click();

        var errorMessage = driver.FindElement(By.CssSelector(".flash.error"));
        Assert.That(errorMessage.Text, Does.Contain("Your username is invalid!"), "Niepoprawne dane logowania nie wywo³a³y b³êdu.");
    }

    [Test]
    public async Task IsCheckboxSelectedTest()
    {
        await driver.Navigate().GoToUrlAsync("https://the-internet.herokuapp.com/checkboxes");

        var checkbox = driver.FindElement(By.XPath("//*[@id=\"checkboxes\"]/input[2]"));

        Assert.That(checkbox.Selected, Is.True);
    }
}