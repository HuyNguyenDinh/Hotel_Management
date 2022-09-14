using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Common.Req
{
    public class RatingReq
    {
        public int Rate { get; set; }
        public string? Comment { get; set; }
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int RoomId { get; set; }
    }
}
