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
    public class RoomTypeSvc : GenericSvc<RoomTypeRep, RoomType>
    {
        private RoomRep roomRep;
        public RoomTypeSvc() : base()
        {
            roomRep = new();
        }
        public MultipleRsp GetRooms(int id)
        {
            MultipleRsp res = new();
            var m = All.FirstOrDefault(x => x.Id == id);
            if (m == null)
                res.SetError("Room type not found");
            else
            {
                var temp = roomRep.All.Where(x => x.RoomTypeId == m.Id).Select(x => new RoomReq()
                {
                    Id = x.Id,
                    Bed = x.Bed,
                    Price = x.Price,
                    IsFree = x.IsFree,
                    Picture = x.Picture,
                    MaxHumans = x.MaxHumans,
                    RoomTypeId = x.RoomTypeId
                }).ToList();
                res.SetData(new List<object>(temp), "200");
            }
            return res;
        }
        public SingleRsp Replace(RoomType roomType)
        {
            SingleRsp res = new();
            if (roomType != null && roomType.Id != null)
            {
                var m = _rep.Read(roomType.Id.GetValueOrDefault());
                if (m != null)
                {
                    m.Name = roomType.Name;
                    res = Update(m);
                }
                else
                {
                    res.SetError("Not found");
                }
            }
            return res;
        }
        public override SingleRsp Delete(int id)
        {
            RoomType? m = _rep.Delete(id);
            var res = new SingleRsp();
            if (m == null)
                res.SetError("NotFound");
            else
                res.SetData("204", m);
            return res;
        }
    }
}
