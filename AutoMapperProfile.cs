using AutoMapper;
using Techverx.Test.Project.Dtos.EmployeeDtos;
using Techverx.Test.Project.Dtos.PaymentDtos;
using Techverx.Test.Project.Models;

namespace Techverx.Test.Project
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            //Employee Mappers
            CreateMap<Employee, GetEmployeeDto>();
            CreateMap<Payment, GetPaymentDto>().ReverseMap();
        }

    }
}
