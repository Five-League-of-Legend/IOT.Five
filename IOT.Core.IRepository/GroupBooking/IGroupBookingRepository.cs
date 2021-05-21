using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.GroupBooking
{
    public interface IGroupBookingRepository
    {
        int Delete(string ids);
        int Insert(Model.GroupBooking Model);
        List<Model.GroupBooking> Query();
        int Uotdate(Model.GroupBooking Model);
        int UptZt(int bid);
    }
}
