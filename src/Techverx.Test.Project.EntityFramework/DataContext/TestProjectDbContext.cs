using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Techvetx.Test.Project.Core.BankAccount;
using Techvetx.Test.Project.Core.Banks;
using Techvetx.Test.Project.Core.Employees;
using Techvetx.Test.Project.Core.Payment;

namespace Techverx.Test.Project.EntityFramework.DataContext
{
    public class TestProjectDbContext : DbContext
    {
        public TestProjectDbContext(DbContextOptions<TestProjectDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
    //public class TestProjectDbContextFactory : IDesignTimeDbContextFactory<TestProjectDbContext>
    //{
    //    public TestProjectDbContextFactory(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    public IConfiguration Configuration { get; }
    //    public TestProjectDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<TestProjectDbContext>();
    //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

    //        return new TestProjectDbContext(optionsBuilder.Options);
    //    }
    //}
}
