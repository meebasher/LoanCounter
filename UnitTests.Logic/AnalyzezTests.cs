using Loans.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Logic
{
    [TestClass]
    public class AnalyzezTests
    {
        [TestMethod]
        public void ShouldReturnTrueOnEvenAmount()
        {
            var eventNumber = 50;

            var result = Analyzer.IsEvenAmount(eventNumber);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldReturnTrueIfDeafultAmountTwiceLowerThanActualAmount()
        {
            var defaultAmount = 25;
            var actualAmount = 50;

            var result = Analyzer.IsDoublePayment(defaultAmount, actualAmount);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldReturnTrueIfMonthDifferenceIsTwiceBiggerThanSpecialMonth()
        {
            var monthDifference = 20;
            var specialMonth = 10;

            var result = Analyzer.IsEverySpecialMonth(monthDifference, specialMonth);

            Assert.IsTrue(result);
        }
    }
}
