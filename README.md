# TVMaze API - Clean Architecture Example

This is a sample project built using .NET Core 8 with Clean Architecture principles. The project includes an ASP.NET Core Web API, SQLite as the database provider, and unit tests written with xUnit, FakeItEasy. The project is developed using Visual Studio 2022.


# Overview

This project demonstrates how to implement a clean architecture in a .NET Core Web API. The application interacts with the TVMaze API to fetch and store information about TV shows in a SQLite database. The solution emphasizes separation of concerns, testability, and maintainability.

# Technologies

- **.NET Core 8**
- **ASP.NET Core Web API**
- **SQLite** (Entity Framework Core)
- **xUnit** (Unit Testing)
- **FakeItEasy** (Mocking Framework)
- **Swagger** (API Documentation)
- **Visual Studio 2022**

## Architecture

The project follows Clean Architecture principles, dividing the solution into separate layers:

- **Core**: Contains the domain entities and interfaces.
- **Application**: Contains business logic, service interfaces, and use cases.
- **Infrastructure**: Contains the database context, repository implementations, and external services.
- **WebAPI**: The presentation layer, which exposes the API endpoints.


### Prerequisites

- [.NET Core 8 SDK]
- [Visual Studio 2022]
- [SQLite]

### ApiKey

For development purposes, the API key is set to 123456. This key is configured in the appsettings.json file
{
  "ApiKey": "123456"
}
