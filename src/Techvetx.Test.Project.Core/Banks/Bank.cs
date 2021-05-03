using System.Collections.Generic;
using Techvetx.Test.Project.Core.BankAccount;

namespace Techvetx.Test.Project.Core.Banks
{
    public class Bank : Entity<int>
    {
        public string Name { set; get; }
        public long BranchCode { set; get; }
        public string Reference { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }  
    }
}
