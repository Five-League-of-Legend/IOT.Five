using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 到店支付
    /// </summary>
    public class PayStore
    {
        public int Pid { get; set; }
        public int Whether { get; set; }
        public int Collection { get; set; }
    }
}
