using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Colonel.Brokerage
{
    public interface IBrokerageRepository
    {
        /// <summary>
        /// 添加佣金流水
        /// </summary>
        /// <param name="brokerage"></param>
        /// <returns></returns>
        int AddBrokerage(Model.Brokerage brokerage);

        /// <summary>
        /// 修改佣金流水
        /// </summary>
        /// <param name="brokerage"></param>
        /// <returns></returns>
        int UptBrokerage(Model.Brokerage brokerage);

        /// <summary>
        /// 删除佣金流水
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DelBrokerage(int id);

        /// <summary>
        /// 佣金流水   两表联查
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="orderFormStatus">订单状态</param>
        /// <param name="colonel">所属团长</param>
        /// <param name="orderNumber">订单号</param>
        /// <param name="brokerageState">佣金状态</param>
        /// <returns></returns>
        List<Model.ViewColonelAndBrokerage> GetBrokerages(string time, int orderFormStatus,string colonel, string orderNumber, int brokerageState);
    
    }
}
