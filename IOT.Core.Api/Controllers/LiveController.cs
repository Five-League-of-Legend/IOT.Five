using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Live;

namespace IOT.Core.Api.Controllers
{
    //直播
    [Route("api/[controller]")]
    [ApiController]
    public class LiveController : ControllerBase
    {
        private readonly ILiveRepository _liveRepository;
        public LiveController(ILiveRepository liveRepository)
        {
            _liveRepository = liveRepository;
        }
        [HttpGet]
        [Route("/api/ShowLiveList")]
        public IActionResult ShowLiveList(int zt = -1, string keyname = "", int page = 1, int limit = 3)
        {
            List<Model.Live> lv = _liveRepository.Query();
            if (zt!=-1)
            {
                lv = lv.Where(x => x.IsEnable.Equals(zt)).ToList();
            }
            if (!string.IsNullOrEmpty(keyname))
            {
                lv = lv.Where(x => x.AnchorName.Contains(keyname)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                count = lv.Count(),
                data = lv.Skip((page - 1) * limit).Take(limit)
            });
        }
        [HttpGet]
        [Route("/api/SelectLiveList")]
        public IActionResult SelectLiveList(int lid = 0, int page = 1, int limit = 3)
        {
            List<Model.Commodity> lv = _liveRepository.SelectGoods(lid);
            if (lv.Count==0)
            {
                return Ok("没有带货商品");
            }
            else
            {
                return Ok(new
                {
                    msg = "",
                    code = 0,
                    count = lv.Count(),
                    data = lv.Skip((page - 1) * limit).Take(limit)
                });
            }
        }
        /// <summary>
        /// 创建直播
        /// </summary>
        /// <param name="live"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddLiveList")]
        public int AddLiveList(Model.Live live)
        {
            int i = _liveRepository.Insert(live);
            return i;
        }
        [HttpPost]
        [Route("/api/DelLiveList")]
        public int DelLiveList(string ids)
        {
            int i = _liveRepository.Delete(ids);
            return i;
        }
        [HttpPost]
        [Route("/api/UptLiveList")]
        public int UptLiveList(Model.Live live)
        {
            int i = _liveRepository.UptDate(live);
            return i;
        }
        [HttpPost]
        [Route("/api/UptZtLiveList")]
        public int UptZtLiveList(int lid)
        {
            int i = _liveRepository.UptZt(lid);
            return i;
        }
    }
}
