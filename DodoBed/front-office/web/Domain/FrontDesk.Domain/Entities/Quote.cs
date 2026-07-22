using FrontDesk.Domain.Enums;

namespace FrontDesk.Domain.Entities;

public class Quote
{
    public Guid Id { get; set; }
    public string QuoteNumber { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public Guid SalesAgentId { get; set; }
    public DateTime RequestedDeliveryDate { get; set; }
    public QuoteStatus Status { get; set; }
    public decimal SubTotal { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal GrandTotal { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
}
