using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarchCwiczenia.Tests.E2e.Scenarios;

public abstract class TestBase
{
    protected IWebDriver driver;

    [SetUp]
    public virtual void Setup()
    {
        new WebDriverManager.DriverManager().SetUpDriver(
            new WebDriverManager.DriverConfigs.Impl.ChromeConfig());

        var options = new ChromeOptions();
        options.AddUserProfilePreference("download.default_directory", Path.Combine(Environment.CurrentDirectory, "Download"));
        options.AddUserProfilePreference("download.prompt_for_download", false);

        options.AddArgument("headless");
        options.AddArgument("--disable-gpu");
        options.AddArgument("--window-size=1920,1080");

        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [TearDown]
    public virtual void Teardown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
