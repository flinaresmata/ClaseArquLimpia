using ReservacionesRESTFULL.Bussiness.Entities;
using ReservacionesRESTFULL.Data.DTO;

namespace ReservacionesRESTFULL.Bussiness.Services
{
    public interface IReservationService
    {
        public List<Reservation> GetAll();
        public int Insert(ReservationDTO reservation);
        public List<Room> GetAvailableRooms();
    }
}
