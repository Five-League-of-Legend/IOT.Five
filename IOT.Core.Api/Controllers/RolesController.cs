using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Roles;
namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

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
            return _rolesRepository.DelRoles(id);
        }


        //修改
        [HttpPost]
        [Route("/api/RolesUpt")]
        public int AgentUpt(IOT.Core.Model.Roles a)
        {
            return _rolesRepository.UptRoles(a);
        }
        
        [HttpPost]
        [Route("/api/RolesAdd")]
        public int RolesAdd([FromForm] IOT.Core.Model.Roles a)
        {
            int i = _rolesRepository.AddRoles(a);
            return i;
        }
    }
}
