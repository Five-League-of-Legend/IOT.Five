using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.RoleManage;

namespace IOT.Core.Repository.RoleManage
{
    public class RoleManageRepository : IRoleManageRepository
    {
        public int AddRoleManage(Model.RoleManage a)
        {
            try
            {
                string sql = $"insert into RoleManage values (null,{a.RMId},'{a.HobOne}','{a.HobTwo}','{a.HobThree}','{a.Four}')";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public int Delete(string ids)
        {
            throw new NotImplementedException();
        }

        public int Insert(Model.PutLibrary Model)
        {
            throw new NotImplementedException();
        }

        public List<Model.PutLibrary> Query()
        {
            throw new NotImplementedException();
        }

        public int Update(Model.PutLibrary Model)
        {
            throw new NotImplementedException();
        }
    }
}
