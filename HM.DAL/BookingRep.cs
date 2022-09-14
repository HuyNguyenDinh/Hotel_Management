using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HM.Common.DAL;
using HM.DAL.Models;

namespace HM.DAL
{
    public class BookingRep : GenericRep<Hotel_ManagementContext, Booking>
    {
        public override Booking? Read(int id)
        {
            var res = All.FirstOrDefault(x => x.Id == id);
            return res;
        }
        public override Booking? Delete(int id)
        {
            var res = All.FirstOrDefault(u => u.Id == id);
            if (res != null)
                res = Delete(res);
            return res;
        }
        public IQueryable<Booking> FilterByDate(DateTime startDate, DateTime endDate)
        {
            //var bookings = All.Where(x => x.StartDate >= startDate && x.EndDate <= endDate);
            var bookings = All.Where(x => x.StartDate <= endDate && x.EndDate >= startDate);
            return bookings;
        }
        public List<Booking> BookingRoomInDateRange(DateTime startDate, DateTime endDate, int roomID) 
        {
            var booking = All.Where(x => x.StartDate <= endDate && x.EndDate >= startDate && x.RoomId == roomID);
            return booking.ToList();
        }
    }
}
