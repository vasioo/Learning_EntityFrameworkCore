using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LanguageIntegratedQueryInEFC.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
        }

        [Key]
        [Column("DepartmentID")]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("ManagerID")]
        public int? ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        [InverseProperty("Departments")]
        public virtual Employees Manager { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
