using System;
using Hypertrophy.Domain.Exercise;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hypertrophy.Infrastructure.Configurations;

internal class MuscleGroupConfiguration : IEntityTypeConfiguration<MuscleGroupEntity>
{
    public void Configure(EntityTypeBuilder<MuscleGroupEntity> builder)
    {
        builder.ToTable("muscle_groups");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever(); // seeded from enum numeric value

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired();

        builder.Entity<MuscleGroupEntity>().HasData(
        Enum.GetValues<eMuscleGroup>()
        .Select(e => new MuscleGroupEntity
        {
            Id = (int)e,
            Name = e.ToString()
        })
        );
    }
}
