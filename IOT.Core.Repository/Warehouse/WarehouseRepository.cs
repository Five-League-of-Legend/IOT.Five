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

        // 显示
        public List<Model.Warehouse> ShowWarehouse()
        {
            string sql = "select * from Warehouse";
            return DapperHelper.GetList<Model.Warehouse>(sql);
        }

        // 删除
        public int DelWarehouse(string id)
        {
            string sql = $"delete from Warehouse where WarehouseId={id}";
            return DapperHelper.Execute(sql);
        }

        // 新增
        public int AddWarehouse(Model.Warehouse a)
        {
            string sql = $"insert into Warehouse values (null,'{a.WarehouseName}', '{a.WarehouseSite}'," +
                $" '{a.WarehouseCoordinate}', '{a.WarehouseNum}', '{a.WarehouseState}')";
            return DapperHelper.Execute(sql);
        }

        // 修改
        public int UptWarehouse(Model.Warehouse a)
        {
            string sql = $"Update Warehouse Set  WarehouseName='{a.WarehouseName}' , WarehouseSite='{a.WarehouseSite}', WarehouseCoordinate='{a.WarehouseCoordinate}'," +
                 $"WarehouseNum='{a.WarehouseNum}', WarehouseState='{a.WarehouseState}' where WarehouseId='{a.WarehouseId}' ";
            return DapperHelper.Execute(sql);
        }

    }
}
