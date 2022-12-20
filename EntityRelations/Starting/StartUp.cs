using SoftUni.Data.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext softUniCon = new SoftUniContext();
            //string result = method(softUniCon);
            //Console.WriteLine(result);
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var allEmployees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                })
                .ToArray();

            foreach (var e in allEmployees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var allEmployees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();
            foreach (var employee in allEmployees)
            {
                stringBuilder.
                    AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder builder = new StringBuilder();
            var allEmployees = context
                .Employees
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName
                ,
                    e.LastName
                ,
                    DepartmentName = e.Department.Name
                ,
                    e.Salary
                })
                .Where(e => e.DepartmentName == "Research and Development")
                .ToArray();
            foreach (var employee in allEmployees)
            {
                builder
                    .AppendLine($"{employee.FirstName} {employee.LastName}" +
                    $" from {employee.DepartmentName} - {employee.Salary:f2}");
            }
            return builder.ToString().TrimEnd();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(address);
            Employee nakov = context
                .Employees
                .First(e => e.LastName == "Nakov");
            nakov.Address = address;
            context.SaveChangesAsync();
            var addresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(a=>a.Address.AddressText)
                .ToArray();

            foreach (var addressator in addresses)
            {
                sb.AppendLine(addressator);
            }
                return sb.ToString().TrimEnd();
        }
    }
}