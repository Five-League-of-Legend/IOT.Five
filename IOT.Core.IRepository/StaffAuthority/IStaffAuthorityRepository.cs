using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.StaffAuthority
{
    public interface IStaffAuthorityRepository
    {
        int UptAut(int rid, string menuid);//编辑权限
        string FanMenu(int rid);//反填显示角色权限信息
    }
}
