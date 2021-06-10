using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.StaffAuthority;
using NLog;
namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffAuthorityController : ControllerBase
    {
        //依赖注入
        private readonly IStaffAuthorityRepository _staffAuthorityRepository;
        public StaffAuthorityController(IStaffAuthorityRepository staffAuthorityRepository)
        {
            _staffAuthorityRepository = staffAuthorityRepository;
        }

        [HttpGet]
        [Route("/api/AutUpt")]
        public int AutUpt(int rId, string menuID)
        {
            int i = 0;
            i += _staffAuthorityRepository.UptAut(rId, menuID);
            return i;
        }

        [HttpGet]
        [Route("/api/GetAut")]
        public IActionResult GetAut(int rid)
        {
            var result = _staffAuthorityRepository.FanMenu(rid);
            return Ok(result);
        }
    }
}













