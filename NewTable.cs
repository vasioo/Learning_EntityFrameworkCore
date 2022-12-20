using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LanguageIntegratedQueryInEFC.Models
{
    [Table("newTable")]
    public partial class NewTable
    {
        [Column("DepartmentID")]
        public int DepartmentId { get; set; }
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
    }
}
