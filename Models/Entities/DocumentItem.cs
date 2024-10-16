namespace KopiusLibrary.Models.Entities
{
    public class DocumentItem
    {
        public Guid Id { get; set; }
        public string? Quantity { get; set; }
        public float Subtotal { get; set; }

        public Book? Book { get; set; }
        public Document? Document { get; set; }
        public Price? Price { get; set; } // 
    }
}
