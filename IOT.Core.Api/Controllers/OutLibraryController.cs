using IOT.Core.IRepository.OutLibrary;
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
    public class OutLibraryController : ControllerBase
    {

        // 依赖注入
        private readonly IOutLibraryRepository _outLibrary;
        public OutLibraryController(IOutLibraryRepository outLibrary)
        {
            _outLibrary = outLibrary;
        }

        // 显示
        [Route("/api/OutLibraryShow")]
        [HttpGet]
        public IActionResult OutLibraryShow()
        {
            var ls = _outLibrary.ShowOutLibrary();
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //添加
        [HttpPost]
        [Route("/api/OutLibraryAdd")]
        public int OutLibraryAdd(IOT.Core.Model.OutLibrary a)
        {
            int i = _outLibrary.AddOutLibrary(a);
            return i;
        }

        //删除
        [HttpPost]
        [Route("/api/OutLibraryDel")]
        public int OutLibraryDel(string ids)
        {
            return _outLibrary.DelOutLibrary(ids);
        }

        //修改
        [HttpPost]
        [Route("/api/OutLibraryUpt")]
        public int OutLibraryUpt(IOT.Core.Model.OutLibrary a)
        {
            return _outLibrary.UptOutLibrary(a);
        }

    }
}
