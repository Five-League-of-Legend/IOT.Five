using IOT.Core.Common;
using IOT.Core.IRepository.PayStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.PayStore
{
    public class PayStoreRepository : IPayStoreRepository
    {

        public List<Model.PayStore> GetPayStores()
        {
            string sql = "SELECT * FROM PayStore where Pid=1";
            List<Model.PayStore> lp = DapperHelper.GetList<Model.PayStore>(sql);
            return lp;
        }

        public int UptCollection()
        {
            string sql = "SELECT * FROM PayStore";
            List<IOT.Core.Model.PayStore> lp = DapperHelper.GetList<IOT.Core.Model.PayStore>(sql);
            IOT.Core.Model.PayStore payStore = lp.FirstOrDefault(x => x.Pid.Equals(1));
            string sqls = "";
            if (payStore.Collection == 0)
            {
                sqls = "UPDATE PayStore SET Collection=Collection+1 where Pid=1";
            }
            else
            {
                sqls = "UPDATE PayStore SET Collection=Collection-1 where Pid=1";
            }
            return DapperHelper.Execute(sqls);
        }

        public int UptWhether()
        {
            string sql = "SELECT * FROM PayStore";
            List<IOT.Core.Model.PayStore> lp = DapperHelper.GetList<IOT.Core.Model.PayStore>(sql);
            IOT.Core.Model.PayStore payStore = lp.FirstOrDefault(x => x.Pid.Equals(1));
            string sqls = "";
            if (payStore.Whether == 0)
            {
                sqls = "UPDATE PayStore SET Whether=Whether+1 where Pid=1";
            }
            else
            {
                sqls = "UPDATE PayStore SET Whether=Whether-1 where Pid=1";
            }
            return DapperHelper.Execute(sqls);
        }

    }
}
