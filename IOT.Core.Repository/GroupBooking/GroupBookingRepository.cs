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
            throw new NotImplementedException();
        }

        public int Uotdate(Model.GroupBooking Model)
        {
            throw new NotImplementedException();
        }

        public int UptZt(int bid)
        {
            throw new NotImplementedException();
        }
    }
}
