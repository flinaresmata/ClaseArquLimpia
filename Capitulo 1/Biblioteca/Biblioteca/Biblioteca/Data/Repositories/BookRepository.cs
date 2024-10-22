using Biblioteca.Data.DTO;
using Microsoft.EntityFrameworkCore;
using ReservacionesRESTFULL.Bussiness.Entities;

namespace ReservacionesRESTFULL.Data.Repositories
{
    public class BookRepository
    {
        private readonly AppDBContext _dbContext;

        public BookRepository(AppDBContext dbContext) {
            this._dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public int Insert(Book book)
        {
            _dbContext.Books.Add(book);
            var result = _dbContext.SaveChanges();
            return result;
        }

        public List<Book> GetAll()
        {
            return _dbContext.Books.ToList();
        }

        public List<Book> Find(BookDTO pBook)
        {
            List<Book> books = _dbContext.Books.Where(b => 
            (String.IsNullOrEmpty(pBook.Name) || b.Name.ToLower().Equals(pBook.Name.ToLower()))
            && (String.IsNullOrEmpty(pBook.Autor) || b.Autor.Name.ToLower().Equals(pBook.Autor.ToLower()))).ToList();
            return books.Count() > 0 ? books : throw new Exception($"No existe {pBook.Name}");
        }
    }
}
