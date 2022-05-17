How to use Entity Framework Core Migrations
========================================

This sample show how to use migrations with layered architecture. 

Layer            | Description
---------------- | -----------
Project.Data     | Contains the `DbContext`, migration scripts and entity type classes.
Project.Startup  | The startup project. Configures the `DbContext` and dependancies.

### Migrations assembly
In `Startup.ConfigureServices()`, we tell the `DbContext` where to find the migrations classes:

```cs
optionsBuilder.UseSqlServer(
    Configuration.GetConnectionString("DefaultConnection"),
    option => option.MigrationsAssembly("Project.Data"));
```

### Migrations scripts
To auto generate migrations based on `DbSet` added to `DbContext` run the following commands;

```sh
cd ./Project.Data/
dotnet ef migrations add MyMigrationName --startup-project ../Project.Startup/
```
You can also specify the output directory path by using the option `-o ~/your_output_path`.

You do not always have to auto generate migrations, we can write custom migrations as denoted by `Custom_CreatePersons_2022051600`.

### Migrate Scripts

To manually migrate scripts use the following from `Project.Startup`;
```sh 
dotnet ef database update
``` 

Alternatively it can be done automatically with the `Startup.Configure()` method, we can add `MyContext dbContext` to the parameters and use `dbContext.Database.Migrate()` to automatically migration any scripts when the project is ran.
