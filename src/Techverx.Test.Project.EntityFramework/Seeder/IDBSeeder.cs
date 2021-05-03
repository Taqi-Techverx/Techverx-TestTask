using System.Threading.Tasks;

namespace Techverx.Test.Project.EntityFramework.Seeder
{
	public interface IDBSeeder
	{
		Task Seed();
	}
}