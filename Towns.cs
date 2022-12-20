using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PracticingEFCore.Infrastructure.Data.Models
{
    public partial class Towns
    {
        public Towns()
        {
            Addresses = new HashSet<Addresses>();
        }

        [Key]
        [Column("TownID")]
        public int TownId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("Town")]
        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
