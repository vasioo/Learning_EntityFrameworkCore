using Microsoft.EntityFrameworkCore;
using ORM.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Data
{
    class DbContextTry : DbContext
    {
        public DbContextTry(){}//only for testing
        public DbContextTry(DbContextOptions dbContextOptions)
            :base(dbContextOptions)//for deployment
        {

        }
        public DbSet<Employee> Employees { get; set; }//table
        public DbSet<Department> Departments { get; set; }//table
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.connectionString);
            }
        }
    }
}
