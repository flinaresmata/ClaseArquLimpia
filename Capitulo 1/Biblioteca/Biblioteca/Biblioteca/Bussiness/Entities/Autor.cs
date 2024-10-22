using System.Text.Json.Serialization;

namespace ReservacionesRESTFULL.Bussiness.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Nationality { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
    }
}
