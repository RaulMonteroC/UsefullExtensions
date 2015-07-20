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

            newDate = newDate.AddDays(weekendDays + holidays);            

            return newDate;
        }

        private static int GetWeekendCount(DateTime date, DateTime finalDate)
        {
            int totalWeekendDays = 0;
            int days = 0;
            int totalWeeks = 0;
            int weekendDays = 0;
            do
            {
                days = (finalDate - date).Days;
                totalWeeks = (days / 7);                
                weekendDays = totalWeeks * 2;

                if (finalDate.DayOfWeek == DayOfWeek.Saturday || finalDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    weekendDays += 2;
                }

                date = finalDate;
                finalDate = finalDate.AddDays(weekendDays);
                totalWeekendDays += weekendDays;
            
            }while(weekendDays > 0);

            return totalWeekendDays;
        }

        private static int GetHolidayCount(DateTime originalDate, DateTime finalDate)
        {
            return 0;
        }
    }
}
