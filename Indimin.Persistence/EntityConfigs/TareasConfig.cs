using Indimin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indimin.Persistence.EntityConfigs;

public class TaskConfig : IEntityTypeConfiguration<Tareas>
{
    public void Configure(EntityTypeBuilder<Tareas> builder)
    {
        builder.ToTable("Tasks");
        
        builder.HasKey(task => task.Id);
        builder.Property(task => task.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("task_id")
            .HasColumnType("UniqueIdentifier");
        
        builder.Property(task => task.Name)
            .HasColumnName("name")
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder.Property(task => task.Description)
            .HasColumnName("description")
            .HasColumnType("nvarchar(255)");
        
        builder.Property(task => task.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(task => task.IsCompleted)
            .HasColumnName("is_completed")
            .HasColumnType("bit");
        
        // builder.Property(task => task.IsDeleted)
        //     .HasColumnName("is_deleted")
        //     .HasColumnType("bit");

        builder.Property(task => task.CitizenId)
            .HasColumnName("citizen_id");

        // builder.HasOne(c => c.Citizen)
        //     .WithMany(c => c.Tareas)
        //     .HasForeignKey(c => c.CitizenId)
        //     .IsRequired(false);

    }
}