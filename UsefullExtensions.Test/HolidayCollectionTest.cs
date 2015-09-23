using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UsefullExtensions.Test
{
    [TestFixture]
    public class HolidayCollectionTest
    {
        [Test]
        public void ClearAllHolidays()
        {
            HolidayCollection.Clear();
            Assert.AreEqual(HolidayCollection.Count(), 0);
        }

        [Test]
        public void CanAddNewDatetime()
        {
            HolidayCollection.Clear();
            HolidayCollection.Add(DateTime.Now);
            Assert.Greater(HolidayCollection.Count(), 0);
        }

        [Test]
        public void CanAddMultipleDatetime()
        {
            HolidayCollection.Clear();
            HolidayCollection.Add(new List<DateTime>()
            {
                DateTime.Now, DateTime.Now
            });
            Assert.AreEqual(HolidayCollection.Count(), 2);
        }

        [Test]
        public void GetAllHolidays()
        {
            HolidayCollection.Clear();
            HolidayCollection.Add(new List<DateTime>()
            {
                DateTime.Now, DateTime.Now
            });

            var holidayList = HolidayCollection.GetAll();

            Assert.AreEqual(HolidayCollection.Count(), holidayList.Count());
        }
    }
}
