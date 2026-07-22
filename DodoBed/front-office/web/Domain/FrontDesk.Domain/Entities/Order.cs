using FrontDesk.Domain.Enums;

namespace FrontDesk.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public Guid? QuoteId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid SalesAgentId { get; set; }
    public OrderStatus Status { get; set; }
    public string BatchProductionId { get; set; } = string.Empty;
    public DateTime ConfirmedDeliveryDate { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }
}
