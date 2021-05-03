using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Techverx.Test.Project.BaseModule;
using Techverx.Test.Project.BaseModule.Managers.Employee;
using Techverx.Test.Project.BaseModule.Managers.Employee.Dto;
using Techverx.Test.Project.EntityFramework.DataContext;

namespace Techverx.Test.Project.CoreApp.Employees.Manager
{
	public class EmployeeManager : IEmployeeManager
	{

		private readonly TestProjectDbContext _dbContext;
		

		public EmployeeManager(TestProjectDbContext dbContext)
		{
			_dbContext = dbContext;
        }

		public async Task<ServiceResponse<GetEmployeeDto>> GetEmployee(int id)
		{
			var serviceResponse = new ServiceResponse<GetEmployeeDto>();
			var entity = await _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == id);
			var empDto = new GetEmployeeDto()
            {
				ClientCode = entity.ClientCode,
				CustomerCode = entity.CustomerCode,
				FirstName = entity.FirstName,
				Id = entity.Id,
				Surname = entity.Surname
            };
			serviceResponse.Data = empDto;
			return serviceResponse;
		}
		public async Task<ServiceResponse<List<GetEmployeeDto>>> GetAllEmployees()
		{
			var response = new ServiceResponse<List<GetEmployeeDto>>();
			var query =  _dbContext.Employees.AsQueryable();
            var listOfEmptDto = await query.Select(employee => new GetEmployeeDto()
                {
                    ClientCode = employee.ClientCode,
                    CustomerCode = employee.CustomerCode,
                    FirstName = employee.FirstName,
                    Id = employee.Id,
                    Surname = employee.Surname
                })
                .ToListAsync();
            response.Data = listOfEmptDto;
			response.Success = true;
			return response;
		}

	}

}
