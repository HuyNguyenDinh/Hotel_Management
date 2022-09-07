using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HM.Common.DAL;
using HM.Common.Rsp;
using HM.DAL.Models;

namespace HM.DAL
{
    public class UserRep : GenericRep<Hotel_ManagementContext, User>
    {
        public override User? Read(string id)
        {
            var res = All.FirstOrDefault(u => u.IdentificationCode == id);
            return res;
        }

        public override User? Delete(string id)
        {
            var res = All.FirstOrDefault(u => u.IdentificationCode == id);
            if (res != null)
                res = Delete(res);
            return res;
        }
    }
}
