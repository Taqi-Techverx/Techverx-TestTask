using System;
using Techverx.Test.Project.BaseModule.Managers.Enums;

namespace Techverx.Test.Project.BaseModule.Managers.Payment.Dto
{
    [Serializable]
    public class GetPaymentDto
    {
	    public int Id { get; set; }
	    public int PaymentStatus { get; set; }
	    public double Initials { get; set; }
	    public double FileAmount { get; set; }
	    public int BankId { get; set; }
	    public int AccountType { get; set; }
	    public int EmployeeId { get; set; }
	    public FileAmountType AmountMultiplier { get; set; }
	    public string Reference { get; set; }
	    public string EmployeeCode { get; set; }
	    public string EmployeeName { get; set; }
	    public string Result { get; set; }
	    public string ResultMessage { get; set; }
	}
}
