using BookApi.Utils;
using System;


namespace BookAPI.Helpers
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset)
        {
            var currentDate = SystemTime.Now();
            int age = currentDate.Year - dateTimeOffset.Year;

            if (currentDate < dateTimeOffset.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}

