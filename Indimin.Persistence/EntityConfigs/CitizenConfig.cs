using Indimin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indimin.Persistence.EntityConfigs;

public class CitizenConfig : IEntityTypeConfiguration<Citizen>
{
    public void Configure(EntityTypeBuilder<Citizen> builder)
    {
        builder.ToTable("Citizens");
        
        builder.HasKey(citizen => citizen.Id);
        builder.Property(citizen => citizen.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("citizen_id")
            .HasColumnType("UniqueIdentifier");
        
        builder.Property(citizen => citizen.Name)
            .HasColumnName("citizen_name")
            .HasColumnType("nvarchar(50)")
            .IsRequired();
        
        builder.Property(citizen => citizen.Lastname)
            .HasColumnName("citizen_lastname")
            .HasColumnType("nvarchar(50)")
            .IsRequired();

        builder.HasMany(task => task.Tareas)
            .WithOne(c => c.Citizen)
            .HasForeignKey(c => c.CitizenId)
            .IsRequired(false);

    }
}