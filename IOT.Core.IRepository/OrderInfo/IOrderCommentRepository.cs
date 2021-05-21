using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.OrderInfo
{
    public interface IOrderCommentRepository
    {
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <returns></returns>
        List<Model.ViewOrderComAndCom_Com> ShowOrderCom();

        /// <summary>
        /// 修改显示状态
        /// </summary>
        /// <returns></returns>
        int UptOrderCom(Model.OrderComment orderComment);
    }
}
