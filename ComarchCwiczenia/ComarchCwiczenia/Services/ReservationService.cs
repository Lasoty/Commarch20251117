using ComarchCwiczenia.Model;

namespace ComarchCwiczenia.Services;
public class ReservationService
{
    public Reservation CreateReservation(Guid userId, Guid carId, DateTime start, DateTime end)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("User is required", nameof(userId));

        if (carId == Guid.Empty)
            throw new ArgumentException("Car is required", nameof(carId));

        if (end <= start)
            throw new ArgumentException("End time must be after start time", nameof(end));

        // Normalnie: tu sprawdzenie dostępności, zapis do bazy, itd.
        return new Reservation(Guid.NewGuid(), userId, carId, start, end);
    }
}
