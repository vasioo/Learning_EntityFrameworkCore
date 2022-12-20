using MusicHub.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Producer
    {
        public Producer()
        {
            this.Albums = new HashSet<Album>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstant.ProducerMaxLength)]
        public string Name { get; set; }

        public string Pseudonym { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
