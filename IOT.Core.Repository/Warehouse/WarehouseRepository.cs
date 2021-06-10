using IOT.Core.Common;
using IOT.Core.IRepository.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Warehouse
{
    public class WarehouseRepository: IWarehouseRepository
    {

        public int Delete(string ids)
        {
            string sql = $"DELETE FROM Warehouse WHERE WarehouseId IN({ids})";
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.Warehouse Model)
        {
            string sql = $"INSERT INTO Warehouse VALUES(NULL,'{Model.WarehouseName}','{Model.WarehouseSite}','{Model.WarehouseCoordinate}',{Model.WarehouseNum},'{Model.WarehouseState}')";
            return DapperHelper.Execute(sql);
        }

        public List<Model.Warehouse> Query()
        {
            string sql = "SELECT * FROM Warehouse";
            return DapperHelper.GetList<IOT.Core.Model.Warehouse>(sql);
        }

        public int Update(Model.Warehouse warehouse)
        {
            string sql = $"UPDATE Warehouse SET WarehouseName='{warehouse.WarehouseName}',WarehouseSite='{warehouse.WarehouseSite}',WarehouseCoordinate='{warehouse.WarehouseCoordinate}',WarehouseNum={warehouse.WarehouseNum},WarehouseState='{warehouse.WarehouseState}' WHERE WarehouseId={warehouse.WarehouseId}";
            return DapperHelper.Execute(sql);
        }

        public int UptState(int id)
        {
            string sql = "SELECT * FROM Warehouse";
            List<IOT.Core.Model.Warehouse> lw = DapperHelper.GetList<IOT.Core.Model.Warehouse>(sql);
            IOT.Core.Model.Warehouse warehouse = lw.FirstOrDefault(x => x.WarehouseId.Equals(id));
            string sqls = "";
            if (warehouse.WarehouseState == "0")
            {
                sqls = $"UPDATE Warehouse SET WarehouseState='1' WHERE WarehouseId={id}";
            }
            else
            {
                sqls = $"UPDATE Warehouse SET WarehouseState='0' WHERE WarehouseId={id}";
            }
            return DapperHelper.Execute(sqls);
        }

    }
}
