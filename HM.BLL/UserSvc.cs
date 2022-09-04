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
        UserRep userRep = new UserRep();
        
        public MultipleUserRsp Read()
        {
            var res = new MultipleUserRsp();
            if (All == null)
                res.SetError("not found");
            else
            {
                var data = All.Select(u => new UserReq
                {
                    IdentificationCode = u.IdentificationCode,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber
                });
                res.SetData(data.ToList());
            }
                
            return res;
        }
        public override UserRsp Read(string code)
        {
            var res = new UserRsp();
            var m = userRep.Read(code);
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
        public UserRsp CreateUser(UserReq userReq)
        {
            User user = new User
            {
                IdentificationCode = userReq.IdentificationCode,
                Email = userReq.Email,
                FirstName = userReq.FirstName,
                LastName = userReq.LastName,
                PhoneNumber = userReq.PhoneNumber
            };
            var res = new UserRsp();
            var m = Create(user);
            if (m.Success)
                res.SetData("201", userReq);
            else
                res.SetError("cannot add user, please check Identification");
            return res;
        }
    }
}
