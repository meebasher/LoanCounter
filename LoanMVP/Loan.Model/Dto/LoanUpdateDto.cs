namespace Loans.Model
{
    public class LoanUpdateDto : ILoanUpdateDto
    {
        public string ID { get; set; }
        public string Amount { get; set; }
    }
}
