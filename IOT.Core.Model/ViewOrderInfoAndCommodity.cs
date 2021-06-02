using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    public class ViewOrderInfoAndCommodity
    {
        public int Orderid { get; set; }
        public int CommodityId { get; set; }
        public int UserId { get; set; }
        public int SendWay { get; set; }
        public int OrderState { get; set; }
        public string Remark { get; set; }
        public float CommodityPrice { get; set; }
        public float DistributionCosts { get; set; }
        public float OrderPrice { get; set; }
        public float CouponPrice { get; set; }
        public float AmountPaid { get; set; }
        public DateTime StartTime { get; set; }

        public string CommodityName { get; set; }//商品名称
        public string CommodityPic { get; set; } //商品图片
        public string SendAddress { get; set; } //地址
        public string ShopNum { get; set; } //数量

        public string ShopPrice { get; set; }    //销售单价
        public int SId { get; set; }             //规格

        public string UserName { get; set; }    //买家姓名
        public string Phone { get; set; }    //买家电话
        public string Address { get; set; }    //买家地址

        public string ColonelName { get; set; } //团长姓名
        public string Region { get; set; }      //团长小区


    }
}
