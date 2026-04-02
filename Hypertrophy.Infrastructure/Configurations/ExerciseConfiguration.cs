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

        builder.HasMany(x => x.MuscleGroups)
           .WithOne(x => x.Exercise)
           .HasForeignKey(x => x.ExerciseId);

        builder.Property(x => x.Equipment)
            .HasColumnName("equipment")
            .HasConversion<int>();

        builder.OwnsMany(x => x.ExerciseMedia, media =>
        {
            media.ToTable("exercise_media");
            media.WithOwner()
            .HasForeignKey("exercise_id");

            media.Property<Guid>("id");
            media.HasKey("id");

            media.Property(m => m.Kind)
                .HasColumnName("kind")
                .HasConversion<int>();

            media.Property(m => m.Url)
            .HasColumnName("url")
            .HasColumnType("text")
            .HasConversion(
                uri => uri == null ? null : uri.ToString(),
                value => string.IsNullOrWhiteSpace(value) ? null :
                new Uri(value, UriKind.Absolute)
            );

            media.Property(m => m.ThumbnailUrl)
                .HasColumnName("thumbnail_url")
                .HasColumnType("text");

            media.Property(m => m.MimeType)
                .HasColumnName("mime_type")
                .HasMaxLength(100);
            media.Property(m => m.Width)
                .HasColumnName("width");

            media.Property(m => m.Height)
                .HasColumnName("height");

            media.Property(m => m.Duration)
                .HasColumnName("duration");
        });
    }
}
