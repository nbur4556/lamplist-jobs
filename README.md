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
<!-- TODO: readme: Prettier and linting instructions -->

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

<!-- TODO: readme: does my database have to have a specific name in my application? (probably...)-->
Open the PostgreSQL command line tool (usually named `psql`) and create a new database.
```sh
createdb mydatabase
```

<!-- TODO: readme: is this part (migrating and updating the database) actually necessary? probably just needs to update to most current migration right? -->
If you're using Entity Framework Core, you can use migrations to create and update your database schema.

1. **Add a migration:**
   ```sh
   dotnet ef migrations add InitialCreate
   ```

2. **Update the database:**
   ```sh
   dotnet ef database update
   ```

<!-- TODO: What are the steps to building the database? Is it just build when running `dotnet`? Is it the `ef database update`?-->
- Build the database `dotnet`

#### User Secretes

The project requires the following environment variables for accessing the database

- DOTNET SECRETS HERE!

It is recommended to add these environment variables using `dotnet user-secrets`PROJECTS
<!-- TODO: readme: Link to creating dotnet user secrets -->

Start server: `dotnet run`

## Contribution

When contributing to Lamplist Jobs, please use the merge request feature provided by GitHub and tag nbur4556 for a code review. It is recommended to create a new branch for each individual feature contributed. Github pull requests should merge to **staging** not main. This allows for testing code in a production environment before it's applied to the live application.

