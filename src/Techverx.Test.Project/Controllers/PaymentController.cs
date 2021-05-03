using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Techverx.Test.Project.BaseModule.Managers.Header.Dto;
using Techverx.Test.Project.BaseModule.Managers.Payment;
using Techverx.Test.Project.BaseModule.Managers.CallBack.Dto;

namespace Techverx.Test.Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManager _paymentManager;
        public PaymentController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }
		[HttpGet("Get")]
		public async Task<IActionResult> Get(string clientCode)
		{
			return Ok(await _paymentManager.GetAllPayments(clientCode));
		}

		[HttpPost("PaymentRequest")]
		public async Task<IActionResult> PaymentRequest(PaymentCreator input)
		{
			return Ok(await _paymentManager.RequestPaymentAsync(input));
		}

		[Consumes("application/xml")]
        [Produces("application/xml")]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [HttpPost("PaymentCallBack")]
        public async Task PaymentCallBack([FromBody]Response input)
        {
	        await _paymentManager.UpdatePayment(input);
        }
    }
}
