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
                return DapperHelper.Execute(sql);
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
