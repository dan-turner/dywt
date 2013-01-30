using System;

namespace Dywt.App.Infrastructure
{
    public static class SystemTime
    {
        public static Func<DateTime> UtcNow = () => DateTime.Now.ToUniversalTime();
    }
}
