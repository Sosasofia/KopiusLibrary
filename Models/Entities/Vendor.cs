namespace KopiusLibrary.Models.Entities
{
    public class Vendor
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateOut { get; set; }
        public Branch? Branch { get; set; }  //
    }
}
