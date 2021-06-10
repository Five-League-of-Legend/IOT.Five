using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 现有库存
    /// </summary>
    public class NowRep
    {
        public int NowRepId { get; set; }
        public int CommodityId { get; set; }
        public int WarehouseId { get; set; }
        public int PutLibraryId { get; set; }
        public int OutLibraryId { get; set; }


        //商品
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }
        /// <summary>
        /// 商品图
        /// </summary>
        public string CommodityPic { get; set; }
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
        /// 团长id
        /// </summary>
        public int ColonelID { get; set; }

        //仓库
        public string WarehouseName { get; set; }
        public string WarehouseSite { get; set; }


        //入库
        public int GoodNum { get; set; }
        public DateTime PutDate { get; set; }
        public string PTime { get { return PutDate.ToString("yyyy-MM-dd HH:MM:ss"); } }
        public string PutNO { get; set; }

        //出库
        public int GoodNums { get; set; }
        public DateTime OutDate { get; set; }
        public string OutNO { get; set; }

        public int Num { get { return GoodNum - GoodNums; } }
    }
}
