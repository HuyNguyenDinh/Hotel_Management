using HM.Common.DAL;
using HM.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DAL
{
    public class AccountRep : GenericRep<Hotel_ManagementContext, Account>
    {
        public override Account? Read(string username)
        {
            Account? userAccount = All.FirstOrDefault(a => a.Username == username);
            return userAccount;
        }
    }
}
