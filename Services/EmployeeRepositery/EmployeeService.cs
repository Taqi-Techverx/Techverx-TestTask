using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Test.Project.DataContext;
using Techverx.Test.Project.Dtos.EmployeeDtos;
using Techverx.Test.Project.Models;

namespace Techverx.Test.Project.Services.EmployeeRepositery
{
	public class EmployeeService : IEmployeeService
	{

		private readonly ContextClass _contextClass;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IMapper _mapper;

		public EmployeeService(ContextClass contextClass, IHttpContextAccessor httpContextAccessor, IMapper mapper)
		{
			_contextClass = contextClass;
			_httpContextAccessor = httpContextAccessor;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<GetEmployeeDto>> GetEmployee(int id)
		{
			var serviceResponse = new ServiceResponse<GetEmployeeDto>();
			var entity = await _contextClass.Employees.FirstOrDefaultAsync(c => c.Id == id);
			serviceResponse.Data = _mapper.Map<GetEmployeeDto>(entity);
			return serviceResponse;
		}
		public async Task<ServiceResponse<List<GetEmployeeDto>>> GetAllEmployees()
		{
			var response = new ServiceResponse<List<GetEmployeeDto>>();
			var query = _contextClass.Employees.AsQueryable();
			response.Data = await query.Select(o => _mapper.Map<GetEmployeeDto>(o)).ToListAsync();
			response.Success = true;
			return response;
		}

	}

}
