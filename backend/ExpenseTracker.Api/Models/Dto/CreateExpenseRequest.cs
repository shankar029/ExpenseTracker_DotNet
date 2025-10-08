using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Api.Models.Dto;

public class CreateExpenseRequest
{
    [Required(ErrorMessage = "Amount is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be a positive value")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [MaxLength(255, ErrorMessage = "Description cannot exceed 255 characters")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Category is required")]
    [MaxLength(50, ErrorMessage = "Category cannot exceed 50 characters")]
    public string Category { get; set; } = string.Empty;

    [Required(ErrorMessage = "Date is required")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
}