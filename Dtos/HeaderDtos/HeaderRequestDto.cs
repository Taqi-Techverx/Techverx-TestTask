using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Techverx.Test.Project.Enums;

namespace Techverx.Test.Project.Dtos.HeaderDtos
{
    public class HeaderRequestDto
    {
        public string PsVer { get; set; }
        public string Client { get; set; }
        public string DueDate { get; set; }
        public ServiceBatchType Service { get; set; }
        public EmployeeType ServiceType { get; set; }
        public string Reference { get; set; }
        public  string CallBackUrl { get; set; }

    }
}
