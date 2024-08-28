namespace KopiusLibrary.Models.Entities
{
    public class Tax
    {
        public Guid Id { get; set; } // Primary key
        public string? Description { get; set; } 
        public string? Type { get; set; }
        public decimal Rate { get; set; } // 0.5 ?? % ?? fixed
    }

}
