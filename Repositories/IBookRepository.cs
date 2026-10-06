using BookManager.Models;

namespace BookManager.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        IEnumerable<Book> Search(string query);
        void Add(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}