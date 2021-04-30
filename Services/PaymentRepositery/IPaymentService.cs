using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Test.Project.Dtos.HeaderDtos;
using Techverx.Test.Project.Dtos.PaymentDtos;
using Techverx.Test.Project.Dtos.PaySoft;
using Techverx.Test.Project.Models;

namespace Techverx.Test.Project.Services.PaymentRepositery
{
    public interface IPaymentService
    {
	    Task<Response> RequestPaymentAsync(PaymentCreator input);
        Task<ServiceResponse<List<GetPaymentDto>>> GetAllPayments(string clientCode);
        Task UpdatePayment(Dtos.CallBack.Response input);


    }
}
