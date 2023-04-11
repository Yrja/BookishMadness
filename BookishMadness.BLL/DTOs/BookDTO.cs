﻿namespace BookishMadness.DAL.Entities
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int PagesCount { get; set; }
        public string Genre { get; set; }
    }
}
