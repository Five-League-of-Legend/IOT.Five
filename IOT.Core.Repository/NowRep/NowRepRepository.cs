using IOT.Core.Common;
using IOT.Core.IRepository.NowRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.NowRep
{
    public class NowRepRepository:INowRepRepository
    {

        public int Delete(string ids)
        {
            string sql = $"DELETE  FROM NowRep WHERE NowRepId in({ids})";
            return DapperHelper.Execute(sql);
        }

        public List<Model.NowRep> Query()
        {
            string sql = "SELECT a.NowRepId, b.CommodityPic,b.CommodityName,b.CommodityId,c.WarehouseName,d.GoodNum,e.GoodNum GoodNums FROM NowRep a JOIN Commodity b ON a.CommodityId=b.CommodityId JOIN Warehouse c ON a.WarehouseId=c.WarehouseId JOIN PutLibrary d ON a.PutLibraryId=d.PutLibraryId JOIN OutLibrary e ON a.PutLibraryId = e.PutLibraryId";
            return DapperHelper.GetList<IOT.Core.Model.NowRep>(sql);
        }

    }
}
