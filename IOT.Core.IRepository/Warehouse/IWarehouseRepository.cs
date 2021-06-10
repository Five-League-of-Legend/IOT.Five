using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Warehouse
{
    public interface IWarehouseRepository
    {
        int Update(IOT.Core.Model.Warehouse warehouse);
        int Delete(string ids);
        int Insert(IOT.Core.Model.Warehouse Model);
        List<IOT.Core.Model.Warehouse> Query();
        int UptState(int id);

    }
}
