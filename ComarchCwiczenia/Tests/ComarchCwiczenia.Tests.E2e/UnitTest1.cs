using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

    }
}