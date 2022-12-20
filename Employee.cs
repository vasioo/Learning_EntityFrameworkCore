using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ORM.Data.Entity
{
    public class Employee
    {
        public Employee()
        {
            
        }
        [Key]//Pk
        public int EmployeeId { get; set; }
        
        [Required]//not null
        [MaxLength(50)]//max length of the varchar(50)
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }//non-required

        [Required]
        [MaxLength(50)]
        public string JobTitle { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }//FK->ABSOLUTELY MUST to have
        public Department Department { get; set; }//nav prop not a must
    }
}
