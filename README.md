```markdown:e:\Github Repo\CRUD_WEBAPI_WITH_MVC_INTEGRATION\CRUD_WEBAPI_WITH_MVC_INTEGRATION\README.md
# CRUD Web API with MVC Integration

A .NET application demonstrating how to build a CRUD API with SQL Server backend and consume it from an MVC web application. This project showcases best practices for building scalable and maintainable web applications using .NET technologies.

## 🚀 Features

- **RESTful API**: Complete CRUD operations for employee management
- **SQL Server Integration**: Uses stored procedures for data access
- **MVC Frontend**: Clean separation of concerns with Model-View-Controller pattern
- **Repository Pattern**: Abstraction layer between data access and business logic
- **Swagger Documentation**: API endpoints are fully documented and testable

## 📋 Prerequisites

- [.NET 9.0 SDK]
- [SQL Server]
- [Visual Studio 2022] or [Visual Studio Code]


## 📚 Dependencies

### EmployeeAPI
- Microsoft.AspNetCore.OpenApi
- Microsoft.Data.SqlClient
- Swashbuckle.AspNetCore

### EmployeeMVCApp
- Microsoft.AspNetCore.Mvc
- System.Net.Http.Json



## 🛠️ Setup and Installation

### Database Setup

1. Restore the database from the backup file in `EmployeeAPI/Database Backup/` folder
2. Or run the SQL scripts to create the database schema and stored procedures

### API Project Setup

1. Navigate to the EmployeeAPI directory:
   ```bash
   cd EmployeeAPI
   ```

2. Update the connection string in `appsettings.json` to point to your SQL Server instance:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. Run the API:
   ```bash
   dotnet run
   ```

4. The API will be available at `https://localhost:7001` (the port may vary)

### MVC Project Setup

1. Navigate to the EmployeeMVCApp directory:
   ```bash
   cd EmployeeMVCApp
   ```

2. Update the API base URL in `appsettings.json`:
   ```json
   "ApiSettings": {
     "BaseUrl": "https://localhost:7001/api"
   }
   ```

3. Run the MVC application:
   ```bash
   dotnet run
   ```

4. The MVC application will be available at `https://localhost:7002` (the port may vary)

## 🔄 API Endpoints

| Method | Endpoint           | Description                   |
|--------|-------------------|-------------------------------|
| GET    | /api/employees    | Get all employees             |
| GET    | /api/employees/{id} | Get employee by ID          |
| POST   | /api/employees    | Create a new employee         |
| PUT    | /api/employees/{id} | Update an existing employee |
| DELETE | /api/employees/{id} | Delete an employee          |

## 💻 Implementation Details

### EmployeeAPI

The API project uses:
- **DbHelper**: A utility class for executing stored procedures
- **Repository Pattern**: Abstracts data access logic
- **Dependency Injection**: For loose coupling between components
- **Swagger**: For API documentation and testing

### EmployeeMVCApp

The MVC project:
- Consumes the API using HttpClient
- Implements service layer for API communication
- Uses Razor views for the UI
- Follows MVC pattern for separation of concerns

## 🧪 Testing

You can test the API using:
- Swagger UI (available at `/swagger` endpoint when running the API)
- Postman or any other API testing tool
- The included MVC application





