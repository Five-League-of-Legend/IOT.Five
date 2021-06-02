using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Live;
using NLog;

namespace IOT.Core.Api.Controllers
{
    //直播
    [Route("api/[controller]")]
    [ApiController]
    public class LiveController : ControllerBase
    {
        Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly ILiveRepository _liveRepository;
        public LiveController(ILiveRepository liveRepository)
        {
            _liveRepository = liveRepository;
        }
        [HttpGet]
        [Route("/api/ShowLiveList")]
        public IActionResult ShowLiveList(int zt = -1, string keyname = "")
        {
            try
            {
                List<Model.Live> lv = _liveRepository.Query();
                if (zt != -1)
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
                    data = lv
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("/api/SelectLiveList")]
        public IActionResult SelectLiveList(int lid = 0)
        {
            try
            {
                List<Model.Commodity> lv = _liveRepository.SelectGoods(lid);
                if (lv.Count == 0)
                {
                    return Ok("没有带货商品");
                }
                else
                {
                    return Ok(new
                    {
                        msg = "",
                        code = 0,
                        data = lv
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 创建直播
        /// </summary>
        /// <param name="live"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddLiveList")]
        public int AddLiveList([FromForm]Model.Live live)
        {
            try
            {
                logger.Debug($"用户对直播列表进行添加,添加的名称为:{live.LiveTitle}");
                int i = _liveRepository.Insert(live);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("/api/DelLiveList")]
        public int DelLiveList(string ids)
        {
            try
            {
                logger.Debug($"用户对直播列表进行删除,删除的ID为:{ids}");
                int i = _liveRepository.Delete(ids);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("/api/UptLiveList")]
        public int UptLiveList(Model.Live live)
        {
            try
            {
                logger.Debug($"用户对直播列表进行修改,修改的ID为:{live.LiveId}");
                int i = _liveRepository.UptDate(live);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("/api/UptZtLiveList")]
        public int UptZtLiveList(int lid)
        {
            try
            {
                logger.Debug($"用户对直播列表进行修改状态,修改状态的ID为:{lid}");
                int i = _liveRepository.UptZt(lid);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
