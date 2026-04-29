# Notes API
## System Overview

This is a simple REST API for managing notes. It supports creating, retrieving, and deleting notes stored in a SQLite database.

The application follows a minimal ASP.NET Core Web API structure with Entity Framework Core handling persistence. Automated tests are included to validate both API behavior and data-layer operations.

## Tech Choices
- ASP.NET Core Web API – lightweight REST API framework
- Entity Framework Core – ORM for database access
- SQLite – file-based database for simplicity and portability
- xUnit – testing framework
- Microsoft.AspNetCore.Mvc.Testing – integration testing support
- EF Core InMemory provider – isolated data-layer testing

SQLite was chosen to keep the project self-contained without external dependencies.

# How to run the project
## Prerequisites
- .NET SDK 10

## Run the API
```Bash
dotnet run --project BluestaqNotesApp
```
The API will be available at:
```Bash
http://localhost:5xxx/api/notes
```

## How to Run tests
```Bash
dotnet test
```

This runs:
- API integration tests using WebApplicationFactory
- Data-layer tests using EF Core InMemory database

## API Usage
### Create a Note
```Bash
POST /api/notes
```
Request body:
```Bash
{
  "content": "Example note"
}
```
Response:
```Bash
{
  "id": 1,
  "content": "Example note",
  "created_at": "2026-04-29T12:00:00Z"
}
```
### Get All Notes
```Bash
GET /api/notes
```
### Get Note by ID
```Bash
GET /api/notes/{id}
```
### Delete Note
```Bash
DELETE /api/notes/{id}
```

Returns:
```Bash
204 No Content
```

# Assumptions and Tradeoffs
- SQLite is used for simplicity and portability, meeting the requirement for a self-contained database. It is sufficient for a small-scale application but introduces limitations around concurrency and scalability compared to a full relational database server.
- No authentication or authorization is implemented, meaning all users can access and delete all notes. This keeps the scope focused on core API functionality but would require extension with user accounts and ownership controls for any real-world use case.
- Notes are immutable after creation, with no update endpoint. This simplifies the domain model and API surface but limits flexibility for modifying existing data.
- The database is created automatically using EnsureCreated, reducing setup complexity. However, this approach does not support schema versioning or controlled migrations.
- Schema migrations are not used due to project scope, meaning structural changes require manual reset of the database rather than incremental evolution.

# Potential Future Improvements
- Add update endpoint for notes
- Add authentication and authorization
- Introduce pagination for listing notes
- Replace EnsureCreated with EF Core migrations
- Add validation improvements (max length, sanitization)
- Add structured logging and monitoring
- Containerize with Docker for deployment consistency
