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
        RoomRep roomRep;
        BookingRep bookingRep;
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
        public SingleRsp CreateBill(int bookingId)
        {
            roomRep = new();
            bookingRep = new();
            SingleRsp res;
            var booking = bookingRep.Read(bookingId);
            if (booking != null)
            {
                var room = roomRep.Read(booking.RoomId.GetValueOrDefault());
                if (room != null)
                {
                    room.IsFree = true;
                    roomRep.Update(room);
                    Bill bill = new()
                    {
                        Price = (booking.EndDate - booking.StartDate).TotalDays * room.Price,
                        Humans = room.MaxHumans,
                        BookingId = booking.Id.GetValueOrDefault(),
                    };
                    res = Create(bill);
                }
                else
                {
                    res = new SingleRsp();
                    res.SetError("400", "Room was invalid");
                }
            }
            else
            {
                res = new SingleRsp();
                res.SetError("404", "booking not found");
            }
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
