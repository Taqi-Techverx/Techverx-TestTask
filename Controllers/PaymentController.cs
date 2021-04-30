using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Techverx.Test.Project.Dtos.CallBack;
using Techverx.Test.Project.Dtos.EmployeeDtos;
using Techverx.Test.Project.Dtos.HeaderDtos;
using Techverx.Test.Project.Dtos.PaymentDtos;
using Techverx.Test.Project.Services.PaymentRepositery;

namespace Techverx.Test.Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
		[HttpGet("Get")]
		public async Task<IActionResult> Get(string clientCode)
		{
			return Ok(await _paymentService.GetAllPayments(clientCode));
		}

		[HttpPost("PaymentRequest")]
		public async Task<IActionResult> PaymentRequest(PaymentCreator input)
		{
			return Ok(await _paymentService.RequestPaymentAsync(input));
		}

		[Consumes("application/xml")]
        [Produces("application/xml")]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [HttpPost("PaymentCallBack")]
        public async Task PaymentCallBack([FromBody]Response input)
        {
	        await _paymentService.UpdatePayment(input);
        }
    }
}
