using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Store
{
    /// <summary>
    /// 门店_门店
    /// </summary>
    public interface IStoreRepository
    {

        //添加
        int AddStore(IOT.Core.Model.Store a);

        //显示
        List<IOT.Core.Model.Store> ShowStore();

        //删除
        int DelStore(string id);

        //修改
        int UptStore(IOT.Core.Model.Store a);

    }
}
