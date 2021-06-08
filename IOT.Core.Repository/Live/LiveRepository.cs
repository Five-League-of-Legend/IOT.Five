using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.IRepository.Live;
using IOT.Core.Common;
using IOT.Core.Model;

namespace IOT.Core.Repository.Live
{
    public class LiveRepository : ILiveRepository
    {
        public List<Model.CommType> Binds()
        {
            string sql = "select * from CommType";
            List<Model.CommType> list = DapperHelper.GetList<Model.CommType>(sql);
            return list;
        }

        public int Delete(string ids)
        {
            string sql = $"DELETE FROM live WHERE LiveId in ({ids})";
            string sql2 = $"insert into Lognote values (NULL,'删除',NOW(),'Live直播表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.Live Model)
        {
            string sql = $"INSERT INTO live VALUES (NULL,'{Model.LiveTitle}','{Model.Remark}','{Model.LiveCover}','{Model.GoodId}',{Model.LiveModel},{Model.AnchorId},'{Model.BeginLiveDate}','{Model.EndLiveDate}',{Model.IsEnable})";
            string sql2 = $"insert into Lognote values (NULL,'添加',NOW(),'Live直播表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.Execute(sql);
        }

        public List<Model.Live> Query()
        {
            string sql = $"SELECT a.*,b.AnchorName FROM live a join anchor b ON a.anchorId=b.anchorId";
            return DapperHelper.GetList<Model.Live>(sql);
        }

        public List<Model.Commodity> SelectGoods(int lid)
        {
            if (lid != 0)
            {
                string sql = $"SELECT GoodId FROM live where LiveId ={lid}";
                object goodid = DapperHelper.Exescalar(sql);
                if (goodid != null)
                {
                    string sql1 = $"SELECT * FROM Commodity WHERE CommodityId IN ({goodid})";
                    List<Model.Commodity> lc = DapperHelper.GetList<Model.Commodity>(sql1);
                    return lc;
                }
                else
                {
                    List<Model.Commodity> lc = new List<Model.Commodity>();
                    return lc;
                }
            }
            else
            {
                List<Model.Commodity> lc = new List<Model.Commodity>();
                return lc;
            }
        }

        public int UptDate(Model.Live Model)
        {
            string sql = $"UPDATE Live set LiveTitle='{Model.LiveTitle}',Remark='{Model.Remark}',LiveCover='{Model.LiveCover}',GoodId='{Model.GoodId}',LiveModel={Model.LiveModel},AnchorId={Model.AnchorId},BeginLiveDate='{Model.BeginLiveDate}',EndLiveDate='{Model.EndLiveDate}',IsEnable={Model.IsEnable} WHERE LiveId ={Model.LiveId}";
            string sql2 = $"insert into Lognote values (NULL,'修改',NOW(),'Live直播表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.Execute(sql);
        }

        public int UptZt(int lid)
        {
            string sql = $"select * FROM live";
            List<Model.Live> lv = DapperHelper.GetList<Model.Live>(sql);
            Model.Live ll = lv.FirstOrDefault(x => x.LiveId.Equals(lid));
            string sql1 = "";
            if (ll.IsEnable == 0)
            {
                sql1 = $"UPDATE Live SET IsEnable=IsEnable+1 WHERE LiveId ={lid}";
            }
            else
            {
                sql1 = $"UPDATE Live SET IsEnable=IsEnable-1 WHERE LiveId ={lid}";
            }
            string sql2 = $"insert into Lognote values (NULL,'修改状态',NOW(),'Live直播表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.Execute(sql1);
        }
    }
}
