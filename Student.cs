using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }
        public DateTime Birthday { get; set; }
    }
}
