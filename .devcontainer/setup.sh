#!/bin/bash

# Set workspace root - in devcontainer it's typically /workspaces/<folder-name>
if [ -d "/workspaces/ExpenseTracker_DotNet" ]; then
    WORKSPACE_ROOT="/workspaces/ExpenseTracker_DotNet"
else
    # Fallback: Get the directory where this script is located
    SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
    # Get the workspace root (parent of .devcontainer)
    WORKSPACE_ROOT="$(dirname "$SCRIPT_DIR")"
fi

echo "Setting up Expense Tracker development environment..."
echo "Workspace root: $WORKSPACE_ROOT"

# Change to workspace root
cd "$WORKSPACE_ROOT"

# Clean any Windows-specific build artifacts
echo "Cleaning build artifacts..."
rm -rf backend/ExpenseTracker.Api/obj
rm -rf backend/ExpenseTracker.Api/bin

# Clear NuGet cache to avoid Windows path issues
echo "Clearing NuGet cache..."
dotnet nuget locals all --clear

# Install backend dependencies
echo "Restoring .NET packages..."
cd "$WORKSPACE_ROOT/backend/ExpenseTracker.Api"
dotnet restore --force

# Install frontend dependencies
echo "Installing Node.js packages..."
cd "$WORKSPACE_ROOT/frontend"
npm install

echo "Setup complete!"
echo ""
echo "To start the application:"
echo "1. Backend: cd backend/ExpenseTracker.Api && dotnet run --urls http://0.0.0.0:5000"
echo "2. Frontend: cd frontend && npm start"