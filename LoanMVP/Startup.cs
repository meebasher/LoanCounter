using Loans.Logic;
using Loans.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace LoanMVP
{
    public class Startup
    {
        public void InitializeApp()
        {
            Console.WriteLine("Greetings! This app helps you to count next months loan payment amount.\n" +
                "Enter a save file path with filename and its extention that contains the loan data");

            var filePath = GetFilePath();

            var file = Path.Combine(filePath);
            var loans = File.ReadAllLines(file);

            var loanUpdatedList = ProcessPaimentCheck(loans);

            if (loanUpdatedList?.Count > 0)
            {
                Serializer.ExtractLoanData(loanUpdatedList);

                Console.WriteLine("Finished.\nPress any key to exit...");
                Console.ReadKey();
            }
        }

        private List<ILoanUpdateDto> ProcessPaimentCheck(string[] loans)
        {
            const int MONTH_PAYMENT_OFFSET = 1;
            var loanUpdatedList = new List<ILoanUpdateDto>();
            Guid id;
            decimal defaultPaymentValue;
            decimal lastPaymentValue;
            DateTime starDate;
            DateTime disbursementDate;
            DateTime lastPaymentDate;
            decimal nextPaymentAmount;

            for (int i = 0; i < loans.Length; i++)
            {
                var splittedLoan = loans[i].Split(';');

                if (splittedLoan.Length < 6)
                {
                    Console.Clear();
                    Console.WriteLine("Error. Incorrect files data format.\nPress any key to exit..");
                    Console.ReadKey();
                    return null;
                }

                ParseLoanData(out id, out defaultPaymentValue, out lastPaymentValue, out starDate, out disbursementDate, out lastPaymentDate, splittedLoan);

                nextPaymentAmount = defaultPaymentValue;
                var isDoubledPaiment = Analyzer.IsDoublePayment(defaultPaymentValue, lastPaymentValue);

                if (isDoubledPaiment)
                {
                    nextPaymentAmount -= Counter.GetRoundDicount(defaultPaymentValue);
                }

                var monthDifference = Counter.GetMonthDifference(starDate, lastPaymentDate) - MONTH_PAYMENT_OFFSET;
                var isOnTenthMonth = Analyzer.IsEverySpecialMonth(monthDifference, 10);

                if (isOnTenthMonth)
                {
                    nextPaymentAmount = Counter.GetPercentageDiscount(defaultPaymentValue, 1);
                }

                var isOnEighteenthMonth = Analyzer.IsEverySpecialMonth(monthDifference, 18);

                if (Analyzer.IsEvenAmount(defaultPaymentValue) && isOnEighteenthMonth)
                {
                    nextPaymentAmount = 0;
                }

                loanUpdatedList.Add(new LoanUpdateDto
                {
                    ID = id.ToString(),
                    Amount = nextPaymentAmount == 0 ? "-" : nextPaymentAmount.ToString()
                });
            }

            return loanUpdatedList;
        }

        private string GetFilePath()
        {
            var filePath = Console.ReadLine();
            while (!File.Exists(filePath) || Path.GetExtension(filePath) != ".csv")
            {
                Console.Clear();
                Console.WriteLine("Incorrrect file path or filename. Enter correct file path");
                filePath = Console.ReadLine();
            }
            return filePath;
        }

        private void ParseLoanData(out Guid id, out decimal defaultPaymentValue, out decimal lastPaymentValue, out DateTime starDate, out DateTime disbursementDate, out DateTime lastPaymentDate, string[] splittedLoan)
        {

            Guid.TryParse(splittedLoan[0], out id);
            DateTime.TryParse(splittedLoan[2], out starDate);
            DateTime.TryParse(splittedLoan[3], out disbursementDate);
            DateTime.TryParse(splittedLoan[5], out lastPaymentDate);
            decimal.TryParse(splittedLoan[1], out defaultPaymentValue);
            decimal.TryParse(splittedLoan[4], out lastPaymentValue);
        }
    }



}
