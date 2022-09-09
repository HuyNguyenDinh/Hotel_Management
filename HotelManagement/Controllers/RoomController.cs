using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HM.BLL;
using HM.Common.Rsp;
using HM.DAL.Models;
using HM.Common.Req;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        RoomSvc roomSvc;
        public RoomController()
        {
            roomSvc = new();
        }
        [HttpGet("q")]
        public ActionResult<MultipleRsp> GetAllRooms(bool? free, DateTime? dateStart, DateTime? dateEnd)
        {
            var res = new MultipleRsp();
            if (free != null && free.GetValueOrDefault())
                res = roomSvc.GetFreeRoom();
            else
                res = roomSvc.GetAll();
            return res;
        }
        [HttpGet("{id}")]
        public ActionResult<SingleRsp> GetRoom(int id)
        {
            var res = roomSvc.Read(id);
            if (res.Success)
                return Ok(res);
            return NotFound(res);
        }
        [HttpPost]
        public ActionResult<SingleRsp> AddRoom([FromBody] RoomReq room)
        {

            var res = roomSvc.Create(room);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }
    }
}
