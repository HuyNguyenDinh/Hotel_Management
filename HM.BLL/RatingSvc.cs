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
    public class RatingSvc : GenericSvc<RatingRep, Rating>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            if (m == null)
                res.SetError("404", "not found");
            else
            {
                RatingReq result = new RatingReq
                {
                    Id = m.Id,
                    Rate = m.Rate,
                    Comment = m.Comment,
                    UserId = m.UserId,
                    RoomId = m.RoomId,
                };
                res.SetData("200", result);
            }
            return res;
        }
        public SingleRsp CreateRating(RatingReq ratingReq)
        {
            Rating? rating = new()
            {
                Rate = ratingReq.Rate,
                Comment = ratingReq.Comment,
                UserId = ratingReq.UserId,
                RoomId = ratingReq.RoomId
            };
            var res = Create(rating);
            return res;
        }
        public override SingleRsp Delete(int id)
        {
            Rating? m = _rep.Delete(id);
            var res = new SingleRsp();
            if (m == null)
                res.SetError("NotFound");
            else
                res.SetData("204", m);
            return res;
        }
        public SingleRsp Replace(RatingReq ratingReq)
        {
            SingleRsp res = new();
            if (ratingReq.Id == null)
            {
                res.SetError("Id can not be null");
                return res;
            }

            var m = _rep.Read(ratingReq.Id);

            if (m != null)
            {
                m.Rate = ratingReq.Rate;
                m.Comment = ratingReq.Comment;
                res = Update(m);
            }
            return res;
        }
    }
}
