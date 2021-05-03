using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Techverx.Test.Project.BaseModule;
using Techverx.Test.Project.BaseModule.Managers.CallBack;
using Techverx.Test.Project.BaseModule.Managers.Enums;
using Techverx.Test.Project.BaseModule.Managers.FileContent.Dto;
using Techverx.Test.Project.BaseModule.Managers.Header.Dto;
using Techverx.Test.Project.BaseModule.Managers.Payment;
using Techverx.Test.Project.BaseModule.Managers.Payment.Dto;
using Techverx.Test.Project.BaseModule.Managers.PaySoft.Dto;
using Techverx.Test.Project.BaseModule.Managers.Total.Dto;
using Techverx.Test.Project.CoreApp.RequestGenerator;
using Techverx.Test.Project.EntityFramework.DataContext;
using Techvetx.Test.Project.Core.Payment;

namespace Techverx.Test.Project.CoreApp.APIPaymentRequests.Manager
{
    public class PaymentManager : IPaymentManager
    {
	    private readonly IConfiguration _config;
        private readonly TestProjectDbContext _dbContext;
        private readonly IProxyService _proxyService;

        public PaymentManager(EntityFramework.DataContext.TestProjectDbContext dbContext,
	        IConfiguration config,
            IProxyService proxyService)
        {
            _dbContext = dbContext;
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
		        Data = await _dbContext.Payments.Where(x => x.Client.Equals(clientCode))
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

        public async Task UpdatePayment(BaseModule.Managers.CallBack.Dto.Response input)
        {
	       var payment= await _dbContext.Payments.OrderBy(x=>x.Id).LastOrDefaultAsync(x=>x.AccountNumber.Equals(input.PaymentResults.Result.AccountNumber));
	        
	       if (input.Result.ToLower().Equals("ok"))
	       {
		       payment.PaymentStatus = PaymentStatus.Success;
		       payment.Result = input.Result;
		       payment.ResultMessage = input.PaymentResults.Result.ResultMessage; 
		       await _dbContext.SaveChangesAsync();
	       }
        }

        private async Task<APIPaymentsRequest> MakeHeader(PaymentCreator input)
        {
            var apiPaymentsRequest = new APIPaymentsRequest();
            var entity = await _dbContext.Employees.
	            Include(x => x.Account)
	            .ThenInclude(x=>x.Bank)
	            .FirstOrDefaultAsync(x => x.Id== input.EmployeeId);
            var file = new FileContentRequestDto
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
            apiPaymentsRequest.Totals = new TotalRequestDto
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
	        await _dbContext.Payments.AddAsync(new Payment
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
	        await _dbContext.SaveChangesAsync();
        }
    }




}
