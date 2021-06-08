using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Role;
using NLog;
namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        //显示
        [HttpGet]
        [Route("/api/RoleShow")]
        public IActionResult RoleShow()
        {
            var rolelist = _roleRepository.GetRole();
            return Ok(new
            {
                msg = "",
                code = 0,
                data = rolelist
            });
        }
        //角色新增
        [HttpPost]
        [Route("/api/RoleAdd")]
        public int RoleAdd([FromForm]IOT.Core.Model.Role role)
        {
            int i = 0;
            i += _roleRepository.AddRole(role);
            return i;
        }
        //角色删除
        [HttpDelete]
        [Route("/api/RoleDel")]
        public int RoleDel(int rid)
        {
            int i = 0;
            i += _roleRepository.DelRole(rid);
            return i;
        }
        //角色编辑
        [HttpPut]
        [Route("/api/RoleUpt")]
        public int RoleUpt([FromForm] IOT.Core.Model.Role role)
        {
            int i = 0;
            i += _roleRepository.UptRole(role);
            return i;
        }

        //角色反填
        [HttpGet]
        [Route("/api/RoleFan")]
        public IActionResult RoleFan(int rid)
        {
            var rolelist = _roleRepository.GetRole();
            IOT.Core.Model.Role ro = rolelist.First(x => x.RId == rid);
            return Ok(new
            {
                msg = "",
                code = 0,
                data = ro
            });
        }
    }
}
