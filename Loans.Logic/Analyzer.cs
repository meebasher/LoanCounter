namespace Loans.Logic
{
    public static class Analyzer
    {
        public static bool IsEvenAmount(decimal amount)
        {
            return amount % 2 == 0;
        }

        public static bool IsDoublePayment(decimal defaultAmount, decimal actualAmount)
        {
            return actualAmount >= (defaultAmount * 2);
        }

        public static bool IsEverySpecialMonth(int monthDifference, int specialMonth)
        {
            return monthDifference % specialMonth == 0;
        }
    }
}
