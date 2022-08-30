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

        public User? Delete(string id)
        {
            var res = All.First(u => u.IdentificationCode == id);
            res = Delete(res);
            return res;
        }
        public SingleRsp CreateUser(User user)
        {
            var res = new SingleRsp();
            var o = Create(user);
            if (o == null)
                res.SetError("cannot add user");
            else
                res.SetData("201", o);
            return res;
        }
        public SingleRsp UpdateUser(User user)
        {
            var res = new SingleRsp();
            var o = Update(user);
            if (o == null)
                res.SetError("cannot update user");
            else
                res.SetData("200", o);
            return res;
        }
    }
}
