
using AutoMapper;
using Techverx.Test.Project.BaseModule.Managers.Employee.Dto;
using Techverx.Test.Project.BaseModule.Managers.Payment.Dto;
using Techvetx.Test.Project.Core.Employees;

namespace Techvetx.Test.Project.Core
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, GetEmployeeDto>();
            CreateMap<GetEmployeeDto, Employee>();
            CreateMap<Payment.Payment, GetPaymentDto>().ReverseMap();
        }

    }
}
