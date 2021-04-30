using System;using System.Collections.Generic;using System.Linq;using System.Threading.Tasks;using Techverx.Test.Project.DataContext;using Techverx.Test.Project.Models;using Techverx.Test.Project.Models.BankAccount;using Techverx.Test.Project.Models.Banks;namespace Techverx.Test.Project.Seeder{    public class DBSeeder : IDBSeeder    {        private readonly ContextClass _contextClass;        public DBSeeder(ContextClass contextClass)        {            _contextClass = contextClass;        }        public async Task Seed()        {            if (!_contextClass.Employees.Any())            {                await _contextClass.Employees.AddRangeAsync(new List<Employee>            {                new Employee{ FirstName = "John" , Email = "John@gmail.com", Surname = "Alia", ClientCode= "42111", CustomerCode ="3212"},                new Employee{ FirstName = "Lionel" , Email = "Lionel@hotmail.com", Surname = "Messi", ClientCode= "123112", CustomerCode ="3332"},                new Employee{ FirstName = "Neymar" , Email = "Neymar@live.com", Surname = "Jr", ClientCode= "231211", CustomerCode ="5466"},                new Employee{ FirstName = "Isco" , Email = "Isco@gmail.com", Surname = "Alcander", ClientCode= "322303", CustomerCode ="1321"},            });            }            _contextClass.SaveChanges();            if (!_contextClass.Banks.Any())            {                await _contextClass.Banks.AddRangeAsync(new List<Bank>            {                new Bank{ Name = "Zeen" , BranchCode = 4331, Reference = "Zeen Bank"},                new Bank{ Name = "Alfalah" , BranchCode = 5331,Reference = "Alfalah Bank" },                new Bank{ Name = "Sindh" , BranchCode = 2331, Reference = "Sindh Bank"},                new Bank{ Name = "Yelo" , BranchCode = 1331 , Reference = "Yelo Bank"}            });            }            _contextClass.SaveChanges();            if (!_contextClass.Accounts.Any())            {                await _contextClass.Accounts.AddRangeAsync(new List<Account>            {                new Account{ AccountNumber = "01021231" , BankId = 1, EmployeeId = 1, AccountType = 0 , BranchCode= 4801},                new Account{ AccountNumber = "01021232" , BankId = 2, EmployeeId = 2, AccountType = 0 , BranchCode= 2111},                new Account{ AccountNumber = "01021233" , BankId = 3, EmployeeId = 3, AccountType = 0 , BranchCode= 042},                new Account{ AccountNumber = "01021234" , BankId = 4, EmployeeId = 4, AccountType = 0 , BranchCode= 2117}            });            }            _contextClass.SaveChanges();






















            /* if (!_contextClass.Payments.Any())            {            await _contextClass.Payments.AddRangeAsync(new List<Payment>            {            new Payment{PaymentStatus = false,Initials=424.2343, FileAmount = 433.3, BankId = 1, AccountType = 0 , EmployeeId = 1, AmountMultiplier =0, Reference="This is Payment1"},            new Payment{PaymentStatus = false,Initials=424.2343, FileAmount = 433.3, BankId = 2, AccountType = 0 , EmployeeId = 2, AmountMultiplier =0, Reference="This is Payment2"},            new Payment{PaymentStatus = false,Initials=424.2343, FileAmount = 433.3, BankId = 3, AccountType = 0 , EmployeeId = 3, AmountMultiplier =0, Reference="This is Payment3"},            new Payment{PaymentStatus = false,Initials=424.2343, FileAmount = 433.3, BankId = 4, AccountType = 0 , EmployeeId = 4, AmountMultiplier =0, Reference="This is Payment4"}            });            _contextClass.SaveChanges();*/

        }    }}