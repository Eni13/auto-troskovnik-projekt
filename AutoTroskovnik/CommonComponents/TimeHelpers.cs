using System;

namespace CommonComponents
{
    public class TimeHelpers
    {
        public static string dateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
