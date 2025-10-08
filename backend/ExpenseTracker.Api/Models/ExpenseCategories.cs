namespace ExpenseTracker.Api.Models;

public static class ExpenseCategories
{
    public static readonly string[] AllCategories = 
    {
        "Food",
        "Transportation",
        "Entertainment",
        "Healthcare",
        "Shopping",
        "Utilities",
        "Other"
    };

    public const string Food = "Food";
    public const string Transportation = "Transportation";
    public const string Entertainment = "Entertainment";
    public const string Healthcare = "Healthcare";
    public const string Shopping = "Shopping";
    public const string Utilities = "Utilities";
    public const string Other = "Other";

    public static bool IsValidCategory(string category)
    {
        return AllCategories.Contains(category, StringComparer.OrdinalIgnoreCase);
    }
}