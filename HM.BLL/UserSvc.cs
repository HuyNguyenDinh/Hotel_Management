using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HM.Common.BLL;
using HM.DAL;
using HM.DAL.Models;
using HM.Common.Rsp;
using HM.Common.Req;

namespace HM.BLL
{
    public class UserSvc : GenericSvc<UserRep, User>
    {
        public override SingleRsp Read(string code)
        {
            var res = new SingleRsp();
            var m = _rep.Read(code);
            if (m == null)
                res.SetError("404", "not found");
            else
            {
                UserReq result = new UserReq {
                    Email = m.Email,
                    IdentificationCode = m.IdentificationCode,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    PhoneNumber = m.PhoneNumber
                };
                res.SetData("200", result);
            }
            return res;
        }
        public SingleRsp CreateUser(UserReq userReq)
        {
            User? user = new()
            {
                IdentificationCode = userReq.IdentificationCode,
                FirstName = userReq.FirstName,
                LastName = userReq.LastName,
                Email = userReq.Email,
                PhoneNumber = userReq.PhoneNumber
            };
            var res = Create(user);
            return res;
        }
        public override SingleRsp Delete(string code)
        {
            User? m = _rep.Delete(code);
            var res = new SingleRsp();
            if (m == null)
                res.SetError("NotFound");
            else
                res.SetData("204", m);
            return res;
        }
        public SingleRsp Replace(UserReq userReq)
        {
            SingleRsp res = new();
            var m = _rep.Read(userReq.IdentificationCode);
            if (m != null)
            {
                m.FirstName = userReq.FirstName;
                m.LastName = userReq.LastName;
                m.Email = userReq.Email;
                m.PhoneNumber = userReq.PhoneNumber;
                res = Update(m);
            }
            return res;
        }
    }
}
