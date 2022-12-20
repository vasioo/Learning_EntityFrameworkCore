using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.Data.Models
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey(nameof(PersonId))]
        public int PersonId { get; set; }

        public Person Owner { get; set; }
    }
}
