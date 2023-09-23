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
<!-- TODO: Prettier and linting instructions -->

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
- Build the database `dotnet`
<!-- TODO: Link to building and migrating dotnet databases -->

#### User Secretes

The project requires the following environment variables for accessing the database

- DOTNET SECRETS HERE!

It is recommended to add these environment variables using `dotnet user-secrets`PROJECTS
<!-- TODO: Link to creating dotnet user secrets -->

Start server: `dotnet run`

## Contribution

When contributing to Lamplist Jobs, please use the merge request feature provided by GitHub and tag nbur4556 for a code review. It is recommended to create a new branch for each individual feature contributed. Github pull requests should merge to **staging** not main. This allows for testing code in a production environment before it's applied to the live application.

