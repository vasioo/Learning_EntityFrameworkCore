using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LanguageIntegratedQueryInEFC.Models
{
    public partial class Addresses
    {
        public Addresses()
        {
            Employees = new HashSet<Employees>();
        }

        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }
        [Required]
        [StringLength(100)]
        public string AddressText { get; set; }
        [Column("TownID")]
        public int? TownId { get; set; }

        [ForeignKey(nameof(TownId))]
        [InverseProperty(nameof(Towns.Addresses))]
        public virtual Towns Town { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
