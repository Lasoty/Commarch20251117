using ComarchCwiczenia.Model;
using ComarchCwiczenia.Repositories;

namespace ComarchCwiczenia.Tests.Unit.Repositories;

[TestFixture]
public class CarRepositoryTests
{
    private CarRepository cut;

    [SetUp]
    public void Setup()
    {
        cut = new CarRepository();
    }

    [Test]
    public void GetAvailableCars_ReturnsNotEmptyCollection()
    {
        // Act
        var cars = cut.GetAvailableCars();

        // Assert
        Assert.That(cars, Is.Not.Null, "Kolekcja nie może być nullem.");
        Assert.That(cars, Is.Not.Empty, "Kolekcja nie może być pusta.");
        Assert.That(cars, Has.Count.GreaterThanOrEqualTo(1));
    }

    [Test]
    public void GetAvailableCars_AllHavePlateNumbers()
    {
        // Act
        IEnumerable<Car> cars = cut.GetAvailableCars();

        Assert.That(cars.Select(c => c.PlateNumber), Has.All.Not.Null.And.All.Length.GreaterThanOrEqualTo(3));
    }

    [Test]
    public void GetAvailableCars_HasOnlyOneTesla()
    {
        // Act
        IEnumerable<Car> cars = cut.GetAvailableCars();

        Assert.That(cars, Has.Exactly(1).Matches<Car>(car => car.Brand.Equals("Tesla", StringComparison.InvariantCultureIgnoreCase)));
    }

}
