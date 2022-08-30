using System;
using System.Collections.Generic;

namespace HM.DAL.Models
{
    public partial class Account
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsStaff { get; set; }
        public string UserId { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
