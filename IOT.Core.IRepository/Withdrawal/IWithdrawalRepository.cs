using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Withdrawal
{
    public interface IWithdrawalRepository
    {

        //显示
        List<IOT.Core.Model.Withdrawal> ShowIWithdrawal();

    }
}
