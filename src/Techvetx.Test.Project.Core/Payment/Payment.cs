using Techverx.Test.Project.BaseModule.Managers.Enums;

namespace Techvetx.Test.Project.Core.Payment
{
	public class Payment : Entity<int>
	{
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
