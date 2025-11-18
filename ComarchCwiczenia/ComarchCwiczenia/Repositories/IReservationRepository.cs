using ComarchCwiczenia.Model;

namespace ComarchCwiczenia.Repositories;

public interface IReservationRepository
{
    void Save(Reservation reservation);
    bool UserHasActiveReservation(Guid userId);
}
