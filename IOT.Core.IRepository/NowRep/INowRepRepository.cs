using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.NowRep
{
    public interface INowRepRepository
    {
        // 显示
        List<IOT.Core.Model.NowRep> ShowNowRep();

        // 删除
        int DelNowRep(string id);
    }
}
