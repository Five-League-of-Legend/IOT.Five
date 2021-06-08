using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 出库
    /// </summary>
    public class OutLibrary
    {
        public int PutLibraryId { get; set; }
        public int WarehouseId { get; set; }
        public int CommodityId { get; set; }
        public int GoodNum { get; set; }
        public DateTime OutDate { get; set; }
        public string OTime { get { return OutDate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public string OutNO { get; set; }


        public string WarehouseName { get; set; }
        public string WarehouseSite { get; set; }
        public string WarehouseCoordinate { get; set; }
        public int WarehouseNum { get; set; }
        public string WarehouseState { get; set; }


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

    }
}
