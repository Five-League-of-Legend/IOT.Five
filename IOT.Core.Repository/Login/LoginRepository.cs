using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.Login;

namespace IOT.Core.Repository.Login
{
    public class LoginRepository : ILoginRepository
    {
        /// <summary>
        /// 刘俊豪大哥写的登录呀
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public object Login(string loginName, string pwd)
        {
            try
            {
                object result = DapperHelper.Exescalar($"select count(1) from Users where LoginName='{loginName}' and LoginPwd='{pwd}'");
                return result;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
