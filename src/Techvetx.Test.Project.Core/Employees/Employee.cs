using Techvetx.Test.Project.Core.BankAccount;

namespace Techvetx.Test.Project.Core.Employees
{
    public class Employee : Entity<int>
    {
        public string FirstName { get; set; }
		public string Email { get; set; }
		public string Surname { get; set; }
		public string ClientCode{ get; set; }
		public string CustomerCode { get; set; }
		public virtual Account Account { get; set; }
       
    }
}
