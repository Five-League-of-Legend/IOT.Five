using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.PayStore
{
    public interface IPayStoreRepository
    {

        //显示
        List<IOT.Core.Model.PayStore> ShowIPayStore();

    }
}
