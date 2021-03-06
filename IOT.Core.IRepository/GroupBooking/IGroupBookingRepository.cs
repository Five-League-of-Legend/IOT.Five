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
        List<Model.GroupBooking> QueryList();
        int Uptdate(Model.GroupBooking Model);
        int UptZt(int bid);
        List<Model.Colonel> Binds();
    }
}
