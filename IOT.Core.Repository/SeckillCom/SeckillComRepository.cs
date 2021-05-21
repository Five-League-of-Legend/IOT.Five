using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.IRepository.SeckillCom;
using IOT.Core.Common;

namespace IOT.Core.Repository.SeckillCom
{
    public class SeckillComRepository : ISeckillComRepository
    {
        public int Delete(string ids)
        {
            string sql = $"delete from SeckillCom where SeckillComId in ({ids})";
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.SeckillCom Model)
        {
            string sql = $"insert into SeckillCom values (null,{Model.ActivityId},{Model.CommodityId},'{Model.SeckillTitle}','{Model.SeckillRemaek}',{Model.SeckillModel},{Model.TackTime},'{Model.ActionDate}',{Model.State},{Model.SeckilPrice},{Model.LimitNum})";
            return DapperHelper.Execute(sql);
        }

        public List<Model.SeckillCom> Query()
        {
            string sql = "select a.*,b.ActivityId,c.CommodityPic,b.ActivityName,b.BeginTime,b.EndTime,c.ShopPrice,NOW() times,c.CommodityName FROM SeckillCom a JOIN Activity b ON a.ActivityId=b.ActivityId JOIN Commodity c ON a.CommodityId=c.CommodityId";
            return DapperHelper.GetList<IOT.Core.Model.SeckillCom>(sql);
        }

        public int Uptdate(Model.SeckillCom Model)
        {
            string sql = $"update SeckillCom set ActivityId={ Model.ActivityId},CommodityId={Model.CommodityId},SeckillTitle='{Model.SeckillTitle}',SeckillRemaek='{Model.SeckillRemaek}',SeckillModel={ Model.SeckillModel},TackTime={ Model.TackTime},ActionDate='{Model.ActionDate}',State={ Model.State}.SeckilPrice={ Model.SeckilPrice},LimitNum={ Model.LimitNum} where SeckillComId={Model.SeckillComId}";
            return DapperHelper.Execute(sql);
        }

        public int UptZt(int sid)
        {
            string sql = "select a.*,b.ActivityId,c.CommodityPic,b.ActivityName,b.BeginTime,b.EndTime,c.ShopPrice,NOW() times,c.CommodityName FROM SeckillCom a JOIN Activity b ON a.ActivityId=b.ActivityId JOIN Commodity c ON a.CommodityId=c.CommodityId";
            List<Model.Activity> la = DapperHelper.GetList<Model.Activity>(sql);
            Model.Activity aa = la.FirstOrDefault(x => x.ActivityId.Equals(sid));
            string sql1 = "";
            if (aa.State == 0)
            {
                sql1 = $"UPDATE SeckillCom SET State=State+1 where SeckillComId={sid}";
            }
            else
            {
                sql1 = $"UPDATE SeckillCom SET State=State-1 where SeckillComId={sid}";
            }
            return DapperHelper.Execute(sql1);
        }
    }
}
