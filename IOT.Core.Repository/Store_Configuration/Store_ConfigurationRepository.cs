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

        public int InsertPic(Model.Store_Configuration Model)
        {
            string sql = $"insert into Store_Configuration values(NULL,'{Model.StorePic}','{Model.StoreName}','{Model.State}','{Model.CreateTime}')";
            return DapperHelper.Execute(sql);
        }

    }
}
