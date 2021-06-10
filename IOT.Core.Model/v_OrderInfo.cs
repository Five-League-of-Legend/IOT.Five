using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
   public class v_OrderInfo:OrderInfo
    {
        public int Onum { get; set; }
        public int Og { get; set; }
        public int Sg { get; set; }
        public int ev { get; set; }
        public int Mo { get; set; }
        public int Opt { get; set; }
        public int Oat { get; set; }

    }
}
