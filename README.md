# TyreAPI

TyreAPI is a .NET-based restful web API for managing a tyre inventory system. It provides endpoints for managing tyres, customers, and orders.

## Technologies Used

- .NET 8.0
- Entity Framework Core 8.0.7
- MySQL (via Pomelo.EntityFrameworkCore.MySql 8.0.2)
- Swagger (via Swashbuckle.AspNetCore 6.6.2)
- Selenium WebDriver 4.22.0

## Prerequisites

- .NET 8.0 SDK
- MySQL Server

## Getting Started

1. Clone the repository:
git clone https://github.com/Bahi-slh/TyreAPI.git

2. Navigate to the project directory:
cd TyreAPI

3. Update the connection string in `appsettings.json` to point to your MySQL database.

4. Run the database migrations:
dotnet ef database update

5. Run the application:
dotnet run

6. The API will be available at `https://localhost:7062` or `http://localhost:5062`.
## API Documentation

Once the application is running, you can access the Swagger UI for API documentation at:
https://localhost:7062/swagger

## Features

- Tyre Management: CRUD operations for tyres
- Customer Management: CRUD operations for customers
- Order Management: CRUD operations for orders
