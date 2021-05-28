using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.IRepository.Bargain;
using IOT.Core.Common;

namespace IOT.Core.Repository.Bargain
{
    public class BargainRepository : IBargainRepository
    {
        public int Delete(string ids)
        {
            string sql = $"DELETE FROM Bargain WHERE BargainId IN ({ids})";
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.Bargain Model)
        {
            string sql = $"insert into Bargain VALUES (null,{Model.CommodityId},{Model.PeopleNum},{Model.KNum},'{Model.BeginDate}','{Model.EndDate}',{Model.Astrict},{Model.ActionState},{Model.PartNum},{Model.MinPrice},{Model.SurplusNum},{Model.SurplusBargain},'{Model.BargainName}','{Model.BargainRemark}',{Model.Template},{Model.LimitNum},{Model.BargainSum})";
            return DapperHelper.Execute(sql);
        }

        public List<Model.Bargain> Query()
        {
            string sql = "SELECT a.*,b.CommodityName,b.CommodityPic from Bargain a JOIN Commodity b ON a.CommodityId=b.CommodityId";
            return DapperHelper.GetList<Model.Bargain>(sql);
        }

        public int UptDate(Model.Bargain Model)
        {
            string sql = $"UPDATE Bargain set CommodityId={Model.CommodityId},PeopleNum={Model.PeopleNum},KNum={Model.KNum},BeginDate='{Model.BeginDate}',EndDate='{Model.EndDate}',Astrict={Model.Astrict},ActionState={Model.ActionState},PartNum={Model.PartNum},MinPrice={Model.MinPrice}, SurplusNum ={Model.SurplusNum},SurplusBargain={Model.SurplusBargain},BargainName='{Model.BargainName}',BargainRemark='{Model.BargainRemark}',Template={Model.Template},LimitNum={Model.LimitNum},BargainSum ={Model.BargainSum} where BargainId={Model.BargainId}";
            return DapperHelper.Execute(sql);
        }

        public int UptZt(int bid)
        {
            string sql = "select * FROM Bargain";
            List<Model.Bargain> lb = DapperHelper.GetList<Model.Bargain>(sql);
            Model.Bargain ba = lb.FirstOrDefault(x => x.BargainId.Equals(bid));
            string sql1 = "";
          

            if (ba.ActionState == 0)
            {
                sql1 = $"UPDATE Bargain SET ActionState=ActionState+1 WHERE BargainId={bid}";
            }
            else
            {
                sql1 = $"UPDATE Bargain SET ActionState=ActionState-1 WHERE BargainId={bid}";
            }
            return DapperHelper.Execute(sql1);
        }
    }
}
