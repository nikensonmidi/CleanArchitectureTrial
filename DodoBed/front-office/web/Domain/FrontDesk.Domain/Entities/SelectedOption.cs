namespace FrontDesk.Domain.Entities;

public class SelectedOption
{
    public Guid Id { get; set; }
    public Guid QuoteLineItemId { get; set; }
    public Guid ProductOptionValueId { get; set; }
}
