How to use Entity Framework Core Migrations
========================================

This sample show how to use migrations when your application is split up into seperate assemblies or
architectural layers. 

Assembly         | Description
---------------- | -----------
Project.Data     | Contains the `DbContext`,
""               | Contains migration scripts,
""               | Contains entity type classes.
Project.Startup  | The startup project. Configures the `DbContext` and dependancies.

Running commands
----------------
To auto generate migrations based on `DbSet` added to `DbContext` run the following commands;

```sh
cd ./Project.Data/
dotnet ef migrations add MyMigrationName --startup-project ../Project.Startup/
```

You do not always have to auto gen migrations, we can write custom migrations as denoted by `Custom_CreatePersons_2022051600`

### Migrations assembly
In `Startup.ConfigureServices()`, we tell the `DbContext` where to find the migrations classes:

```cs
optionsBuilder.UseSqlServer(
    Configuration.GetConnectionString("DefaultConnection"),
    option => option.MigrationsAssembly("Project.Data"));
```

### Additional Notes
In `Startup.Configure()`, we can add `MyContext dbContext` to the parameters and use `dbContext.Database.Migrate()` to automatically migration any scripts when the project is ran.