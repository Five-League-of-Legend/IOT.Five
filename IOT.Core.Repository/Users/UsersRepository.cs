using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.Users;

namespace IOT.Core.Repository.Users
{
    public class UsersRepository : IUsersRepository
    {
        public int AddUsers(Model.Users a)
        {
            string sql = $"insert into Users values (null,'{a.UserName}','{a.LoginName}','{a.LoginPwd}','{a.Phone}','{a.Address}', {a.State},'{a.NickName}', {a.ColonelID}, {a.RoleId})";
            return DapperHelper.Execute(sql);
        }

        public int DelUsers(string id)
        {
            string sql = $"delete from Users where UserId={id}";
            return DapperHelper.Execute(sql);
        }

        public List<Model.Users> ShowUsers()
        {
            string sql = "select * from Users";
            return DapperHelper.GetList<Model.Users>(sql);
        }


        /// <summary>
        /// 查询审核员
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public List<Model.Users> ShowUsersWhereColonelID(int cid)
        {
            string sql = $"select * from Users Where 1=1 ";

            if (cid != 9999)
            {
                sql += $" and ColonelID = {cid}";
            }

            return DapperHelper.GetList<Model.Users>(sql);
        }

        public int UptUsers(Model.Users a)
        {
            string sql = $"update set Users  UserName='{a.UserName}', LoginName='{a.LoginName}', LoginPwd='{a.LoginPwd}', Phone='{a.Phone}', Address='{a.Address}', NickName='{a.NickName}', ColonelID={a.ColonelID}, RoleId={a.RoleId}  where UserId={a.UserId}";
            return DapperHelper.Execute(sql);
        }

        public int UptZt(int sid)
        {
            string sql = "select * from Users";

            List<Model.Users> la = DapperHelper.GetList<Model.Users>(sql);

            Model.Users aa = la.FirstOrDefault(x => x.UserId.Equals(sid));
            string sql1 = "";
            if (aa.State == 0)
            {
                sql1 = $"UPDATE Users SET State=State+1 where UserId={sid}";

            }
            else
            {
                sql1 = $"UPDATE Users SET State=State-1 where UserId={sid}";

            }
            int i = DapperHelper.Execute(sql1);
            return i;
        }
    }
}
