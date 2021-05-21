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

        // 显示
        public List<Model.PayStore> ShowIPayStore()
        {
            string sql = "select * from PayStore";
            return DapperHelper.GetList<Model.PayStore>(sql);
        }

    }
}
