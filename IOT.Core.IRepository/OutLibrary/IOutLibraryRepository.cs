using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.OutLibrary
{
    public interface IOutLibraryRepository
    {

        // 显示
        List<IOT.Core.Model.OutLibrary> ShowOutLibrary();

        // 删除
        int DelOutLibrary(string id);

        // 新增
        int AddOutLibrary(IOT.Core.Model.OutLibrary a);

        // 修改
        int UptOutLibrary(IOT.Core.Model.OutLibrary a);

    }
}
