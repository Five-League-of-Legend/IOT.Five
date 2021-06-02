using IOT.Core.Common;
using IOT.Core.IRepository.Colonel.GroupPurchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Colonel.GroupPurchase
{
    public class GroupPurchaseRepository : IGroupPurchaseRepository
    {
        /// <summary>
        /// 添加团购配置
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int AddGroupPurchase(Model.GroupPurchase gp)
        {
            try
            {
                string sql = $" insert into GroupPurchase values (null,{gp.IsGroup},'{gp.Notice}','{gp.CloseTime}','{gp.PosterOne}','{gp.PosterTwo}','{gp.PosterThree}','{gp.DespatchMode}','{gp.HeadName}',{gp.CoverageArea},{gp.ServiceCharge},{gp.WithdrawDeposit},{gp.Commission})   ";

                return DapperHelper.Execute(sql);
            }
            catch (Exception)
            {

                throw;
            }
      
        }
    }
}
