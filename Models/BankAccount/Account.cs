using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Test.Project.Models.Banks;

namespace Techverx.Test.Project.Models.BankAccount
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
		public int AccountType { get; set; }

		public long BranchCode { get; set; }
	}
}