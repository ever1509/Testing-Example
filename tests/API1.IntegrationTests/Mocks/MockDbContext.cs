using System;
using System.Collections.Generic;
using System.Text;
using API1.IntegrationTests.Attributes;
using API1.Models;
using API1.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace API1.IntegrationTests.Mocks
{
    public class MockDbContext:ApplicationDbContext
    {
        public MockDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }
        [SeedData("Student")]
        public override DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(k=>k.StudentId);
            modelBuilder.Entity<Student>()
                .Property(e => e.Age).HasColumnType("int");
            modelBuilder.Entity<Student>()
                .Property(e => e.DateBirth).HasColumnType("date");
            modelBuilder.Entity<Student>()
                .Property(e => e.Name).HasColumnType("varchar(25)");
            modelBuilder.Entity<Student>()
                .Property(e => e.LastName).HasColumnType("varchar(25)");
            modelBuilder.Entity<Student>()
                .Property(e => e.Email).HasColumnType("varchar(50)");
            modelBuilder.Entity<Student>()
                .Property(e => e.Phone).HasColumnType("varchar(8)");
        }
    }
}
