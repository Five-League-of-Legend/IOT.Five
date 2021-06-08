using IOT.Core.Common;
using IOT.Core.IRepository.PutLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.PutLibrary
{
    public class PutLibraryRepository: IPutLibraryRepository
    {

        public int Delete(string ids)
        {
            string sql = $"DELETE FROM PutLibrary WHERE PutLibraryId in({ids})";
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'删除ID为{ids}的出库信息',NOW(),'出库表')");
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.PutLibrary Model)
        {
            string sql = $"INSERT INTO PutLibrary VALUES(NULL,{Model.WarehouseId},{Model.CommodityId},{Model.GoodNum},NOW(),'{Model.PutNO}')";
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'添加单号为{Model.PutNO}的出库信息',NOW(),'出库表')");
            return DapperHelper.Execute(sql);
        }

        public List<Model.PutLibrary> Query()
        {
            string sql = "SELECT * FROM PutLibrary a JOIN Warehouse b ON a.WarehouseId=b.WarehouseId JOIN Commodity c ON a.CommodityId = c.CommodityId";
            return DapperHelper.GetList<IOT.Core.Model.PutLibrary>(sql);
        }

        public int Update(Model.PutLibrary Model)
        {
            string sql = $"UPDATE PutLibrary SET WarehouseId={Model.WarehouseId},CommodityId={Model.CommodityId},GoodNum={Model.GoodNum},PutDate=NOW() WHERE PutLibraryId=({Model.PutLibraryId})";
            DapperHelper.Execute($"INSERT INTO Lognote VALUES(NULL,'修改ID为{Model.PutLibraryId}出库信息',NOW(),'出库表')");
            return DapperHelper.Execute(sql);
        }

    }
}
