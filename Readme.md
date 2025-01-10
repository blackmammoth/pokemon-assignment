# Pokemon API

This is a simple ASP.NET Core Web API for managing Pokemon data using MongoDB.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MongoDB](https://www.mongodb.com/try/download/community)

## Getting Started

### Configuration

1. **MongoDB Settings**: Update the `appsettings.json` file with your MongoDB connection string and database name.

```json
{
  "MongoDBSettings": {
    "ConnectionString": "your-mongodb-connection-string",
    "DatabaseName": "your-database-name"
  }
}
```

### Build and Run
1. Restore the project dependencies by running: `dotnet restore`

2. Build the project by running: `dotnet build`

3. Run the project by running: `dotnet run`

### API Endpoints
- You can test out the API by going to `<url>/swagger`

