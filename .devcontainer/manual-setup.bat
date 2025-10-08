@echo off
echo Setting up Expense Tracker development environment...

echo Cleaning build artifacts...
if exist "backend\ExpenseTracker.Api\obj" rmdir /s /q "backend\ExpenseTracker.Api\obj"
if exist "backend\ExpenseTracker.Api\bin" rmdir /s /q "backend\ExpenseTracker.Api\bin"

echo Clearing NuGet cache...
dotnet nuget locals all --clear

echo Restoring .NET packages...
cd backend\ExpenseTracker.Api
dotnet restore --force

echo Installing Node.js packages...
cd ..\..\frontend
npm install

echo Setup complete!
echo.
echo To start the application:
echo 1. Backend: cd backend\ExpenseTracker.Api ^&^& dotnet run --urls http://0.0.0.0:5000
echo 2. Frontend: cd frontend ^&^& npm start