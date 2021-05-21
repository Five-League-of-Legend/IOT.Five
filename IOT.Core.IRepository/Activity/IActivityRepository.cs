using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Activity
{
    public interface IActivityRepository
    {
        int Delete(string ids);
        int Insert(Model.Activity Model);
        List<Model.Activity> Query();
        int Uptdate(Model.Activity Model);
        int UptZt(int aid);
    }
}
