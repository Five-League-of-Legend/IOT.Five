using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.WorkBench
{
    public interface IWorkBenchRepository
    {
        List<Model.OrderInfo> OrderSelect();
        List<Model.Lognote> lognotesSelect();
    }
}
