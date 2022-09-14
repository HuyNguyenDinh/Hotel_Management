using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HM.Common.DAL;
using HM.DAL.Models;

namespace HM.DAL
{
    public class RatingRep : GenericRep<Hotel_ManagementContext, Rating>
    {
        public override Rating? Read(int id)
        {
            var res = All.FirstOrDefault(x => x.Id == id);
            return res;
        }
        public override Rating? Delete(int id)
        {
            var res = All.FirstOrDefault(u => u.Id == id);
            if (res != null)
                res = Delete(res);
            return res;
        }
    }
}
