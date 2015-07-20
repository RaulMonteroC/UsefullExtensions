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
            Assert.AreEqual(date.AddWorkableDays(4), new DateTime(2015, 7, 24));
        }

        [Test]
        public void AddDaysDoesntAddWeekends()
        {
            // When land in weekend
            Assert.AreEqual(date.AddWorkableDays(5), new DateTime(2015, 7, 27));
            // When passes weekend
            Assert.AreEqual(date.AddWorkableDays(9), new DateTime(2015, 7, 31));
            
            Assert.AreEqual(date.AddWorkableDays(30), new DateTime(2015, 8, 31));
        }
    }
}
