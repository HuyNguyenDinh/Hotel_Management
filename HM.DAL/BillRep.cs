using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HM.Common.DAL;
using HM.DAL.Models;

namespace HM.DAL
{
    public class BillRep : GenericRep<Hotel_ManagementContext, Bill>
    {
        public override Bill? Read(int id)
        {
            var res = All.FirstOrDefault(x => x.BookingId == id);
            return res;
        }
        public override Bill? Delete(int id)
        {
            var res = All.FirstOrDefault(u => u.BookingId == id);
            if (res != null)
                res = Delete(res);
            return res;
        }
    }
}
