using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;
using Techverx.Test.Project.DataContext;
using Techverx.Test.Project.Dtos.EmployeeDtos;
using Techverx.Test.Project.Dtos.FileContentsDto;
using Techverx.Test.Project.Dtos.HeaderDtos;
using Techverx.Test.Project.Dtos.PaymentDtos;
using Techverx.Test.Project.Dtos.PaySoft;
using Techverx.Test.Project.Dtos.TotalsDtos;
using Techverx.Test.Project.Enums;
using Techverx.Test.Project.Enums.PaymentEnums;
using Techverx.Test.Project.Models;
using Techverx.Test.Project.ProxyService;
using Techverx.Test.Project.Utitlity;

namespace Techverx.Test.Project.Services.PaymentRepositery
{
    public class PaymentService : IPaymentService
    {
	    private readonly IConfiguration _config;
        private readonly ContextClass _contextClass;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IProxyService _proxyService;

        public PaymentService(ContextClass contextClass,
	        IConfiguration config,
            IHttpContextAccessor httpContextAccessor, IMapper mapper,
	        IProxyService proxyService)
        {
            _contextClass = contextClass;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _proxyService = proxyService;
            _config = config;
        }

        public async Task<Response> RequestPaymentAsync(PaymentCreator input)
        {

	        var request = await MakeHeader(input);

           var response= await _proxyService.Send(XmlRequestGenerator.Serialize(request));
	       if (response.Result.Equals("Error"))
	       {
		       await SavePayment(2, request, response);
	       }
	       else if (response.Result.Equals("OK"))
	       {
		       await SavePayment(1, request, response);
	       } return response;
        }
    
        public async Task<ServiceResponse<List<GetPaymentDto>>> GetAllPayments(string clientCode)
        {
	        return new ServiceResponse<List<GetPaymentDto>>
	        {
		        Data = await _contextClass.Payments.Where(x => x.Client.Equals(clientCode))
			        .Select(payment => new
				        GetPaymentDto
				        {
                            Reference = payment.Reference,
                            ResultMessage = payment.ResultMessage,
                            Result = payment.Result,
					        FileAmount = payment.FileAmount,
					        AmountMultiplier = payment.AmountMultiplier,
					        PaymentStatus = (int) payment.PaymentStatus,
					        EmployeeCode = payment.Client,
					        Id = payment.Id
				        }).ToListAsync(),
		        Success = true
	        };
        }

        public async Task UpdatePayment(Dtos.CallBack.Response input)
        {
	       var payment= await _contextClass.Payments.OrderBy(x=>x.Id).LastOrDefaultAsync(x=>x.AccountNumber.Equals(input.PaymentResults.Result.AccountNumber));
	        
	       if (input.Result.ToLower().Equals("ok"))
	       {
		       payment.PaymentStatus = PaymentStatus.Success;
		       payment.Result = input.Result;
		       payment.ResultMessage = input.PaymentResults.Result.ResultMessage; 
		       await _contextClass.SaveChangesAsync();
	       }
        }

        private async Task<APIPaymentsRequest> MakeHeader(PaymentCreator input)
        {
            var apiPaymentsRequest = new APIPaymentsRequest();
            var entity = await _contextClass.Employees.
	            Include(x => x.Account)
	            .ThenInclude(x=>x.Bank)
	            .FirstOrDefaultAsync(x => x.Id== input.EmployeeId);
            var file = new FileContentsRequestDto
            {
                Reference = entity.Account.Bank.Reference,
                AccountType = entity.Account.AccountType,
                AmountMultiplier = FileAmountType.Cents,
                AccountNumber = entity.Account.AccountNumber,
                FileAmount = 100,
                BranchCode = entity.Account.BranchCode,
                FirstName = entity.FirstName,
                Surname = entity.Surname
            };
            apiPaymentsRequest.Payments.FileContents = file;
            apiPaymentsRequest.Header = new HeaderRequestDto
            {
                Service = input.Service,
                ServiceType = input.ServiceType,
               CallBackUrl = _config["PaySoft:CallBackUrl"],
               Client = entity.ClientCode,
               PsVer = _config["PaySoft:PsVer"],
               DueDate = "20200625"
            };
            apiPaymentsRequest.Totals = new TotalsRequestDto
            {
                Records = 1,
                Amount = 100,
                AccountHash = file.BranchCode,
                BranchHash = file.BranchCode
            };
            return apiPaymentsRequest;
        }
        private async Task SavePayment(int status, APIPaymentsRequest input, Response response)
        {
	        await _contextClass.Payments.AddAsync(new Payment
	        {
                AmountMultiplier = FileAmountType.Cents,
                 Client=input.Header.Client,
                FileAmount = input.Payments.FileContents.FileAmount,
                PaymentStatus =(PaymentStatus) status,
                Reference = input.Payments.FileContents.Reference,
                BranchCode = input.Payments.FileContents.BranchCode,
                AccountNumber = input.Payments.FileContents.AccountNumber,
                Result = response.Result,
                ResultMessage = status==2?response.ResultMessage:string.Empty,
            });
	        await _contextClass.SaveChangesAsync();
        }
    }




}
