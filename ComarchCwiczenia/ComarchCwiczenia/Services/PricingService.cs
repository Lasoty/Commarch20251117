namespace ComarchCwiczenia.Services;
public class PricingService
{
    public decimal CalculatePrice(
        decimal distanceKm,
        TimeSpan duration,
        bool isPeakTime)
    {

        decimal basePerKm = isPeakTime ? 1.5m : 1m;
        decimal basePerMinute = isPeakTime ? 0.5m : 0.3m;

        decimal price = distanceKm * basePerKm + (decimal)duration.TotalMinutes * basePerMinute;

        if (price < 5) 
            price = 5m;

        return price;
    }
}
