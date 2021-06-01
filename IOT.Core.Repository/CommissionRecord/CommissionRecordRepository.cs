using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.CommissionRecord;

namespace IOT.Core.Repository.CommissionRecord
{
    public class CommissionRecordRepository : ICommissionRecordRepository
    {
       

        public List<Model.CommissionRecord> ShowCommissionRecord()
        {
       
            string sql = "select * from commissionrecord a join SVIP b on a.SId=b.SId";

        
            
            return DapperHelper.GetList<Model.CommissionRecord>(sql);
        }
    }
}
