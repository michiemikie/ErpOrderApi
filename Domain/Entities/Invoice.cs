namespace ErpOrderApi.Domain.Entities;

/// <summary>
/// Represents an invoice in the ERP order-to-invoice process.
/// An invoice is created after a successful delivery.
/// </summary>
public class Invoice
{
    /// <summary>
    /// Technical database identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Business invoice number.
    /// Example: INV-1001.
    /// </summary>
    public string InvoiceNumber { get; set; } = string.Empty;

    /// <summary>
    /// Foreign key of the related sales order.
    /// </summary>
    public int SalesOrderId { get; set; }

    /// <summary>
    /// Sales order related to this invoice.
    /// </summary>
    public SalesOrder SalesOrder { get; set; } = null!;

    /// <summary>
    /// Total invoice amount.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Current payment status of the invoice.
    /// Example: Open, Paid.
    /// </summary>
    public string Status { get; set; } = "Open";

    /// <summary>
    /// Date and time when the invoice was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}