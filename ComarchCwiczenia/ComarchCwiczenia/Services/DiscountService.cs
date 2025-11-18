namespace ComarchCwiczenia.Services;

/// <summary>
/// Zniżki w systemie:
/// - WELCOME10: 10% zniżki
/// - FREEFIRST: przejazd do 50 zł za darmo
/// </summary>
public class DiscountService
{
    public decimal ApplyDiscount(decimal basePrice, string discountCode)
    {
        if (string.IsNullOrWhiteSpace(discountCode))
            return basePrice;

        if (discountCode == "WELCOME10")
            return basePrice * 0.9m;

        if (discountCode == "FREEFIRST" && basePrice <= 50)
            return 0;

        return basePrice;
    }
}
