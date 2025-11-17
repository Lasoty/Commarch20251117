namespace ComarchCwiczenia.Model;

public class CarWithLocation : Car
{
    public Location Location { get; }

    public CarWithLocation(string plateNumber, string brand, string model, Location location)
        : base(plateNumber, brand, model)
    {
        Location = location;
    }
}