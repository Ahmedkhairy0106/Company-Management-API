# Company Management API

A RESTful API for managing departments and employees, built with ASP.NET Core and Entity Framework Core. This project demonstrates CRUD operations, relational database design, and API documentation using Swagger.

## Table of Contents

- Features
- Technologies
- Setup and Installation
- API Endpoints
- Challenges and Learnings
- Future Improvements

## Features

- Create, Read, Update, and Delete (CRUD) operations for departments and employees.
- Relational database design with one-to-many relationships between departments and employees.
- Input validation using Data Annotations and EF Core configurations.
- API documentation with Swagger UI.
- Prevention of circular references in JSON serialization using `[JsonIgnore]`.

## Technologies

- **Backend**: ASP.NET Core 8.0
- **Database**: SQL Server, Entity Framework Core
- **API Documentation**: Swagger/OpenAPI
- **Other**: C#, LINQ, Dependency Injection

## Setup and Installation

1. **Clone the repository**:

   ```bash
   git clone https://github.com/<your-username>/Company-Management-API.git
   cd CompanyAPI
   ```

2. **Configure the database**:

   - Update the connection string in `appsettings.json` to point to your SQL Server instance.
   - Run migrations to create the database:

     ```bash
     dotnet ef database update
     ```

3. **Run the application**:

   ```bash
   dotnet run
   ```

4. **Access the API**:

   - Open `https://localhost:<port>/swagger` in your browser to explore the API endpoints.

## API Endpoints

- **Departments**:

  - `GET /api/Departments`: Retrieve all departments with employee names.
  - `GET /api/Departments/{id}`: Retrieve a department by ID.
  - `POST /api/Departments`: Create a new department.
  - `PUT /api/Departments/{id}`: Update an existing department.
  - `DELETE /api/Departments/{id}`: Delete a department.

- **Employees**:

  - `GET /api/Employees`: Retrieve all employees.
  - `GET /api/Employees/{id}`: Retrieve an employee by ID.
  - `POST /api/Employees`: Create a new employee.
  - `PUT /api/Employees/{id}`: Update an existing employee.
  - `DELETE /api/Employees/{id}`: Delete an employee.

## Challenges and Learnings

- **Validation Issue**: Faced an issue where empty fields were saved despite `IsRequired()` in EF Core configurations. Learned to combine Data Annotations (`[Required]`) with EF Core configurations for robust validation.
- **Circular References**: Handled circular references between `Department` and `Employee` using `[JsonIgnore]` to prevent serialization errors.
- **Database Design**: Gained experience in designing one-to-many relationships and applying migrations with Entity Framework Core.

## Future Improvements

- Add JWT-based authentication and role-based authorization.
- Implement unit tests using xUnit or NUnit.
- Develop a frontend interface using React or Angular.
- Add global exception handling middleware.
- Integrate CI/CD with GitHub Actions.
