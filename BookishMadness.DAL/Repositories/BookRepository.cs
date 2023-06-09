﻿using BookishMadness.DAL.EF;
using BookishMadness.DAL.Entities;
using BookishMadness.DAL.Interfaces;
using BookishMadness.DAL.Strategy;
using Microsoft.EntityFrameworkCore;

namespace BookishMadness.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private AppDbContext db;

        public IBooksSummaryStrategy Strategy { get; set; }

        public BookRepository(AppDbContext db)
        {
            this.db = db;
        }

        public Book Create(Book item)
        {
            db.Books.Add(item);
            return item;
        }

        public void Delete(Guid id)
        {
            var book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return db.Books.Where(predicate);
        }

        public Book Get(Guid id)
        {
            return db.Books.Include(it => it.Author)
                .Include(it => it.Reactions)
                .Include(it => it.Genres)
                .FirstOrDefault(it => it.Id.Equals(id));
        }

        public IQueryable<Book> GetAll()
        {
            return db.Books.Include(it => it.Author)
                .Include(it => it.Reactions)
                .Include(it => it.Genres);
        }

        public Book Update(Book item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public IQueryable<BookSummary> GetBooksSummary(DateTime? dateFrom, DateTime? dateTo, Guid? bookId, bool useProcedure)
        {
            return Strategy.GetBooksSummary(dateFrom, dateTo, bookId, db);
        }

        public IQueryable<BookSummary> AllBooks()
        {
            return db.BooksSummary;
        }
    }
}
