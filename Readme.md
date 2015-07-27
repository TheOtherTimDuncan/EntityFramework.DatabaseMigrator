## EntityFramework.DatabaseMigrator

### NuGet Packages

```
Install-Package EntityFramework.DatabaseMigrator
```

Back story and additional details available [here](http://theothertimduncan.com/archive/Entity-Framework-Migrations-Real-World/).

Assuming you already have migrations enabled,

1. Add a new WinForms project to your solution.

2. Delete the form automatically added to the new project.

3. Open `program.cs` in the root of your project and change Form1 to EntityFramework.DatabaseMigrator.DatabaseMigrator

    ```csharp
    	 static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new EntityFramework.DatabaseMigrator.DatabaseMigrator());
            }
        }
    ```

5. Change your migration configuration to inherit from [BaseMigrationConfiguration](https://github.com/TheOtherTimDuncan/EntityFramework.DatabaseMigrator/blob/master/EntityFramework.DatabaseMigrator/Migrations/BaseMigrationConfiguration.cs) or add and implement the [IMigrationConfiguration](https://github.com/TheOtherTimDuncan/EntityFramework.DatabaseMigrator/blob/master/EntityFramework.DatabaseMigrator/Migrations/IMigrationConfiguration.cs) interface.

    ```csharp
    internal sealed class Configuration : BaseMigrationConfiguration<EntityFramework.DatabaseMigrator.Example.Data.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EntityFramework.DatabaseMigrator.Example.Data.BlogContext";
        }
    }
    ```
