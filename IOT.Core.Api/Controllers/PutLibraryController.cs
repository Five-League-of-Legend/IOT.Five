using IOT.Core.IRepository.PutLibrary;
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
    public class PutLibraryController : ControllerBase
    {

        // 依赖注入
        private readonly IPutLibraryRepository _putLibrary;
        public PutLibraryController(IPutLibraryRepository putLibrary)
        {
            _putLibrary = putLibrary;
        }

        // 显示
        [Route("/api/PutLibraryShow")]
        [HttpGet]
        public IActionResult PutLibraryShow()
        {
            var ls = _putLibrary.ShowPutLibrarye();
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //添加
        [HttpPost]
        [Route("/api/PutLibraryAdd")]
        public int PutLibraryAdd(IOT.Core.Model.PutLibrary a)
        {
            int i = _putLibrary.AddPutLibrary(a);
            return i;
        }

        //删除
        [HttpPost]
        [Route("/api/PutLibraryDel")]
        public int PutLibraryDel(string ids)
        {
            return _putLibrary.DelPutLibrary(ids);
        }

        //修改
        [HttpPost]
        [Route("/api/PutLibraryUpt")]
        public int PutLibraryUpt(IOT.Core.Model.PutLibrary a)
        {
            return _putLibrary.UptPutLibrary(a);
        }

    }
}
