namespace DodoBed.Manufacturing.Domain.Entities
{
    public class Note
    {
        public Employee Author { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
    }
}