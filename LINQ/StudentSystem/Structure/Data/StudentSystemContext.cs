using Microsoft.EntityFrameworkCore;
using P01_StudentSystem;
using P01_StudentSystem.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    class StudentSystemContext:DbContext
    {
        public StudentSystemContext(){}
        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            :base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentCourse());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=true");
            }
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<HomeworkSubmission> HomeworkSubmissions { get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Resource> Resources{ get; set; }
    }
}
