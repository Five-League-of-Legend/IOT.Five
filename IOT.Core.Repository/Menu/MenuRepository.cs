using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Core.Common;
using IOT.Core.IRepository.Menu;

namespace IOT.Core.Repository.Menu
{
    public class MenuRepository : IMenuRepository
    {
        public List<Model.Menu> GetMenu()
        {
            try
            {
                string sql = "select * from Menu where parentid != 0";
                return DapperHelper.GetList<Model.Menu>(sql);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}







