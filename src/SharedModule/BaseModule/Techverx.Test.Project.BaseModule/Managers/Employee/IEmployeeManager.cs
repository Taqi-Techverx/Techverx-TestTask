using System.Collections.Generic;
using System.Threading.Tasks;
using Techverx.Test.Project.BaseModule.Managers.Employee.Dto;

namespace Techverx.Test.Project.BaseModule.Managers.Employee
{
    public interface IEmployeeManager
    {
        Task<ServiceResponse<GetEmployeeDto>> GetEmployee(int id);
        Task<ServiceResponse<List<GetEmployeeDto>>> GetAllEmployees();
    }
}
