using Hypertrophy.Domain.Exercise;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hypertrophy.Infrastructure.Configurations;

internal class ExerciseConfiguration : IEntityTypeConfiguration<ExerciseEntity>
{
    public void Configure(EntityTypeBuilder<ExerciseEntity> builder)
    {
        builder.ToTable("exercises");

        builder.HasKey(prop => prop.Id);

        builder.Property(prop => prop.Id)
        .HasConversion(Id => Id!.Value, value => new ExerciseId(value));

        builder.Property(x => x.Name)
        .HasColumnName("name")
        .HasMaxLength(200)
        .IsRequired();

        builder.Property(x => x.PrimaryMuscleGroup)
            .HasColumnName("primary_muscle_groups")
            .HasColumnType("jsonb");

        builder.Property(x => x.SecondaryMuscleGroup)
            .HasColumnName("secondary_muscle_groups")
            .HasColumnType("jsonb");

        builder.Property(x => x.Equipment)
            .HasColumnName("equipment")
            .HasConversion<int>();

        builder.Property(x => x.ExerciseMedia)
            .HasColumnName("exercise_media")
            .HasColumnType("jsonb");

    }
}
