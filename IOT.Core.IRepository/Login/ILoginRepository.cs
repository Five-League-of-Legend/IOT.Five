using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Login
{
    public interface ILoginRepository
    {
        /// <summary>
        /// 刘俊豪他大哥写的登录
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        object Login(string loginName, string pwd);
    }
}
