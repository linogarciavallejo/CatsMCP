# CatsMCP - Model Context Protocol Cat Management System

A .NET-based Model Context Protocol (MCP) server for managing cat data with multi-language support and Entity Framework Core integration.

## 🐱 Overview

CatsMCP is a sophisticated cat management system built using Clean Architecture principles and the Model Context Protocol. The application provides tools for retrieving cat information and supports both Spanish and English localization.

## 🏗️ Architecture

The solution follows Clean Architecture patterns with clear separation of concerns:

```
CatsMCP/
├── CatsMCP.Domain/          # Domain entities and business logic
├── CatsMCP.Application/     # Application services and interfaces
├── CatsMCP.Infrastructure/  # Data access and external dependencies
└── CatsMCP.WebApi/         # MCP server host and tools
```

### Projects

- **CatsMCP.Domain**: Contains core entities (`Cat`, `CatEn`) representing cat data in Spanish and English
- **CatsMCP.Application**: Business logic, services, and repository interfaces
- **CatsMCP.Infrastructure**: Entity Framework DbContext, repository implementations, and database scripts
- **CatsMCP.WebApi**: MCP server host with cat management tools

## 🚀 Features

- **Multi-language Support**: Spanish (`Cat`) and English (`CatEn`) entity models
- **Model Context Protocol Integration**: Exposes cat data through MCP tools
- **Entity Framework Core**: SQL Server database integration with LocalDB support
- **Clean Architecture**: Maintainable and testable codebase structure
- **Dependency Injection**: Proper IoC container configuration

## 🛠️ Technology Stack

- **.NET 9.0**: Latest .NET framework
- **Entity Framework Core 9.0**: ORM for database operations
- **SQL Server LocalDB**: Local development database
- **Model Context Protocol 0.3.0**: MCP server implementation
- **C#**: Primary programming language

## 📋 Prerequisites

- .NET 9.0 SDK
- SQL Server LocalDB
- Visual Studio 2022 (recommended) or VS Code

## ⚙️ Configuration

### Database Connection

The application uses SQL Server LocalDB by default. Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Default": "Server=(localdb)\\MSSQLLocalDB;Database=CatsDB;Trusted_Connection=True;"
  },
  "Language": "es"
}
```

### Language Settings

Set the `Language` configuration to control the entity model language:
- `"es"` (default): Uses Spanish `Cat` entities
- `"en"`: Uses English `CatEn` entities

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
cd CatsMCP
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Update Database

```bash
dotnet ef database update --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
```

### 4. Seed Data (Optional)

Execute the SQL scripts in `CatsMCP.Infrastructure/scripts/`:
- `insert_cats.sql` - Spanish cat data
- `insert_cats_en.sql` - English cat data

### 5. Run the Application

```bash
dotnet run --project CatsMCP.WebApi
```

## 🔧 Available MCP Tools

The server exposes the following tools through the Model Context Protocol:

### GetCats
- **Description**: Retrieves a list of all cats
- **Parameters**: None
- **Returns**: JSON array of cat objects

### GetCat
- **Description**: Retrieves a specific cat by name
- **Parameters**: 
  - `name` (string): The name of the cat to retrieve
- **Returns**: JSON object representing the cat

## 📁 Project Structure Details

### Domain Layer (`CatsMCP.Domain`)
```
Entities/
├── Cat.cs      # Spanish cat entity model
└── CatEn.cs    # English cat entity model
```

### Application Layer (`CatsMCP.Application`)
```
Interfaces/
├── Repositories/
│   ├── ICatRepository.cs    # Spanish repository interface
│   └── ICatRepositoryEn.cs  # English repository interface
└── Services/
    ├── CatService.cs        # Spanish cat service
    ├── CatServiceEn.cs      # English cat service
    └── ICatService.cs       # Service interface
```

### Infrastructure Layer (`CatsMCP.Infrastructure`)
```
Repositories/
├── CatDbContext.cs       # Entity Framework DbContext
├── CatRepository.cs      # Spanish repository implementation
└── CatRepositoryEn.cs    # English repository implementation
scripts/
├── insert_cats.sql       # Spanish seed data
└── insert_cats_en.sql    # English seed data
```

### Presentation Layer (`CatsMCP.WebApi`)
```
├── Program.cs          # Application entry point and DI configuration
├── CatTools.cs         # MCP tool definitions
├── appsettings.json    # Configuration settings
└── Data/
    └── felinos.json    # Additional cat data
```

## 🗃️ Database Schema

The application supports two entity models with the following key properties:

### Cat Properties (Spanish)
- `Nombre` - Cat name
- `Raza` - Breed
- `Edad` - Age
- `Sexo` - Sex
- `Temperamento` - Temperament
- `EstadoAdopcion` - Adoption status

### CatEn Properties (English)
- `Name` - Cat name
- `Breed` - Breed
- `Age` - Age
- `Sex` - Sex
- `Temperament` - Temperament
- `AdoptionStatus` - Adoption status

## 🔄 Development Workflow

1. **Build Solution**:
   ```bash
   dotnet build
   ```

2. **Run Tests** (if available):
   ```bash
   dotnet test
   ```

3. **Update Database Schema**:
   ```bash
   dotnet ef migrations add <MigrationName> --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
   dotnet ef database update --project CatsMCP.Infrastructure --startup-project CatsMCP.WebApi
   ```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Support

For questions or support, please create an issue in the repository or contact the development team.

---

**Note**: This project uses the Model Context Protocol (MCP) for exposing cat management functionality. Ensure you have compatible MCP clients for optimal interaction with the server.
