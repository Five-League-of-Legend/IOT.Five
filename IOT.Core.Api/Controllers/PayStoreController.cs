using IOT.Core.IRepository.PayStore;
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
    public class PayStoreController : ControllerBase
    {

        // 依赖注入
        private readonly IPayStoreRepository _Pay;
        public PayStoreController(IPayStoreRepository Pay)
        {
            _Pay = Pay;
        }

        // 显示
        [Route("/api/PayStoreShow")]
        [HttpGet]
        public IActionResult PayStoreShow()
        {
            var ls = _Pay.ShowIPayStore();
            return Ok(new { msg = "", code = 0, data = ls });
        }

    }
}
