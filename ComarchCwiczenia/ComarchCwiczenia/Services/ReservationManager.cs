using ComarchCwiczenia.Model;
using ComarchCwiczenia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarchCwiczenia.Services;


public class ReservationManager
{
    private readonly ICarRepository _carRepo;
    private readonly IReservationRepository _reservationRepo;
    private readonly INotificationService _notificationService;

    public ReservationManager(
        ICarRepository carRepo,
        IReservationRepository reservationRepo,
        INotificationService notificationService)
    {
        _carRepo = carRepo;
        _reservationRepo = reservationRepo;
        _notificationService = notificationService;
    }

    public Reservation CreateReservation(Guid userId, string plateNumber)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("User required", nameof(userId));

        var car = _carRepo.GetByPlate(plateNumber)
                  ?? throw new ArgumentException("Car not found");

        if (_reservationRepo.UserHasActiveReservation(userId))
            throw new InvalidOperationException("User already has active reservation");

        var reservation = new Reservation(
            Guid.NewGuid(),
            userId,
            Guid.NewGuid(), // w realnym systemie byłby tutaj car.Id
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1));

        _reservationRepo.Save(reservation);

        _notificationService.NotifyReservationCreated(userId, reservation.Id);

        return reservation;
    }
}