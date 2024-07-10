# TyreAPI

TyreAPI is a RESTful API for managing tyre information, customers, and orders. It allows you to perform CRUD operations on tyres, manage customer details, and handle orders. The API is built using .NET 8 and follows best practices for modern web API development.

## Features 

- CRUD operations for tyres, customers, and orders.
- Input validation and error handling.
- Use of Entity Framework Core for database operations.
- Swagger integration for API documentation and testing.


## Technologies and Frameworks

- **.NET 8**: The main framework for building the API.
- **Entity Framework Core 8**: For database operations.
  - `Microsoft.EntityFrameworkCore` (8.0.7)
  - `Microsoft.EntityFrameworkCore.Tools` (8.0.7)
  - `Pomelo.EntityFrameworkCore.MySql` (8.0.2)
- **Swagger**: For API documentation and testing.
  - `Swashbuckle.AspNetCore` (6.6.2)
- **Selenium WebDriver**: For automated testing.
  - `Selenium.WebDriver` (4.22.0)
- **AWS MySQL**: Database for storing tyre, customer, and order information.

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/Bahi-slh/TyreAPI.git
   ```

2. Navigate to the project directory:

   ```bash
   cd TyreAPI
   ```

3. Restore the dependencies:

   ```bash
   dotnet restore
   ```

4. Update the connection string in `appsettings.json` to connect to your AWS MySQL instance:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=database-1.c7gioy0eiakg.ap-southeast-2.rds.amazonaws.com;Port=3306;Database=TyreManagementDB;User=admin;Password=admin123admin!;"
   }
   ```

5. Apply database migrations:

   ```bash
   dotnet ef database update
   ```

6. Run the application:

   ```bash
   dotnet run
   ```

## Usage

Once the application is running, you can access the Swagger UI to interact with the API:

```
http://localhost:5000/swagger
```

## API Endpoints

### Tyres
- `GET /api/tyres` - Retrieve all tyres.
- `GET /api/tyres/{id}` - Retrieve a specific tyre by ID.
- `POST /api/tyres` - Create a new tyre.
- `PUT /api/tyres/{id}` - Update an existing tyre.
- `DELETE /api/tyres/{id}` - Delete a tyre by ID.

### Customers
- `GET /api/customers` - Retrieve all customers.
- `GET /api/customers/{id}` - Retrieve a specific customer by ID.
- `POST /api/customers` - Create a new customer.
- `PUT /api/customers/{id}` - Update an existing customer.
- `DELETE /api/customers/{id}` - Delete a customer by ID.

### Orders
- `GET /api/orders` - Retrieve all orders.
- `GET /api/orders/{id}` - Retrieve a specific order by ID.
- `POST /api/orders` - Create a new order.
- `PUT /api/orders/{id}` - Update an existing order.
- `DELETE /api/orders/{id}` - Delete an order by ID.

## Example Data

### Tyre
```json
{
  "brand": "Michelin",
  "model": "Pilot Sport 4",
  "size": "225/45R17",
  "price": 150.00,
  "stockQuantity": 20
}
```

### Customer
```json
{
  "name": "John Doe",
  "email": "john.doe@example.com",
  "phone": "123-456-7890"
}
```

### Order
```json
{
  "customerId": 1,
  "tyreId": 2,
  "quantity": 4,
  "orderDate": "2024-07-10"
}
```
---

This README now includes information about the AWS MySQL database and how to configure the connection string to connect to it.
