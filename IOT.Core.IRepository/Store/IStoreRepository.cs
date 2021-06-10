using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Store
{
    /// <summary>
    /// 门店_门店
    /// </summary>
    public interface IStoreRepository
    {

        /// <summary>
        /// 显示门店
        /// </summary>
        /// <returns></returns>
        List<IOT.Core.Model.Store> GetStores();

        /// <summary>
        /// 显示 查询门店
        /// </summary>
        /// <returns></returns>
        List<IOT.Core.Model.V_Store> GetStores(string address = "", string key = "");

        /// <summary>
        /// 显示商品
        /// </summary>
        /// <returns></returns>
        List<IOT.Core.Model.Commodity> GetCommodities();

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<IOT.Core.Model.Store> GetStoresFan(int id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int InsertStore(Model.Store Model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        int UptStore(Model.Store Model);

        /// <summary>
        /// 修改门店状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UptStoreState(int id);

        /// <summary>
        /// 修改商品状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UptCom(int cid);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        int DelStore(int ids);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// 
        int DelCom(int ids);

    }
}
