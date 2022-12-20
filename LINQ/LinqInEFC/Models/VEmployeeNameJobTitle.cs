using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LanguageIntegratedQueryInEFC.Models
{
    public partial class VEmployeeNameJobTitle
    {
        [Required]
        [Column("Full Name")]
        [StringLength(152)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }
    }
}
