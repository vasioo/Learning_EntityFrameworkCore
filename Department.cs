using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ORM.Data.Entity
{
    public class Department
    {
        public Department()
        {
            //this is only a backup but improves performance
            this.Employees = new HashSet<Employee>();
        }
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
