using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Delivery
{
    public interface IDeliveryRepository
    {

        int Update(IOT.Core.Model.Delivery Model);
        int Delete(string ids);
        int Insert(IOT.Core.Model.Delivery Model);
        List<IOT.Core.Model.Delivery> Query();

    }
}
