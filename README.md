# Courses Shop APIs

## Overview

The Courses Shop APIs is a asp net core api project for manage a shop for courses, is a just training project , it developed by asp.net core api and sql server following the Clean Architecture principles combined with Command Query Responsibility Segregation (CQRS) patterns. The application utilizes MediatR for managing requests and notifications, Entity Framework Core for data access,.

## Project Architecture

### Clean Architecture with CQRS
- **Clean Architecture**: The project is organized into layers to achieve separation of concerns. This includes layers such as Api, Core, Service, Infrastructure and Data.
- **CQRS**: Command Query Responsibility Segregation (CQRS) is used to separate read and write operations, enhancing performance and scalability.

### Technologies and Packages
- **ASP.NET Core**: The primary framework for building the web API.
- **MediatR**: Used for handling requests and notifications.
- **Entity Framework Core (EF Core)**: ORM for data access.
- **Fluent Validation**: A validation library that uses a fluent interface to construct strongly-typed validation rules.
- **Auto Mapper**: A convention-based object-object mapper.
- **MailKit**: is a library for send email based on MimeKit.

### Databases 
- **CoursesShopDbContext**: Handles all data operations.

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server

### Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/LahcenMohamed/CoursesShop.git
    cd CoursesShopDbContext-api
    ```

2. Restore dependencies:
    ```bash
    dotnet restore
    ```

3. Update database connections in `appsettings.json`.

4. Make sure to add secretKey in jwt section as well as email and password in email settings section in `appsettings.json`.

5. Apply database migrations:
    ```bash
    dotnet ef database update
    ```

7. Run the application:
    ```bash
    dotnet run
    ```
