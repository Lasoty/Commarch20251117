using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V140.Network;
using OpenQA.Selenium.Support.UI;

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

    [Test]
    public async Task DropdownTest()
    {
        await driver.Navigate().GoToUrlAsync("https://the-internet.herokuapp.com/dropdown");

        var dropdown = driver.FindElement(By.Id("dropdown"));
        var selectElement = new SelectElement(dropdown);
        selectElement.SelectByValue("1");

        Assert.That(selectElement.SelectedOption.Text, Is.EqualTo("Option 1"));

        selectElement.SelectByText("Option 2");
        Assert.That(selectElement.SelectedOption.Text, Is.EqualTo("Option 2"));
    }

    [Test]
    public async Task HandleJavaScriptAlerts()
    {
        await driver.Navigate().GoToUrlAsync("https://the-internet.herokuapp.com/javascript_alerts");

        var alertBtn = driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[1]/button"));
        alertBtn.Click();

        var alert = driver.SwitchTo().Alert();
        Assert.That(alert.Text, Is.EqualTo("I am a JS Alert"));
        alert.Accept();
        var resultText = driver.FindElement(By.Id("result"));
        Assert.That(resultText.Text, Does.Contain("You successfully clicked an alert"));
    }

    [Test]
    public async Task HandleJavaScriptConfirmOkCancel()
    {
        await driver.Navigate().GoToUrlAsync("https://the-internet.herokuapp.com/javascript_alerts");

        var alertBtn = driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']"));
        alertBtn.Click();

        var alert = driver.SwitchTo().Alert();
        Assert.That(alert.Text, Is.EqualTo("I am a JS Confirm"));
        alert.Accept();
        var resultText = driver.FindElement(By.Id("result"));
        Assert.That(resultText.Text, Does.Contain("You clicked: Ok"));

        alertBtn.Click();
        alert = driver.SwitchTo().Alert();
        alert.Dismiss();
        Assert.That(resultText.Text, Does.Contain("You clicked: Cancel"));
    }

    [Test]
    public async Task HandleJavaScriptPrompt()
    {
        await driver.Navigate().GoToUrlAsync("https://the-internet.herokuapp.com/javascript_alerts");

        var alertBtn = driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']"));
        alertBtn.Click();

        var alert = driver.SwitchTo().Alert();
        Assert.That(alert.Text, Is.EqualTo("I am a JS prompt"));
        alert.SendKeys("Leszek");
        alert.Accept();
        var resultText = driver.FindElement(By.Id("result"));
        Assert.That(resultText.Text, Does.Contain("You entered: Leszek"));
    }

    
}