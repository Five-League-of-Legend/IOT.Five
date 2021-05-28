using IOT.Core.IRepository.MiniProgram;
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
    public class MiniProgramController : ControllerBase
    {

        private readonly IMiniProgramRepository _miniProgramRepository1;
        public MiniProgramController(IMiniProgramRepository  miniProgramRepository)
        {
            _miniProgramRepository1 = miniProgramRepository;
        }

        /// <summary>
        /// 小程序显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/GetMiniPrograms")]
        public List<Model.MiniProgram> GetMiniPrograms()
        {
            return _miniProgramRepository1.MiniPrograms();
        }

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="miniProgram"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptMiniProgram")]
        public int UptMiniProgram(Model.MiniProgram miniProgram)
        {
            return _miniProgramRepository1.UptMiniProgram(miniProgram);
        }
    }
}
