using FrontDesk.Domain.Enums;

namespace FrontDesk.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public Guid SalesAgentId { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string TaxId { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public decimal CurrentBalance { get; set; }
    public PricingTier PricingTier { get; set; }
    public Guid BillingAddressId { get; set; }
    public Guid ShippingAddressId { get; set; }
}
