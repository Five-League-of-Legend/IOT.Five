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

        // 显示
        public List<Model.PutLibrary> ShowPutLibrarye()
        {
            string sql = "select * from PutLibrary";
            return DapperHelper.GetList<Model.PutLibrary>(sql);
        }

        // 删除
        public int DelPutLibrary(string id)
        {
            string sql = $"delete from PutLibrary where PutLibraryId={id}";
            return DapperHelper.Execute(sql);
        }

        // 新增
        public int AddPutLibrary(Model.PutLibrary a)
        {
            string sql = $"insert into PutLibrary values (null,'{a.WarehouseId}', '{a.CommodityId}','{a.GoodNum}', '{a.PutDate}', '{a.PutNO}')";
            return DapperHelper.Execute(sql);
        }

        // 修改
        public int UptPutLibrary(Model.PutLibrary a)
        {
            string sql = $"Update PutLibrary Set  WarehouseId='{a.WarehouseId}' , CommodityId='{a.CommodityId}', GoodNum='{a.GoodNum}'," +
                 $"PutDate='{a.PutDate}', PutNO='{a.PutNO}' where PutLibraryId='{a.PutLibraryId}' ";
            return DapperHelper.Execute(sql);
        }

    }
}
