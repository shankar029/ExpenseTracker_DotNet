# Expense Tracker Backend (.NET Core Web API)

A complete .NET 8 Web API backend for the Expense Tracker application with JWT authentication, SQLite database, and CORS support.

## ✅ Project Setup Complete

The foundational backend structure has been successfully created with all necessary configurations and dependencies.

## 🏗️ Project Structure

```
backend/
└── ExpenseTracker.Api/
    ├── Controllers/         # API Controllers (to be implemented)
    ├── Models/             # Data models (to be implemented)
    ├── Services/           # Business logic services (to be implemented)
    ├── Data/               # Database context and migrations
    │   └── ApplicationDbContext.cs
    ├── Properties/         # Launch settings
    ├── bin/                # Build output
    ├── obj/                # Build artifacts
    ├── Program.cs          # Application startup and configuration
    ├── appsettings.json    # Configuration settings
    └── README.md           # Detailed project documentation
```

## 📦 Installed Packages

- **Microsoft.EntityFrameworkCore.Sqlite** (9.0.9) - SQLite database provider
- **Microsoft.EntityFrameworkCore.Tools** (9.0.9) - EF Core CLI tools
- **Microsoft.AspNetCore.Authentication.JwtBearer** (8.0.10) - JWT authentication
- **System.ComponentModel.Annotations** (5.0.0) - Data validation attributes
- **Swashbuckle.AspNetCore** (6.6.2) - Swagger documentation (built-in)

## ⚙️ Configuration

### Database
- **Provider**: SQLite
- **Connection String**: `Data Source=expensetracker.db`
- **Context**: ApplicationDbContext configured and ready

### JWT Authentication
- **Issuer**: ExpenseTracker.Api
- **Audience**: ExpenseTracker.Client
- **Key**: Configured with secure 32+ character secret
- **Expiry**: 60 minutes

### CORS
- **Frontend Origin**: http://localhost:3000 (React development server)
- **Methods**: All HTTP methods allowed
- **Headers**: All headers allowed
- **Credentials**: Enabled for JWT token handling

### API Documentation
- **Swagger UI**: Available at `/swagger` endpoint
- **JWT Integration**: Bearer token authentication configured in Swagger

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK installed
- Visual Studio Code or Visual Studio

### Running the API

1. **Navigate to the API project**:
   ```bash
   cd backend/ExpenseTracker.Api
   ```

2. **Run the application**:
   ```bash
   dotnet run
   ```

3. **Access the API**:
   - **HTTPS**: https://localhost:5001
   - **HTTP**: http://localhost:5000
   - **Swagger UI**: https://localhost:5001/swagger

### Build Verification
```bash
cd backend/ExpenseTracker.Api
dotnet build
```
✅ **Build Status**: Successfully builds without errors

## 🎯 Next Steps

The foundational backend setup is complete. The next phase involves:

1. **Model Implementation**:
   - User model with authentication properties
   - Expense model with validation attributes
   - Category enumeration or model

2. **Database Setup**:
   - Create and run EF Core migrations
   - Seed initial data (categories)

3. **Service Implementation**:
   - Authentication service with JWT generation
   - Password hashing service
   - Expense management service

4. **Controller Implementation**:
   - AuthController (register, login, logout)
   - ExpensesController (CRUD operations)
   - CategoriesController (get categories)

5. **Testing & Validation**:
   - Unit tests for services
   - Integration tests for controllers
   - API endpoint testing with Swagger

## 🔧 Development Commands

```bash
# Build the project
dotnet build

# Run the project
dotnet run

# Watch for changes (hot reload)
dotnet watch run

# Clean build artifacts
dotnet clean

# Restore NuGet packages
dotnet restore

# Create EF Core migration (when models are ready)
dotnet ef migrations add InitialCreate

# Apply migrations to database
dotnet ef database update

# List available EF Core commands
dotnet ef --help
```

## 🛡️ Security Features Configured

- ✅ JWT Bearer token authentication
- ✅ CORS policy for frontend communication
- ✅ HTTPS redirection enabled
- ✅ Input validation attributes ready
- ✅ Swagger UI with JWT authorization

## 📍 API Endpoints (Planned)

```
Authentication:
├── POST /api/auth/register    # User registration
├── POST /api/auth/login      # User login
├── POST /api/auth/logout     # User logout
└── GET  /api/auth/me         # Get current user

Expenses:
├── GET    /api/expenses      # Get user expenses (paginated, filtered)
├── POST   /api/expenses      # Create new expense
├── GET    /api/expenses/{id} # Get specific expense
├── PUT    /api/expenses/{id} # Update expense
└── DELETE /api/expenses/{id} # Delete expense

Categories:
└── GET /api/categories       # Get available categories
```

The .NET Core Web API backend foundation is now ready for model and controller implementation!