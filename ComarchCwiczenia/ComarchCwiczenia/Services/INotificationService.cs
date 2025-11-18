using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarchCwiczenia.Services;

public interface INotificationService
{
    void NotifyReservationCreated(Guid userId, Guid reservationId);
}
