using IOT.Core.IRepository.Store;
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
    public class StoreController : ControllerBase
    {

        // 依赖注入
        private readonly IStoreRepository _Store;
        public StoreController(IStoreRepository Store)
        {
            _Store = Store;
        }

        // 显示
        [Route("/api/StoreShow")]
        [HttpGet]
        public IActionResult StoreShow()
        {
            var ls = _Store.ShowStore();
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //添加
        [HttpPost]
        [Route("/api/StoreAdd")]
        public int StoreAdd(IOT.Core.Model.Store a)
        {
            int i = _Store.AddStore(a);
            return i;
        }

        //删除
        [HttpPost]
        [Route("/api/StoreDel")]
        public int StoreDel(string ids)
        {
            return _Store.DelStore(ids);
        }

        //修改
        [HttpPost]
        [Route("/api/StoreUpt")]
        public int StoreUpt(IOT.Core.Model.Store a)
        {
            return _Store.UptStore(a);
        }

    }
}
