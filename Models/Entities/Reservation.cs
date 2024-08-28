namespace KopiusLibrary.Models.Entities
{
    public class Reservation 
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; } 
        public DateTime DueDate { get; set; } 

        public Status? Status { get; set; }
        public Client? Client { get; set; } 
        public Vendor? Vendor { get; set; }
        public Book? Book { get; set; }
    }
}
