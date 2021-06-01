using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.Sett;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettController : ControllerBase
    {
        private readonly ISettRepository _settRepository;

        public SettController(ISettRepository settRepository)
        {
            _settRepository = settRepository;
        }

        //添加
        [HttpPost]
        [Route("/api/SettAdd")]
        public int SettAdd([FromForm]IOT.Core.Model.Sett a)
        {
            int i = _settRepository.AddSett(a);
            return i;
        }
    }
}
