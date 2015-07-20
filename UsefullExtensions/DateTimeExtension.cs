using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsefullExtensions
{
    public static class DatetimeExtension
    {
        public static DateTime AddWorkableDays(this DateTime date, int days)
        {
            var newDate = date.AddDays(days);
            var weekendDays = GetWeekendCount(date, newDate);
            var holidays = GetHolidayCount(date, newDate);

            newDate = newDate.AddDays(weekendDays);
            newDate = newDate.AddDays(holidays);

            return newDate;
        }

        private static int GetWeekendCount(DateTime date, DateTime finalDate)
        {
            var days = (finalDate - date).Days;
            var weekendDays = (days / 7) * 2;

            if (finalDate.DayOfWeek == DayOfWeek.Saturday || finalDate.DayOfWeek == DayOfWeek.Sunday)
            {
                weekendDays += 2;
            }

            return weekendDays;
        }

        private static int GetHolidayCount(DateTime originalDate, DateTime finalDate)
        {
            return 0;
        }
    }
}
