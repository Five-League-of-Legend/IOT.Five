using IOT.Core.IRepository.NowRep;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        // 依赖注入
        private readonly INowRepRepository _nowrep;

        public NowRepController(INowRepRepository nowrep)
        {
            _nowrep = nowrep;
        }

        //显示
        [Route("/api/NowRepShow")]
        [HttpGet]
        public IActionResult NowRepShow(string wname = "")
        {
            var ls = _nowrep.ShowNowRep();
            if (!string.IsNullOrEmpty(wname))
                ls = ls.Where(os => os.WarehouseName.Contains(wname)).ToList();
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //删除
        [HttpPost]
        [Route("/api/NowRepDel")]
        public int NowRepDel(string ids)
        {
            return _nowrep.DelNowRep(ids);
        }

    }
}
