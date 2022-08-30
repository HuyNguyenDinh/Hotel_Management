using System;
using System.Collections.Generic;

namespace HM.DAL.Models
{
    public partial class Rating
    {
        public int Rate { get; set; }
        public string? Comment { get; set; }
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int RoomId { get; set; }

        public virtual Room Room { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
