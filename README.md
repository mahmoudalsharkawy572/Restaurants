# 🍽️ Restaurants API

A modern **Restaurant Management System** built with **ASP.NET Core** following **Clean Architecture** principles. Manage restaurants, dishes, and user authentication with a robust and scalable API.

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Project Structure](#-project-structure)
- [Technology Stack](#-technology-stack)
- [Features](#-features)
- [Getting Started](#-getting-started)
- [Project Components](#-project-components)
- [Architecture](#-architecture)
- [API Endpoints](#-api-endpoints)
- [CQRS & MediatR Pattern](#-cqrs--mediator-pattern)
- [Authentication & Security](#-authentication--security)
- [Database Models](#-database-models)
- [Contributing](#-contributing)

---

## 🎯 Overview

**Restaurants API** is a comprehensive restaurant management system that enables:
- 🍽️ Browse and manage restaurants
- 🍲 Manage restaurant menus and dishes
- 👤 User authentication and authorization
- 📍 Restaurant location and address management
- 🚚 Track restaurant delivery capabilities
- 📊 Structured logging and monitoring

The platform uses **CQRS pattern** with **MediatR** for clean separation of commands and queries, making the codebase highly maintainable and scalable.

---

## 📁 Project Structure

```
Restaurants/
├── 📦 Restaurants.API/                # Web API & Presentation Layer
│   ├── Controllers/                   # API Endpoints
│   │   ├── RestaurantsController.cs
│   │   ├── DishesController.cs
│   │   └── IdentityController.cs
│   ├── Extensions/                    # Service Registration
│   ├── Middlewares/                   # Custom Middlewares
│   │   ├── ErrorHandlingMiddleware
│   │   └── RequestTimeLoggingMiddleware
│   ├── Program.cs                     # Startup Configuration
│   └── appsettings.json
│
├── 📚 Restaurants.Application/        # Business Logic Layer (CQRS)
│   ├── Restaurants/                   # Restaurant Use Cases
│   │   ├── Commands/                  # Write Operations
│   │   │   ├── CreateRestaurantCommand
│   │   │   └── UpdateRestaurantCommand
│   │   ├── Queries/                   # Read Operations
│   │   │   ├── GetAllRestaurantsQuery
│   │   │   └── GetRestaurantByIdQuery
│   │   ├── Handlers/                  # CQRS Handlers
│   │   └── Dtos/                      # Data Transfer Objects
│   ├── Dishes/                        # Dish Use Cases
│   │   ├── Commands/
│   │   ├── Queries/
│   │   └── Dtos/
│   ├── Users/                         # User Management
│   ├── Extensions/                    # Service Registration
│   └── Common/                        # Shared Utilities
│
├── 🏛️ Restaurants.Domain/             # Core Domain Layer
│   ├── Entities/                      # Domain Models
│   │   ├── Restaurant.cs
│   │   ├── Dish.cs
│   │   ├── User.cs
│   │   └── Address.cs
│   ├── Interfaces/                    # Service Contracts
│   ├── IRepositories/                 # Repository Patterns
│   ├── Exceptions/                    # Custom Exceptions
│   └── Constants/                     # Business Constants
│
└── 🔧 Restaurants.Infrastructure/     # Data Access Layer
    ├── Persistence/                   # DbContext
    ├── Repositories/                  # Repository Implementations
    ├── Migrations/                    # Database Migrations
    ├── Seeders/                       # Data Seeders
    ├── Authorization/                 # Authorization Logic
    └── Extensions/                    # Service Registration

```

---

## 🛠️ Technology Stack

| Component | Technology | Purpose |
|-----------|-----------|---------|
| **Framework** | ASP.NET Core 8.0 | Web API Development |
| **Language** | C# 12+ | Primary Development |
| **Database** | SQL Server | Data Persistence |
| **ORM** | Entity Framework Core 8.0 | Database Access |
| **CQRS** | MediatR 12.0.1 | Command/Query Separation |
| **Validation** | FluentValidation 11.3.1 | Input Validation |
| **Mapping** | AutoMapper 13.0.1 | DTO Mapping |
| **Authentication** | ASP.NET Core Identity 8.0 | User Management |
| **Logging** | Serilog 8.0.3 | Structured Logging |
| **API Docs** | Swashbuckle 6.6.2 | OpenAPI/Swagger |

---

## ✨ Features

### 🍽️ Restaurant Management
- ✅ Create, read, update restaurants
- ✅ Manage restaurant details and addresses
- ✅ Track delivery capabilities
- ✅ Store contact information

### 🍲 Dish Management
- ✅ Add dishes to restaurants
- ✅ Manage dish information
- ✅ Query dishes by restaurant
- ✅ Delete dishes

### 👤 Authentication & Authorization
- ✅ User registration
- ✅ Secure login with ASP.NET Identity
- ✅ JWT token support
- ✅ Role-based access control
- ✅ Password security best practices

### 🏗️ Architecture & Patterns
- ✅ **Clean Architecture** - Layered separation of concerns
- ✅ **CQRS Pattern** - Commands for writes, Queries for reads
- ✅ **MediatR** - Mediator pattern for loose coupling
- ✅ **Repository Pattern** - Abstraction for data access
- ✅ **Dependency Injection** - Loose coupling via DI container
- ✅ **FluentValidation** - Robust input validation

### 📊 Logging & Monitoring
- ✅ Structured logging with Serilog
- ✅ Request timing middleware
- ✅ Error handling middleware
- ✅ Console and file logging

### 📖 API Documentation
- ✅ Swagger/OpenAPI integration
- ✅ Interactive API exploration
- ✅ Auto-generated documentation

---

## 🚀 Getting Started

### Prerequisites
- 📌 .NET 8.0 or higher
- 📌 SQL Server
- 📌 Visual Studio 2022 or VS Code
- 📌 Git

### Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/mahmoudalsharkawy572/Restaurants.git
   cd Restaurants
   ```

2. **Configure Database Connection**
   - Update `appsettings.json` in `Restaurants.API`
   - Set your SQL Server connection string:
   ```json
   "ConnectionStrings": {
     "RestaurantsDb": "Server=YOUR_SERVER;Database=RestaurantsDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

4. **Run Database Migrations**
   ```bash
   cd Restaurants.Infrastructure
   dotnet ef database update
   ```

5. **Run the Application**
   ```bash
   cd Restaurants.API
   dotnet run
   ```

6. **Access the Application**
   - 🌐 API Base URL: `https://localhost:7123`
   - 📚 Swagger UI: `https://localhost:7123/swagger`

---

## 🏗️ Project Components

### 1️⃣ Restaurants.API
**Presentation Layer - REST API Endpoints**

Contains all API controllers and middleware:

**Controllers:**
- `RestaurantsController` - Restaurant CRUD operations
- `DishesController` - Dish management operations
- `IdentityController` - User authentication endpoints

**Middlewares:**
- `ErrorHandlingMiddleware` - Global exception handling
- `RequestTimeLoggingMiddleware` - Request timing and logging

**Configuration:**
- Swagger/OpenAPI setup
- CORS configuration
- Dependency injection registration
- Serilog logging setup

### 2️⃣ Restaurants.Application
**Application Layer - Business Logic (CQRS)**

Contains all business logic organized by CQRS pattern:

**Structure:**
- **Commands/** - Write operations (Create, Update, Delete)
- **Queries/** - Read operations (Get, GetAll)
- **Handlers/** - MediatR command/query handlers
- **Dtos/** - Data Transfer Objects for API communication
- **Validators/** - FluentValidation rules
- **Extensions/** - Service registration (AddApplication())

**Key Responsibilities:**
- Implement use cases
- Command and query handling via MediatR
- Business rule validation
- DTO mapping with AutoMapper

### 3️⃣ Restaurants.Domain
**Domain Layer - Core Business Models**

Contains domain entities and business rules:

**Entities:**
- `Restaurant` - Main restaurant entity
- `Dish` - Menu item entity
- `User` - User identity entity
- `Address` - Location information

**Interfaces:**
- Repository contracts (IRepository<T>)
- Service contracts
- Business rules definitions

### 4️⃣ Restaurants.Infrastructure
**Infrastructure Layer - Data Access & External Services**

Handles all data persistence and external service integration:

**Components:**
- `ApplicationDbContext` - Entity Framework Core DbContext
- `Repository<T>` - Generic repository implementation
- `Migrations/` - Database schema migrations
- `Seeders/` - Initial data population
- `Authorization/` - Authorization policies and handlers
- `Extensions/` - Service registration (AddInfrastructure())

---

## 🏛️ Architecture

```
┌─────────────────────────────────────────┐
│      API Presentation Layer             │
│   (Controllers, Middlewares)            │
└────────────────────┬────────────────────┘
                     │
        ┌────────────┴─────────────┐
        │                          │
┌───────▼────────┐    ┌──────────▼───────┐
│    Commands    │    │     Queries      │
│   (Write Ops)  │    │   (Read Ops)     │
└───────┬────────┘    └──────────┬───────┘
        │                        │
        └────────────┬───────────┘
                     │
        ┌────────────▼──────────────┐
        │  Application Layer (CQRS) │
        │  (MediatR Handlers)       │
        └────────────┬──────────────┘
                     │
        ┌────────────▼──────────────┐
        │   Domain Layer            │
        │  (Entities & Rules)       │
        └────────────┬──────────────┘
                     │
        ┌────────────▼──────────────┐
        │ Infrastructure Layer      │
        │ (EF Core, Repositories)   │
        └────────────┬──────────────┘
                     │
        ┌────────────▼──────────────┐
        │   SQL Server Database     │
        └──────────────────────────┘
```

---

## 🔌 API Endpoints

### 🍽️ Restaurants Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/restaurants` | Get all restaurants |
| `GET` | `/api/restaurants/{id}` | Get restaurant by ID |
| `POST` | `/api/restaurants` | Create new restaurant |
| `PATCH` | `/api/restaurants/{id}` | Update restaurant |

### 🍲 Dishes Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/restaurants/{restaurantId}/dishes` | Get all dishes for restaurant |
| `POST` | `/api/restaurants/{restaurantId}/dishes` | Create new dish |
| `DELETE` | `/api/restaurants/{restaurantId}/dishes/{dishId}` | Delete dish |

### 👤 Identity Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `POST` | `/api/identity/register` | Register new user |
| `POST` | `/api/identity/login` | User login |
| `POST` | `/api/identity/refresh` | Refresh JWT token |
| `GET` | `/api/identity/confirmEmail` | Confirm user email |
| `POST` | `/api/identity/resendConfirmationEmail` | Resend email confirmation |
| `POST` | `/api/identity/forgotPassword` | Request password reset |
| `POST` | `/api/identity/resetPassword` | Reset user password |
| `POST` | `/api/identity/manage/2fa` | Manage two-factor authentication |
| `GET` | `/api/identity/manage/info` | Get user account information |
| `POST` | `/api/identity/manage/info` | Update user account information |
| `PATCH` | `/api/identity/update-user-details` | Update user profile details |
| `POST` | `/api/identity/assign-user-role` | Assign role to user |
| `POST` | `/api/identity/unassign-user-role` | Remove role from user |

---

## 🔄 CQRS & Mediator Pattern

### What is CQRS?
**Command Query Responsibility Segregation** separates read (Query) and write (Command) operations into different models.

### How We Use MediatR

**Command Example:**
```csharp
// 1. Define the Command
public record CreateRestaurantCommand(string Name, string Description) 
    : IRequest<int>;

// 2. Create the Handler
public class CreateRestaurantCommandHandler 
    : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, 
        CancellationToken cancellationToken)
    {
        // Validation, Business Logic, Data Persistence
        var restaurant = new Restaurant { 
            Name = request.Name,
            Description = request.Description 
        };
        // Save to database...
        return restaurant.Id;
    }
}

// 3. Use in Controller
public class RestaurantsController : ControllerBase
{
    private readonly IMediator _mediator;
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRestaurantCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id });
    }
}
```

**Query Example:**
```csharp
// 1. Define the Query
public record GetAllRestaurantsQuery() : IRequest<List<RestaurantDto>>;

// 2. Create the Handler
public class GetAllRestaurantsQueryHandler 
    : IRequestHandler<GetAllRestaurantsQuery, List<RestaurantDto>>
{
    public async Task<List<RestaurantDto>> Handle(GetAllRestaurantsQuery request, 
        CancellationToken cancellationToken)
    {
        // Fetch from database...
        return restaurants;
    }
}

// 3. Use in Controller
[HttpGet]
public async Task<IActionResult> GetAll()
{
    var restaurants = await _mediator.Send(new GetAllRestaurantsQuery());
    return Ok(restaurants);
}
```

### Benefits of CQRS + MediatR
- ✅ **Separation of Concerns** - Read and write logic separated
- ✅ **Testability** - Easy to unit test handlers
- ✅ **Scalability** - Can optimize reads and writes independently
- ✅ **Maintainability** - Clear command/query intent
- ✅ **Flexibility** - Can add behaviors via pipeline behaviors
- ✅ **Single Responsibility** - Each handler has one job

---

## 🔐 Authentication & Security

### ASP.NET Core Identity
```csharp
// Built-in Identity Features
- Secure password hashing (bcrypt)
- User registration and login
- Email validation
- Password reset functionality
- Role-based access control
- Token generation and validation
- Two-factor authentication (2FA)
- User lockout policies
```

### JWT Support
- Built-in JWT endpoint: `/api/identity`
- Automatic token management
- Secure session handling
- Configurable token expiration
- Token refresh mechanism

### Security Features
- ✅ HTTPS enforcement
- ✅ CORS policy configuration
- ✅ Input validation via FluentValidation
- ✅ Global exception handling
- ✅ SQL injection prevention (EF Core)
- ✅ Password security best practices
- ✅ Two-factor authentication support
- ✅ Email confirmation workflow
- ✅ Role-based authorization

---

## 📊 Database Models

### Restaurant Entity
```csharp
public class Restaurant
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public bool HasDelivery { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactNumber { get; set; }
    public Address? Address { get; set; }
    public ICollection<Dish>? Dishes { get; set; }
}
```

### Dish Entity
```csharp
public class Dish
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant? Restaurant { get; set; }
}
```

### Address Entity
```csharp
public class Address
{
    public int Id { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public int RestaurantId { get; set; }
}
```

---

## 📈 Language Composition

| Language | Percentage |
|----------|-----------|
| C# | 100% |

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. 🍴 Fork the repository
2. 🌱 Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. 💬 Commit changes (`git commit -m 'Add AmazingFeature'`)
4. 📤 Push to branch (`git push origin feature/AmazingFeature`)
5. 🔄 Open a Pull Request

---

## 📝 License

This project is open source and available under the MIT License.

---

## 👤 Author

**Mahmoud Alsharkawy**
- 📧 Email: mahmoudalsharkawy572@gmail.com
- 🔗 GitHub: [@mahmoudalsharkawy572](https://github.com/mahmoudalsharkawy572)

---

## 🎉 Acknowledgments

- 🙏 Built with ASP.NET Core
- 🙏 CQRS implementation via MediatR
- 🙏 Database: SQL Server with EF Core
- 🙏 API Documentation: Swagger/OpenAPI
- 🙏 Logging: Serilog

---

**Made with ❤️ by Mahmoud Alsharkawy**

⭐ If you find this project helpful, please consider giving it a star!
