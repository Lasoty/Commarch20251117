using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComarchCwiczenia.Model;

namespace ComarchCwiczenia.Tests.Unit.Model;

[TestFixture]
public class CarTests
{
    private Car cut;

    [SetUp]
    public void Setup()
    {
        cut = new Car("WX12345", "Audi", "C6");
    }

    [Test]
    public void PlateNumber_ShouldHaveExpectedPrefix()
    {
        Assert.That(cut.PlateNumber, Does.StartWith("WX"));
        Assert.That(cut.PlateNumber, Has.Length.GreaterThanOrEqualTo(5));
    }

    [Test]
    public void Brand_ShouldContainAudi()
    {
        Assert.That(cut.Brand, Does.Contain("udi"));
        Assert.That(cut.Brand, Does.EndWith("udi"));
    }

    [Test]
    public void DiscountCode_ShouldMatchPattern()
    {
        string code = "SUMMER-2025-PL";

        Assert.That(code, Does.Match(@"^[A-Z]+-\d{4}-[A-Z]{2}$"));
    }
}
