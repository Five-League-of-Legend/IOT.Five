using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 商品表
    /// </summary>
    public class Commodity
    {
        public int CommodityId   { get; set; }
        public string CommodityName { get; set; }
        public string CommodityPic  { get; set; }
        public string ShopPrice     { get; set; }
        public int ShopNum       { get; set; }
        public int Repertory     { get; set; }
        public int Sort          { get; set; }
        public int State         { get; set; }
        public DateTime OperationDate { get; set; }
        public int TId           { get; set; }
        public string Remark        { get; set; }
        public int TemplateId    { get; set; }
        public string CommodityKey  { get; set; }
        public string SendAddress   { get; set; }
        public string Job           { get; set; }
        public int Integral      { get; set; }
        public int SId           { get; set; }
        public string Color         { get; set; }
        public string Size          { get; set; }
        public int DeleteState   { get; set; }
        public int IsSell        { get; set; }
        public int ColonelID { get; set; }
        public int Mid { get; set; }

        public float CostPrice     { get; set; }
    }
}
