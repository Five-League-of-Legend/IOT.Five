using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Agent;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentRepository _agentRepository;
        public AgentController(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        //显示
        [Route("/api/AgentShow")]
        [HttpGet]
        public IActionResult AgentShow(string keyname = "")
        {
            var ls = _agentRepository.ShowAgent();
            if (!string.IsNullOrEmpty(keyname))
            {
                ls = ls.Where(x => x.AgentName.Contains(keyname)).ToList();
            }

            return Ok(new { msg = "", code = 0, data = ls });

        }


        //删除
        [Route("/api/AgentDel")]
        [HttpGet]
        public int AgentDel(string id)
        {
            return _agentRepository.DelAgent(id);
        }

        //反填
        [Route("/api/AgentShowFt")]
        [HttpGet]
        public IActionResult ActivityShowFT(int ftid)
        {
            //获取全部数据
            var ls = _agentRepository.ShowAgent();
            Model.Agent aa = ls.FirstOrDefault(x => x.AgentId.Equals(ftid));
            return Ok(aa);
        }

        //修改
        [HttpPost]
        [Route("/api/AgentUpt")]
        public int AgentUpt(IOT.Core.Model.Agent a)
        {
            return _agentRepository.UptAgent(a);
        }
        //修改状态
        [HttpPost]
        [Route("/api/AgentUptZt")]
        public int AgentUptZt(int cid)
        {
            return _agentRepository.UptZt(cid);
        }

        [HttpPost]
        [Route("/api/AgentAdd")]
        public int AgentAdd([FromForm]IOT.Core.Model.Agent a)
        {
            int i = _agentRepository.AddAgent(a);
            return i;
        }
        
    }
}
