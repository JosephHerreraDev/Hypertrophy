namespace Hypertrophy.Domain.Shared;

public sealed record Media(
    eMediaKind Kind,
    Uri Url,
    string? ThumbnailUrl = null,
    string? MimeType = null,
    int? Width = null,
    int? Height = null,
    TimeSpan? Duration = null
);