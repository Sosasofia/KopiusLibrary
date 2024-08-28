namespace KopiusLibrary.Models.Entities
{
    public class Branch
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } 
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        //public ICollection<Vendor> Vendors { get; set; } 
    }
}
