using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Test.Project.Dtos.HeaderDtos;
using Techverx.Test.Project.Dtos.TotalsDtos;

namespace Techverx.Test.Project.Dtos.PaymentDtos
{
    public class APIPaymentsRequest
    {
        public HeaderRequestDto Header { get; set; }
        public PaymentRequestDto Payments { get; set; }
        public TotalsRequestDto Totals { get; set; }

       public APIPaymentsRequest()
        {
	        Payments=new PaymentRequestDto();
        }

    }
}
