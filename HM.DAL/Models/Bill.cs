using System;
using System.Collections.Generic;

namespace HM.DAL.Models
{
    public partial class Bill
    {
        public double Price { get; set; }
        public int Humans { get; set; }
        public int BookingId { get; set; }

        public virtual Booking Booking { get; set; } = null!;
    }
}
