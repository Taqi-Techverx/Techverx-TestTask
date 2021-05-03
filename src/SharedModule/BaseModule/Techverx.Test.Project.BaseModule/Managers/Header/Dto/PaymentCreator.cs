using Techverx.Test.Project.BaseModule.Managers.Enums;
using Techverx.Test.Project.Enums;

namespace Techverx.Test.Project.BaseModule.Managers.Header.Dto
{
    public class PaymentCreator
    {
        public int EmployeeId{ get; set; }
        public ServiceBatchType Service { get; set; }
        public EmployeeType ServiceType { get; set; }
    }
}
