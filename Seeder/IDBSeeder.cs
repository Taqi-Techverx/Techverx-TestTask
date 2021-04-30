using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Techverx.Test.Project.Seeder
{
	public interface IDBSeeder
	{
		Task Seed();
	}
}