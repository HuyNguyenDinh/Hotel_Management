using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HM.Common.BLL;
using HM.DAL;
using HM.DAL.Models;
using HM.Common.Rsp;
using HM.Common.Req;

namespace HM.BLL
{
    public class BillSvc : GenericSvc<BillRep, Bill>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            if (m == null)
                res.SetError("404", "not found");
            else
            {
                BillReq result = new BillReq
                {
                    Price = m.Price,
                    Humans = m.Humans,
                    BookingId = m.BookingId,
                };
                res.SetData("200", result);
            }
            return res;
        }
        public SingleRsp CreateBill(BillReq billReq)
        {
            Bill? bill = new()
            {
                Price = billReq.Price,
                Humans = billReq.Humans,
                BookingId = billReq.BookingId,
            };
            var res = Create(bill);
            return res;
        }
        public override SingleRsp Delete(int id)
        {
            Bill? m = _rep.Delete(id);
            var res = new SingleRsp();
            if (m == null)
                res.SetError("NotFound");
            else
                res.SetData("204", m);
            return res;
        }
        public SingleRsp Replace(BillReq billReq)
        {
            SingleRsp res = new();
            if (billReq.BookingId == null)
            {
                res.SetError("Id can not be null");
                return res;
            }

            var m = _rep.Read(billReq.BookingId);

            if (m != null)
            {
                m.Price = billReq.Price;
                m.Humans = billReq.Humans;
                res = Update(m);
            }
            return res;
        }
    }
}
