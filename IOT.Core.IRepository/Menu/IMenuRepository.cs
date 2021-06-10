using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.IRepository.Menu
{
    public interface IMenuRepository
    {
        List<IOT.Core.Model.Menu> GetMenu();
    }
}
