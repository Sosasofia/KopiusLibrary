namespace KopiusLibrary.Models.Entities
{
    public class Discount
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; } // % or fixed
        public int Amount { get; set; } // int?
        public DateTime StartDated { get; set; }
        public DateTime EndDated { get; set; }
        public string? Status { get; set; } // active, expired 
    }
}
