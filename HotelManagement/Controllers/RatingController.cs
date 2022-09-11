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
    public class RatingController : ControllerBase
    {
        RatingSvc ratingSvc;
        public RatingController()
        {
            ratingSvc = new();
        }
        [HttpGet("q")]
        public ActionResult<MultipleRsp> GetAllRating()
        {
            var res = new MultipleRsp();
            res = ratingSvc.GetAll();
            return res;
        }
        [HttpGet("{id}")]
        public ActionResult<SingleRsp> GetRating(int id)
        {
            var res = ratingSvc.Read(id);
            if (res.Success)
                return Ok(res);
            return NotFound(res);
        }
        [HttpPost]
        public ActionResult<SingleRsp> AddRating([FromBody] RatingReq rating)
        {

            var res = ratingSvc.CreateRating(rating);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpDelete("{id}")]
        public ActionResult<SingleRsp> DeleteRating(int id)
        {
            var res = ratingSvc.Delete(id);
            if (res.Success)
                return Ok(res);
            return NotFound();
        }
        [HttpPut]
        public ActionResult<SingleRsp> UpdateRating([FromBody] RatingReq ratingReq)
        {
            var res = ratingSvc.Replace(ratingReq);
            if (res.Success)
                return Ok(res);
            return NotFound();
        }
    }
}
