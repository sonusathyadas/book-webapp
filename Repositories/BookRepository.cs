using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookManager.Data;
using BookManager.Models;

namespace BookManager.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public IEnumerable<Book> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return GetAll();
            }

            return _context.Books
                .Where(book => book.Title.Contains(query)
                    || book.Author.Contains(query)
                    || book.Genre.Contains(query)
                    || book.Language.Contains(query))
                .ToList();
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}