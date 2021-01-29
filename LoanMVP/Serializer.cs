using Loans.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace LoanMVP
{
    public class Serializer
    {
        public static void ExtractLoanData(IList<ILoanUpdateDto> loans, char separator = ';', string path = null)
        {
            path = path ?? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"'{DateTime.UtcNow.ToString("yyyy_MM_dd_hh.mm.ss.FFFFFF")}_rezultatai.csv");
            var data = string.Empty;
            foreach (var loan in loans)
            {
                data += $"{loan.ID}{separator}{loan.Amount}{separator}{Environment.NewLine}";
            }
            using (FileStream stream = File.Create(path))
            {
                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write(data);
                }
            }
        }
    }
}
