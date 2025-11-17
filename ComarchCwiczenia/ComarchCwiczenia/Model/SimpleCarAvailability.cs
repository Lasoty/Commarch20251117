namespace ComarchCwiczenia.Model;

public class SimpleCarAvailability
{
    public bool CanBeReserved(bool isInService, bool isAlreadyReserved)
        => !isInService && !isAlreadyReserved;
}
