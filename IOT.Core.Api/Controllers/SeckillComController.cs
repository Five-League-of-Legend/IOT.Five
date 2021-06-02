using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.SeckillCom;
using NLog;

namespace IOT.Core.Api.Controllers
{
    //秒杀商品
    [Route("api/[controller]")]
    [ApiController]
    public class SeckillComController : ControllerBase
    {
        private readonly ISeckillComRepository _seckillComRepository;
        Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public SeckillComController(ISeckillComRepository seckillComRepository)
        {
            _seckillComRepository = seckillComRepository;
        }

        //添加
        [Route("/api/SeckillComAdd")]
        [HttpPost]
        public int SeckillComAdd([FromForm]IOT.Core.Model.SeckillCom a)
        {
            try
            {
                logger.Debug($"用户对秒杀商品列表进行添加,添加的名称为:{a.SeckillTitle}");
                int i = _seckillComRepository.Insert(a);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //显示
        [Route("/api/SeckillComShow")]
        [HttpGet]
        public IActionResult SeckillComShow(int aid=0,string nmid="", int st=-1)
        {
            try
            {
                var ls = _seckillComRepository.Query();
                //根据姓名id查询
                if (!string.IsNullOrEmpty(nmid))
                {
                    ls = ls.Where(x => x.CommodityId.Equals(nmid) || x.SeckillTitle.Contains(nmid)).ToList();
                }
                //根据状态查询
                if (st != -1)
                {
                    ls = ls.Where(x => x.State.Equals(st)).ToList();
                }
                if (aid != 0)
                {
                    ls = ls.Where(x => x.ActivityId.Equals(aid)).ToList();
                }
                return Ok(new
                {
                    msg = "",
                    code = 0,
                    data = ls
                });
            }
            catch (Exception)
            {

                throw;
            }
        }


        //删除
        [Route("/api/SeckillComDel")]
        [HttpDelete]
        public int SeckillComDel(string id)
        {
            try
            {
                logger.Debug($"用户对秒杀商品列表进行删除,删除的名称为:{id}");
                int i = _seckillComRepository.Delete(id);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }


        //修改
        [HttpPost]
        [Route("/api/SeckillComUpt")]
        public int SeckillComUpt([FromForm]IOT.Core.Model.SeckillCom a)
        {
            try
            {
                logger.Debug($"用户对秒杀商品列表进行修改,修改的名称为:{a.SeckillComId}");
                int i = _seckillComRepository.Uptdate(a);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //修改状态
        [HttpPost]
        [Route("/api/SeckillComUptZt")]
        public int SeckillComUptZt(int sid)
        {
            try
            {
                logger.Debug($"用户对秒杀商品列表进行修改状态,修改状态的名称为:{sid}");
                int i = _seckillComRepository.UptZt(sid);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
