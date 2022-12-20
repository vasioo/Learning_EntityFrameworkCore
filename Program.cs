using LanguageIntegratedQueryInEFC.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LanguageIntegratedQueryInEFC
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(e => e.DepartmentId == 6)
                    .Include(e => e.Address)
                    .ThenInclude(a => a.Town)
                    .Select(e => new
                    {
                        FullName = $"{e.FirstName} {e.LastName}",
                        JobTitle = e.JobTitle,
                        Town = e.Address.Town.Name    
                    })
                    .GroupBy(e=>e.Town)
                    .ToList();
            }
        }
    }
}
