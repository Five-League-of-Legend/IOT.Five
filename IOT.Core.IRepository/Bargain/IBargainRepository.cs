using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Bargain
{
    public interface IBargainRepository
    {
        int Delete(string ids);
        int Insert(Model.Bargain Model);
        List<Model.Bargain> Query();
        int UptDate(Model.Bargain Model);
        int UptZt(int bid);
    }
}
