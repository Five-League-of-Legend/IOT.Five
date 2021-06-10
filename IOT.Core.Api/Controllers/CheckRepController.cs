using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.CheckRep;
using NLog;
namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckRepController : ControllerBase
    {
        //实例化log
        Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly ICheckRepRepository _checkRepRepository;

        public CheckRepController(ICheckRepRepository checkRepRepository)
        {
            _checkRepRepository = checkRepRepository;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="checkno"></param>
        /// <param name="warehousename"></param>
        /// <param name="sdate"></param>
        /// <param name="zdate"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/ShowCheckRep")]
        public IActionResult ShowCheckRep(string checkno, string warehousename, string sdate = "", string zdate = "")
        {
            List<IOT.Core.Model.CheckRep> lc = _checkRepRepository.Query();
            if (!string.IsNullOrEmpty(checkno))
            {
                lc = lc.Where(x => x.CheckNo.Contains(checkno)).ToList();
            }
            if (!string.IsNullOrEmpty(warehousename))
            {
                lc = lc.Where(x => x.WarehouseName.Contains(warehousename)).ToList();
            }
            if (!string.IsNullOrEmpty(sdate))
            {
                lc = lc.Where(x => x.CheckDate >= Convert.ToDateTime(sdate)).ToList();
            }
            if (!string.IsNullOrEmpty(zdate))
            {
                lc = lc.Where(x => x.CheckDate <= Convert.ToDateTime(zdate)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                data = lc
            });
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="checkRep"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddCheckRep")]
        public int AddCheckRep(IOT.Core.Model.CheckRep checkRep)
        {
            logger.Debug($"用户添加了盘点管理表信息,添加盘点单号为:{checkRep.CheckNo}");
            int i = _checkRepRepository.Insert(checkRep);
            return i;
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/FtCheckRep")]
        public IActionResult FtCheckRep(int id)
        {
            List<IOT.Core.Model.CheckRep> lc = _checkRepRepository.Query();
            IOT.Core.Model.CheckRep checkRep = lc.FirstOrDefault(x => x.CheckRepId.Equals(id));
            return Ok(new
            {
                msg = "",
                code = 0,
                data = checkRep
            });
        }
    }
}
