namespace ErpOrderApi.Domain.Entities;

/// <summary>
/// Represents a product or item in the ERP system.
/// In SAP Business One, this is comparable to an item master record.
/// </summary>
public class Product
{
    /// <summary>
    /// Technical database identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Business product number used in sales, inventory and invoicing processes.
    /// Example: P1001.
    /// </summary>
    public string ProductNumber { get; set; } = string.Empty;

    /// <summary>
    /// Product name shown to users.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Sales price of one product unit.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Current available stock quantity.
    /// </summary>
    public int StockQuantity { get; set; }

    /// <summary>
    /// Sales orders that contain this product.
    /// </summary>
    public ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}