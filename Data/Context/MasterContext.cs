using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class MasterContext : DbContext
    {
        public MasterContext() 
        {

        }
        public MasterContext(DbContextOptions<MasterContext> dbContext)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Configure etmek için 
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=CoreCRUD;Uid=root;Pwd=123456;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Project>().HasKey(x => x.Id);
            modelBuilder.Entity<ProjectRole>().HasKey(x => x.Id);
        }
        public DbSet<User> users { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<ProjectRole> projectRoles { get; set; }



    }
}
