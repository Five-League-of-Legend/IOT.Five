using IOT.Core.Repository.Withdrawal;
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
    public class WithdrawalController : ControllerBase
    {

        // 依赖注入
        private readonly WithdrawalRepository _withdrawal;
        public WithdrawalController(WithdrawalRepository withdrawal)
        {
            _withdrawal = withdrawal;
        }

        // 显示
        [Route("/api/WithdrawalShow")]
        [HttpGet]
        public IActionResult WithdrawalShow()
        {
            var ls = _withdrawal.ShowIWithdrawal();
            return Ok(new { msg = "", code = 0, data = ls });
        }

    }
}
