namespace KopiusLibrary.Models.Entities
{
    public class Price
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Book? Book { get; set; }

        public float Value {  get; set; }
    }
}
