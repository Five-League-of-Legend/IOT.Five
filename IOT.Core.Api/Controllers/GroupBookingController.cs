using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.GroupBooking;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupBookingController : ControllerBase
    {
        private readonly IGroupBookingRepository _groupBookingRepository;

        public GroupBookingController(IGroupBookingRepository groupBookingRepository)
        {
            _groupBookingRepository = groupBookingRepository;
        }

        //添加
        [Route("/api/GroupBookingAdd")]
        [HttpPost]
        public int GroupBookingAdd(Model.GroupBooking groupBooking)
        {
            int i = _groupBookingRepository.Insert(groupBooking);
            return i;
        }
        //显示
        [Route("/api/GroupBookingShow")]
        [HttpGet]
        public IActionResult GroupBookingShow(int zt=0,string keyname="",int page=1,int limit=3)
        {
            List<Model.GroupBooking> lg = _groupBookingRepository.Query();
            lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
            if (!string.IsNullOrEmpty(keyname))
            {
                lg = lg.Where(x => x.CommodityName.Contains(keyname)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                count = lg.Count(),
                data = lg.Skip((page - 1) * limit).Take(limit)
            });
        }
        //显示拼团列表
        [Route("/api/GroupBookingShowList")]
        [HttpGet]
        public IActionResult GroupBookingShowList(string sdate="",int zt=0, int page = 1, int limit = 3)
        {
            List<Model.GroupBooking> lg = _groupBookingRepository.Query();
            lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
            if (!string.IsNullOrEmpty(sdate))
            {
                lg = lg.Where(x => x.GroupBookingSdate == Convert.ToDateTime(sdate)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                count = lg.Count(),
                data = lg.Skip((page - 1) * limit).Take(limit)
            });
        }
        //删除
        [Route("/api/GroupBookingDel")]
        [HttpPost]
        public int GroupBookingDel(string ids)
        {
            int i = _groupBookingRepository.Delete(ids);
            return i;
        }
        //修改
        [Route("/api/GroupBookingUpt")]
        [HttpPost]
        public int GroupBookingUpt(Model.GroupBooking groupBooking)
        {
            int i = _groupBookingRepository.Uptdate(groupBooking);
            return i;
        }
        //添加
        [Route("/api/GroupBookingUptZt")]
        [HttpPost]
        public int GroupBookingUptZt(int bid)
        {
            int i = _groupBookingRepository.UptZt(bid);
            return i;
        }
    }
}
