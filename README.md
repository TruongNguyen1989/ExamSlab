## Run Project:

- add-migration NewEvent -Context EventStoreSqlContext
- update-database -Context EventStoreSqlContext

- add-migration NewTest -Context AppliactionContext
- update-database -Context AppliactionContext

## Technologies implemented:

- ASP.NET 5.0 (with .NET Core 5.0)
 - ASP.NET MVC Core 
 - ASP.NET WebApi Core with JWT Bearer Authentication
 - ASP.NET Identity Core
- Entity Framework Core 5.0
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI with JWT support
- .NET DevPack
- .NET DevPack.Identity

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- Domain Validations
- Aggregate
- CQRS (Imediate Consistency)
- Event Sourcing
- Unit of Work
- Repository