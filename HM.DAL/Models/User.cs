using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HM.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Ratings = new HashSet<Rating>();
        }

        public string IdentificationCode { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Account? Account { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Booking> Bookings { get; set; }
        [JsonIgnore]
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
