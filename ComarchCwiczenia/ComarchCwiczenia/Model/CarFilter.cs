namespace ComarchCwiczenia.Model;

public class CarFilter
{
    public IEnumerable<Car> FilterElectric(IEnumerable<Car> cars)
        => cars.Where(c => c is ElectricCar);
}
