# Expense Tracker .NET Core Web API

A RESTful API backend for the Expense Tracker application built with .NET 8.

## Features

- **Authentication & Authorization**: JWT-based authentication system
- **Database**: SQLite with Entity Framework Core
- **CORS**: Configured for frontend communication
- **API Documentation**: Swagger/OpenAPI integration
- **Validation**: Data annotation attributes for model validation

## Project Structure

```
ExpenseTracker.Api/
├── Controllers/          # API Controllers (Auth, Expenses, Categories)
├── Models/              # Data models (User, Expense, Category)
├── Services/            # Business logic services
├── Data/                # Database context and migrations
├── Properties/          # Launch settings
├── appsettings.json     # Configuration settings
└── Program.cs           # Application startup and configuration
```

## Dependencies

- **Microsoft.EntityFrameworkCore.Sqlite** (9.0.9) - SQLite database provider
- **Microsoft.EntityFrameworkCore.Tools** (9.0.9) - EF Core CLI tools for migrations
- **Microsoft.AspNetCore.Authentication.JwtBearer** (8.0.10) - JWT authentication
- **System.ComponentModel.Annotations** (5.0.0) - Data validation attributes
- **Swashbuckle.AspNetCore** (6.6.2) - Swagger documentation

## Configuration

### Database
- **Provider**: SQLite
- **Connection String**: `Data Source=expensetracker.db`
- **File Location**: Project root directory

### JWT Settings
- **Key**: 32+ character secret key (configured in appsettings.json)
- **Issuer**: ExpenseTracker.Api
- **Audience**: ExpenseTracker.Client
- **Expiry**: 60 minutes

### CORS
- **Allowed Origins**: http://localhost:3000 (React development server)
- **Methods**: All HTTP methods
- **Headers**: All headers
- **Credentials**: Enabled

## API Endpoints (Planned)

### Authentication
- `POST /api/auth/register` - Register new user
- `POST /api/auth/login` - User login
- `POST /api/auth/logout` - User logout
- `GET /api/auth/me` - Get current user

### Expenses
- `GET /api/expenses` - Get user's expenses (with pagination and filtering)
- `POST /api/expenses` - Create new expense
- `GET /api/expenses/{id}` - Get specific expense
- `PUT /api/expenses/{id}` - Update expense
- `DELETE /api/expenses/{id}` - Delete expense

### Categories
- `GET /api/categories` - Get available expense categories

## Development Setup

1. **Install .NET 8 SDK**
2. **Restore NuGet packages**:
   ```bash
   dotnet restore
   ```

3. **Update appsettings.json** with your configuration
4. **Run the application**:
   ```bash
   dotnet run
   ```

5. **Access Swagger UI**: https://localhost:5001/swagger

## Database Migrations

After implementing models, create and apply migrations:

```bash
# Create initial migration
dotnet ef migrations add InitialCreate

# Apply migrations to database
dotnet ef database update
```

## Security Considerations

- JWT secret key should be securely stored (use User Secrets in development)
- CORS origins should be restricted in production
- Implement input validation and sanitization
- Use HTTPS in production
- Consider rate limiting and API throttling

## Next Steps

1. Implement User and Expense models
2. Create database migrations
3. Implement authentication service and controllers
4. Implement expense management controllers
5. Add comprehensive error handling
6. Implement logging
7. Add unit and integration tests

## Port Configuration

- **Development**: https://localhost:5001, http://localhost:5000
- **Frontend Integration**: Configured for React app on http://localhost:3000