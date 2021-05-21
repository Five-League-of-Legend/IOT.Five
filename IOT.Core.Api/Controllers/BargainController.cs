using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Bargain;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BargainController : ControllerBase
    {
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
        public IActionResult ShowBargain(int zt = 0, string keyname = "", int page = 1, int limit = 3)
        {
            List<Model.Bargain> lb = _bargainRepository.Query();
            lb = lb.Where(x => x.ActionState.Equals(zt)).ToList();
            if (!string.IsNullOrEmpty(keyname))
            {
                lb = lb.Where(x => x.CommodityName.Contains(keyname)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                count = lb.Count(),
                data = lb.Skip((page - 1) * limit).Take(limit)
            });
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
        public IActionResult ShowListBargain(int zt = 0, string sdate = "", int page = 1, int limit = 3)
        {
            List<Model.Bargain> lb = _bargainRepository.Query();
            lb = lb.Where(x => x.ActionState.Equals(zt)).ToList();
            if (!string.IsNullOrEmpty(sdate))
            {
                lb = lb.Where(x => x.BeginDate >= Convert.ToDateTime(sdate)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                count = lb.Count(),
                data = lb.Skip((page - 1) * limit).Take(limit)
            });
        }
        [HttpPost]
        [Route("/api/AddBargain")]
        public int AddBargain(Model.Bargain bargain)
        {
            int i = _bargainRepository.Insert(bargain);
            return i;
        }
        [HttpPost]
        [Route("/api/DelBargain")]
        public int DelBargain(string ids)
        {
            int i = _bargainRepository.Delete(ids);
            return i;
        }
        [HttpPost]
        [Route("/api/UptBargain")]
        public int UptBargain(Model.Bargain bargain)
        {
            int i = _bargainRepository.UptDate(bargain);
            return i;
        }
        [HttpPost]
        [Route("/api/UptZtBargain")]
        public int UptZtBargain(int bid)
        {
            int i = _bargainRepository.UptZt(bid);
            return i;
        }
    }
}
