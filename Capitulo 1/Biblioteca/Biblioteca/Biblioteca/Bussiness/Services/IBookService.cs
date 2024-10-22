using Biblioteca.Data.DTO;
using ReservacionesRESTFULL.Bussiness.Entities;
using ReservacionesRESTFULL.Data.DTO;
using ReservacionesRESTFULL.Data.Repositories;

namespace ReservacionesRESTFULL.Bussiness.Services
{
    public interface IBookService
    {
        public List<Book> GetAll();

        public List<Book> FindBooks(BookDTO dto);

        public int Insert(BookDTO dto);
    }
}
