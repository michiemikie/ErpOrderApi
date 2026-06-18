namespace ErpOrderApi.Domain.Entities;

/// <summary>
/// Represents a customer in the ERP system.
/// In SAP Business One, this is comparable to a business partner with customer role.
/// </summary>
public class Customer
{
    /// <summary>
    /// Technical database identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Business customer number used in ERP processes.
    /// Example: C1001.
    /// </summary>
    public string CustomerNumber { get; set; } = string.Empty;

    /// <summary>
    /// Official customer or company name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// City of the customer.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Customer email address used for communication.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Payment term used for invoices.
    /// Example: 30 days.
    /// </summary>
    public string PaymentTerm { get; set; } = string.Empty;

    /// <summary>
    /// Sales orders created for this customer.
    /// </summary>
    public ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
}