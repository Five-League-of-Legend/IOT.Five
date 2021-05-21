using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.SeckillCom
{
    public interface ISeckillComRepository
    {
        int Delete(string ids);
        int Insert(Model.SeckillCom Model);
        List<Model.SeckillCom> Query();
        int Uptdate(Model.SeckillCom Model);
        int UptZt(int sid);
    }
}
