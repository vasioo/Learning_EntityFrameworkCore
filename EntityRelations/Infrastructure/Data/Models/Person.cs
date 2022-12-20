using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Data.Models
{
    public class Person
    {
        public Person()
        {
            Pets = new List<Dog>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public List<Dog> Pets { get; set; }
    }
}
