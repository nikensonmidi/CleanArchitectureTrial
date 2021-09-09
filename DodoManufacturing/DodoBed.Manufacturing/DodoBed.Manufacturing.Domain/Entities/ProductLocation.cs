namespace DodoBed.Manufacturing.Domain.Entities
{
    public class ProductLocation : StorageLocation
    {
        public int ProductLocationId { get; set; }
        public Product Product { get; set; }
    }
}
