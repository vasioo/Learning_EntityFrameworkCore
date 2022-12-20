using EFCoreBestPractices.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracticingEFCore.Core.Contracts;
using PracticingEFCore.Core.Services;
using PracticingEFCore.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace PractisingEFCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddDbContext<SoftUniContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("ConnectionDb"));
                })
                .AddScoped<ISoftUniRepository, SoftUniRepository>()//in case of a change 
                .AddScoped<IEmployeeService, EmployeeService>()
                .BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();

            var service = scope.ServiceProvider.GetService<IEmployeeService>();

            var employees = await service.GetEmployeesFromTheGivenDepartment(7);

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle} {employee.Salary}");
            }
        }
    }
}
