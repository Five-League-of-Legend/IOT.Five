using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.MiniProgram
{
    public interface IMiniProgramRepository
    {
        List<Model.MiniProgram> MiniPrograms();

        int UptMiniProgram(Model.MiniProgram miniProgram);
    }
}
