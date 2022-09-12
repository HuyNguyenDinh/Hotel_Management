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
    public class BookingSvc : GenericSvc<BookingRep, Booking>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            if (m == null)
                res.SetError("404", "not found");
            else
            {
                BookingReq result = new BookingReq
                {
                    Id = m.Id,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    CheckIn = m.CheckIn,
                    RoomId = m.RoomId,
                    UserId = m.UserId,
                };
                res.SetData("200", result);
            }
            return res;
        }
        public SingleRsp CreateBooking(BookingReq bookingReq)
        {
            Booking? booking = new()
            {
                StartDate = bookingReq.StartDate,
                EndDate = bookingReq.EndDate,
                CheckIn = bookingReq.CheckIn,
                RoomId = bookingReq.RoomId,
                UserId = bookingReq.UserId
            };
            var res = Create(booking);
            return res;
        }
        public MultipleRsp GetBookingFilterDate(DateTime startDate, DateTime endDate)
        {
            var m = _rep.FilterByDate(startDate, endDate).Select(x => new BookingReq()
            {
                Id = x.Id,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                CheckIn = x.CheckIn,
                RoomId = x.RoomId,
                UserId = x.UserId,
            }).ToList();
            var res = new MultipleRsp();
            if (m != null)
                res.SetData(new List<object>(m), "200");
            else
                res.SetError("No booking at now");
            return res;
        }
        public override SingleRsp Delete(int id)
        {
            Booking? m = _rep.Delete(id);
            var res = new SingleRsp();
            if (m == null)
                res.SetError("NotFound");
            else
                res.SetData("204", m);
            return res;
        }
        public SingleRsp Replace(BookingReq bookingReq)
        {
            SingleRsp res = new();
            if (bookingReq.Id == null)
            {
                res.SetError("Id can not be null");
                return res;
            }

            var m = _rep.Read(bookingReq.Id.GetValueOrDefault());


            if (m != null)
            {
                m.StartDate = bookingReq.StartDate;
                m.EndDate = bookingReq.EndDate;
                m.CheckIn = bookingReq.CheckIn;
                res = Update(m);
            }
            return res;
        }
    }
}
