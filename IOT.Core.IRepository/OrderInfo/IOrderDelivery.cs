using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.OrderInfo
{
    public interface IOrderDelivery
    {
        /// <summary>
        /// 订单派送
        /// </summary>
        /// <returns></returns>
        List<Model.ViewOrderUsersCommodity> ShowOrderDelivery();

    }
}
