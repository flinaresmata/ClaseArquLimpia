using Biblioteca.Data.DTO;
using ReservacionesRESTFULL.Bussiness.Entities;
using ReservacionesRESTFULL.Data.DTO;
using ReservacionesRESTFULL.Data.Repositories;

namespace ReservacionesRESTFULL.Bussiness.Services
{
    public class BookServiceImpl : IBookService
    {
        private readonly BookRepository _bookRepository;

        public BookServiceImpl(BookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public List<Book> FindBooks(BookDTO dto)
        {
            return _bookRepository.Find(dto);
        }

        public int Insert(BookDTO dto)
        {
            try
            {

                return _bookRepository.Insert(new Book()
                {
                    AutorId = dto.AutorId,
                    Name = dto.Name,
                    Description = dto.Description
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error al insertar el libro {dto.Name}");
            }
        }
    }
}
