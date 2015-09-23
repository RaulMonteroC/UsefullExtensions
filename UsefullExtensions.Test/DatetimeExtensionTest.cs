using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsefullExtensions;
using NUnit.Framework;

namespace UsefullExtensions.Test
{
    [TestFixture]
    public class DatetimeExtensionTest
    {
        private DateTime date;

        [SetUp]
        public void SetUp()
        {
            date = new DateTime(2015, 7, 20);
        }

        [Test]
        public void AddDaysWithNoWeekendBeetween()
        {
            Assert.AreEqual(new DateTime(2015, 7, 24),date.AddWorkableDays(4));
        }

        [Test]
        public void AddDaysDoesntAddWeekends()
        {            
            Assert.AreEqual(new DateTime(2015, 7, 27), date.AddWorkableDays(5)); // When land in weekend            
            Assert.AreEqual(new DateTime(2015, 7, 31), date.AddWorkableDays(9)); // When passes weekend
            Assert.AreEqual(new DateTime(2015, 8, 31),date.AddWorkableDays(30));
        }

        [Test]
        public void AddDaysWithHolidays()
        {
            HolidayCollection.Add(new DateTime(2015, 7, 23));
            Assert.AreEqual(new DateTime(2015, 7, 24), date.AddWorkableDays(3));
            HolidayCollection.Clear();
        }
    }
}
