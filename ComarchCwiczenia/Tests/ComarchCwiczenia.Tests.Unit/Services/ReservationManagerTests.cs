using ComarchCwiczenia.Model;
using ComarchCwiczenia.Repositories;
using ComarchCwiczenia.Services;
using Moq;
using Range = Moq.Range;

namespace ComarchCwiczenia.Tests.Unit.Services;

public class ReservationManagerTests
{
    private Mock<ICarRepository> carRepo;
    private Mock<IReservationRepository> reservationRepo;
    private Mock<INotificationService> notificationService;
    private ReservationManager manager;

    [SetUp]
    public void Setup()
    {
        carRepo = new Mock<ICarRepository>();
        reservationRepo = new Mock<IReservationRepository>();
        notificationService = new Mock<INotificationService>();

        manager = new ReservationManager(carRepo.Object, reservationRepo.Object, notificationService.Object);
    }

    [Test]
    public void CreateReservation_WhenValidData_SaveReservationAndSendsNotification()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var plate = "WX12345";

        // Act
        carRepo.Setup(r => r.GetByPlate(It.IsAny<string>()))
            .Returns(new Car(plate, "Toyota", "Yaris"));

        reservationRepo.Setup(r => r.UserHasActiveReservation(userId))
            .Returns(false);

        var actual = manager.CreateReservation(userId, plate);

        // Assert
        notificationService.Verify(n => n.NotifyReservationCreated(It.IsAny<Guid>(), It.IsAny<Guid>())
            , Times.Once);
        reservationRepo.Verify(r => r.Save(It.IsAny<Reservation>()), Times.Once);

        Assert.That(actual.UserId, Is.EqualTo(userId));
    }

    [Test]
    public void CreateReservation_WhenCarNotFound_ThrowsArgumentException()
    {
        // Arrange
        var userId = Guid.NewGuid();
        carRepo.Setup(c => c.GetByPlate(It.IsAny<string>())).Returns((Car?)null);
        
        // Act
        TestDelegate del = () => manager.CreateReservation(userId, "NOT-EXISTS");

        // Assert
        var exeption = Assert.Throws<ArgumentException>(del);
        
        Assert.That(exeption, Is.Not.Null);
        Assert.That(exeption.Message, Does.Contain("Car not found"));
    }
}
