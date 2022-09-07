using HM.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HM.BLL;
using HM.Common.Req;
using HM.DAL.Models;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserSvc userSvc;
        AccountSvc accountSvc;
        public UsersController()
        {
            userSvc = new UserSvc();
            accountSvc = new AccountSvc();
        }
        [HttpGet]
        public ActionResult<MultipleRsp> GetAllUser()
        {
            var res = userSvc.GetAll();
            if (res.Success)
                return Ok(res);
            return NotFound(res);

        }
        [HttpGet("{code}")]
        public ActionResult<SingleRsp> GetUser(string code)
        {
            var res = userSvc.Read(code);
            if (res.Success)
                return Ok(res);
            return NotFound(res);
        }
        [HttpPost]
        public ActionResult<SingleRsp> AddUser([FromBody] UserReq userReq)
        {
            UserReq user = new()
            {
                IdentificationCode = userReq.IdentificationCode,
                FirstName = userReq.FirstName,
                LastName = userReq.LastName,
                Email = userReq.Email,
                PhoneNumber = userReq.PhoneNumber
            };
            SingleRsp res = userSvc.CreateUser(user);
            if (res.Success)
                return Ok(res);
            return BadRequest();
        }
        [HttpPost("Register")]
        public ActionResult<SingleRsp> AddUserAccount([FromBody] CreateUserAccountReq createUserAccountReq)
        {
            UserReq user = new()
            {
                IdentificationCode = createUserAccountReq.IdentificationCode,
                FirstName = createUserAccountReq.FirstName,
                LastName = createUserAccountReq.LastName,
                Email = createUserAccountReq.Email,
                PhoneNumber = createUserAccountReq.PhoneNumber
            };
            SingleRsp res = userSvc.CreateUser(user);
            if (res.Success)
            {
                AccountReq accountReq = new()
                {
                    Username = createUserAccountReq.AccountReq.Username,
                    Password = createUserAccountReq.AccountReq.Password,
                };
                accountSvc.CreateAccount(accountReq, createUserAccountReq.IdentificationCode);
                return Ok(res);
            }
            return BadRequest();
        }
        [HttpPost("test-login")]
        public ActionResult<SingleRsp> TestLogin([FromBody] AccountReq account)
        {
            var res = accountSvc.Check(account);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);

        }
        [HttpDelete("{code}")]
        public ActionResult<SingleRsp> DeleteUser(string code)
        {
            var res = userSvc.Delete(code);
            if (res.Success)
                return Ok(res);
            return NotFound();
        }
        [HttpPut]
        public ActionResult<SingleRsp> UpdateUser([FromBody] UserReq userReq)
        {
            var res = userSvc.Replace(userReq);
            if (res.Success)
                return Ok(res);
            return NotFound();
        }
    }
}
