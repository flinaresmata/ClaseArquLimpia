using System.Text.Json.Serialization;

namespace ReservacionesRESTFULL.Bussiness.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomId { get; set; }
        public bool Available { get; set; }

        [JsonIgnore]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
