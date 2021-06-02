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
            //int UserId    { get
            //string  UserName  {
            //string LoginName { 
            //string LoginPwd  { 
            //string Phone     { 
            //string Address   { 
            //int State     { get
            //string NickName  { 
            //int ColonelID { get
            //int RoleId { get; s
            //string RoleName { g
            try
            {
                string sql = $"insert into Users values (null,'{a.UserName}','{a.LoginName}','{a.LoginPwd}','{a.Phone}','{a.Address}', {a.State},'{a.NickName}', {a.ColonelID}, {a.RoleId})";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public int DelUsers(string id)
        {

            try
            {
                string sql = $"delete from Users where UserId={id}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<Model.Users> ShowUsers()
        {
            try
            {
                string sql = "select * from Users a join Roles b on a.RoleId=b.RoleId";
                return DapperHelper.GetList<Model.Users>(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        /// <summary>
        /// 查询审核员
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public List<Model.Users> ShowUsersWhereColonelID(int cid)
        {
            try
            {
                string sql = $"select * from Users Where 1=1 ";

                if (cid != 9999)
                {
                    sql += $" and ColonelID = {cid}";
                }

                return DapperHelper.GetList<Model.Users>(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public int UptUsers(Model.Users a)
        {
            try
            {
                string sql = $"update  Users set  UserName='{a.UserName}', LoginName='{a.LoginName}', LoginPwd='{a.LoginPwd}', Phone='{a.Phone}', Address='{a.Address}',State={a.State}, NickName='{a.NickName}', ColonelID={a.ColonelID}, RoleId={a.RoleId}  where UserId={a.UserId}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int UptZt(int cid)
        {
            try
            {
                string sql = "select * from Users";

                List<Model.Users> la = DapperHelper.GetList<Model.Users>(sql);

                Model.Users aa = la.FirstOrDefault(x => x.UserId.Equals(cid));
                string sql1 = "";
                if (aa.State == 0)
                {
                    sql1 = $"UPDATE Users SET State=State+1 where UserId={cid}";

                }
                else
                {
                    sql1 = $"UPDATE Users SET State=State-1 where UserId={cid}";

                }
                int i = DapperHelper.Execute(sql1);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
            
        }


    }
}
