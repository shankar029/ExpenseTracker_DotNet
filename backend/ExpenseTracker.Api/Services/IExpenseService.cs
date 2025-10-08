using ExpenseTracker.Api.Models;
using ExpenseTracker.Api.Models.Dto;

namespace ExpenseTracker.Api.Services;

public interface IExpenseService
{
    Task<ExpenseListResponse> GetExpensesAsync(int userId, int page = 1, int limit = 10, string? category = null, DateTime? dateFrom = null, DateTime? dateTo = null);
    Task<ExpenseResponse?> GetExpenseByIdAsync(int expenseId, int userId);
    Task<ExpenseResponse> CreateExpenseAsync(CreateExpenseRequest request, int userId);
    Task<ExpenseResponse?> UpdateExpenseAsync(int expenseId, UpdateExpenseRequest request, int userId);
    Task<bool> DeleteExpenseAsync(int expenseId, int userId);
    Task<string[]> GetCategoriesAsync();
}