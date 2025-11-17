namespace ComarchCwiczenia.Model;

public class Reservation(Guid id, Guid userId, Guid carId, DateTime start, DateTime end)
{
    public Guid Id { get; } = id;
    public Guid UserId { get; } = userId;
    public Guid CarId { get; } = carId;
    public DateTime StartTime { get; } = start;
    public DateTime EndTime { get; } = end;
}
