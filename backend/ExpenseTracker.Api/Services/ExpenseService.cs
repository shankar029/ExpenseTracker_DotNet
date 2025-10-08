using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.Models;
using ExpenseTracker.Api.Models.Dto;

namespace ExpenseTracker.Api.Services;

public class ExpenseService : IExpenseService
{
    private readonly ApplicationDbContext _context;

    public ExpenseService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ExpenseListResponse> GetExpensesAsync(int userId, int page = 1, int limit = 10, string? category = null, DateTime? dateFrom = null, DateTime? dateTo = null)
    {
        var query = _context.Expenses.Where(e => e.UserId == userId);

        // Apply filters
        if (!string.IsNullOrEmpty(category))
        {
            query = query.Where(e => e.Category.ToLower() == category.ToLower());
        }

        if (dateFrom.HasValue)
        {
            query = query.Where(e => e.Date >= dateFrom.Value.Date);
        }

        if (dateTo.HasValue)
        {
            query = query.Where(e => e.Date <= dateTo.Value.Date);
        }

        // Get total count
        var total = await query.CountAsync();

        // Apply pagination
        var expenses = await query
            .OrderByDescending(e => e.Date)
            .ThenByDescending(e => e.CreatedAt)
            .Skip((page - 1) * limit)
            .Take(limit)
            .Select(e => new ExpenseResponse
            {
                Id = e.Id,
                Amount = e.Amount,
                Description = e.Description,
                Category = e.Category,
                Date = e.Date,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            })
            .ToListAsync();

        var totalPages = (int)Math.Ceiling((double)total / limit);

        return new ExpenseListResponse
        {
            Expenses = expenses,
            Total = total,
            PageInfo = new PageInfo
            {
                Page = page,
                Limit = limit,
                TotalPages = totalPages,
                HasNext = page < totalPages,
                HasPrevious = page > 1
            }
        };
    }

    public async Task<ExpenseResponse?> GetExpenseByIdAsync(int expenseId, int userId)
    {
        var expense = await _context.Expenses
            .Where(e => e.Id == expenseId && e.UserId == userId)
            .Select(e => new ExpenseResponse
            {
                Id = e.Id,
                Amount = e.Amount,
                Description = e.Description,
                Category = e.Category,
                Date = e.Date,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            })
            .FirstOrDefaultAsync();

        return expense;
    }

    public async Task<ExpenseResponse> CreateExpenseAsync(CreateExpenseRequest request, int userId)
    {
        // Validate category
        if (!ExpenseCategories.IsValidCategory(request.Category))
        {
            throw new ArgumentException($"Invalid category. Valid categories are: {string.Join(", ", ExpenseCategories.AllCategories)}");
        }

        var expense = new Expense
        {
            UserId = userId,
            Amount = request.Amount,
            Description = request.Description,
            Category = request.Category,
            Date = request.Date.Date,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        return new ExpenseResponse
        {
            Id = expense.Id,
            Amount = expense.Amount,
            Description = expense.Description,
            Category = expense.Category,
            Date = expense.Date,
            CreatedAt = expense.CreatedAt,
            UpdatedAt = expense.UpdatedAt
        };
    }

    public async Task<ExpenseResponse?> UpdateExpenseAsync(int expenseId, UpdateExpenseRequest request, int userId)
    {
        // Validate category
        if (!ExpenseCategories.IsValidCategory(request.Category))
        {
            throw new ArgumentException($"Invalid category. Valid categories are: {string.Join(", ", ExpenseCategories.AllCategories)}");
        }

        var expense = await _context.Expenses
            .FirstOrDefaultAsync(e => e.Id == expenseId && e.UserId == userId);

        if (expense == null)
        {
            return null;
        }

        expense.Amount = request.Amount;
        expense.Description = request.Description;
        expense.Category = request.Category;
        expense.Date = request.Date.Date;
        expense.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return new ExpenseResponse
        {
            Id = expense.Id,
            Amount = expense.Amount,
            Description = expense.Description,
            Category = expense.Category,
            Date = expense.Date,
            CreatedAt = expense.CreatedAt,
            UpdatedAt = expense.UpdatedAt
        };
    }

    public async Task<bool> DeleteExpenseAsync(int expenseId, int userId)
    {
        var expense = await _context.Expenses
            .FirstOrDefaultAsync(e => e.Id == expenseId && e.UserId == userId);

        if (expense == null)
        {
            return false;
        }

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<string[]> GetCategoriesAsync()
    {
        return await Task.FromResult(ExpenseCategories.AllCategories);
    }
}