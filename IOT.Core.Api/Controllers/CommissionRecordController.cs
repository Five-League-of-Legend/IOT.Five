using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.CommissionRecord;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommissionRecordController : ControllerBase
    {
        private readonly ICommissionRecordRepository _commissionRecordRepository;
        public CommissionRecordController(ICommissionRecordRepository commissionRecordRepository)
        {
            _commissionRecordRepository = commissionRecordRepository;
        }

        //显示
        [Route("/api/CommissionRecordControllerShow")]
        [HttpGet]
        public IActionResult CommissionRecordControllerShow(string keyname = "")
        {
            var ls = _commissionRecordRepository.ShowCommissionRecord();

            if (!string.IsNullOrEmpty(keyname))
            {
                ls = ls.Where(x => x.SName.Equals(keyname)).ToList();
            }
            return Ok(new { msg = "", code = 0, data = ls });

        }

    }
}
