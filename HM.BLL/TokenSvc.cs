using HM.BLL;
using HM.Common.Req;
using HM.Common.Rsp;
using HM.DAL;
using HM.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HM.BLL
{
    public class TokenSvc
    {
        private readonly UserRep _userRep;
        private readonly AccountRep _accountRep;
        public TokenSvc()
        {
            _userRep = new();
            _accountRep = new();
        }
        public SingleRsp GenerateToken(AccountReq accountReq, IConfiguration _configuration)
        {
            var res = new SingleRsp();
            var account = _accountRep.Read(accountReq.Username);
            if (account == null)
            {
                res.SetError("404","Username or password was not correct");
            }
            else
            {
                var user = _userRep.Read(account.UserId);
                if (user != null)
                {
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.IdentificationCode),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("PhoneNumber", user.PhoneNumber),
                    new Claim("Email", user.Email)
                };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                    var tokenResult = new JwtSecurityTokenHandler().WriteToken(token);
                    res.SetData("200", tokenResult);
                }
                else
                    res.SetError("404", "user not found");
            }
            return res;
        }
    }
}
