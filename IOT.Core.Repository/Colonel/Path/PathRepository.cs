using IOT.Core.Common;
using IOT.Core.IRepository.Colonel.Path;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.Colonel.Path
{
    public class PathRepository : IPathRepository
    {
        /// <summary>
        /// 添加路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int AddPath(Model.Path a)
        {
            string sql = $" insert into Path values (null,'{a.PathName}','{a.PName}','{a.Phone}','{a.WarehouseAddress}','{a.LongAndLat}',{a.ColonelNum},{a.State}) ;";
            return DapperHelper.Execute(sql);
        }

        /// <summary>
        /// 删除路线
        /// </summary>
        /// <param name="PathID">路线ID</param>
        /// <returns></returns>
        public int DelPath(int PathID)
        {
            string sql = $" delete from Path where RathID={PathID}";
            return DapperHelper.Execute(sql);
        }

        /// <summary>
        /// 显示路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public List<Model.Path> ShowPath(string nm)
        {
            string sql = $" select * from Path ";

            if (nm != "")
            {
                sql += $" where PathName like '%{nm}%' ";
            }

            return DapperHelper.GetList<Model.Path>(sql);
        }

        /// <summary>
        /// 修改路线
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int UptPath(Model.Path a)
        {
            string sql = $" update Path set PathName='{a.PathName}',PName='{a.PName}',Phone='{a.Phone}',WarehouseAddress='{a.WarehouseAddress}',LongAndLat='{a.LongAndLat}',ColonelNum={a.ColonelNum},State={a.State}  where RathID = {a.RathID}  ;";
            return DapperHelper.Execute(sql);
        }
    }
}
