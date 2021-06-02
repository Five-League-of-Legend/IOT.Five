using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Login;


namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        //添加
        [Route("/api/Login")]
        [HttpPost]
        public int Login([FromForm]Model.Users a)
        {
            object i = _loginRepository.Login(a.LoginName,a.LoginPwd);
            return Convert.ToInt32(i);
        }
    }
}
