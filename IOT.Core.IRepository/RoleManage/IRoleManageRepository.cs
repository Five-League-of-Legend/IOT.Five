using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.RoleManage
{
    public interface IRoleManageRepository
    {
        int Update(IOT.Core.Model.PutLibrary Model);
        int Delete(string ids);
        int Insert(IOT.Core.Model.PutLibrary Model);
        List<IOT.Core.Model.PutLibrary> Query();
        int AddRoleManage(Model.RoleManage a);
    }
}
