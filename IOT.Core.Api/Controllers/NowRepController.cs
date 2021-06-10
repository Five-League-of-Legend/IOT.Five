using IOT.Core.IRepository.NowRep;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NowRepController : ControllerBase
    {
        //实例化log
        Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly INowRepRepository _nowRepRepository;
        public NowRepController(INowRepRepository nowRepRepository)
        {
            _nowRepRepository = nowRepRepository;
        }

        [HttpGet]
        [Route("/api/ShowNowRep")]
        public IActionResult ShowNowRep(string commodityname, string warehousename)
        {
            List<IOT.Core.Model.NowRep> ln = _nowRepRepository.Query();
            if (!string.IsNullOrEmpty(commodityname))
            {
                ln = ln.Where(x => x.CommodityName.Contains(commodityname)).ToList();
            }
            if (!string.IsNullOrEmpty(warehousename))
            {
                ln = ln.Where(x => x.WarehouseName.Contains(warehousename)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                data = ln
            });
        }

        [HttpDelete]
        [Route("/api/DelNowRep")]
        public int DelNowRep(string ids)
        {
            logger.Debug($"用户删除了现有库存表信息,删除现有库存的ID为:{ids}");
            int i = _nowRepRepository.Delete(ids);
            return i;
        }

    }
}
