using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Activity;

namespace IOT.Core.Api.Controllers
{
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
        public int ActivityAdd(IOT.Core.Model.Activity a)
        {
            int i = _activityRepository.Insert(a);
            return i;
        }

        //显示
        [Route("/api/ActivityShow")]
        [HttpGet]
        public IActionResult ActivityShow(string nm = "", int st = 0, int page = 1, int limit = 3)
        {
            //获取全部数据
            var ls = _activityRepository.Query();
            if (!string.IsNullOrEmpty(nm))
            {
                ls = ls.Where(x => x.ActivityName.Contains(nm)).ToList();
            }
            ls = ls.Where(x => x.State.Equals(st)).ToList();

            return Ok(new
            {
                count = ls.Count(),
                msg = "",
                code = 0,
                data = ls.Skip((page - 1) * limit).Take(limit)
            });
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
