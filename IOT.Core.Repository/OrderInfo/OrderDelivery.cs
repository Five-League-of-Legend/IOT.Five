using IOT.Core.Common;
using IOT.Core.IRepository.OrderInfo;
using IOT.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.OrderInfo
{
    public class OrderDelivery : IOrderDelivery
    {
        /// <summary>
        /// 订单配送
        /// </summary>
        /// <returns></returns>
        public List<ViewOrderUsersCommodity> ShowOrderDelivery()
        {
            try
            {
                string sql = @"select * from orderinfo a  
                           join users b on a.UserId = b.UserId 
                           join commodity c on a.CommodityId = c.CommodityId ";

                return DapperHelper.GetList<ViewOrderUsersCommodity>(sql);
            }
            catch (Exception)
            {

                throw;
            }
      
        }
    }
}
