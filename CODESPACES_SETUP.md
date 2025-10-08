# GitHub Codespaces Setup Guide

This document explains how to run the Expense Tracker application in GitHub Codespaces.

## Quick Start

1. **Start the Backend**:
   ```bash
   cd backend/ExpenseTracker.Api
   dotnet run --urls http://0.0.0.0:5000
   ```

2. **Start the Frontend** (in a new terminal):
   ```bash
   cd frontend
   npm start
   ```

## How CORS is Handled

### Backend Configuration
The backend automatically detects when running in Codespaces and allows:
- All localhost variations (ports 3000, 3001)
- GitHub Codespaces URLs (*.github.dev, *.githubpreview.dev, etc.)
- Wildcard subdomain matching for Codespaces

### Frontend Configuration
The frontend automatically detects Codespaces environment and constructs the correct API URL:
- **Local**: `http://localhost:5000/api`
- **Codespaces**: `https://{CODESPACE_NAME}-5000.app.github.dev/api`

## Environment Variables

### Frontend (.env file)
Create a `.env` file in the frontend directory if you need to override the API URL:
```
REACT_APP_API_BASE_URL=https://your-custom-backend-url/api
```

## Port Configuration

### Default Ports
- Backend: Port 5000
- Frontend: Port 3000 (may auto-increment to 3001 if 3000 is busy)

### Codespaces Port Forwarding
Codespaces automatically forwards ports and makes them accessible via HTTPS URLs:
- Backend: `https://{CODESPACE_NAME}-5000.app.github.dev`
- Frontend: `https://{CODESPACE_NAME}-3000.app.github.dev` (or 3001)

## Troubleshooting

### CORS Issues
If you encounter CORS issues:
1. Ensure both services are running
2. Check that the backend is accessible at the expected URL
3. Verify the frontend is using the correct API base URL (check browser console)

### Port Issues
If ports are already in use:
1. The frontend will automatically use the next available port (3001, 3002, etc.)
2. The backend CORS configuration allows multiple port variations
3. You can manually specify ports: `dotnet run --urls http://0.0.0.0:5001`

### Environment Detection
The app detects Codespaces using the `CODESPACE_NAME` environment variable. If this isn't working:
1. Check if the variable exists: `echo $CODESPACE_NAME`
2. Manually set the API URL in frontend/.env if needed

## Security Notes

- The permissive CORS policy is only active in Development mode
- Production deployments should specify exact allowed origins
- JWT tokens are used for authentication between frontend and backend