using System.ComponentModel.DataAnnotations.Schema;

namespace KopiusLibrary.Models.Entities
{
    public class Status
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        
    }
}
