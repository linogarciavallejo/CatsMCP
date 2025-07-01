@echo off
echo CatsMCP Entity Framework Migration Helper
echo ========================================
echo.

if not exist "CatsMCP.sln" (
    echo ERROR: Please run this script from the solution root directory ^(where CatsMCP.sln is located^)
    pause
    exit /b 1
)

:menu
echo Available options:
echo 1. Initialize Database ^(Create initial migration and database^)
echo 2. Create New Migration
echo 3. Update Database
echo 4. List Migrations
echo 5. Remove Last Migration
echo 6. Drop Database
echo 7. Exit
echo.

set /p choice="Enter your choice (1-7): "

if "%choice%"=="1" goto :initialize
if "%choice%"=="2" goto :new_migration
if "%choice%"=="3" goto :update_db
if "%choice%"=="4" goto :list_migrations
if "%choice%"=="5" goto :remove_migration
if "%choice%"=="6" goto :drop_db
if "%choice%"=="7" goto :exit
goto :invalid_choice

:initialize
echo Creating initial migration and database...
dotnet ef migrations add InitialCreate --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
if %errorlevel% neq 0 goto :error
dotnet ef database update --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
if %errorlevel% neq 0 goto :error
echo Database initialized successfully!
goto :continue

:new_migration
set /p migration_name="Enter migration name: "
if "%migration_name%"=="" (
    echo ERROR: Migration name cannot be empty
    goto :continue
)
echo Creating migration: %migration_name%
dotnet ef migrations add "%migration_name%" --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
if %errorlevel% neq 0 goto :error
goto :continue

:update_db
echo Updating database...
dotnet ef database update --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
if %errorlevel% neq 0 goto :error
echo Database updated successfully!
goto :continue

:list_migrations
echo Listing migrations...
dotnet ef migrations list --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
goto :continue

:remove_migration
echo Removing last migration...
dotnet ef migrations remove --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
if %errorlevel% neq 0 goto :error
echo Last migration removed successfully!
goto :continue

:drop_db
echo WARNING: This will drop the entire database!
set /p confirm="Are you sure you want to drop the database? (y/N): "
if /i "%confirm%"=="y" (
    echo Dropping database...
    dotnet ef database drop --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi --force
    if %errorlevel% neq 0 goto :error
    echo Database dropped successfully!
) else (
    echo Operation cancelled.
)
goto :continue

:invalid_choice
echo Invalid choice. Please enter a number between 1 and 7.
goto :continue

:error
echo An error occurred during the operation.
goto :continue

:continue
echo.
pause
echo.
goto :menu

:exit
echo Goodbye!
pause
