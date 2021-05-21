using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Warehouse
{
    public interface IWarehouseRepository
    {
        // 显示
        List<IOT.Core.Model.Warehouse> ShowWarehouse();

        // 删除
        int DelWarehouse(string id);

        // 新增
        int AddWarehouse(IOT.Core.Model.Warehouse a);

        // 修改
        int UptWarehouse(IOT.Core.Model.Warehouse a);

    }
}
