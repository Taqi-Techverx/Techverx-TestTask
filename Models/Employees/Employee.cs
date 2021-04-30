using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Test.Project.Enums;
using Techverx.Test.Project.Models.BankAccount;

namespace Techverx.Test.Project.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
		public string Email { get; set; }
		public string Surname { get; set; }
		public string ClientCode{ get; set; }
		public string CustomerCode { get; set; }
		public virtual Account Account { get; set; }
       
    }
}
