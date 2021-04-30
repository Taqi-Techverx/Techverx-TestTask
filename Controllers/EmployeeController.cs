using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Techverx.Test.Project.Services.EmployeeRepositery;

namespace Techverx.Test.Project.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeService _employeeService;
		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet("Get")]
		public async Task<IActionResult> Get()
		{
			var response = await _employeeService.GetAllEmployees();
			return Ok(response);
		}
		[HttpGet("GetById")]
		public async Task<IActionResult> GetById(int id)
		{
			return Ok(await _employeeService.GetEmployee(id));
		}
	}
}