using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Colonel
{
    public interface IColonelRepository
    {        
        //显示
        List<IOT.Core.Model.Colonel> ShowColonel(int cid);

    }
}
