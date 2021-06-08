using IOT.Core.Common;
using IOT.Core.IRepository.Colonel.Brokerage;
using IOT.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Colonel.Brokerage
{
    public class BrokerageRepository : IBrokerageRepository
    {
        //private string vkey = "VbrokerageRedis";
        //private string key = "brokerageRedis";
        //RedisHelper<ViewColonelAndBrokerage> vrh = new RedisHelper<ViewColonelAndBrokerage>();
        //RedisHelper<Model.Brokerage> rh = new RedisHelper<Model.Brokerage>();
        //List<ViewColonelAndBrokerage> Vjoinls = new List<ViewColonelAndBrokerage>();
        //List<Model.Brokerage> joinls = new List<Model.Brokerage>();

        //RedisHelper<Model.Brokerage> rhadd = new RedisHelper<Model.Brokerage>();
        //List<Model.Brokerage> brokeragels = new List<Model.Brokerage>();

        //public BrokerageRepository()
        //{
        //    Vjoinls = vrh.Get(vkey);
        //    joinls = rh.Get(key);
        //    // brokeragels = rhadd.Get(key);
        //}

        /// <summary>
        /// 添加佣金流水
        /// </summary>
        /// <param name="brokerage"></param>
        /// <returns></returns>
        public int AddBrokerage(Model.Brokerage brokerage)
        {
            try
            {
                string sql = $" insert into Brokerage values (null,{brokerage.ColonelID},{brokerage.BrokerageType},{brokerage.Income},{brokerage.State},'{brokerage.EndTime}',{brokerage.OrderFormStatus}) ";

                int i = DapperHelper.Execute(sql);

                //if (i > 0)
                //{
                //    //重新获取视图数据
                //    Vjoinls = DapperHelper.GetList<ViewColonelAndBrokerage>(" select * from Brokerage a join colonel b on a.ColonelID=b.ColonelID ");
                //    Vjoinls.Add(DapperHelper.GetList<Model.ViewColonelAndBrokerage>(" select * from brokerage order by BId desc limit 1 ").FirstOrDefault());

                //    //joinls.Add(brokerage);

                //    rh.Set(key, joinls);
                //    vrh.Set(vkey, Vjoinls);
                //}
                                                
                //brokeragels.Add(brokerage);

                //rhadd.Set(key, brokeragels);

                return i;
            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// 删除佣金流水
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelBrokerage(int id)
        {
            try
            {
                string sql = $" delete from Brokerage where BId = {id} ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 佣金流水   两表联查
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="orderFormStatus">订单状态</param>
        /// <param name="colonel">所属团长</param>
        /// <param name="orderNumber">订单号</param>
        /// <param name="brokerageState">佣金状态</param>
        /// <returns></returns>  
        public List<ViewColonelAndBrokerage> GetBrokerages(string time, int orderFormStatus, string colonel, string orderNumber, int brokerageState)
        {


            //vrh.Set(vkey,Vjoinls);

            //if (Vjoinls == null || Vjoinls.Count == 0)
            //{
            //    string sql = " select * from Brokerage a join colonel b on a.ColonelID=b.ColonelID where 1=1 ";
            //    Vjoinls = DapperHelper.GetList<ViewColonelAndBrokerage>(sql);
            //}

            //if (joinls == null || joinls.Count == 0)
            //{
            //    joinls = DapperHelper.GetList<Model.Brokerage>("select * from Brokerage");
            //}

            //vrh.Set(vkey,Vjoinls);

            //return Vjoinls;


            string sql = " select * from Brokerage a join colonel b on a.ColonelID=b.ColonelID where 1=1 ";

            try
            {
                if (orderFormStatus != 0)
                {
                    sql += $" and OrderFormStatus = {orderFormStatus} ";
                }

                if (colonel != "aaa")
                {
                    sql += $" and ColonelName like '%{colonel}%' ";
                }
                if (orderNumber != "aaa")
                {
                    sql += $" and BId = {orderNumber} ";
                }

                if (brokerageState != 0)
                {
                    sql += $" and BrokerageType = {brokerageState} ";
                }

                return DapperHelper.GetList<ViewColonelAndBrokerage>(sql);

            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// 修改佣金流水
        /// </summary>
        /// <param name="brokerage"></param>
        /// <returns></returns>       
        public int UptBrokerage(Model.Brokerage brokerage)
        {
            try
            {
                string sql = $" update Brokerage set ColonelID={brokerage.ColonelID},BrokerageType={brokerage.BrokerageType},Income={brokerage.Income},State={brokerage.State},EndTime='{brokerage.EndTime}',OrderFormStatus={brokerage.OrderFormStatus} ";
                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
