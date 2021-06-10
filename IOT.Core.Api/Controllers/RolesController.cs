using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Roles;
using NLog;
namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        Logger logger = NLog.LogManager.GetCurrentClassLogger();//实例化
        private readonly IRolesRepository _rolesRepository;
        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        //显示
        [Route("/api/RolesShow")]
        [HttpGet]
        public IActionResult AgentRoles()
        {
            var ls = _rolesRepository.ShowRoles(); 
            return Ok(new { msg = "", code = 0, data = ls });
        }
        

        //删除
        [Route("/api/RolesDel")]
        [HttpGet]
        public int RolesDel(string id)
        {
            logger.Debug($"用户对角色进行删除,删除的ID为:{id}");
            return _rolesRepository.DelRoles(id);
        }


        //修改
        [HttpPost]
        [Route("/api/RolesUpt")]
        public int AgentUpt(IOT.Core.Model.Roles a)
        {
            logger.Debug($"用户对角色进行修改,修改的ID为:{a.RoleId}");
            return _rolesRepository.UptRoles(a);
        }
        
        [HttpPost]
        [Route("/api/RolesAdd")]
        public int RolesAdd([FromForm] IOT.Core.Model.Roles a)
        {
            logger.Debug($"用户对角色进行添加,添加的名称为:{a.RoleName}");
            int i = _rolesRepository.AddRoles(a);
            return i;
        }
    }
}
