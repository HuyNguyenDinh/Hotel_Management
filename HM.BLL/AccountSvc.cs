using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HM.Common.BLL;
using HM.DAL.Models;
using HM.DAL;
using HM.Common.Rsp;
using HM.Common.Req;

namespace HM.BLL
{
    public class AccountSvc : GenericSvc<AccountRep, Account>
    {
        public override SingleRsp Read(string username)
        {
            SingleRsp res = new();
            var m = _rep.Read(username);
            if (m == null)
                res.SetError("User don't have account");
            else
                res.SetData("200", m);
            return res;

        }
        public SingleRsp CreateAccount(AccountReq accountReq, string code)
        {
            Account account = new()
            {
                Username = accountReq.Username,
                Password = Hash.hashPassword(accountReq.Password),
                UserId = code,
                IsStaff = false
            };
            var m = Create(account);
            SingleRsp res = new();
            if (m != null)
                res.SetData("201", m);
            else
                res.SetError("cannot create");
            return res;
        }
        public SingleRsp Check(AccountReq account)
        {
            SingleRsp res = new();
            var m = _rep.Read(account.Username);
            if (m != null)
            {
                if (m.Password.Equals(Hash.hashPassword(account.Password)))
                    res.SetData("Login success", m.User);
                else
                    res.SetError("Password not correct");
            }
            else
                res.SetError("Username not found");
            return res;
        }
    }
}
