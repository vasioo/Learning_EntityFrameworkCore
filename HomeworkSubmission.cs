using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem
{
    public class HomeworkSubmission
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        public string Content { get; set; }

        public enum ContentType
        {
            Application
           , Pdf
           , Zip
        }

        public DateTime SubmissionTime { get; set; }

        [ForeignKey(nameof(StudentId))]
        public int StudentId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public int CourseId { get; set; }
    }
}
