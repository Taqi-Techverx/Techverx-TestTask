using System.Security.AccessControl;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Techverx.Test.Project.Enums.PaymentEnums;

namespace Techverx.Test.Project.Models
{
	public class Payment
	{
		public int Id { get; set; } 
		public PaymentStatus PaymentStatus { get; set; }
		public double FileAmount { get; set; }
		public FileAmountType AmountMultiplier { get; set; }
		public string Client { get; set; }
		public string AccountNumber { get; set; }
		public string Reference { get; set; }
		public long BranchCode { get; set; }
		public string Result { get; set; }
		public string ResultMessage { get; set; }


	}

	public enum PaymentStatus
        {
	        Pending=1,
	        Failed=2,
	        Success=3
        }
}
