using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.GroupBooking;
using NLog;

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
        Logger logger = NLog.LogManager.GetCurrentClassLogger();//实例化
        public GroupBookingController(IGroupBookingRepository groupBookingRepository)
        {
            _groupBookingRepository = groupBookingRepository;
        }

        //添加
        [Route("/api/GroupBookingAdd")]
        [HttpPost]
        public int GroupBookingAdd([FromForm]Model.GroupBooking groupBooking)
        {
            try
            {
                logger.Debug($"用户对拼团列表进行添加,添加的名称为:{groupBooking.GroupBookingName}");
                int i = _groupBookingRepository.Insert(groupBooking);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //绑定下拉
        [Route("/api/GroupBookingShowBinds")]
        [HttpGet]
        public IActionResult GroupBookingShowBinds()
        {
            try
            {
                List<Model.Colonel> lc = _groupBookingRepository.Binds();
                return Ok(new
                {
                    msg = "",
                    code = 0,
                    data = lc
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        //显示
        [Route("/api/GroupBookingShow")]
        [HttpGet]
        public IActionResult GroupBookingShow(int zt=-1,string keyname="")
        {
            try
            {
                List<Model.GroupBooking> lg = _groupBookingRepository.Query();
                if (zt != -1)
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
            catch (Exception)
            {

                throw;
            }
        }
        //显示拼团列表
        [Route("/api/GroupBookingShowList")]
        [HttpGet]
        public IActionResult GroupBookingShowList(string sdate="",int zt=-1,string zdate="",int code=1)
        {
            try
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
                        lg = lg.Where(x => x.Days == 0).ToList();
                        break;
                    case selectcode.昨天:
                        if (zt != -1)
                        {
                            lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
                        }
                        lg = lg.Where(x => x.Days == 1).ToList();
                        break;
                    case selectcode.最近七天:
                        if (zt != -1)
                        {
                            lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
                        }
                        lg = lg.Where(x => x.Days <= 7).ToList();
                        break;
                    case selectcode.最近三十天:
                        if (zt != -1)
                        {
                            lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
                        }
                        lg = lg.Where(x => x.Days <= 30).ToList();
                        break;
                    case selectcode.本月:
                        if (zt != -1)
                        {
                            lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
                        }
                        lg = lg.Where(x => x.years == Convert.ToDateTime(sdate).Year & x.Months == Convert.ToDateTime(sdate).Month).ToList();
                        break;
                    case selectcode.本年:
                        if (zt != -1)
                        {
                            lg = lg.Where(x => x.GroupBookingState.Equals(zt)).ToList();
                        }
                        lg = lg.Where(x => x.years == Convert.ToDateTime(sdate).Year).ToList();
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
            catch (Exception)
            {

                throw;
            }
        }
        //删除
        [Route("/api/GroupBookingDel")]
        [HttpPost]
        public int GroupBookingDel(string ids)
        {
            try
            {
                logger.Debug($"用户对拼团列表进行删除,删除的名称为:{ids}");
                int i = _groupBookingRepository.Delete(ids);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //修改
        [Route("/api/GroupBookingUpt")]
        [HttpPost]
        public int GroupBookingUpt([FromForm]Model.GroupBooking groupBooking)
        {
            try
            {
                logger.Debug($"用户对拼团列表进行修改,修改的名称为:{groupBooking.GroupBookingID}");
                int i = _groupBookingRepository.Uptdate(groupBooking);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //修改状态
        [Route("/api/GroupBookingUptZt")]
        [HttpPost]
        public int GroupBookingUptZt(int bid)
        {
            try
            {
                logger.Debug($"用户对拼团列表进行修改状态,修改状态的名称为:{bid}");
                int i = _groupBookingRepository.UptZt(bid);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
