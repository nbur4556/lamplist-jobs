# Lamplist Jobs

## Description

Lamplist Jobs utilizes the "Lamp List" job strategy to help prospects track, organize, and discover career opportunities.

## Technologies

- TypeScript
- SvelteKit
- TailwindCSS
- DaisyUI
- C#
- .NET
- PostgreSql

## Development

### Development Environment Requirements

- nodejs
- .NET (and dotnet cli)
- yarn
- postgres

`git clone` the repository

### Client
Navigate to the client directory

Install packages: `yarn install`

Create a .env file:

```sh
PUBLIC_API_URL=http://localhost:5001 #(or url to development server)
```

Start development client: `yarn dev`

### Server

Navigate to the server directory

#### Build Database

- Create a postgres database

Open the PostgreSQL command line tool (usually named `psql`) and create a new database.
```sh
createdb mydatabase
```

Use Entity Framework to update the database to the most recent migration
```sh
dotnet ef database update
```

#### User Secretes

The project requires the following environment variables for accessing the database

- PostgreSql:DbUser - User/Role to the postgres database
- PostgreSql:DbPassword - Password to the postgres database
- PostgreSql:DbHost - Host to the postgres database
- PostgreSql:DbDatabase - Name of the postgres database

It is recommended to add these environment variables using `dotnet user-secrets`PROJECTS
[Microsoft DotNet User-Secrets Instructions](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=linux)

Start server: `dotnet run`

## Contribution

When contributing to Lamplist Jobs, please use the merge request feature provided by GitHub and tag nbur4556 for a code review. It is recommended to create a new branch for each individual feature contributed. Github pull requests should merge to **staging** not main. This allows for testing code in a production environment before it's applied to the live application.

