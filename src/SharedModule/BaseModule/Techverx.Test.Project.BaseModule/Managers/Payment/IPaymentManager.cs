using System.Collections.Generic;
using System.Threading.Tasks;
using Techverx.Test.Project.BaseModule.Managers.Header.Dto;
using Techverx.Test.Project.BaseModule.Managers.Payment.Dto;
using Techverx.Test.Project.BaseModule.Managers.PaySoft.Dto;
using Techverx.Test.Project.Dtos.PaySoft;

namespace Techverx.Test.Project.BaseModule.Managers.Payment
{
    public interface IPaymentManager
    {
	    Task<Response> RequestPaymentAsync(PaymentCreator input);
        Task<ServiceResponse<List<GetPaymentDto>>> GetAllPayments(string clientCode);
        Task UpdatePayment(BaseModule.Managers.CallBack.Dto.Response input);


    }
}
