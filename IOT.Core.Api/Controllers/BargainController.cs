using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Bargain;
using NLog;

namespace IOT.Core.Api.Controllers
{
    public enum selectpage
    {
        全部=1,
        今天=2,
        昨天=3,
        最近七天=4,
        最近三十天=5,
        本月=6,
        本年=7
    }
    //砍价
    [Route("api/[controller]")]
    [ApiController]
    public class BargainController : ControllerBase
    {
        Logger logger = NLog.LogManager.GetCurrentClassLogger();//实例化
        private readonly IBargainRepository _bargainRepository;
        public BargainController(IBargainRepository bargainRepository)
        {
            _bargainRepository = bargainRepository;
        }
        /// <summary>
        /// 显示砍价商品
        /// </summary>
        /// <param name="zt">状态</param>
        /// <param name="keyname">商品名称</param>
        /// <param name="page">分页</param>
        /// <param name="limit">分页</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/ShowBargain")]
        public IActionResult ShowBargain(int zt = -1, string keyname = "")
        {
            try
            {
                List<Model.Bargain> lb = _bargainRepository.Query();
                if (zt != -1)
                {
                    lb = lb.Where(x => x.ActionState.Equals(zt)).ToList();
                }
                if (!string.IsNullOrEmpty(keyname))
                {
                    lb = lb.Where(x => x.CommodityName.Contains(keyname)).ToList();
                }
                return Ok(new
                {
                    msg = "",
                    code = 0,
                    data = lb
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        //反填
        [Route("/api/ShowBargainFT")]
        [HttpGet]
        public IActionResult ShowBargainFT(int ftid)
        {
            try
            {
                //获取全部数据
                var ls = _bargainRepository.Query();
                Model.Bargain aa = ls.FirstOrDefault(x => x.BargainId.Equals(ftid));
                return Ok(aa);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 显示砍价列表
        /// </summary>
        /// <param name="zt">状态</param>
        /// <param name="sdate">时间</param>
        /// <param name="page">分页</param>
        /// <param name="limit">分页</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/ShowListBargain")]
        public IActionResult ShowListBargain(int zt = -1, string sdate = "",int page=1)
        {
            try
            {
                selectpage sp = (selectpage)page;
                List<Model.Bargain> lb = _bargainRepository.Query();
                switch (sp)
                {
                    case selectpage.全部:
                        if (zt != -1)
                        {
                            lb = lb.Where(x => x.ActionState.Equals(zt)).ToList();
                        }
                        if (!string.IsNullOrEmpty(sdate))
                        {
                            lb = lb.Where(x => x.BeginDate.Date == Convert.ToDateTime(sdate)).ToList();
                        }
                        break;
                    case selectpage.今天:
                        if (zt != -1)
                        {
                            lb = lb.Where(x => x.ActionState.Equals(zt)).ToList();
                        }
                        lb = lb.Where(x => x.Days == 0).ToList();
                        break;
                    case selectpage.昨天:
                        if (zt != -1)
                        {
                            lb = lb.Where(x => x.ActionState.Equals(zt)).ToList();
                        }
                        lb = lb.Where(x => x.Days == 1).ToList();
                        break;
                    case selectpage.最近七天:
                        if (zt != -1)
                        {
                            lb = lb.Where(x => x.ActionState.Equals(zt)).ToList();
                        }
                        lb = lb.Where(x => x.Days <= 7).ToList();
                        break;
                    case selectpage.最近三十天:
                        if (zt != -1)
                        {
                            lb = lb.Where(x => x.ActionState.Equals(zt)).ToList();
                        }
                        lb = lb.Where(x => x.Days <= 30).ToList();
                        break;
                    case selectpage.本月:
                        if (zt != -1)
                        {
                            lb = lb.Where(x => x.ActionState.Equals(zt)).ToList();
                        }
                        lb = lb.Where(x => x.years == Convert.ToDateTime(sdate).Year & x.Months == Convert.ToDateTime(sdate).Month).ToList();
                        break;
                    case selectpage.本年:
                        if (zt != -1)
                        {
                            lb = lb.Where(x => x.ActionState.Equals(zt)).ToList();
                        }
                        lb = lb.Where(x => x.years == Convert.ToDateTime(sdate).Year).ToList();
                        break;
                    default:
                        break;
                }
                return Ok(new
                {
                    msg = "",
                    code = 0,
                    data = lb
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("/api/AddBargain")]
        public int AddBargain([FromForm] Model.Bargain bargain)
        {
            try
            {
                logger.Debug($"用户对砍价列表进行添加,添加的名称为:{bargain.BargainName}");
                int i = _bargainRepository.Insert(bargain);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("/api/DelBargain")]
        public int DelBargain(string ids)
        {
            try
            {
                logger.Debug($"用户对砍价列表进行删除,删除的名称为:{ids}");
                int i = _bargainRepository.Delete(ids);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("/api/UptBargain")]
        public int UptBargain([FromForm]Model.Bargain bargain)
        {
            try
            {
                logger.Debug($"用户对砍价列表进行修改,修改的ID为:{bargain.BargainId}");
                int i = _bargainRepository.UptDate(bargain);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("/api/UptZtBargain")]
        public int UptZtBargain(int cid)
        {
            try
            {
                logger.Debug($"用户对砍价列表进行修改状态,修改的ID为:{cid}");
                int i = _bargainRepository.UptZt(cid);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
