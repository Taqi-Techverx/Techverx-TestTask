using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Techverx.Test.Project.BaseModule.Managers.Employee;

namespace Techverx.Test.Project.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeManager _employeeManager;
		public EmployeeController(IEmployeeManager employeeManager)
		{
			_employeeManager = employeeManager;
		}

		[HttpGet("Get")]
		public async Task<IActionResult> Get()
		{
			var response = await _employeeManager.GetAllEmployees();
			return Ok(response);
		}
		[HttpGet("GetById")]
		public async Task<IActionResult> GetById(int id)
		{
			return Ok(await _employeeManager.GetEmployee(id));
		}
	}
}