using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ErpOrderApi.Persistence.Database;

/// <summary>
/// Creates the ERP database context at design time.
/// This is required by Entity Framework Core when creating migrations.
/// </summary>
public class ErpDbContextFactory : IDesignTimeDbContextFactory<ErpDbContext>
{
    /// <summary>
    /// Creates a database context instance for EF Core migration commands.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    /// <returns>An initialized ERP database context.</returns>
    public ErpDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ErpDbContext>();

        optionsBuilder.UseSqlite("Data Source=erp-order-api.db");

        return new ErpDbContext(optionsBuilder.Options);
    }
}