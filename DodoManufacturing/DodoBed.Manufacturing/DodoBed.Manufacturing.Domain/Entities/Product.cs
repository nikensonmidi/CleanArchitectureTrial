namespace DodoBed.Manufacturing.Domain.Entities
{
    public class Product : Item
    {
        public string Notes { get; set; }
        public string InHouseName { get; set; }

    }

    public class ManufacturedProduct : Product
    {
        public Dimension Dimension { get; set; }
    }
}
