using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 订单表
    /// </summary>
    public class OrderInfo
    {
        public int Orderid           { get; set; }
        public int CommodityId       { get; set; }
        public int UserId            { get; set; }
        public int SendWay           { get; set; }
        public int OrderState        { get; set; }
        public string Remark            { get; set; }
        public float CommodityPrice    { get; set; }
        public float DistributionCosts { get; set; }
        public float OrderPrice        { get; set; }
        public float CouponPrice       { get; set; }
        public float AmountPaid        { get; set; }
        public DateTime StartTime         { get; set; }
        public int PayState { get; set; }
        public int days { get; set; }
    }
}
