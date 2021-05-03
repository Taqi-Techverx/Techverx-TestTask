using System.Threading.Tasks;
using Techverx.Test.Project.BaseModule.Managers.PaySoft.Dto;
using Techverx.Test.Project.Dtos.PaySoft;

namespace Techverx.Test.Project.BaseModule.Managers.CallBack
{
	public interface IProxyService
	{
		Task<Response> Send(string date);
	}
}
