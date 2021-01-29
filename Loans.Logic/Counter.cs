using System;

namespace Loans.Logic
{
    public static class Counter
    {
        public static decimal GetPercentageDiscount(decimal paymentValue, int discountPercantage)
        {
            return paymentValue - (paymentValue * discountPercantage / 100);
        }

        public static decimal GetRoundDicount(decimal defaultPayment, decimal roundingPoint = 100)
        {
            if (defaultPayment > roundingPoint)
            {
                return defaultPayment % roundingPoint;
            }
            return 0;
        }

        public static int GetMonthDifference(DateTime startDate, DateTime lastDate)
        {
            if (startDate > lastDate)
            {
                throw new ArgumentException();
            }
            return ((lastDate.Year - startDate.Year) * 12) + lastDate.Month - startDate.Month;
        }
    }
}
