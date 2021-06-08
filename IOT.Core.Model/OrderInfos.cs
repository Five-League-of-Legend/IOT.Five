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
    public class OrderInfos
    {
        public int Orderid           { get; set; }
        public string Ordernumber { get; set; }
        public int Orderexpress { get; set; }

        public int CommodityId       { get; set; }
        public int UserId            { get; set; }
        public int SendWay           { get; set; }
        public int OrderState        { get; set; }

        public float CommodityPrice    { get; set; }
        public float DistributionCosts { get; set; }
        public float OrderPrice        { get; set; }
        public float CouponPrice       { get; set; }
        public float AmountPaid        { get; set; }
        public DateTime StartTime         { get; set; }


        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }
        /// <summary>
        /// 商品图
        /// </summary>
        public string CommodityPic { get; set; }
        /// <summary>
        /// 商品售价
        /// </summary>
        public float ShopPrice { get; set; }
        /// <summary>
        /// 销量
        /// </summary>
        public int ShopNum { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int Repertory { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 操作日期
        /// </summary>
        public DateTime OperationDate { get; set; }
        public string OTime { get { return OperationDate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        /// <summary>
        /// 商品类别
        /// </summary>
        public int TId { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 模板
        /// </summary>
        public int TemplateId { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string CommodityKey { get; set; }
        /// <summary>
        /// 配送地址
        /// </summary>
        public string SendAddress { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int Integral { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public int SId { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 尺寸
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 删除状态
        /// </summary>
        public int DeleteState { get; set; }
        /// <summary>
        /// 是否出售
        /// </summary>
        public int IsSell { get; set; }
        /// <summary>
        /// 成本价
        /// </summary>
        public float CostPrice { get; set; }
        /// <summary>
        /// 团长id
        /// </summary>
        public int ColonelID { get; set; }
        /// <summary>
        /// 门店id
        /// </summary>
        public int Mid { get; set; }


        public string NickName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string STime { get { return StartTime.ToString("yyyy-MM-dd HH:MM:ss"); } }

        //团长

        public int Sex { get; set; }

        public string ColonelName { get; set; }
        public string MemberNum { get; set; }
        public string PColonelId { get; set; }
        public string Region { get; set; }
        public string Estate { get; set; }

        public string Coordinates { get; set; }
        public DateTime RegisterTime { get; set; }
        public string RTime { get { return RegisterTime.ToString("yyyy-MM-dd HH:MM:ss"); } }

        public decimal Saleroom { get; set; }
        public int DeliveryStatus { get; set; }
        public decimal Cost { get; set; }
        public string Alipay { get; set; }
        public string BankSite { get; set; }
        public string CardName { get; set; }
        public string BankCard { get; set; }
        public string HeadPortrait { get; set; }
        public string CommIds { get; set; }
    }
}
