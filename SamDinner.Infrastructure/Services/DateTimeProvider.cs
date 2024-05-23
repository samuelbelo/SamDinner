using SamDinner.Application.Common.Interfaces.Services;

namespace SamDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
