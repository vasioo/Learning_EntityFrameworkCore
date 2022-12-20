using PracticingEFCore.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticingEFCore.Core.Contracts
{
    public interface IEmployeeService
    {
        Task<int> AddEmployee(EmployeeModel model);

        Task<List<EmployeeModel>> GetEmployeesFromTheGivenDepartment(int departmentId);
    }
}
