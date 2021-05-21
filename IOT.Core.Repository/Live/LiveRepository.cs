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
        public int Delete(string ids)
        {
            string sql = $"DELETE FROM live WHERE LiveId in ({ids})";
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.Live Model)
        {
            string sql = $"INSERT INTO live VALUES (NULL,'{Model.LiveTitle}','{Model.Remark}','{Model.LiveCover}','{Model.GoodId}',{Model.LiveModel},{Model.AnchorId},'{Model.BeginLiveDate}','{Model.EndLiveDate}',{Model.IsEnable})";
            return DapperHelper.Execute(sql);
        }

        public List<Model.Live> Query()
        {
            string sql = $"SELECT a.*,b.AnchorName FROM live a join anchor b ON a.anchorId=b.anchorId";
            return DapperHelper.GetList<Model.Live>(sql);
        }

        public List<Model.Commodity> SelectGoods(int lid)
        {
            string sql = $"SELECT GoodId FROM live where LiveId ={lid}";
            object goodid = DapperHelper.Exescalar(sql);
            string sql1 = $"SELECT * FROM Commodity WHERE CommodityId IN ({goodid})";
            List<Model.Commodity> lc = DapperHelper.GetList<Model.Commodity>(sql1);
            return lc;
        }

        public int UptDate(Model.Live Model)
        {
            string sql = $"UPDATE Live set LiveTitle='{Model.LiveTitle}',Remark='{Model.Remark}',LiveCover='{Model.LiveCover}',GoodId='{Model.GoodId}',LiveModel={Model.LiveModel},AnchorId={Model.AnchorId},BeginLiveDate='{Model.BeginLiveDate}',EndLiveDate='{Model.EndLiveDate}',IsEnable={Model.IsEnable} WHERE LiveId ={Model.LiveId}";
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
            return DapperHelper.Execute(sql1);
        }
    }
}
