using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.OutLibrary
{
    public interface IOutLibraryRepository
    {

        int Update(IOT.Core.Model.OutLibrary Model);
        int Delete(string ids);
        int Insert(IOT.Core.Model.OutLibrary Model);
        List<IOT.Core.Model.OutLibrary> Query();

    }
}
