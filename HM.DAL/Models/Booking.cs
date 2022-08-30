using System;
using System.Collections.Generic;

namespace HM.DAL.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CheckIn { get; set; }
        public int? RoomId { get; set; }
        public string? UserId { get; set; }

        public virtual Room? Room { get; set; }
        public virtual User? User { get; set; }
        public virtual Bill Bill { get; set; } = null!;
    }
}
