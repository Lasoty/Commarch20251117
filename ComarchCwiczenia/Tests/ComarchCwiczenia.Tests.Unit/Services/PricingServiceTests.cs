using ComarchCwiczenia.Services;

namespace ComarchCwiczenia.Tests.Unit.Services;

[TestFixture]
public class PricingServiceTests
{
    private PricingService cut;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Console.WriteLine("OneTimeSetUp");
    }

    [SetUp]
    public void Setup()
    {
        cut = new PricingService();
    }

    [Test]
    public void CalculatePrice_NormalConditions_ReturnExpectedPrice()
    {
        // Arrange
        var expected = 10m * 1m + 15m * 0.3m;

        // Act
        var actual = cut.CalculatePrice(
            distanceKm: 10m,
            duration:TimeSpan.FromMinutes(15),
            isPeakTime: false
        );

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CalculatePrice_IsAtLeastMinimumFee()
    {
        // Arrange
        var distanceKm = 1m;
        var duration = TimeSpan.FromSeconds(1);
        var isPeakTime = false;

        // Act
        var actual = cut.CalculatePrice(distanceKm, duration, isPeakTime);

        // Assert
        Assert.That(actual, Is.AtLeast(5m));
    }

    [Test]
    public void CalculatePrice_ShouldReturn_HigherPriceInPeakTime()
    {
        // Arrange
        var distanceKm = 10m;
        var duration = TimeSpan.FromMinutes(10);

        // Act
        var offPeak = cut.CalculatePrice(distanceKm, duration, isPeakTime: false);
        var peak = cut.CalculatePrice(distanceKm, duration, isPeakTime: true);

        // Assert
        Assert.That(peak, Is.GreaterThan(offPeak));
    }

    [TearDown]
    public void TearDown()
    {
        Console.WriteLine("TearDown");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Console.WriteLine("OneTimeTearDown");
    }

}
