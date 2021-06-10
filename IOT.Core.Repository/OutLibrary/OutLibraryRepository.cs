using IOT.Core.Common;
using IOT.Core.IRepository.OutLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.OutLibrary
{
    public class OutLibraryRepository: IOutLibraryRepository
    {

        public int Delete(string ids)
        {
            string sql = $"DELETE FROM OutLibrary WHERE PutLibraryId in({ids})";
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.OutLibrary Model)
        {
            string sql = $"INSERT INTO OutLibrary VALUES(NULL,{Model.WarehouseId},{Model.CommodityId},{Model.GoodNum},NOW(),'{Model.OutNO}')";
            return DapperHelper.Execute(sql);
        }

        public List<Model.OutLibrary> Query()
        {
            string sql = "SELECT * FROM OutLibrary a JOIN Warehouse b ON a.WarehouseId=b.WarehouseId JOIN Commodity c ON a.CommodityId = c.CommodityId";
            return DapperHelper.GetList<IOT.Core.Model.OutLibrary>(sql);
        }

        public int Update(Model.OutLibrary Model)
        {
            string sql = $"UPDATE OutLibrary SET WarehouseId={Model.WarehouseId},CommodityId={Model.CommodityId},GoodNum={Model.GoodNum},OutDate=NOW() WHERE PutLibraryId=({Model.PutLibraryId})";
            return DapperHelper.Execute(sql);
        }
    }
}
