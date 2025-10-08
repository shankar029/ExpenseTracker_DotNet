# Models Directory

This directory contains the Entity Framework data models for the Expense Tracker application.

## Models

### User.cs
- Represents user accounts with authentication and profile information
- Properties: Id, Username, Email, PasswordHash, CreatedAt, UpdatedAt
- Navigation property to related Expenses

### Expense.cs
- Represents individual expense records
- Properties: Id, UserId, Amount, Description, Category, Date, CreatedAt, UpdatedAt
- Foreign key relationship to User with cascade delete

### ExpenseCategories.cs
- Static class containing predefined expense categories
- Categories: Food, Transportation, Entertainment, Healthcare, Shopping, Utilities, Other
- Utility methods for category validation

## Database Schema

The models are configured with:
- Data annotations for validation (required fields, string lengths, email format)
- Entity Framework Fluent API configurations in ApplicationDbContext
- Unique constraints on Username and Email
- Proper indexing for performance (UserId, Date, Username, Email)
- Decimal precision for monetary amounts (10,2)
- Cascade delete for expenses when user is deleted

## Validation Rules

### User Model
- Username: Required, max 80 characters, unique
- Email: Required, max 120 characters, unique, valid email format
- PasswordHash: Required, max 255 characters

### Expense Model
- Amount: Required, positive decimal with 2 decimal places
- Description: Required, max 255 characters
- Category: Required, max 50 characters (should match predefined categories)
- Date: Required
- UserId: Required (foreign key to User)

All models include automatic CreatedAt and UpdatedAt timestamps.