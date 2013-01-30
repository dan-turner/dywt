using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dywt.App.Infrastructure
{
    public interface IUserTime
    {
        DateTimeOffset Now();
        DateTimeOffset ToOffset(DateTime dateTimeUser);
        DateTimeOffset FromUtc(DateTime dateTimeUtc);
    }

    public static class UserTime
    {
        public static Func<TimeZoneInfo> CurrentTimeZone = () => TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
        
        public static DateTimeOffset LocalNow()
        {
            var now = SystemTime.UtcNow();
            return FromUtc(now);
        }

        public static DateTimeOffset ToOffset(DateTime dateTimeUser)
        {
            if (dateTimeUser.Kind == DateTimeKind.Utc)
            {
                throw new ArgumentException("Parameter must not be in UTC", "dateTimeUser");
            }
            return new DateTimeOffset(dateTimeUser, CurrentTimeZone().GetUtcOffset(dateTimeUser));
        }

        public static DateTimeOffset FromUtc(DateTime dateTimeUtc)
        {
            if (dateTimeUtc.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException("Parameter must be in UTC", "dateTimeUtc");
            }
            return TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, CurrentTimeZone());
        }
    }
}
