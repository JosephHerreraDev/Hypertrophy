namespace Hypertrophy.Domain.Abstractions;

public class PagedResults<TItem>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalNumberOfPages { get; set; }
    public int TotalNumberOfRecords { get; set; }
    public List<TItem> Results { get; set; } = new();
}