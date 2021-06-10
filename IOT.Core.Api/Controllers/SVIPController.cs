using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.SVIP;
using NLog;
namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SVIPController : ControllerBase
    {
        Logger logger = NLog.LogManager.GetCurrentClassLogger();//实例化
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
            logger.Debug($"用户对超级会员进行添加,添加的名称为:{a.SName}");
            int i = _svipRepository.AddSvip(a);
            return i;
        }


    }
}
