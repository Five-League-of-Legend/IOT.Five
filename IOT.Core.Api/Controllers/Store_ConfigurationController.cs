using IOT.Core.IRepository.Store_Configuration;
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
    public class Store_ConfigurationController : ControllerBase
    {

        // 依赖注入
        private readonly IStore_ConfigurationRepository _ConfigurationRepository;
        public Store_ConfigurationController (IStore_ConfigurationRepository ConfigurationRepository)
        {
            _ConfigurationRepository = ConfigurationRepository;
        }

        // 显示
        [Route("/api/Store_ConfigurationShow")]
        [HttpGet]
        public IActionResult Store_ConfigurationShow()
        {
            var ls = _ConfigurationRepository.ShowStore_Config();
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //添加
        [HttpPost]
        [Route("/api/Store_ConfigurationAdd")]
        public int Store_ConfigurationAdd(IOT.Core.Model.Store_Configuration a)
        {
            int i = _ConfigurationRepository.AddStore_Config(a);
            return i;
        }

        //修改
        [HttpPost]
        [Route("/api/Store_ConfigurationUpt")]
        public int Store_ConfigurationUpt(IOT.Core.Model.Store_Configuration a)
        {
            return _ConfigurationRepository.UptStore_Config(a);
        }

    }
}
