using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 佣金流水
    /// </summary>
    public class Brokerage
    {
        public int  BId               { get; set; }
        public int  ColonelID         { get; set; }
        public int  BrokerageType     { get; set; }
        public decimal Income            { get; set; }
        public int  State             { get; set; }
        public DateTime  EndTime           { get; set; }
        public int  OrderFormStatus   { get; set; }        
    }
}
