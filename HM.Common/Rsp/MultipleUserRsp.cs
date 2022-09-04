using HM.Common.Req;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Common.Rsp
{
    public class MultipleUserRsp : SingleRsp
    {
        public new List<UserReq>? Data;
        public void SetData(List<UserReq> userReqs)
        {
            Data = userReqs;
        }
    }
    
}
