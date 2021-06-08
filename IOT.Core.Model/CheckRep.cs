using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 盘点库存
    /// </summary>
    public class CheckRep
    {
        public int CheckRepId { get; set; }
        public string CheckNo { get; set; }
        public int WarehouseId { get; set; }
        public int CheckNum { get; set; }
        public string CheckPeople { get; set; }
        public DateTime CheckDate { get; set; }
        public string CTime { get { return CheckDate.ToString("yyyy-MM-dd HH:MM:ss"); } }

        //仓库外键
        public string WarehouseName { get; set; }
        public string WarehouseSite { get; set; }
        public string WarehouseCoordinate { get; set; }
        public int WarehouseNum { get; set; }
        public string WarehouseState { get; set; }
    }
}
