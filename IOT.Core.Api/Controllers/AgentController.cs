using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Agent;
using NLog;
namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {

        Logger logger = NLog.LogManager.GetCurrentClassLogger();//实例化
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
          
            logger.Debug($"用户对代理商进行删除,删除的配置ID为:{id}");
          
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
        public int AgentUpt([FromForm]IOT.Core.Model.Agent a)
        {

          
            logger.Debug($"用户对代理商进行修改,修改的ID为:{a.AgentId}");
           
            a.Consume = 15;
            a.Money = 123;
            a.Fans = "何垚最帅了";
            a.AgentState = 1;
            a.NFans = "何垚是个男的";
            return _agentRepository.UptAgent(a);
        }
        //修改状态
        [HttpPost]
        [Route("/api/AgentUptZt")]
        public int AgentUptZt(int cid)
        {
            
            logger.Debug($"用户对代理商进行修改状态,修改状态的ID为:{cid}");
            return _agentRepository.UptZt(cid);
        }

        [HttpPost]
        [Route("/api/AgentAdd")]
        public int AgentAdd([FromForm]IOT.Core.Model.Agent a)
        {
            logger.Debug($"用户对代理商进行添加,添加的名称为:{a.AgentName}");
            
            int i = _agentRepository.AddAgent(a);
            return i;
        }
        
    }
}
