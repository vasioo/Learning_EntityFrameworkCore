using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PracticingEFCore.Infrastructure.Data.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PracticingEFCore.Infrastructure.Data
{
    public partial class SoftUniContext : DbContext
    {
        public SoftUniContext()
        {
        }

        public SoftUniContext(DbContextOptions<SoftUniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.Property(e => e.AddressText).IsUnicode(false);

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.TownId)
                    .HasConstraintName("FK_Addresses_Towns");
            });

           
            modelBuilder.Entity<Departments>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Departments_Employees");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.JobTitle).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MiddleName).IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Employees_Addresses");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Departments");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Employees_Employees");
            });

            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
