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

        // 显示
        public List<Model.NowRep> ShowNowRep()
        {
            string sql = "select * from NowRep A " +
                "join Commodity B on A.CommodityId=B.CommodityId " +
                "join Warehouse C On A.WarehouseId=C.WarehouseId " +
                "join PutLibrary D On A.PutLibraryId=D.PutLibraryId " +
                "join OutLibrary E On A.OutLibraryId=E.OutLibraryId " +
                "join OrderInfo F On B.CommodityId=F.CommodityId";
            return DapperHelper.GetList<Model.NowRep>(sql);
        }

        // 删除
        public int DelNowRep(string id)
        {
            string sql = $"delete from NowRep where NowRepId={id}";
            return DapperHelper.Execute(sql);
        }

    }
}
