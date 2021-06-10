using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Model;
namespace IOT.Core.IRepository.Role
{
     public interface  IRoleRepository
    {
    
        //显示
        List<IOT.Core.Model.Role> GetRole();
        //添加
        int AddRole(IOT.Core.Model.Role role);
        //删除
        int DelRole(int rid);

        //修改
        int UptRole(IOT.Core.Model.Role role);
    }
}
