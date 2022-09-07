using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HM.DAL.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public int? Id { get; set; }
        public string Name { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
