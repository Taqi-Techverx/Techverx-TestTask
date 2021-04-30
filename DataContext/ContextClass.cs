using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techverx.Test.Project.Models;
using Techverx.Test.Project.Models.BankAccount;
using Techverx.Test.Project.Models.Banks;

namespace Techverx.Test.Project.DataContext
{
    public class ContextClass : DbContext
    {
        public ContextClass(DbContextOptions<ContextClass> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
