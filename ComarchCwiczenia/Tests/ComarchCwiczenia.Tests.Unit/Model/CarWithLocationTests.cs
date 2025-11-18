using ComarchCwiczenia.Model;

namespace ComarchCwiczenia.Tests.Unit.Model;

[TestFixture]
public class CarWithLocationTests
{
    private CarWithLocation car;

    [SetUp]
    public void Setup()
    {
        car = new CarWithLocation(
            "WX12345",
            "Toyota",
            "Yaris",
            new Location(91.2297, 181.0122));
    }

    [Test]
    public void CarWithLocation_ShouldHaveValidTextFields()
    {
        // Act + Assert
        Assert.Multiple(() =>
        {


            Assert.That(car.PlateNumber,
                Is.Not.Null.And.Not.Empty,
                "PlateNumber should not be null or empty");

            Assert.That(car.Brand,
                Is.Not.Null.And.Not.Empty,
                "Brand should not be null or empty");

            Assert.That(car.Model,
                Is.Not.Null.And.Not.Empty,
                "Model should not be null or empty");
        });
    }

    [Test]
    public void CarWithLocation_ShouldHaveValidLocation()
    {
        // Act + Assert
        Assert.Multiple(() =>
        {
            Assert.That(car.Location,
                Is.Not.Null,
                "Location should not be null");

            Assert.That(car.Location.Latitude,
                Is.InRange(-90.0, 90.0),
                "Latitude must be between -90 and 90");

            Assert.That(car.Location.Longitude,
                Is.InRange(-180.0, 180.0),
                "Longitude must be between -180 and 180");
        });
    }
}