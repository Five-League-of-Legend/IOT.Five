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
                string sql1 = $"insert into Lognote values (NULL,'登录用户名{loginName}密码{pwd}',NOW(),'Users用户表');";
                DapperHelper.Execute(sql1);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
