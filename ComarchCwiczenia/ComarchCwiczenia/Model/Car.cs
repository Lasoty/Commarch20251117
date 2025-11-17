namespace ComarchCwiczenia.Model;

public class Car
{
    public string PlateNumber { get; }
    public string Brand { get; }
    public string Model { get; }

    public Car(string plateNumber, string brand, string model)
    {
        PlateNumber = plateNumber;
        Brand = brand;
        Model = model;
    }
}

public class ElectricCar : Car
{
    public int BatteryCapacityKwh { get; }

    public ElectricCar(string plateNumber, string brand, string model, int batteryCapacityKwh)
        : base(plateNumber, brand, model)
    {
        BatteryCapacityKwh = batteryCapacityKwh;
    }
}