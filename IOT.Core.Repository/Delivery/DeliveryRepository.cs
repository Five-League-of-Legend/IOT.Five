using IOT.Core.Common;
using IOT.Core.IRepository.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Delivery
{
    public class DeliveryRepository: IDeliveryRepository
    {

        // 显示
        public List<Model.Delivery> ShowDelivery()
        {
            string sql = "select * from Delivery";
            return DapperHelper.GetList<Model.Delivery>(sql);
        }

        // 删除
        public int DelDelivery(string id)
        {
            string sql = $"delete from Delivery where DeliveryId={id}";
            return DapperHelper.Execute(sql);
        }

        // 修改
        public int UptDelivery(Model.Delivery a)
        {
            string sql = $"Update PutLibrary Set  UserId='{a.UserId}' , ColonelID='{a.ColonelID}', DeliveryPath='{a.DeliveryPath}'," +
                 $"DeliveryName='{a.DeliveryName}' where DeliveryId='{a.DeliveryId}' ";
            return DapperHelper.Execute(sql);
        }
    }
}
