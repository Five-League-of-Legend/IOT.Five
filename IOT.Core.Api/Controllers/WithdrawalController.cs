using IOT.Core.IRepository.Withdrawal;
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
        private readonly IWithdrawalRepository _withdrawalRepository;
        public WithdrawalController(IWithdrawalRepository  withdrawalRepository)
        {
            _withdrawalRepository = withdrawalRepository;
        }
        [HttpGet]
        [Route("/api/GetWithdrawals")]
        public IActionResult GetWithdrawals(string name="")
        {
            List<Model.Withdrawal> list = _withdrawalRepository.Query();
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Mname.Contains(name)).ToList();
            }
            return Ok(new
            {
                msg = "",
                code = 0,
                data = list
            });
        }
    }
}
