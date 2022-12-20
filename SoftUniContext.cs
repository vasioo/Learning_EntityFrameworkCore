using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LanguageIntegratedQueryInEFC.Models
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
        public virtual DbSet<DeletedEmployees> DeletedEmployees { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<EmployeesProjects> EmployeesProjects { get; set; }
        public virtual DbSet<NewTable> NewTable { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }
        public virtual DbSet<VEmployeeNameJobTitle> VEmployeeNameJobTitle { get; set; }
        public virtual DbSet<VEmployeesHiredAfter2000> VEmployeesHiredAfter2000 { get; set; }
        public virtual DbSet<VEmployeesSalaries> VEmployeesSalaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=SoftUni;Integrated Security=true");
            }
        }

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

            modelBuilder.Entity<DeletedEmployees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__Deleted___7AD04F11FD47224E");

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.JobTitle).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MiddleName).IsUnicode(false);
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

            modelBuilder.Entity<EmployeesProjects>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.ProjectId });

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeesProjects)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeesProjects_Employees");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.EmployeesProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeesProjects_Projects");
            });

            modelBuilder.Entity<NewTable>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Towns>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<VEmployeeNameJobTitle>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_EmployeeNameJobTitle");

                entity.Property(e => e.FullName).IsUnicode(false);

                entity.Property(e => e.JobTitle).IsUnicode(false);
            });

            modelBuilder.Entity<VEmployeesHiredAfter2000>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_EmployeesHiredAfter2000");

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });

            modelBuilder.Entity<VEmployeesSalaries>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_EmployeesSalaries");

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
