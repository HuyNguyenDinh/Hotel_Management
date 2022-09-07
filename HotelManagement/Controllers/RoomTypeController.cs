using HM.BLL;
using HM.Common.Rsp;
using HM.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private RoomTypeSvc roomTypeSvc;
        public RoomTypeController()
        {
            roomTypeSvc = new RoomTypeSvc();
        }
        [HttpGet]
        public ActionResult<MultipleRsp> ListRoomType()
        {
            var res = roomTypeSvc.GetAll();
            if (res.Success)
                return Ok(res);
            return NotFound(res);
        }
        [HttpGet("{id}")]
        public ActionResult<MultipleRsp> GetRoomsByRoomType(int id)
        {
            var res = roomTypeSvc.GetRooms(id);
            if (res.Success)
                return Ok(res);
            return NotFound(res);
        }
        [HttpPost]
        public ActionResult<SingleRsp> AddRoomType([FromBody] RoomType roomType)
        {
            var res = roomTypeSvc.Create(roomType);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpPut]
        public ActionResult<SingleRsp> UpdateRoomType([FromBody] RoomType roomType)
        {
            var res = roomTypeSvc.Replace(roomType);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpDelete("{id}")]
        public ActionResult<SingleRsp> DeleteRoomType(int id)
        {
            var res = roomTypeSvc.Delete(id);
            if (res.Success)
                return Ok(res);
            return NotFound(res);
        }
    }
}
