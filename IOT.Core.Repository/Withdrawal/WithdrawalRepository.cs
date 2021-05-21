using IOT.Core.Common;
using IOT.Core.IRepository.Withdrawal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Withdrawal
{
    public class WithdrawalRepository : IWithdrawalRepository
    {

        // 显示
        public List<Model.Withdrawal> ShowIWithdrawal()
        {
            string sql = "select * from Withdrawal";
            return DapperHelper.GetList<Model.Withdrawal>(sql);
        }

    }
}
