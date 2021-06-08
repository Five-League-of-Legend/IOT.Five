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
        //实例化缓存帮助类
        RedisHelper<Model.Activity> rh = new RedisHelper<Model.Activity>();
        //创建一个缓存关键字
        string redisKey;
        //全部数据
        List<Model.Activity> lst = new List<Model.Activity>();
        public ActivityRepository()
        {
            redisKey = "Activity_list";
            lst = rh.GetList(redisKey);
        }
        public int Delete(string ids)
        {
            string sql = $"DELETE FROM Activity WHERE ActivityId IN ({ids})";
            string sql2 = $"insert into Lognote values (NULL,'删除',NOW(),'Activity配置表');";
            DapperHelper.Execute(sql2);
            int i = DapperHelper.Execute(sql);
            if (i > 0)
            {
                //如果是批量删除的话需要字符串截取
                string[] arr = ids.Split(',');
                foreach (var item in arr)
                {
                    //找到要删除的对象
                    Model.Activity ac = lst.FirstOrDefault(x => x.ActivityId.ToString().Equals(item));
                    lst.Remove(ac);
                }
                //重新存入
                rh.SetList(lst, redisKey);
            }
            return i;
        }

        public int Insert(Model.Activity Model)
        {
            string sql = $"INSERT INTO Activity VALUES (NULL,'{Model.ActivityName}','{Model.BeginTime}','{Model.EndTime}','{Model.Slideshow}',{Model.State},NOW(),{Model.ActivityTime});";
            string sql2 = $"insert into Lognote values (NULL,'添加',NOW(),'Activity配置表');";
            DapperHelper.Execute(sql2);
            int i = DapperHelper.Execute(sql);
            if (i > 0)
            {
                Model = DapperHelper.GetList<Model.Activity>("select * from Activity order by ActivityId desc LIMIT 1").FirstOrDefault();
                lst.Add(Model);
                //重新放入缓存
                rh.SetList(lst, redisKey);
            }
            return i;
        }

        public List<Model.Activity> Query()
        {
            string sql = "SELECT * FROM Activity;";
            //添加到日志表
            string sql2 = $"insert into Lognote values (NULL,'显示',NOW(),'Activity配置表');";
            DapperHelper.Execute(sql2);
            //判断缓存数据是否存在
            if (lst == null || lst.Count == 0)
            {
                //拿到所有数据
                lst = DapperHelper.GetList<Model.Activity>(sql);
                //放入缓存
                rh.SetList(lst, redisKey);
            }
            return lst;
        }

        public int Uptdate(Model.Activity Model)
        {
            string sql = $"update Activity set ActivityName='{Model.ActivityName}', BeginTime='{Model.BeginTime}', EndTime='{Model.EndTime}', Slideshow='{Model.Slideshow}', State={Model.State},CreateDate='{Model.CreateDate}', ActivityTime={Model.ActivityTime} where ActivityId={Model.ActivityId}";
            string sql2 = $"insert into Lognote values (NULL,'修改',NOW(),'Activity配置表');";
            DapperHelper.Execute(sql2);
            int i = DapperHelper.Execute(sql);
            if (i > 0)
            {
                lst[lst.IndexOf(lst.FirstOrDefault(x => x.ActivityId == Model.ActivityId))] = Model;
                //重新存入
                rh.SetList(lst, redisKey);
            }
            return i;
        }

        public int UptZt(int aid)
        {
            //string sql = "SELECT * FROM Activity;";
            string sql2 = $"insert into Lognote values (NULL,'修改状态',NOW(),'Activity配置表');";
            DapperHelper.Execute(sql2);
            //List<Model.Activity> la = DapperHelper.GetList<Model.Activity>(sql);
            Model.Activity aa = lst.Where(x => x.ActivityId.Equals(aid)).FirstOrDefault();
            string sql1 = "";
            if (aa.State == 0)
            {
                sql1 = $"UPDATE Activity SET State=State+1 where ActivityId={aid}";
            }
            else
            {
                sql1 = $"UPDATE Activity SET State=State-1 where ActivityId={aid}";
            }
            int i = DapperHelper.Execute(sql1);
            if (i > 0)
            {
                //lst = DapperHelper.GetList<Model.Activity>("SELECT * FROM Activity");
                //rh.SetList(lst, redisKey);
                lst[lst.IndexOf(lst.FirstOrDefault(x => x.ActivityId == aid))] = aa;
                rh.SetList(lst, redisKey);
            }
            return i;
        }
    }
}
