
using Techverx.Test.Project.Enums.PaymentEnums;

namespace Techverx.Test.Project.Dtos.FileContentsDto
{
    public class FileContentsRequestDto
    {
        public double Initials { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public long BranchCode { set; get; }
        public string AccountNumber { get; set; }
        public double FileAmount { get; set; } = 100;
        public int AccountType { get; set; }
        public FileAmountType AmountMultiplier { get; set; }
        public string CustomerCode { get; set; } 
        public string Reference { get; set; }
    }
}
