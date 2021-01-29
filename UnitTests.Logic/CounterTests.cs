using Loans.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.Logic
{
    [TestClass]
    class CounterTests
    {
        [TestMethod]
        public void ShouldGetFiftyAsFiftyPercentOfOneHundred()
        {
            var percent = 50;
            var actaul = 100;
            var expected = 50;

            var result = Counter.GetPercentageDiscount(actaul, percent);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldGetCorrectNumbersOfMonths()
        {
            var today = DateTime.UtcNow;
            var nextYear = DateTime.UtcNow.AddYears(1);
            var expected = 12;

            var result = Counter.GetMonthDifference(today, nextYear);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldGetCorrectRoundingPoint()
        {
            var defaultAmount = 233;
            var roundingPoint = 100;
            var expected = 200;

            var result = Counter.GetRoundDicount(defaultAmount, roundingPoint);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldGetZeroIfRoundingPointIsBeggerThanAmount()
        {
            var defaultAmount = 79;
            var roundingPoint = 100;
            var expected = 0;

            var result = Counter.GetRoundDicount(defaultAmount, roundingPoint);

            Assert.AreEqual(expected, result);
        }
    }
}
