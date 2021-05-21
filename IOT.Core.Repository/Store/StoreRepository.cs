using IOT.Core.Common;
using IOT.Core.IRepository.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Store
{
    /// <summary>
    /// 门店_门店
    /// </summary>
    public class StoreRepository:IStoreRepository
    {
        
        //添加
        int IStoreRepository.AddStore(Model.Store a)
        {
            string sql = $"insert into Store values (null,'{a.MName}', '{a.Shopowner}', '{a.Goods}'," +
                $"'{a.Volume}','{a.Extraction}','{a.StoreType}','{a.State}')";
            return DapperHelper.Execute(sql);
        }

        //显示
        List<Model.Store> IStoreRepository.ShowStore()
        {
            string sql = "select * from Store";
            return DapperHelper.GetList<Model.Store>(sql);
        }

        //删除
        int IStoreRepository.DelStore(string id)
        {
            string sql = $"delete from Store where Mid={id}";
            return DapperHelper.Execute(sql);
        }

        //修改
        int IStoreRepository.UptStore(Model.Store a)
        {
            string sql = $"Update Store Set MName='{a.MName}', Shopowner='{a.Shopowner}', Goods='{a.Goods}'," +
                $"Volume='{a.Volume}', Extraction='{a.Extraction}', StoreType='{a.StoreType}', State='{a.State}' where Mid='{a.Mid}' ";
            return DapperHelper.Execute(sql);
        }

    }
}
