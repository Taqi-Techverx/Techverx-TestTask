using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Test.Project.Dtos.EmployeeDtos;
using Techverx.Test.Project.Models;

namespace Techverx.Test.Project.Services.EmployeeRepositery
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<GetEmployeeDto>> GetEmployee(int id);
        Task<ServiceResponse<List<GetEmployeeDto>>> GetAllEmployees();
    }
}
