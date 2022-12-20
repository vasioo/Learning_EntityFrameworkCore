using EFCoreBestPractices.Infrastructure.Data.Common;
using PracticingEFCore.Core.Contracts;
using PracticingEFCore.Core.Models;
using PracticingEFCore.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PracticingEFCore.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ISoftUniRepository repository;

        public EmployeeService(ISoftUniRepository _repository)
        {
            repository = _repository;//Dependency injection 
        }

        public Task<int> AddEmployee(EmployeeModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmployeeModel>> GetEmployeesFromTheGivenDepartment(int departmentId)
        {
            return await repository.AllReadonly<Employees>()
                .Where(empl => empl.DepartmentId == departmentId)
                .Select(empl => new EmployeeModel()
                {
                    FirstName= empl.FirstName,
                    HireDate = empl.HireDate,
                    Id = empl.EmployeeId,
                    JobTitle = empl.JobTitle,
                    LastName=empl.LastName,
                    MiddleName = empl.MiddleName,
                    Salary= empl.Salary
                })
                .ToListAsync();
        }
    }
}
