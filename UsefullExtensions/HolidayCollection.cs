using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsefullExtensions
{
    public static class HolidayCollection
    {
        private static ICollection<DateTime> holidays;

        static HolidayCollection()
        {
            holidays = new List<DateTime>();
        }

        public static void Add(DateTime holiday)
        {
            holidays.Add(holiday.Date);
        }

        public static void Add(ICollection<DateTime> holidays)
        {
            foreach (var holiday in holidays)
            {
                HolidayCollection.holidays.Add(holiday);
            }   
        }

        public static IEnumerable<DateTime> GetAll()
        {
            return holidays.AsEnumerable();
        }

        public static void Clear()
        {
            holidays.Clear();
        }

        public static int Count() 
        {
            return holidays.Count;
        }
    }
}
