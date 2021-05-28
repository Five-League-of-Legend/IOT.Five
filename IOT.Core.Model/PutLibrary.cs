using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 入库
    /// </summary>
    public class PutLibrary
    {
        public int PutLibraryId { get; set; }
        public int WarehouseId  { get; set; }
        public int CommodityId  { get; set; }
        public int GoodNum      { get; set; }
        public DateTime PutDate { get; set; }
        public string PutNO { get; set; }
        public string WarehouseName { get; set; }
    }
}
