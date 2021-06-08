using IOT.Core.Common;
using IOT.Core.IRepository.Store;
using IOT.Core.Model;
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

        public int DelCom(int ids)
        {
            string sql = $"DELETE FROM Commodity WHERE CommodityId=({ids})";
            return DapperHelper.Execute(sql);
        }

        public int DelStore(int ids)
        {
            string sql = $"delete from Store where Mid in ({ids})";
            return DapperHelper.Execute(sql);
        }

        public List<Model.Commodity> GetCommodities()
        {
            string sql = "SELECT * FROM Commodity";
            return DapperHelper.GetList<IOT.Core.Model.Commodity>(sql);
        }


        public List<Model.Store> GetStores()
        {
            string sql = $"SELECT * FROM Store ";
            return DapperHelper.GetList<Model.Store>(sql);
        }

        /// <summary>
        /// 显示查询门店
        /// </summary>
        /// <param name="address"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<V_Store> GetStores(string address = "", string key = "")
        {
            //获取全部数据
            List<V_Store> lst = DapperHelper.GetList<V_Store>("select * from V_Store");
            lst = lst.Where(x => (string.IsNullOrEmpty(address) ? true : x.Address.Contains(address)) && (string.IsNullOrEmpty(key) ? true : (x.UserName.Contains(key) || x.Phone == key))).ToList();
            return lst;
        }

        public List<Model.Store> GetStoresFan(int id)
        {
            string sql = $"select * from Store where Mid={id}";
            return DapperHelper.GetList<IOT.Core.Model.Store>(sql);
        }

        public int InsertStore(Model.Store Model)
        {
            string sql = $"INSERT INTO Store VALUES(NULL,'{Model.MName}','{Model.Shopowner}','{Model.Goods}','{Model.Volume}','{Model.StoreType}','{Model.Extraction}','{Model.State}','{Model.StoreNo}','{Model.Pwd}','{Model.Phone}','{Model.Background}','{Model.Logo}','{Model.Approve}')";
            return DapperHelper.Execute(sql);
        }
        /// <summary>
        /// 修改商品状态
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int UptCom(int cid)
        {
            string sql = $"SELECT * FROM Commodity ";

            List<IOT.Core.Model.Commodity> list = DapperHelper.GetList<IOT.Core.Model.Commodity>(sql);

            IOT.Core.Model.Commodity order = list.FirstOrDefault(x => x.CommodityId.Equals(cid));
            string sqlq = "";
            if (order.State == 0)
            {
                sqlq = $"UPDATE Commodity SET State=State+1 where CommodityId={cid}";
            }
            else
            {
                sqlq = $"UPDATE Commodity SET State=State-1 where CommodityId={cid}";

            }
            return DapperHelper.Execute(sqlq);
        }

        public int UptStore(Model.Store Model)
        {
            string sql = $"UPDATE Store SET MName ='{Model.MName}',Shopowner='{Model.Shopowner}',Goods='{Model.Goods}',Volume='{Model.Volume}',StoreType='{Model.StoreType}',Extraction='{Model.Extraction}',State='{Model.State}',StoreNo='{Model.StoreNo}',Pwd='{Model.Pwd}',Phone='{Model.Phone}',Background='{Model.Background}',Logo='{Model.Logo}',Approve='{Model.Approve}' where Mid='{Model.Mid}'";
            return DapperHelper.Execute(sql);
        }

        public int UptStoreState(int id)
        {
            string sql = $"SELECT * FROM Store ";

            List<IOT.Core.Model.Store> list = DapperHelper.GetList<IOT.Core.Model.Store>(sql);

            IOT.Core.Model.Store order = list.FirstOrDefault(x => x.Mid.Equals(id));
            string sqlq = "";
            if (order.State == 0)
            {
                sqlq = $"UPDATE Store SET State=State+1 where Mid={id}";
            }
            else
            {
                sqlq = $"UPDATE Store SET State=State-1 where Mid={id}";

            }
            return DapperHelper.Execute(sqlq);
        }

    }
}
