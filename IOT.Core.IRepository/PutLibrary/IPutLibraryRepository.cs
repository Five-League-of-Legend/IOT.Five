using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.PutLibrary
{
    public interface IPutLibraryRepository
    {

        // 显示
        List<IOT.Core.Model.PutLibrary> ShowPutLibrarye();

        // 删除
        int DelPutLibrary(string id);

        // 新增
        int AddPutLibrary(IOT.Core.Model.PutLibrary a);

        // 修改
        int UptPutLibrary(IOT.Core.Model.PutLibrary a);

    }
}
