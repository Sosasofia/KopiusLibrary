﻿namespace KopiusLibrary.Models.Entities
{
    public class Book 
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Isbn { get; set; }
        public string? Published { get; set; }

        public Guid PublisherId { get; set; }
        public Guid BranchId { get; set; }

        public Branch? Branch { get; set; }
        public Publisher? Publisher { get; set; }

        public IEnumerable<AuthorBook> BookAuthors { get; set; } 
        public IEnumerable<BookGenre> BookGenres { get; set; } 
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
