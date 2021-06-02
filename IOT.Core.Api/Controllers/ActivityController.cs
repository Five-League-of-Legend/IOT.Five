using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Activity;
using NLog;

namespace IOT.Core.Api.Controllers
{
    //秒杀配置
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        Logger logger = NLog.LogManager.GetCurrentClassLogger();//实例化
        private readonly IActivityRepository _activityRepository;

        public ActivityController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        //添加
        [Route("/api/ActivityAdd")]
        [HttpPost]
        public int ActivityAdd([FromForm]IOT.Core.Model.Activity a)
        {
            try
            {
                logger.Debug($"用户对秒杀配置进行添加,添加的配置名称为:{a.ActivityName}");
                int i = _activityRepository.Insert(a);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //显示
        [Route("/api/ActivityShow")]
        [HttpGet]
        public IActionResult ActivityShow(string nm = "", int st = -1)
        {
            try
            {
                //获取全部数据
                List<Model.Activity> ls = _activityRepository.Query();
                foreach (var item in ls)
                {
                    item.stimes = item.BeginTime.ToString("HH:mm");
                    item.ztimes = item.EndTime.ToString("HH:mm");
                }
                if (!string.IsNullOrEmpty(nm))
                {
                    ls = ls.Where(x => x.ActivityName.Contains(nm)).ToList();
                }
                if (st != -1)
                {
                    ls = ls.Where(x => x.State.Equals(st)).ToList();
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

        //反填
        [Route("/api/ActivityShowFT")]
        [HttpGet]
        public IActionResult ActivityShowFT(int ftid)
        {
            try
            {
                //获取全部数据
                var ls = _activityRepository.Query();
                Model.Activity aa = ls.FirstOrDefault(x => x.ActivityId.Equals(ftid));
                return Ok(aa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //删除
        [Route("/api/ActivityDel")]
        [HttpDelete]
        public int ActivityDel(string id)
        {
            try
            {
                logger.Debug($"用户对秒杀配置进行删除,删除的配置ID为:{id}");
                return _activityRepository.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }


        //修改
        [HttpPost]
        [Route("/api/ActivityUpt")]
        public int ActivityUpt([FromForm]IOT.Core.Model.Activity a)
        {
            try
            {
                logger.Debug($"用户对秒杀配置进行修改,修改的配置ID为:{a.ActivityId}");
                int i= _activityRepository.Uptdate(a);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //修改状态
        [HttpPost]
        [Route("/api/ActivityUptst")]
        public int ActivityUptst(int st)
        {
            try
            {
                logger.Debug($"用户对秒杀配置进行修改状态,修改状态的配置ID为:{st}");
                return _activityRepository.UptZt(st);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
