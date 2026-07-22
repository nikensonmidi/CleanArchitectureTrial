namespace FrontDesk.Domain.Entities;

public class QuoteLineItem
{
    public Guid Id { get; set; }
    public Guid QuoteId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }
}
