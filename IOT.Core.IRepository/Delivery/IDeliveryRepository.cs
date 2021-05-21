using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Delivery
{
    public interface IDeliveryRepository
    {

        // 显示
        List<IOT.Core.Model.Delivery> ShowDelivery();

        // 删除
        int DelDelivery(string id);

        // 修改
        int UptDelivery(IOT.Core.Model.Delivery a);

    }
}
