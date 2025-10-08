# Expense Tracker

A full-stack expense tracking application built with .NET Core API backend and React frontend.

## Features

- User authentication with JWT tokens
- Add, view, and manage expenses
- Categorize expenses
- Responsive web interface

## Technology Stack

- **Backend**: .NET 8.0 Web API
- **Frontend**: React 18 with React Router
- **Database**: SQLite with Entity Framework Core
- **Authentication**: JWT Bearer tokens
- **Styling**: Custom CSS

## Quick Start

### Local Development

1. **Clone the repository**
2. **Start the backend**:
   ```bash
   cd backend/ExpenseTracker.Api
   dotnet restore
   dotnet run --urls http://localhost:5000
   ```

3. **Start the frontend** (in a new terminal):
   ```bash
   cd frontend
   npm install
   npm start
   ```

4. **Access the application**:
   - Frontend: http://localhost:3000
   - Backend API: http://localhost:5000
   - API Documentation: http://localhost:5000/swagger

### GitHub Codespaces

This repository is fully configured for GitHub Codespaces with automatic CORS handling.

1. **Open in Codespaces** - Click the "Code" button and select "Open with Codespaces"

2. **Start the backend**:
   ```bash
   cd backend/ExpenseTracker.Api
   dotnet run --urls http://0.0.0.0:5000
   ```

3. **Start the frontend** (in a new terminal):
   ```bash
   cd frontend
   npm start
   ```

The application will automatically detect the Codespaces environment and configure CORS and API URLs correctly.

📖 **For detailed Codespaces setup instructions, see [CODESPACES_SETUP.md](./CODESPACES_SETUP.md)**

## Project Structure

```
ExpenseTracker_DotNet/
├── backend/
│   └── ExpenseTracker.Api/          # .NET Core Web API
│       ├── Controllers/             # API controllers
│       ├── Models/                  # Data models and DTOs
│       ├── Services/                # Business logic services
│       ├── Data/                    # Entity Framework context
│       └── Program.cs               # Application entry point
├── frontend/
│   ├── src/
│   │   ├── components/              # React components
│   │   ├── pages/                   # Page components
│   │   ├── services/                # API services
│   │   └── context/                 # React context
│   └── public/                      # Static assets
├── .devcontainer/                   # Codespaces configuration
└── ARCHITECTURE.md                  # Architecture documentation
```

## API Endpoints

### Authentication
- `POST /api/auth/register` - Register new user
- `POST /api/auth/login` - Login user
- `GET /api/auth/me` - Get current user info

### Expenses (Coming Soon)
- `GET /api/expenses` - Get user expenses
- `POST /api/expenses` - Create expense
- `PUT /api/expenses/{id}` - Update expense
- `DELETE /api/expenses/{id}` - Delete expense

## Configuration

### Environment Variables

**Frontend (.env)**:
```
REACT_APP_API_BASE_URL=http://localhost:5000/api
```

**Backend (appsettings.json)**:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=expensetracker.db"
  },
  "JwtSettings": {
    "Key": "your-secret-key",
    "Issuer": "ExpenseTracker",
    "Audience": "ExpenseTracker"
  }
}
```

## CORS Configuration

The application includes intelligent CORS handling:

- **Development**: Allows localhost and GitHub Codespaces URLs
- **Production**: Specify exact allowed origins
- **Automatic Detection**: Codespaces URLs are automatically allowed

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test in both local and Codespaces environments
5. Submit a pull request

## License

This project is licensed under the MIT License.# ExpenseTracker_DotNet
