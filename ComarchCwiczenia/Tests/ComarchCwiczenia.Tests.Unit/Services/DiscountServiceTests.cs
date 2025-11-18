using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComarchCwiczenia.Services;

namespace ComarchCwiczenia.Tests.Unit.Services;


public class DiscountServiceTests
{
    private DiscountService sut;

    [SetUp]
    public void Setup()
    {
        sut = new DiscountService();
    }

    [TestCase(100, null, 100)]
    [TestCase(100, "", 100)]
    [TestCase(100, "WELCOME10", 90)]
    [TestCase(50, "FREEFIRST", 0)]
    [TestCase(60, "FREEFIRST", 60)]
    public void ApplyDiscount_ReturnsExpectedPrice(decimal basePrice, string? discountCode, decimal expected)
    {
        // Act
        var result = sut.ApplyDiscount(basePrice, discountCode);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(0.01m));
    }

    [Test]
    public void ApplyDiscount_Range_ReturnsExpectedPrice([Range(0, 55)] decimal basePrice, [Range(0, 10)] decimal test)
    {
        string discountCode = "FREEFIRST";
        decimal expected = 0;

        // Act
        var result = sut.ApplyDiscount(basePrice, discountCode);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(0.01m));
    }

    [TestCase(60, "FREEFIRST", ExpectedResult = 60)]
    public decimal ApplyDiscount_VariusCode_ReturnsExpectedPrice(decimal basePrice, string? discountCode)
    {
        return sut.ApplyDiscount(basePrice, discountCode);
    }
}
