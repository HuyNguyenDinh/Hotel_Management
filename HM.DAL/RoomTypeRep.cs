using HM.Common.DAL;
using HM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DAL
{
    public class RoomTypeRep : GenericRep<Hotel_ManagementContext, RoomType>
    {
        public override RoomType? Read(int id)
        {
            var res = All.FirstOrDefault(x => x.Id == id);
            return res;
        }
        public override RoomType? Delete(int id)
        {
            var res = All.FirstOrDefault(u => u.Id == id);
            if (res != null)
                res = Delete(res);
            return res;
        }
    }
}
