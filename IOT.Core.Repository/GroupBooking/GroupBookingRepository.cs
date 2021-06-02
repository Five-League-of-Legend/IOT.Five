using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.IRepository.GroupBooking;
using IOT.Core.Common;

namespace IOT.Core.Repository.GroupBooking
{
    public class GroupBookingRepository : IGroupBookingRepository
    {
        public List<Model.Colonel> Binds()
        {
            string sql = "select * from Colonel";
            List<Model.Colonel> lc = DapperHelper.GetList<Model.Colonel>(sql);
            return lc;
        }

        public int Delete(string ids)
        {
            string sql = $"delete from GroupBooking where GroupBookingID in ({ids})";
            string sql2 = $"insert into Lognote values (NULL,'删除',NOW(),'GroupBooking拼团表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.GroupBooking Model)
        {
            string sql = $"insert into  GroupBooking values(null,{Model.ColonelID},{Model.CommodityId},'{Model.GroupBookingName}','{Model.GroupBookingRemark}','{Model.GroupBookingUnit}','{Model.GroupBookingSdate}','{Model.GroupBookingZdate}',{ Model.GroupBookingResults},{ Model.GroupBookingNumber},{ Model.GroupBookingSellLimitNum},{ Model.GroupBookingSort},{ Model.GroupBookingTemplate},{ Model.GroupBookingState},{ Model.GroupBookingPrice},{ Model.GroupBookingLimitNum}) ";
            string sql2 = $"insert into Lognote values (NULL,'添加',NOW(),'GroupBooking拼团表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.Execute(sql);
        }

        public List<Model.GroupBooking> Query()
        {
            string sql = "SELECT a.*,c.ColonelName,b.CommodityId,b.CommodityPic,b.Remark,b.CommodityName,b.ShopPrice,c.HeadPortrait,TIMESTAMPDIFF(DAY,a.GroupBookingSdate,NOW()) Days,MONTH(a.GroupBookingSdate) Months,YEAR(a.GroupBookingSdate) years FROM GroupBooking a join Commodity b on a.CommodityId=b.CommodityId JOIN Colonel c ON a.ColonelID=c.ColonelID";
            string sql2 = $"insert into Lognote values (NULL,'显示查看拼团商品',NOW(),'GroupBooking拼团表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.GetList<Model.GroupBooking>(sql);
        }

        public List<Model.GroupBooking> QueryList()
        {
            string sql = "SELECT a.*,c.ColonelName,c.HeadPortrait,b.CommodityName FROM GroupBooking a join Commodity b on a.CommodityId=b.CommodityId JOIN Colonel c ON a.ColonelID=c.ColonelID";
            string sql2 = $"insert into Lognote values (NULL,'显示查看拼团列表',NOW(),'GroupBooking拼团表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.GetList<Model.GroupBooking>(sql);
        }

        public int Uptdate(Model.GroupBooking Model)
        {
            string sql = $"UPDATE GroupBooking SET ColonelID={Model.ColonelID},CommodityId={Model.CommodityId},GroupBookingName='{Model.GroupBookingName}',GroupBookingRemark='{Model.GroupBookingRemark}',GroupBookingUnit='{Model.GroupBookingUnit}',GroupBookingSdate='{Model.GroupBookingSdate}',GroupBookingZdate='{Model.GroupBookingZdate}',GroupBookingResults={Model.GroupBookingResults},GroupBookingNumber={Model.GroupBookingNumber},GroupBookingSellLimitNum={Model.GroupBookingSellLimitNum},GroupBookingSort={Model.GroupBookingSort},GroupBookingTemplate={Model.GroupBookingTemplate},GroupBookingState={Model.GroupBookingState},GroupBookingPrice={Model.GroupBookingPrice},GroupBookingLimitNum={Model.GroupBookingLimitNum} where GroupBookingID ={Model.GroupBookingID}";
            string sql2 = $"insert into Lognote values (NULL,'修改',NOW(),'GroupBooking拼团表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.Execute(sql);
        }

        public int UptZt(int bid)
        {
            string sql = "select * FROM groupbooking";
            List<Model.GroupBooking> lg = DapperHelper.GetList<Model.GroupBooking>(sql);
            Model.GroupBooking mg = lg.FirstOrDefault(x => x.GroupBookingID.Equals(bid));
            string sql1 = "";
            if (mg.GroupBookingState==0)
            {
                sql1 = $"UPDATE GroupBooking SET GroupBookingState=GroupBookingState+1 WHERE GroupBookingID={bid}";
            }
            else
            {
                sql1 = $"UPDATE GroupBooking SET GroupBookingState=GroupBookingState-1 WHERE GroupBookingID={bid}";
            }
            string sql2 = $"insert into Lognote values (NULL,'修改状态',NOW(),'GroupBooking拼团表');";
            DapperHelper.Execute(sql2);
            return DapperHelper.Execute(sql1);
        }
    }
}
