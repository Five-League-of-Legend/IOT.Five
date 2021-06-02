using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.SVIP;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SVIPController : ControllerBase
    {
        private readonly ISVIPRepository _svipRepository;

        public SVIPController(ISVIPRepository ivipRepository)
        {
            _svipRepository = ivipRepository;
        }

        //添加
        [HttpPost]
        [Route("/api/SVIPAdd")]
        public int SVIPAdd([FromForm]IOT.Core.Model.SVIP a)
        {
            int i = _svipRepository.AddSvip(a);
            return i;
        }


    }
}
