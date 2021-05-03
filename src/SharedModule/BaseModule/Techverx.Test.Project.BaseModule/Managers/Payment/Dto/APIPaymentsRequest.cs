using Techverx.Test.Project.BaseModule.Managers.Header.Dto;
using Techverx.Test.Project.BaseModule.Managers.Total.Dto;

namespace Techverx.Test.Project.BaseModule.Managers.Payment.Dto
{
    public class APIPaymentsRequest
    {
        public HeaderRequestDto Header { get; set; }
        public PaymentRequestDto Payments { get; set; }
        public TotalRequestDto Totals { get; set; }

       public APIPaymentsRequest()
        {
	        Payments=new PaymentRequestDto();
        }

    }
}
