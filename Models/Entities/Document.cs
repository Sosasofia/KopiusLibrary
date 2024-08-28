using Newtonsoft.Json;

namespace KopiusLibrary.Models.Entities
{
    public class Document // invoice
    {

        [JsonProperty("DocumentId")]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public float TotalAmount { get; set; }

        public Discount? Discount { get; set; }
        public Tax? Tax { get; set; }
        public Client? Client { get; set; }
        public Vendor? Vendor { get; set; }
        public DocumentType? Type { get; set; } // rent, buy, reservate
        public Status? Status { get; set; }
        //public DocumentItem? DocumentItem{ get; set; }
        public Branch? Branch { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }


        public Guid DocumentItemId { get; set; }
        public IEnumerable<DocumentItem>? DocumentItems { get; set; }

        //public IEnumerable<Book>? Books { get; set; }
    }
}
