using HM.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HM.BLL;
using HM.Common.Req;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserSvc userSvc;
        public UsersController()
        {
            userSvc = new UserSvc();
        }
        [HttpGet]
        public ActionResult<MultipleUserRsp> GetAllUser()
        {
            var res = userSvc.Read();
            if (res.Success)
                return Ok(res);
            return NotFound(res);

        }
        [HttpGet("{code}")]
        public ActionResult<UserRsp> GetUser(string code)
        {
            var res = userSvc.Read(code);
            if (res.Success)
                return Ok(res);
            return NotFound(res);
        }
        [HttpPost]
        public ActionResult<UserRsp> AddUser([FromBody] UserReq userReq)
        {
            var res = userSvc.CreateUser(userReq);
            if (res.Success)
                return Ok(res);
            return BadRequest();
        }
    }
}
