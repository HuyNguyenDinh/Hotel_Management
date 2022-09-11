using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HM.BLL;
using HM.Common.Rsp;
using HM.Common.Req;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        BillSvc billSvc;
        public BillController()
        {
            billSvc = new();
        }
        [HttpGet("q")]
        public ActionResult<MultipleRsp> GetAllBi()
        {
            var res = new MultipleRsp();
            res = billSvc.GetAll();
            return res;
        }
        [HttpGet("{id}")]
        public ActionResult<SingleRsp> GetBill(int id)
        {
            var res = billSvc.Read(id);
            if (res.Success)
                return Ok(res);
            return NotFound(res);
        }
        [HttpPost]
        public ActionResult<SingleRsp> AddBill([FromBody] BillReq bill)
        {

            var res = billSvc.CreateBill(bill);
            if (res.Success)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpDelete("{id}")]
        public ActionResult<SingleRsp> DeleteBill(int id)
        {
            var res = billSvc.Delete(id);
            if (res.Success)
                return Ok(res);
            return NotFound();
        }
        [HttpPut]
        public ActionResult<SingleRsp> UpdateBill([FromBody] BillReq billReq)
        {
            var res = billSvc.Replace(billReq);
            if (res.Success)
                return Ok(res);
            return NotFound();
        }
    }
}
