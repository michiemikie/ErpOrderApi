using ErpOrderApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ErpOrderApi.Persistence.Database;

/// <summary>
/// Represents the database context of the ERP order API.
/// It defines the database tables and the relationships between the ERP entities.
/// </summary>
public class ErpDbContext : DbContext
{
    /// <summary>
    /// Creates a new database context instance with the given options.
    /// </summary>
    /// <param name="options">Database context configuration options.</param>
    public ErpDbContext(DbContextOptions<ErpDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Customers stored in the ERP system.
    /// </summary>
    public DbSet<Customer> Customers => Set<Customer>();

    /// <summary>
    /// Products or items stored in the ERP system.
    /// </summary>
    public DbSet<Product> Products => Set<Product>();

    /// <summary>
    /// Sales orders created by customers.
    /// </summary>
    public DbSet<SalesOrder> SalesOrders => Set<SalesOrder>();

    /// <summary>
    /// Delivery documents created for sales orders.
    /// </summary>
    public DbSet<Delivery> Deliveries => Set<Delivery>();

    /// <summary>
    /// Invoices created after successful deliveries.
    /// </summary>
    public DbSet<Invoice> Invoices => Set<Invoice>();

    /// <summary>
    /// Configures database relationships and simple data rules.
    /// </summary>
    /// <param name="modelBuilder">Model builder used by Entity Framework Core.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .HasIndex(customer => customer.CustomerNumber)
            .IsUnique();

        modelBuilder.Entity<Product>()
            .HasIndex(product => product.ProductNumber)
            .IsUnique();

        modelBuilder.Entity<SalesOrder>()
            .HasIndex(order => order.OrderNumber)
            .IsUnique();

        modelBuilder.Entity<Delivery>()
            .HasIndex(delivery => delivery.DeliveryNumber)
            .IsUnique();

        modelBuilder.Entity<Invoice>()
            .HasIndex(invoice => invoice.InvoiceNumber)
            .IsUnique();

        modelBuilder.Entity<Customer>()
            .HasMany(customer => customer.SalesOrders)
            .WithOne(order => order.Customer)
            .HasForeignKey(order => order.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Product>()
            .HasMany(product => product.SalesOrders)
            .WithOne(order => order.Product)
            .HasForeignKey(order => order.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SalesOrder>()
            .HasOne(order => order.Delivery)
            .WithOne(delivery => delivery.SalesOrder)
            .HasForeignKey<Delivery>(delivery => delivery.SalesOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<SalesOrder>()
            .HasOne(order => order.Invoice)
            .WithOne(invoice => invoice.SalesOrder)
            .HasForeignKey<Invoice>(invoice => invoice.SalesOrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}