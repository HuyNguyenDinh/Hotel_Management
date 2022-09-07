using System;
using System.Collections.Generic;

namespace HM.DAL.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
            Ratings = new HashSet<Rating>();
        }

        public int? Id { get; set; }
        public int Bed { get; set; }
        public double Price { get; set; }
        public bool? IsFree { get; set; }
        public byte[] Picture { get; set; } = null!;
        public int MaxHumans { get; set; }
        public int? RoomTypeId { get; set; }

        public virtual RoomType? RoomType { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
