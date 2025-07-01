# Entity Framework Migration Helper Scripts for CatsMCP
# Run these commands from the solution root directory

Write-Host "CatsMCP Entity Framework Migration Helper" -ForegroundColor Green
Write-Host "=======================================" -ForegroundColor Green
Write-Host ""

# Function to check if we're in the correct directory
function Test-SolutionDirectory {
    if (-not (Test-Path "CatsMCP.sln")) {
        Write-Error "Please run this script from the solution root directory (where CatsMCP.sln is located)"
        exit 1
    }
}

# Function to create a new migration
function New-Migration {
    param(
        [Parameter(Mandatory=$true)]
        [string]$MigrationName
    )
    
    Test-SolutionDirectory
    
    Write-Host "Creating migration: $MigrationName" -ForegroundColor Yellow
    dotnet ef migrations add $MigrationName --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
}

# Function to update the database
function Update-Database {
    Test-SolutionDirectory
    
    Write-Host "Updating database..." -ForegroundColor Yellow
    dotnet ef database update --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
}

# Function to remove the last migration
function Remove-LastMigration {
    Test-SolutionDirectory
    
    Write-Host "Removing last migration..." -ForegroundColor Yellow
    dotnet ef migrations remove --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
}

# Function to list migrations
function Get-Migrations {
    Test-SolutionDirectory
    
    Write-Host "Listing migrations..." -ForegroundColor Yellow
    dotnet ef migrations list --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
}

# Function to drop the database
function Drop-Database {
    Test-SolutionDirectory
    
    Write-Host "WARNING: This will drop the entire database!" -ForegroundColor Red
    $confirmation = Read-Host "Are you sure you want to drop the database? (y/N)"
    
    if ($confirmation -eq 'y' -or $confirmation -eq 'Y') {
        Write-Host "Dropping database..." -ForegroundColor Yellow
        dotnet ef database drop --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi --force
    } else {
        Write-Host "Operation cancelled." -ForegroundColor Green
    }
}

# Function to create initial migration and update database
function Initialize-Database {
    Test-SolutionDirectory
    
    Write-Host "Initializing database with initial migration..." -ForegroundColor Yellow
    
    # Create initial migration
    dotnet ef migrations add InitialCreate --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
    
    # Update database
    dotnet ef database update --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
    
    Write-Host "Database initialized successfully!" -ForegroundColor Green
}

# Display menu
Write-Host "Available commands:" -ForegroundColor Cyan
Write-Host "1. Initialize-Database    - Create initial migration and database"
Write-Host "2. New-Migration         - Create a new migration"
Write-Host "3. Update-Database       - Apply pending migrations to database"
Write-Host "4. Get-Migrations        - List all migrations"
Write-Host "5. Remove-LastMigration  - Remove the last migration"
Write-Host "6. Drop-Database         - Drop the entire database"
Write-Host ""
Write-Host "Examples:" -ForegroundColor Cyan
Write-Host "  New-Migration 'AddCatBreedIndex'"
Write-Host "  Update-Database"
Write-Host "  Initialize-Database"
Write-Host ""

# Export functions for use in PowerShell session
Export-ModuleMember -Function New-Migration, Update-Database, Remove-LastMigration, Get-Migrations, Drop-Database, Initialize-Database
