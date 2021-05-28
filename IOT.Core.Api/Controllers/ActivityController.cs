using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Activity;

namespace IOT.Core.Api.Controllers
{
    //秒杀配置
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
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
            return _activityRepository.Delete(id);
        }


        //修改
        [HttpPost]
        [Route("/api/ActivityUpt")]
        public int ActivityUpt(IOT.Core.Model.Activity a)
        {
            return _activityRepository.Uptdate(a);
        }

        //修改状态
        [HttpPost]
        [Route("/api/ActivityUptst")]
        public int ActivityUptst(int st)
        {
            return _activityRepository.UptZt(st);
        }
    }
}
