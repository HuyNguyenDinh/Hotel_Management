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
    public class BookingController : ControllerBase
    {
        BookingSvc bookingSvc;
        public BookingController()
        {
            bookingSvc = new();
        }
        [HttpGet("q")]
        public ActionResult<MultipleRsp> GetAllBooking(DateTime? dateStart, DateTime? dateEnd)
        {
            var res = new MultipleRsp();
            if (dateStart != null && dateEnd != null)
            {
                res = bookingSvc.GetBookingFilterDate(dateStart.GetValueOrDefault(), dateEnd.GetValueOrDefault());
            }
            else
            {
                res = bookingSvc.GetAll();
            }
            return res;
        }
        [HttpGet("{id}")]
        public ActionResult<SingleRsp> GetBooking(int id)
        {
            var res = bookingSvc.Read(id);
            if (res.Success)
                return Ok(res);
            return NotFound(res);
        }
        [HttpPost("{id}/check-in")]
        public ActionResult<SingleRsp> AddBookingChecking([FromBody] BookingReq booking)
        {

            var res = bookingSvc.CreateBooking(booking);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpPost]
        public ActionResult<SingleRsp> AddBooking([FromBody] BookingReq booking)
        {

            var res = bookingSvc.CreateBooking(booking);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpDelete("{id}")]
        public ActionResult<SingleRsp> DeleteBooking(int id)
        {
            var res = bookingSvc.Delete(id);
            if (res.Success)
                return Ok(res);
            return NotFound();
        }
        [HttpPut]
        public ActionResult<SingleRsp> UpdateBooking([FromBody] BookingReq bookingReq)
        {
            var res = bookingSvc.Replace(bookingReq);
            if (res.Success)
                return Ok(res);
            return NotFound();
        }
    }
}
