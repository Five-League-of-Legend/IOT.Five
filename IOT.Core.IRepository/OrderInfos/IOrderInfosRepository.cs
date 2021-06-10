using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.OrderInfos
{
    public interface IOrderInfosRepository
    {
        /// <summary>
        /// 订单概述
        /// </summary>
        /// <returns></returns>
        List<IOT.Core.Model.v_OrderInfo> getnum();
        List<IOT.Core.Model.OrderInfos> GetOrderInfos(string name, int sendway, string state, string end, int tui, int dingt, int uid, string cname, string ziti);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        int insert(IOT.Core.Model.OrderInfos orderInfo);
        int Delete(string ids);
        int Insert(IOT.Core.Model.OrderInfos Model);
        List<IOT.Core.Model.OrderInfos> Query();
        /// <summary>
        /// 修改备注
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int UptRemark(IOT.Core.Model.OrderInfos Model);
        /// <summary>
        /// 修改配送地址
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int UptSendWay(IOT.Core.Model.OrderInfos Model);
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int UptOrderState(IOT.Core.Model.OrderInfos Model);


    }
}
