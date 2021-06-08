using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    public class WorkBench
    {
        //今日订单量
        public int Ordernum { get; set; }
        //今日支付金额
        public float Payprice { get; set; }
        //今日访客数量
        public int Visitornum { get; set; }
        //今日客单价
        public float Customerunit { get; set; }
        //待发货数量
        public int Waitdeliver { get; set; }
        //退款中数量
        public int Refunding { get; set; }
        //库存预警
        public int Inventorywarn { get; set; }
    }
}
