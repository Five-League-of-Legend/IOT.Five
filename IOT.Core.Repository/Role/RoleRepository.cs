using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.Role;

namespace IOT.Core.Repository.Role
{
    public class RoleRepository : IRoleRepository
    {
        public int AddRole(Model.Role role)
        {
            try
            {
                string sql = $"insert into Role values (null,'{role.RName}')";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
            

          //  string sql = $"insert into Role(RName) values ('{role.RName}')";
          //  return DapperHelper.Execute(sql);
        }

        public int DelRole(int rid)
        {
            try
            {
                string sql = $"delete from Role where RId={rid}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<Model.Role> GetRole()
        {
            try
            {
                string sql = "select * from Role";
                return DapperHelper.GetList<Model.Role>(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public int UptRole(Model.Role role)
        {
            try
            {
                string sql = $"update Role set RName='{role.RName}' where RId={role.RId}";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}


