namespace PrinterManagerServer.Types.Responses;

public class ListResponse<TItem>(IEnumerable<TItem> items) where TItem : class
{
    public IEnumerable<TItem> Items { get; set; } = items.ToList();
    public int Count { get; set; } = items.Count();
}