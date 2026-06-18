namespace ErpOrderApi.Domain.Entities;

/// <summary>
/// Represents a customer sales order in the ERP process.
/// In SAP Business One, this is comparable to a sales order document.
/// </summary>
public class SalesOrder
{
    /// <summary>
    /// Technical database identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Business order number used to identify the sales order.
    /// Example: SO-1001.
    /// </summary>
    public string OrderNumber { get; set; } = string.Empty;

    /// <summary>
    /// Foreign key of the customer who placed the order.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// Customer related to this sales order.
    /// </summary>
    public Customer Customer { get; set; } = null!;

    /// <summary>
    /// Foreign key of the ordered product.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Product ordered by the customer.
    /// </summary>
    public Product Product { get; set; } = null!;

    /// <summary>
    /// Ordered quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Current process status of the sales order.
    /// Example: Open, Delivered, Invoiced.
    /// </summary>
    public string Status { get; set; } = "Open";

    /// <summary>
    /// Date and time when the sales order was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Delivery created for this sales order.
    /// </summary>
    public Delivery? Delivery { get; set; }

    /// <summary>
    /// Invoice created for this sales order.
    /// </summary>
    public Invoice? Invoice { get; set; }

    /// <summary>
    /// Calculates the total amount of the sales order.
    /// </summary>
    public decimal TotalAmount => Quantity * Product.Price;
}