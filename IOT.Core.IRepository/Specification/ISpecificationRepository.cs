using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Specification
{
    public interface ISpecificationRepository
    {
        int Delete(string ids);
        int Insert(Model.Specification Model);
        List<Model.Specification> Query();
        List<Model.Specification> Query(string commspec = "");
        List<Model.Specification> UptState(int id);
        int Uptss(Model.Specification c);
        int Deletes(string id);
    }
}
