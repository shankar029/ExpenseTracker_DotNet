#!/bin/bash

echo "=== Dev Container Setup Validation ==="
echo ""

# Check if we're in the container
if [ -d "/workspaces" ]; then
    echo "✓ Running inside dev container"
    WORKSPACE="/workspaces/ExpenseTracker_DotNet"
else
    echo "⚠ Not running in dev container"
    WORKSPACE="$(pwd)"
fi

echo "Workspace: $WORKSPACE"
echo ""

# Check required tools
echo "=== Checking Required Tools ==="
command -v dotnet >/dev/null 2>&1 && echo "✓ .NET SDK available" || echo "✗ .NET SDK missing"
command -v node >/dev/null 2>&1 && echo "✓ Node.js available" || echo "✗ Node.js missing"
command -v npm >/dev/null 2>&1 && echo "✓ npm available" || echo "✗ npm missing"
echo ""

# Check project structure
echo "=== Checking Project Structure ==="
[ -f "$WORKSPACE/backend/ExpenseTracker.Api/ExpenseTracker.Api.csproj" ] && echo "✓ Backend project found" || echo "✗ Backend project missing"
[ -f "$WORKSPACE/frontend/package.json" ] && echo "✓ Frontend project found" || echo "✗ Frontend project missing"
[ -f "$WORKSPACE/.devcontainer/setup.sh" ] && echo "✓ Setup script found" || echo "✗ Setup script missing"
echo ""

echo "=== Manual Setup Instructions ==="
echo "If automatic setup fails, run these commands manually:"
echo "1. cd $WORKSPACE"
echo "2. bash .devcontainer/setup.sh"
echo ""
echo "Or run setup steps individually:"
echo "1. dotnet nuget locals all --clear"
echo "2. cd backend/ExpenseTracker.Api && dotnet restore --force"
echo "3. cd ../../frontend && npm install"