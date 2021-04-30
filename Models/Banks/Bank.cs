using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Test.Project.Models.BankAccount;

namespace Techverx.Test.Project.Models.Banks
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public long BranchCode { set; get; }
        public string Reference { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }  
    }
}
