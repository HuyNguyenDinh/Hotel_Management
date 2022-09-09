using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HM.Common.BLL;
using HM.DAL.Models;
using HM.DAL;
using HM.Common.Rsp;
using HM.Common.Req;

namespace HM.BLL
{
    public class RoomSvc : GenericSvc<RoomRep, Room>
    {
        public override SingleRsp Read(int id)
        {
            var m = All.FirstOrDefault(x => x.Id == id);
            var res = new SingleRsp();
            if (m != null)
                res.SetData("200", m);
            else
                res.SetError("not found");
            return res;
        }
        public MultipleRsp GetFreeRoom()
        {
            var m = All.Where(x => x.IsFree == true).Select(x => new RoomReq()
            {
                Id = x.Id,
                Bed = x.Bed,
                Price = x.Price,
                IsFree = x.IsFree,
                Picture = x.Picture,
                MaxHumans = x.MaxHumans,
                RoomTypeId = x.RoomTypeId
            }).ToList();
            var res = new MultipleRsp();
            if (m != null)
                res.SetData(new List<object>(m), "200");
            else
                res.SetError("No free room at now");
            return res;
        }
        public MultipleRsp GetFreeRoom(DateTime startDate, DateTime endDate)
        {
            var m = _rep.FilterByDate(startDate, endDate, true).Select(x => new RoomReq()
            {
                Id = x.Id,
                Bed = x.Bed,
                Price = x.Price,
                IsFree = x.IsFree,
                Picture = x.Picture,
                MaxHumans = x.MaxHumans,
                RoomTypeId = x.RoomTypeId
            }).ToList();
            var res = new MultipleRsp();
            if (m != null)
                res.SetData(new List<object>(m), "200");
            else
                res.SetError("No free room at now");
            return res;
        }
        public SingleRsp Create(RoomReq roomReq)
        {
            Room m = new()
            {
                Bed = roomReq.Bed,
                Price = roomReq.Price,
                IsFree = true,
                Picture = roomReq.Picture,
                MaxHumans = roomReq.MaxHumans,
                RoomTypeId = roomReq.RoomTypeId
            };
            return base.Create(m);
        }
        public override MultipleRsp GetAll()
        {
            var m = All.Select(x => new RoomReq
            {
                Id = x.Id,
                Bed = x.Bed,
                Price = x.Price,
                IsFree = x.IsFree,
                Picture = x.Picture,
                MaxHumans = x.MaxHumans,
                RoomTypeId = x.RoomTypeId
            }).ToList();
            var res = new MultipleRsp();
            if (m != null)
                res.SetData(new List<object>(m), "200");
            else
                res.SetError("No room");
            return res;
        }
        public MultipleRsp GetAll(DateTime startDate, DateTime endDate)
        {
            MultipleRsp res = new MultipleRsp();
            var m = _rep.FilterByDate(startDate, endDate, false).ToList();
            if (m != null)
                res.SetData(new List<object>(m), "200");
            else
                res.SetError("not found rooms that do not have booking in these days");
            return res;

        }
    }
}
