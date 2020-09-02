using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API2.Infrastructure.Persistance.Configurations
{
    public class StudentConfiguration:IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(e => e.StudentId);
            builder.Property(e => e.Age).HasColumnType("int");
            builder.Property(e => e.DateOfBirth).HasColumnType("date");
            builder.Property(e => e.Name).HasColumnType("varchar(25)");
            builder.Property(e => e.LastName).HasColumnType("varchar(25)");
            builder.Property(e => e.Email).HasColumnType("varchar(50)");
            builder.Property(e => e.Phone).HasColumnType("varchar(8)");
            
        }
    }
}
