using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Users
{
    public interface IUsersRepository
    {
        int UptZt(int sid);//修改状态
        //添加
        int AddUsers(IOT.Core.Model.Users a);

        //显示
        List<IOT.Core.Model.Users> ShowUsers(); 

        //显示审核员
        List<IOT.Core.Model.Users> ShowUsersWhereColonelID(int cid); 

        //删除
        int DelUsers(string id);

        //修改
        int UptUsers(IOT.Core.Model.Users a);
    }
}
