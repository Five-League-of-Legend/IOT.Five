using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Live
{
    public interface ILiveRepository
    {
        int Delete(string ids);
        int Insert(Model.Live Model);
        List<Model.Live> Query();
        int UptDate(Model.Live Model);
        int UptZt(int lid);
        List<Model.Commodity> SelectGoods(int lid);
    }
}
