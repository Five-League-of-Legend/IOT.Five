using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    public  class Menu
    {
        public int MenuID { get; set; }
        public string  MenuName { get; set; }
        public int ParentID { get; set; }
        public string Link { get; set; }
        public string ICon { get; set; }
       
    }
}
