namespace ErpOrderApi.Domain.Entities;

/// <summary>
/// Represents a delivery document in the ERP order-to-invoice process.
/// A delivery is created after the sales order and before the invoice.
/// </summary>
public class Delivery
{
    /// <summary>
    /// Technical database identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Business delivery number.
    /// Example: DL-1001.
    /// </summary>
    public string DeliveryNumber { get; set; } = string.Empty;

    /// <summary>
    /// Foreign key of the related sales order.
    /// </summary>
    public int SalesOrderId { get; set; }

    /// <summary>
    /// Sales order related to this delivery.
    /// </summary>
    public SalesOrder SalesOrder { get; set; } = null!;

    /// <summary>
    /// Date and time when the delivery was created.
    /// </summary>
    public DateTime DeliveredAt { get; set; } = DateTime.UtcNow;
}