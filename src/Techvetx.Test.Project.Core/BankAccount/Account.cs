using Techvetx.Test.Project.Core.Banks;
using Techvetx.Test.Project.Core.Employees;

namespace Techvetx.Test.Project.Core.BankAccount
{
    public class Account : Entity<int>
    {
        public string AccountNumber { get; set; }
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
		public int AccountType { get; set; }

		public long BranchCode { get; set; }
	}
}