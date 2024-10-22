using Microsoft.EntityFrameworkCore;
using ReservacionesRESTFULL.Bussiness.Entities;

namespace ReservacionesRESTFULL.Data.Repositories
{
    public class ReservationRepository
    {
        private readonly AppDBContext _dbContext;

        public ReservationRepository(AppDBContext dbContext)
        {
            this._dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public int Insert(Reservation reservation){
            _dbContext.Reservations.Add(reservation);
            var result = _dbContext.SaveChanges();
            return result;
        }

        public Reservation FindById(int id) {
            var result = _dbContext.Reservations.Find(id);
            return result != null ? result : throw new Exception($"No existe reservación {id}");
        }

        public List<Reservation> GetAll() {
            return _dbContext.Reservations
                .Include(r => r.Room)
                .Include(r => r.User)
                .ToList();
        }
    }
}
