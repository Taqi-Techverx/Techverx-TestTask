using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Test.Project.Enums;

namespace Techverx.Test.Project.Dtos.EmployeeDtos
{
    public class GetEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string ClientCode { get; set; }
        public string CustomerCode { get; set; }
    }
}
