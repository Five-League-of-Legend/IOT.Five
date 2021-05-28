using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public   class Users
    {
        public int UserId    { get; set; }
        public string  UserName  { get; set; }
        public string LoginName { get; set; }
        public string LoginPwd  { get; set; }
        public string Phone     { get; set; }
        public string Address   { get; set; }
        public int State     { get; set; }
        public string NickName  { get; set; }
        public int ColonelID { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
