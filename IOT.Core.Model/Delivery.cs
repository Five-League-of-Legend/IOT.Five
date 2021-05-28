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
        public int DeliveryId   { get; set; }
        public int UserId       { get; set; }
        public int ColonelID    { get; set; }
        public string DeliveryPath { get; set; }
        public string DeliveryName { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseSite { get; set; }
        public string WarehouseCoordinate { get; set; }
        public int WarehouseNum { get; set; }
        public string WarehouseState { get; set; }
    }
}
