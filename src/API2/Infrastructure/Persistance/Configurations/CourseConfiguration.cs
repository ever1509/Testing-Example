using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API2.Infrastructure.Persistance.Configurations
{
    public class CourseConfiguration:IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(e => e.CourseId);
            builder.Property(e => e.Title).HasColumnType("varchar(20)");
            builder.Property(e => e.Location).HasColumnType("varchar(25)");
            builder.Property(e => e.Department).HasColumnType("varchar(25)");


            builder.HasOne(e => e.Student)
                .WithMany(d => d.Courses)
                .HasForeignKey(e => e.StudentId)
                .HasConstraintName("FK_Couse_Student");

            builder.HasOne(e => e.Instructor)
                .WithMany(d => d.Courses)
                .HasForeignKey(e => e.StudentId)
                .HasConstraintName("FK_Couse_Instructor");

        }
    }
}
