namespace ComarchCwiczenia.Services;

public class CarAvailabilityService
{
    public bool CanBeReserved(bool isInService, bool isAlreadyReserved, decimal fuelLevelPercent)
    {
        if (fuelLevelPercent < 0 || fuelLevelPercent > 100)
            throw new ArgumentOutOfRangeException(nameof(fuelLevelPercent));

        if (isInService)
            return false;

        if (isAlreadyReserved)
            return false;

        return fuelLevelPercent >= 10;
    }
}
