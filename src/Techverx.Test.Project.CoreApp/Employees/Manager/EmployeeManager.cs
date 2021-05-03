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
		private readonly IMapper _mapper;

		public EmployeeManager(TestProjectDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
            _mapper = mapper;
		}

		public async Task<ServiceResponse<GetEmployeeDto>> GetEmployee(int id)
		{
			var serviceResponse = new ServiceResponse<GetEmployeeDto>();
			var entity = await _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == id);
			serviceResponse.Data = _mapper.Map<GetEmployeeDto>(entity);
			return serviceResponse;
		}
		public async Task<ServiceResponse<List<GetEmployeeDto>>> GetAllEmployees()
		{
			var response = new ServiceResponse<List<GetEmployeeDto>>();
			var query = _dbContext.Employees.AsQueryable();
			response.Data = await query.Select(o => _mapper.Map<GetEmployeeDto>(o)).ToListAsync();
			response.Success = true;
			return response;
		}

	}

}
