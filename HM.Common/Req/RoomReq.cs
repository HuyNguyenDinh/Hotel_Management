using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Common.Req
{
    public class RoomReq
    {
        public int? Id { get; set; }
        public int Bed { get; set; }
        public double Price { get; set; }
        public bool? IsFree { get; set; }
        public byte[] Picture { get; set; } = null!;
        public int MaxHumans { get; set; }
        public int? RoomTypeId { get; set; }
    }
}
