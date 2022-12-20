using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Configuration
{
    class StudentCourse:IEntityTypeConfiguration<Student>
    {
        
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p => p.StudentId);
            builder.HasNoKey();
        }
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(p => p.CourseId);
            builder.HasNoKey();
        }
    }
}
