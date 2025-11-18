using ComarchCwiczenia.Model;

namespace ComarchCwiczenia.Repositories;

public class CarRepository : ICarRepository
{
    public IReadOnlyList<Car> GetAvailableCars()
    {
        return new List<Car>
        {
            new Car("WX12345", "Toyota", "Yaris"),
            new ElectricCar("WX67890", "Tesla", "Model 3", 60),
            new Car("KR00001", "Volkswagen", "Golf")
        };
    }

    public Car? GetByPlate(string plateNumber)
    {
        throw new NotImplementedException();
    }
}

public interface ICarRepository
{
    IReadOnlyList<Car> GetAvailableCars();
    Car? GetByPlate(string plateNumber);
}