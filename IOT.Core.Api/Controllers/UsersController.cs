using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.Users;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        //显示
        [Route("/api/UsersShow")]
        [HttpGet]
        public IActionResult UsersShow()
        {
            var ls = _usersRepository.ShowUsers();
            return Ok(new { msg = "", code = 0, data = ls });
        }

        //显示
        [Route("/api/ShowUsersWhereColonelID")]
        [HttpGet]
        public IActionResult ShowUsersWhereColonelID(int cid)
        {
            var ls = _usersRepository.ShowUsersWhereColonelID(cid);
            return Ok(ls);
        }

        
        //删除
        [Route("/api/UsersDel")]
        [HttpDelete]
        public int UsersDel(string id)
        {
            return _usersRepository.DelUsers(id);
        }


        //修改
        [HttpPost]
        [Route("/api/UsersUpt")]
        public int UsersUpt(IOT.Core.Model.Users a)
        {
            return _usersRepository.UptUsers(a);
        }
    }
}
