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
        public int OutLibraryId { get; set; }
        public int PutLibraryId { get; set; }
        public int WarehouseId { get; set; }
        public int CommodityId { get; set; }
        public int GoodNum { get; set; }
        public DateTime OutDate { get; set; }
        public string OutNO { get; set; }
        public string WarehouseName { get; set; }

    }
}
