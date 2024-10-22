﻿using ReservacionesRESTFULL.Bussiness.Entities;

namespace ReservacionesRESTFULL.Data.DTO
{
    public class ReservationDTO
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
    }
}
