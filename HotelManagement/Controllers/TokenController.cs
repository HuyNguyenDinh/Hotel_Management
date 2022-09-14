using HM.BLL;
using HM.Common.Req;
using HM.Common.Rsp;
using HM.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfigurationRoot _configuration;
        private readonly TokenSvc _tokenSvc;
        private readonly AccountSvc _accountSvc;

        public TokenController()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _tokenSvc = new();
            _accountSvc = new();
        }

        [HttpPost]
        public ActionResult<SingleRsp> Post(AccountReq accountReq)
        {
            var acc = _accountSvc.Check(accountReq);
            SingleRsp res;
            if (acc.Success)
            {
                res = _tokenSvc.GenerateToken(accountReq, _configuration);
                if (res.Success)
                    return Ok(res);
                return BadRequest(res);
            }
            res = acc;
            return res;
        }
    }
}