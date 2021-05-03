using Techverx.Test.Project.BaseModule.Managers.Enums;
using Techverx.Test.Project.Enums;

namespace Techverx.Test.Project.BaseModule.Managers.Header.Dto
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
