using IOT.Core.Common;
using IOT.Core.IRepository.Store_Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Store_Configuration
{
    /// <summary>
    /// 门店_配置
    /// </summary>
    public class Store_ConfigurationRepository:IStore_ConfigurationRepository
    {

        //添加
        int IStore_ConfigurationRepository.AddStore_Config(Model.Store_Configuration a)
        {
            string sql = $"insert into Store_Configuration values (null,'{a.StoreName}', '{a.State}', '{a.CreateTime}')";
            return DapperHelper.Execute(sql);
        }

        //显示
        List<Model.Store_Configuration> IStore_ConfigurationRepository.ShowStore_Config()
        {
            string sql = "select * from Store_Configuration";
            return DapperHelper.GetList<Model.Store_Configuration>(sql);
        }
                
        //修改
        int IStore_ConfigurationRepository.UptStore_Config(Model.Store_Configuration a)
        {
            string sql = $"Update Store_Configuration Set StoreName='{a.StoreName}', " +
                $"State='{a.State}', CreateTime='{a.CreateTime}' where StoreId='{a.StoreId}' ";
            return DapperHelper.Execute(sql);
        }

        // 上传图片


    }
}
