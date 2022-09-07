using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Common.Req
{
    public class CreateUserAccountReq
    {
        public string IdentificationCode { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
        public AccountReq AccountReq { get; set; }
    }
}
