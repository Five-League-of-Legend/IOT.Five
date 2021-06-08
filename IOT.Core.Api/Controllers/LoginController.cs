using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT.Core.IRepository.Login;
using NLog;

namespace IOT.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        Logger logger = NLog.LogManager.GetCurrentClassLogger();//实例化
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        //添加
        [Route("/api/Login")]
        [HttpPost]
        public int Login(Model.Users a)
        {
            logger.Debug($"用户登录,用户的名称为:{a.UserName},用户账号{a.LoginName}为密码为{a.LoginPwd}");
            object i = _loginRepository.Login(a.LoginName,a.LoginPwd);
            return Convert.ToInt32(i);
        }
    }
}
