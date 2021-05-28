using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.GroupBooking;

namespace IOT.Core.Api.Controllers
{
    public enum selectcode
    {
        全部 = 1,
        今天 = 2,
        昨天 = 3,
        最近七天 = 4,
        最近三十天 = 5,
        本月 = 6,
        本年 = 7
    }
    //拼团
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
        public IActionResult GroupBookingShow(int zt=-1,string keyname="")
        {
            List<Model.GroupBooking> lg = _groupBookingRepository.Query();
            if (zt!=-1)
            {
                lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
            }
            if (!string.IsNullOrEmpty(keyname))
            {
                lg = lg.Where(x => x.CommodityName.Contains(keyname)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                data = lg
            });
        }
        //显示拼团列表
        [Route("/api/GroupBookingShowList")]
        [HttpGet]
        public IActionResult GroupBookingShowList(string sdate="",int zt=-1,string zdate="",int code=1)
        {
            selectcode co = (selectcode)code;
            List<Model.GroupBooking> lg = _groupBookingRepository.Query();
            switch (co)
            {
                case selectcode.全部:
                    if (zt != -1)
                    {
                        lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
                    }
                    if (!string.IsNullOrEmpty(sdate))
                    {
                        lg = lg.Where(x => x.GroupBookingSdate.Date == Convert.ToDateTime(sdate)).ToList();
                    }
                    break;
                case selectcode.今天:
                    if (zt != -1)
                    {
                        lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
                    }
                    lg = lg.Where(x => x.GroupBookingSdate.Date == Convert.ToDateTime(sdate)).ToList();
                    break;
                case selectcode.昨天:
                    if (zt != -1)
                    {
                        lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
                    }
                    lg = lg.Where(x => x.GroupBookingSdate.Date == Convert.ToDateTime(sdate)).ToList();
                    break;
                case selectcode.最近七天:
                    if (zt != -1)
                    {
                        lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
                    }
                    lg = lg.Where(x => x.GroupBookingSdate.Date >= Convert.ToDateTime(sdate) & x.GroupBookingZdate.Date <= Convert.ToDateTime(zdate)).ToList();
                    break;
                case selectcode.最近三十天:
                    if (zt != -1)
                    {
                        lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
                    }
                    lg = lg.Where(x => x.GroupBookingSdate.Date >= Convert.ToDateTime(sdate) & x.GroupBookingZdate.Date <= Convert.ToDateTime(zdate)).ToList();
                    break;
                case selectcode.本月:
                    if (zt != -1)
                    {
                        lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
                    }
                    lg = lg.Where(x => x.GroupBookingSdate.Year == Convert.ToDateTime(sdate).Year & x.GroupBookingZdate.Month == Convert.ToDateTime(sdate).Month).ToList();
                    break;
                case selectcode.本年:
                    if (zt != -1)
                    {
                        lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
                    }
                    lg = lg.Where(x => x.GroupBookingSdate.Year == Convert.ToDateTime(sdate).Year).ToList();
                    break;
                default:
                    break;
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                data = lg
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
        //修改状态
        [Route("/api/GroupBookingUptZt")]
        [HttpPost]
        public int GroupBookingUptZt(int bid)
        {
            int i = _groupBookingRepository.UptZt(bid);
            return i;
        }
    }
}
