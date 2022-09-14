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
        BookingSvc bookingSvc;
        public RoomController()
        {
            roomSvc = new();
            bookingSvc = new();
        }

        [HttpGet("q")]
        public ActionResult<MultipleRsp> GetAllRooms(bool? free, DateTime? dateStart, DateTime? dateEnd)
        {
            var res = new MultipleRsp();
            if (free != null && free.GetValueOrDefault())
            {
                if (dateStart != null && dateEnd != null)
                    res = roomSvc.GetFreeRoom(dateStart.GetValueOrDefault(), dateEnd.GetValueOrDefault());
                else
                    res = roomSvc.GetFreeRoom();
            }
            else
            {
                if (dateStart != null && dateEnd != null)
                    res = roomSvc.GetAll(dateStart.GetValueOrDefault(), dateEnd.GetValueOrDefault());
                else
                    res = roomSvc.GetAll();
            }
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
        [HttpPut]
        public ActionResult<SingleRsp> UpdateRoom([FromBody] RoomReq roomReq)
        {
            var res = roomSvc.Update(roomReq);
            if (res.Success)
                return Ok(res);
            return NotFound(res);
        }
        [HttpPost("{id}/Booking")]
        public ActionResult<SingleRsp> Booking([FromBody] BookingReq bookingReq, int id)
        {
            if (id != bookingReq.RoomId)
            {
                return BadRequest();
            }
            var res = bookingSvc.CreateBooking(bookingReq);
            if (res.Success)
                return Ok(res);
            return NotFound(res);
        }
    }
}
