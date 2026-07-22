namespace FrontDesk.Domain.Entities;

public class OrderLineItem
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
}
