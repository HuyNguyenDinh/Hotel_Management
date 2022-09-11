using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Common.Req
{
    public class BillReq
    {
        public double Price { get; set; }
        public int Humans { get; set; }
        public int BookingId { get; set; }
    }
}
