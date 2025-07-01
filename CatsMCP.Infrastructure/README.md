# CatsMCP.Infrastructure - Database Migrations Guide

This document explains how to work with Entity Framework Core migrations in the CatsMCP Infrastructure layer.

## 🗃️ Database Setup

The Infrastructure layer uses Entity Framework Core with SQL Server LocalDB for data persistence. Two entity models are supported:
- **Cat** (Spanish entities) - stored in `Cats` table
- **CatEn** (English entities) - stored in `Cats_EN` table

## 🚀 Quick Start

### Prerequisites
- .NET 9.0 SDK
- SQL Server LocalDB
- Entity Framework Core Tools

### Install EF Core Tools (if not already installed)
```bash
dotnet tool install --global dotnet-ef
```

## 🔧 Migration Commands

Run all commands from the **solution root directory** (where `CatsMCP.sln` is located).

### 1. Create Initial Migration and Database
```bash
# Create the initial migration
dotnet ef migrations add InitialCreate --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi

# Apply the migration to create the database
dotnet ef database update --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
```

### 2. Create New Migration
```bash
dotnet ef migrations add <MigrationName> --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
```

### 3. Apply Migrations
```bash
dotnet ef database update --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
```

### 4. List Migrations
```bash
dotnet ef migrations list --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
```

### 5. Remove Last Migration
```bash
dotnet ef migrations remove --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
```

### 6. Drop Database
```bash
dotnet ef database drop --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
```

## 🛠️ Helper Scripts

For convenience, use the provided helper scripts:

### PowerShell (Recommended)
```powershell
# From solution root directory
.\CatsMCP.Infrastructure\scripts\migration-helper.ps1

# Available functions:
Initialize-Database          # Create initial migration and database
New-Migration "MigrationName" # Create new migration
Update-Database             # Apply pending migrations
Get-Migrations             # List all migrations
Remove-LastMigration       # Remove last migration
Drop-Database             # Drop entire database
```

### Batch File (Windows Command Prompt)
```cmd
# From solution root directory
.\CatsMCP.Infrastructure\scripts\migration-helper.bat
```

## 🏗️ DbContext Configuration

### Design-Time Factory
The `CatDbContextFactory` is configured to:
- Read connection strings from `appsettings.json` in the WebApi project
- Support both Development and Production configurations
- Provide design-time context creation for EF tools

### Connection String
Update `appsettings.json` in the WebApi project:
```json
{
  "ConnectionStrings": {
    "Default": "Server=(localdb)\\MSSQLLocalDB;Database=CatsDB;Trusted_Connection=True;"
  }
}
```

## 📊 Database Schema

### Tables
- **Cats** - Spanish cat entities with properties like `Nombre`, `Raza`, `Edad`, etc.
- **Cats_EN** - English cat entities with properties like `Name`, `Breed`, `Age`, etc.

### Key Features
- Both tables include an `EmbeddingVector` column for AI/ML scenarios
- Float arrays are converted to comma-separated strings for storage
- Proper entity configurations with appropriate table mappings

## 🔍 Troubleshooting

### Common Issues

**1. "No design-time services" error**
- Ensure you're running commands from the solution root directory
- Verify `CatDbContextFactory` exists and is properly configured

**2. "Connection string not found" error**
- Check `appsettings.json` in the WebApi project
- Verify the connection string name is "Default"

**3. "LocalDB not available" error**
- Install SQL Server LocalDB
- Verify LocalDB is running: `sqllocaldb info`

**4. Migration conflicts**
- Check for pending migrations: `dotnet ef migrations list`
- Remove problematic migrations if needed
- Ensure database schema matches expected state

### Best Practices

1. **Always backup your database** before applying migrations in production
2. **Test migrations** in a development environment first
3. **Use descriptive names** for migrations (e.g., "AddCatBreedIndex", "UpdateCatAgeColumn")
4. **Review generated migrations** before applying them
5. **Keep migrations small and focused** on specific changes

## 📝 Example Workflow

```bash
# 1. Initialize the database (first time only)
dotnet ef migrations add InitialCreate --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
dotnet ef database update --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi

# 2. Make changes to your entities (Cat.cs, CatEn.cs)

# 3. Create migration for the changes
dotnet ef migrations add AddBreedIndexes --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi

# 4. Review the generated migration files in Migrations folder

# 5. Apply the migration
dotnet ef database update --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi

# 6. Verify the changes in your database
```

## 🗂️ File Structure

```
CatsMCP.Infrastructure/
├── Repositories/
│   ├── CatDbContext.cs              # Main DbContext
│   ├── CatDbContextFactory.cs       # Design-time factory
│   ├── CatRepository.cs             # Spanish repository
│   └── CatRepositoryEn.cs           # English repository
├── Migrations/                      # Generated migration files
├── scripts/
│   ├── migration-helper.ps1         # PowerShell helper
│   ├── migration-helper.bat         # Batch helper
│   ├── insert_cats.sql             # Spanish seed data
│   └── insert_cats_en.sql          # English seed data
├── InfrastructureServiceCollectionExtensions.cs  # DI configuration
└── README.md                       # This file
```

For more information about Entity Framework Core migrations, visit the [official documentation](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/).
