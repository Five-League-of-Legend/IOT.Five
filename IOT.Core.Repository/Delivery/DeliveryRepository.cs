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

        public int Delete(string ids)
        {
            string sql = $"DELETE FROM Delivery WHERE DeliveryId IN({ids})";
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.Delivery Model)
        {
            string sql = $"INSERT INTO Delivery VALUES(NULL,{Model.UserId},{Model.ColonelID},'{Model.DeliveryPath}','{Model.DeliveryName}')";
            return DapperHelper.Execute(sql);
        }

        public List<Model.Delivery> Query()
        {
            string sql = "SELECT * FROM Delivery a JOIN Users b ON a.UserId=b.UserId join Colonel c ON a.ColonelID=c.ColonelID";
            return DapperHelper.GetList<IOT.Core.Model.Delivery>(sql);
        }

        public int Update(Model.Delivery Model)
        {
            string sql = $"UPDATE Delivery SET DeliveryName='{Model.DeliveryName}',DeliveryPath='{Model.DeliveryPath}' WHERE DeliveryId={Model.DeliveryId}";
            return DapperHelper.Execute(sql);
        }

    }
}
