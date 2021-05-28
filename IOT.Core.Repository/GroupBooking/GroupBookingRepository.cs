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
        public int Delete(string ids)
        {
            string sql = $"delete from GroupBooking where GroupBookingID in ({ids})";
            return DapperHelper.Execute(sql);
        }

        public int Insert(Model.GroupBooking Model)
        {
            string sql = $"insert into  GroupBooking values(null,{Model.ColonelID},{Model.CommodityId},'{Model.GroupBookingName}','{Model.GroupBookingRemark}','{Model.GroupBookingUnit}','{Model.GroupBookingSdate}','{Model.GroupBookingZdate}',{ Model.GroupBookingResults},{ Model.GroupBookingNumber},{ Model.GroupBookingSellLimitNum},{ Model.GroupBookingSort},{ Model.GroupBookingTemplate},{ Model.GroupBookingState},{ Model.GroupBookingPrice},{ Model.GroupBookingLimitNum}) ";
            return DapperHelper.Execute(sql);
        }

        public List<Model.GroupBooking> Query()
        {
            string sql = "SELECT a.*,c.ColonelName,b.CommodityId,b.CommodityPic,b.Remark,b.CommodityName,b.ShopPrice,c.HeadPortrait FROM GroupBooking a join Commodity b on a.CommodityId=b.CommodityId JOIN Colonel c ON a.ColonelID=c.ColonelID";
            return DapperHelper.GetList<Model.GroupBooking>(sql);
        }

        public List<Model.GroupBooking> QueryList()
        {
            string sql = "SELECT a.*,c.ColonelName,c.HeadPortrait,b.CommodityName FROM GroupBooking a join Commodity b on a.CommodityId=b.CommodityId JOIN Colonel c ON a.ColonelID=c.ColonelID";
            return DapperHelper.GetList<Model.GroupBooking>(sql);
        }

        public int Uptdate(Model.GroupBooking Model)
        {
            string sql = $"UPDATE GroupBooking SET ColonelID={Model.ColonelID},CommodityId={Model.CommodityId},GroupBookingName='{Model.GroupBookingName}',GroupBookingRemark='{Model.GroupBookingRemark}',GroupBookingUnit='{Model.GroupBookingUnit}',GroupBookingSdate='{Model.GroupBookingSdate}',GroupBookingZdate='{Model.GroupBookingZdate}',GroupBookingResults={Model.GroupBookingResults},GroupBookingNumber={Model.GroupBookingNumber},GroupBookingSellLimitNum={Model.GroupBookingSellLimitNum},GroupBookingSort={Model.GroupBookingSort},GroupBookingTemplate={Model.GroupBookingTemplate},GroupBookingState={Model.GroupBookingState},GroupBookingPrice={Model.GroupBookingPrice},GroupBookingLimitNum={Model.GroupBookingLimitNum} where GroupBookingID ={Model.GroupBookingID}";
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
            return DapperHelper.Execute(sql1);
        }
    }
}
