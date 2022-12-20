using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public enum ResourceType
        {
            Video
                , Presentation
                , Document
                , Other
        }
        [Required]
        public string Url { get; set; }
        
        [ForeignKey(nameof(CourseId))]
        public int CourseId { get; set; }
    }
}
