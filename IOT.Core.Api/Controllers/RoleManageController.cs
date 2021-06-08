using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.RoleManage;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleManageController : ControllerBase
    {
        private readonly IRoleManageRepository _roleManageRepository;

        public RoleManageController(IRoleManageRepository roleManageRepository)
        {
            _roleManageRepository = roleManageRepository;
        }

        //添加
        [HttpPost]
        [Route("/api/RoleManageAdd")]
        public int RoleManageAdd(IOT.Core.Model.RoleManage a)
        {
            
           
            int i = _roleManageRepository.AddRoleManage(a);
            return i;
        }
    }
}
