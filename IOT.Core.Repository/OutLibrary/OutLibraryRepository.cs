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

        // 显示
        public List<Model.OutLibrary> ShowOutLibrary()
        {
            string sql = "select * from OutLibrary";
            return DapperHelper.GetList<Model.OutLibrary>(sql);
        }

        // 删除
        public int DelOutLibrary(string id)
        {
            string sql = $"delete from OutLibrary where PutLibraryId={id}";
            return DapperHelper.Execute(sql);
        }

        // 新增
        public int AddOutLibrary(Model.OutLibrary a)
        {
            string sql = $"insert into Warehouse values (null,'{a.WarehouseId}', '{a.CommodityId}'," +
                $" '{a.GoodNum}', '{a.OutDate}', '{a.OutNO}')";
            return DapperHelper.Execute(sql);
        }

        // 修改
        public int UptOutLibrary(Model.OutLibrary a)
        {
            string sql = $"Update Warehouse Set  WarehouseId='{a.WarehouseId}' , CommodityId='{a.CommodityId}', GoodNum='{a.GoodNum}'," +
                 $"OutDate='{a.OutDate}', OutNO='{a.OutNO}' where PutLibraryId='{a.PutLibraryId}' ";
            return DapperHelper.Execute(sql);
        }

    }
}
