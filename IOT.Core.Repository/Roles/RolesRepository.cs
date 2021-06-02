using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.Roles;

namespace IOT.Core.Repository.Roles
{
    public class RolesRepository : IRolesRepository
    {
        public int AddRoles(Model.Roles a)
        {
            try
            {
                string sql = $"insert into Roles values (null,'{a.RoleName}')";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public int DelRoles(string id)
        {
            try
            {
                string sql = $"delete from Roles where RoleId={id}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public List<Model.Roles> ShowRoles()
        {
            try
            {
                string sql = "select * from Roles";
                return DapperHelper.GetList<Model.Roles>(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public int UptRoles(Model.Roles a)
        {
            try
            {
                string sql = $"update  Roles  set  RoleName='{a.RoleName}' where RoleId={a.RoleId})";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
