using System;

namespace Dywt.App
{
    public static class SystemTime
    {
        public static Func<DateTime> UtcNow = () => DateTime.Now.ToUniversalTime();
        public static Func<DateTime> LocalNow = () => UtcNow().ToLocalTime();
    }
}
