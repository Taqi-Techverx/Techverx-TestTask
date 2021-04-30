using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Test.Project.Dtos.PaySoft;

namespace Techverx.Test.Project.ProxyService
{
	public interface IProxyService
	{
		Task<Response> Send(string date);
	}
}
