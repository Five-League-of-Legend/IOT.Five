using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.IRepository.CheckRep;
using IOT.Core.Common;

namespace IOT.Core.Repository.CheckRep
{
    public class CheckRepRepository : ICheckRepRepository
    {
        public int Insert(Model.CheckRep Model)
        {
            string sql = $"INSERT INTO CheckRep VALUES(NULL,'{Model.CheckNo}',{Model.WarehouseId},{Model.CheckNum},'{Model.CheckPeople}','{Model.CheckDate}')";
            return DapperHelper.Execute(sql);
        }

        public List<Model.CheckRep> Query()
        {
            string sql = "select * FROM CheckRep a JOIN Warehouse b on a.WarehouseId=b.WarehouseId";
            return DapperHelper.GetList<IOT.Core.Model.CheckRep>(sql);
        }
    }
}
