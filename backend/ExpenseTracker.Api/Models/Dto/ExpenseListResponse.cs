namespace ExpenseTracker.Api.Models.Dto;

public class ExpenseListResponse
{
    public List<ExpenseResponse> Expenses { get; set; } = new();
    public int Total { get; set; }
    public PageInfo PageInfo { get; set; } = new();
}

public class PageInfo
{
    public int Page { get; set; }
    public int Limit { get; set; }
    public int TotalPages { get; set; }
    public bool HasNext { get; set; }
    public bool HasPrevious { get; set; }
}