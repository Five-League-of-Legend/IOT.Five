using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.IRepository.WorkBench;
using IOT.Core.Common;
using IOT.Core.Model;

namespace IOT.Core.Repository.WorkBench
{
    public class WorkBenchRepository : IWorkBenchRepository
    {
        public List<Lognote> lognotesSelect()
        {
            string sql = $"select *,TIMESTAMPDIFF(DAY,Operationtime,NOW()) from Lognote ";
            List<Model.Lognote> lognotes = DapperHelper.GetList<Model.Lognote>(sql);
            return lognotes;
        }

        public List<Model.OrderInfo> OrderSelect()
        {
            string sql = "select *,TIMESTAMPDIFF(DAY,StartTime,NOW()) days from OrderInfo";
            List<Model.OrderInfo> list = DapperHelper.GetList<Model.OrderInfo>(sql);
            return list;
        }
    }
}
