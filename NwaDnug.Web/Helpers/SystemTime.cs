using System;

namespace NwaDnug.Web.Helpers
{
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
        public static DateTime UtcNow { get { return Now().ToUniversalTime(); } }
    }
}