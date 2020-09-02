using API2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API2.Infrastructure.Persistance.Configurations
{
    public class InstructorConfiguration:IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(e => e.InstructorId);
            builder.Property(e => e.Name).HasColumnType("varchar(25)");
            builder.Property(e => e.LastName).HasColumnType("varchar(25)");
            builder.Property(e => e.Nivel).HasColumnType("int");
        }
    }
}
