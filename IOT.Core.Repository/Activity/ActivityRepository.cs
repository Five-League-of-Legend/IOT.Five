using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.IRepository.Activity;
using IOT.Core.Common;

namespace IOT.Core.Repository.Activity
{
    public class ActivityRepository : IActivityRepository
    {
        public int Delete(string ids)
        {
            string sql = $"DELETE FROM Activity WHERE ActivityId IN ({ids})";
            string sql2 = $"insert into Lognote values (NULL,'删除',NOW(),'Activity配置表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.Activity Model)
        {
            string sql = $"INSERT INTO Activity VALUES (NULL,'{Model.ActivityName}','{Model.BeginTime}','{Model.EndTime}','{Model.Slideshow}',{Model.State},NOW(),{Model.ActivityTime});";
            string sql2 = $"insert into Lognote values (NULL,'添加',NOW(),'Activity配置表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.Execute(sql);
        }

        public List<Model.Activity> Query()
        {
            string sql = "SELECT * FROM Activity;";
            string sql2 = $"insert into Lognote values (NULL,'显示',NOW(),'Activity配置表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.GetList<Model.Activity>(sql);
        }

        public int Uptdate(Model.Activity Model)
        {
            string sql = $"update Activity set ActivityName='{Model.ActivityName}', BeginTime='{Model.BeginTime}', EndTime='{Model.EndTime}', Slideshow='{Model.Slideshow}', State={Model.State},CreateDate='{Model.CreateDate}', ActivityTime={Model.ActivityTime} where ActivityId={Model.ActivityId}";
            string sql2 = $"insert into Lognote values (NULL,'修改',NOW(),'Activity配置表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.Execute(sql);
        }

        public int UptZt(int aid)
        {
            string sql = "SELECT * FROM Activity;";
            string sql2 = $"insert into Lognote values (NULL,'修改状态',NOW(),'Activity配置表');";
            DapperHelper.Execute(sql2);
            List<Model.Activity> la = DapperHelper.GetList<Model.Activity>(sql);
            Model.Activity aa = la.FirstOrDefault(x => x.ActivityId.Equals(aid));
            string sql1 = "";
            if (aa.State == 0)
            {
                sql1 = $"UPDATE Activity SET State=State+1 where ActivityId={aid}";
            }
            else
            {
                sql1 = $"UPDATE Activity SET State=State-1 where ActivityId={aid}";
            }
            return DapperHelper.Execute(sql1);
        }
    }
}
