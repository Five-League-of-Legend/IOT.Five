using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.CommType
{
    public interface ICommTypeRepository
    {
        int Delete(string ids);
        int Insert(Model.CommType Model);
        List<Model.CommType> Query(string TName, int State);
        List<IOT.Core.Model.CommType> UptState(int id);
        int Uptss(Model.CommType c);
 
        List<Model.CommType> Bang(int ParentId);
    }
}
