using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 配送小区
    /// </summary>
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int UserId { get; set; }
        public int ColonelID { get; set; }
        public string DeliveryPath { get; set; }
        public string DeliveryName { get; set; }
        public int WarehouseId { get; set; }



        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int State { get; set; }
        public string NickName { get; set; }
        public int RoleId { get; set; }

        public int Sex { get; set; }
        public string Phones { get; set; }
        public string ColonelName { get; set; }
        public string MemberNum { get; set; }
        public string PColonelId { get; set; }
        public string Region { get; set; }
        public string Estate { get; set; }
        public string Addresss { get; set; }
        public string Coordinates { get; set; }
        public DateTime RegisterTime { get; set; }
        public int Integral { get; set; }
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
