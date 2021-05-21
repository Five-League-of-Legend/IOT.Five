using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    public class ViewOrderUsersCommodity
    {

        public string CommodityName { get; set; }
        public string CommodityPic { get; set; }
        public string ShopPrice { get; set; }
        public int ShopNum { get; set; }
        public int Repertory { get; set; }
        public int Sort { get; set; }
        public int State { get; set; }
        public DateTime OperationDate { get; set; }
        public int TId { get; set; }
        public string Remark { get; set; }
        public int TemplateId { get; set; }
        public string CommodityKey { get; set; }
        public string SendAddress { get; set; }
        public string Job { get; set; }
        public int Integral { get; set; }
        public int SId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int DeleteState { get; set; }
        public int IsSell { get; set; }
        public float CostPrice { get; set; }



        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string NickName { get; set; }
        public int ColonelID { get; set; }
        public int RoleId { get; set; }


        public int Orderid { get; set; }
        public int SendWay { get; set; }
        public int OrderState { get; set; }
        public float CommodityPrice { get; set; }
        public float DistributionCosts { get; set; }
        public float OrderPrice { get; set; }
        public float CouponPrice { get; set; }
        public float AmountPaid { get; set; }
        public DateTime StartTime { get; set; }
    }
}
