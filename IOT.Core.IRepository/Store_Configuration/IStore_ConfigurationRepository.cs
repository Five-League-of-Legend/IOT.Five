using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Store_Configuration
{
    /// <summary>
    /// 门店_配置
    /// </summary>
    public interface IStore_ConfigurationRepository
    {

        //添加
        int AddStore_Config(IOT.Core.Model.Store_Configuration a);

        //显示
        List<IOT.Core.Model.Store_Configuration> ShowStore_Config();

        //修改
        int UptStore_Config(IOT.Core.Model.Store_Configuration a);

        // 上传图片


    }
}
