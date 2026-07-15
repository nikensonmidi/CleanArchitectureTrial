namespace DodoBed.Manufacturing.Domain.Entities
{
    public class ProductLocation 
    {
        public StorageLocation Location { get; set; }
        public int ProductLocationID { get; set; }
        public Product Product { get; set; }
        public Dimension Size { get; set; }
    }
}
