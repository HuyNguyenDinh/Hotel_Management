using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HM.DAL.Models
{
    public partial class Account
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        [JsonIgnore]
        public bool? IsStaff { get; set; } = false!;
        [JsonIgnore]
        public string UserId { get; set; } = null!;

        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
