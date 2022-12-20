using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ORM.Data;
using ORM.Data.Entity;
namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            using DbContextTry dbContext = new DbContextTry();
            Department it = new Department() { Name = "IT" };
            Department hr = new Department() { Name = "HR" };
            Department pr = new Department() { Name = "PR" };

            dbContext.Departments.Add(it);
            dbContext.Departments.Add(hr);
            dbContext.Departments.Add(pr);
            Employee josh = new Employee()
            {
                FirstName = "Josh",
                LastName = "Smith",
                JobTitle = "JavaScript",
                Department = it
            };
            Employee maria = new Employee()
            {
                FirstName = "Maria",
                LastName = "Ivanova",
                JobTitle = "Recruiter(Don't smoke)",
                Department = hr
            };
            Employee goshko = new Employee()
            {
                FirstName = "Goshko",
                LastName = "Goshkov",
                JobTitle = "idk what pr is",
                Department = pr
            };
            dbContext.Employees.Add(josh);
            dbContext.Employees.Add(maria);
            dbContext.Employees.Add(goshko);
            dbContext.SaveChanges();//end of transaction
            Console.WriteLine("Successful command!!!");

            int searchId = 2;
            Department dep2 = dbContext
                .Departments
                .Find(searchId);

            Employee joshnot =
                 dbContext.Employees
                .First(e => e.FirstName == "Pesho");
            joshnot.FirstName = "Josa";
            dbContext.SaveChanges();

            dbContext.Employees.Remove(joshnot);
            dbContext.SaveChanges();

            var itEmployees =
                dbContext.Employees
                .Where(e => e.Department.Name == "IT")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle
                })
                .ToList();

            Console.WriteLine("Department of the it sector");
            Console.WriteLine("----------------------------");
            foreach (var employee in itEmployees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            }
        }
    }
}
