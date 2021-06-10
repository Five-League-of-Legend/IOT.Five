using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Model;
namespace IOT.Core.IRepository.CheckRep
{
    public interface ICheckRepRepository
    {
        int Insert(IOT.Core.Model.CheckRep Model);
        List<IOT.Core.Model.CheckRep> Query();
    }
}
