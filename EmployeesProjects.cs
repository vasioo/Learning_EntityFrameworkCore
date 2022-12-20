using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LanguageIntegratedQueryInEFC.Models
{
    public partial class EmployeesProjects
    {
        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Key]
        [Column("ProjectID")]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(Employees.EmployeesProjects))]
        public virtual Employees Employee { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty(nameof(Projects.EmployeesProjects))]
        public virtual Projects Project { get; set; }
    }
}
