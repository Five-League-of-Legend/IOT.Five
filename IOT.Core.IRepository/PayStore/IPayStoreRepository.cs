using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.PayStore
{
    public interface IPayStoreRepository
    {

        int UptWhether();
        int UptCollection();
        List<IOT.Core.Model.PayStore> GetPayStores();

    }
}
