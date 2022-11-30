using Indimin.Domain.Interfaces;

namespace Indimin.Persistence.Services;

public class DateTimeService : IDatetimeService
{
    public DateTime utcNow => DateTime.UtcNow.Date;
}